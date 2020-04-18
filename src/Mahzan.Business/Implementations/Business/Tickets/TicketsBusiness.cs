using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mahzan.Business.Enums.Result;
using Mahzan.Business.Interfaces.Business.Tickets;
using Mahzan.Business.Resources.Business.Tickets;
using Mahzan.Business.Results.Tickets;
using Mahzan.DataAccess.DTO.ProductsStore;
using Mahzan.DataAccess.DTO.ProductsTaxes;
using Mahzan.DataAccess.DTO.Tickets;
using Mahzan.DataAccess.Interfaces;
using Mahzan.DataAccess.Interfaces.TicketsRepositoryServices;
using Mahzan.DataAccess.Paging;
using Mahzan.Models.Enums.Taxes;

namespace Mahzan.Business.Implementations.Business.Tickets
{
    public class TicketsBusiness : ITicketsBusiness
    {
        #region Properties

        private readonly ITicketsValidations _ticketsValidations;

        private readonly IAddTicketRepositoryService _addTicketRepositoryService;

        private readonly ITicketsRepositories _ticketsRepositories;

        private readonly ITicketsRepository _ticketsRepository;

        #endregion

        #region Constructors
        public TicketsBusiness(
            IAddTicketRepositoryService addTicketRepositoryService,
            ITicketsValidations ticketsValidations,
            ITicketsRepositories ticketsRepositories,
            ITicketsRepository ticketsRepository)
        {
            //Repositories
            _addTicketRepositoryService = addTicketRepositoryService;
            _ticketsRepositories = ticketsRepositories;
            _ticketsRepository = ticketsRepository;

            //Validaciones
            _ticketsValidations = ticketsValidations;
        }

        #endregion

        #region Public Methods
        public async Task<PostTicketCalculationResult> Calculate(TicketCalculationDto addTicketsDto)
        {
            PostTicketCalculationResult result = new PostTicketCalculationResult()
            {
                IsValid = true,
                StatusCode = 200,
                ResultTypeEnum = ResultTypeEnum.SUCCESS,
                Title = AddTicketsResources.ResourceManager.GetString("Add_Title"),
                Message = AddTicketsResources.ResourceManager.GetString("Add_200_SUCCESS_Message")
            };

            try
            {
                //Validaciones de Ticket
                //PostTicketsResult postTicketsResult = await _ticketsValidations
                //                                            .AddTicketValid(addTicketsDto);

                //if (!postTicketsResult.IsValid)
                //{
                //    return postTicketsResult;
                //}

                //Contruye Ticket
                TicketCalculationDto ticketToAdd = await BuildTicketDetail(addTicketsDto);

                result.Total = ticketToAdd.Total;
                result.TotalProducts = ticketToAdd.TotalProducts;
                result.PostTicketDetailDto = ticketToAdd.PostTicketCalculationDetailDto;
                result.TicketDetailTaxesDto = ticketToAdd.TicketDetailCalculationTaxesDto;

                //Agrega Ticket/TikcetDetail
                //result.Ticket = await _ticketsRepositories
                //                      .AddTicket(ticketToAdd);

            }
            catch (Exception ex)
            {
                result.IsValid = false;
                result.StatusCode = 500;
                result.ResultTypeEnum = ResultTypeEnum.ERROR;
                result.Message = ex.Message;
            }

            return result;
        }

        public async Task<PostTicketCloseSaleResult> CloseSale(TicketCalculationDto ticketCalculationDto)
        {
            PostTicketCloseSaleResult result = new PostTicketCloseSaleResult()
            {
                IsValid = true,
                StatusCode = 200,
                ResultTypeEnum = ResultTypeEnum.SUCCESS,
                Title = CloseSaleResource.ResourceManager.GetString("CloseSale_Title"),
                Message = CloseSaleResource.ResourceManager.GetString("CloseSale_200_SUCCESS_Message")
            };

            //Contruye Ticket
            TicketCalculationDto ticketCalculation = await BuildTicketDetail(ticketCalculationDto);


            //Agrega Ticket/TikcetDetail/TicketDetailTaxes
            result.Ticket = await _addTicketRepositoryService
                                  .Add(ticketCalculation);

            return result;
        }

        #endregion

        #region Private Methods

        public async Task<TicketCalculationDto> BuildTicketDetail(TicketCalculationDto addTicketsDto)
        {
            TicketCalculationDto result = new TicketCalculationDto()
            {
                StoresId = addTicketsDto.StoresId,
                PointsOfSalesId = addTicketsDto.PointsOfSalesId,
                PaymentTypesId = addTicketsDto.PaymentTypesId,
                AspNetUserId = addTicketsDto.AspNetUserId,
                MembersId = addTicketsDto.MembersId,
                PostTicketCalculationDetailDto = new List<PostTicketCalculationDetailDto>(),
                TicketDetailCalculationTaxesDto = new List<TicketDetailCalculationTaxesDto>(),
            };

            decimal total = 0;
            int totalProducts = 0;

            foreach (var ticketDetailDto in addTicketsDto.PostTicketCalculationDetailDto)
            {

                //Busca el producto
                List<Models.Entities.Products> product = await _ticketsRepositories
                                                               .GetProduct(addTicketsDto.MembersId,
                                                                           ticketDetailDto.ProductsId);
                if (product.Any())
                {
                    //Asigna Precio
                    ticketDetailDto.Price = product.FirstOrDefault().Price;

                    //Calcula el Monto (Con o Sin Impuesto)
                    TicketDetailCalculationTaxesDto ticketDetailTaxesDto = await CalculateAmount(addTicketsDto.MembersId,
                                                                                      ticketDetailDto);


                    //Detalle de Ticket
                    result.PostTicketCalculationDetailDto.Add(new PostTicketCalculationDetailDto
                    {
                        ProductsId = ticketDetailDto.ProductsId,
                        Quantity = ticketDetailDto.Quantity,
                        Description = product.FirstOrDefault().Description,
                        Price = product.FirstOrDefault().Price,
                        Amount = ticketDetailTaxesDto.Amount,
                        FollowInventory = product.FirstOrDefault().FollowInventory
                    });

                    //Detalle de Ticket con Impuestos
                    if (ticketDetailTaxesDto.TaxRate != 0)
                    {
                        result.TicketDetailCalculationTaxesDto.Add(ticketDetailTaxesDto);
                    }


                    //Totales
                    totalProducts += ticketDetailDto.Quantity;
                    total += ticketDetailTaxesDto.Amount;
                }


            }

            result.TotalProducts = totalProducts;
            result.Total = total;

            //Pago en Efectivo
            result.CashPayment = addTicketsDto.CashPayment;
            result.CashExchange = (addTicketsDto.CashPayment - total);

            return result;
        }

        private async Task<TicketDetailCalculationTaxesDto> CalculateAmount(Guid membersId,
                                                                 PostTicketCalculationDetailDto postTicketDetailDto) 
        {
            TicketDetailCalculationTaxesDto result = new TicketDetailCalculationTaxesDto(); ;


            //Identifica los impuestos aplicados a este producto
            PagedList<Models.Entities.ProductsTaxes> productsTaxes = await _ticketsRepositories
                                                                            .GetProductsTaxes(new GetProductsTaxesDto
                                                                            {
                                                                                MembersId = membersId,
                                                                                ProductsId = postTicketDetailDto.ProductsId
                                                                            });

            if (productsTaxes.Any())
            {

                foreach (var tax in productsTaxes)
                {
                    decimal withOutTax = postTicketDetailDto.Price * postTicketDetailDto.Quantity;

                    decimal amountWithTaxes = (withOutTax + (withOutTax * (tax.TaxRate) / 100));



                    //Detalle de Impuestos
                    result = new TicketDetailCalculationTaxesDto
                    {
                        TaxRate = tax.TaxRate,
                        Amount = tax.Taxes.TaxType == TaxTypeEnum.ADD_IN_PRICE? amountWithTaxes: withOutTax,
                        ProductsId = tax.ProductsId,
                        TaxesId = tax.TaxesId,
                        Price = postTicketDetailDto.Price,
                    };
                }

            }
            else
            {

                result.Amount += postTicketDetailDto.Price * postTicketDetailDto.Quantity;
            }


            return result; 
        }

        public async Task<GetTicketsResult> GetAll(GetTicketsDto getTicketsDto)
        {
            GetTicketsResult result = new GetTicketsResult
            {
                IsValid = true,
                StatusCode = 200,
                ResultTypeEnum = ResultTypeEnum.SUCCESS,
                Title = GetAllResource.ResourceManager.GetString("GetAll_Title"),
                Message = GetAllResource.ResourceManager.GetString("GetAll_200_SUCCESS_Message")
            };

            //Validaciones

            result.Tickets = await _ticketsRepository
                                   .GetAll(getTicketsDto);


            return result;
        }

        public async Task<GetTicketResult> Get(GetTicketDto getTicketDto)
        {
            GetTicketResult result = new GetTicketResult
            {
                IsValid = true,
                StatusCode = 200,
                ResultTypeEnum = ResultTypeEnum.SUCCESS,
                Title = GetResource.ResourceManager.GetString("Get_Title"),
                Message = GetResource.ResourceManager.GetString("Get_200_SUCCESS_Message")
            };

            result.Ticket = await _ticketsRepository
                                  .Get(getTicketDto);

            return result;
        }



        #endregion
    }
}
