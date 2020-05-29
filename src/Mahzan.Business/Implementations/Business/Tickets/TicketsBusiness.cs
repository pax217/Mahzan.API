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
                ClientsId = addTicketsDto.ClientsId,
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
                    List<TicketDetailCalculationTaxesDto> ticketDetailTaxesDto = await CalculateAmount(addTicketsDto.MembersId,
                                                                                      ticketDetailDto);

                    foreach (var ticketDetailTaxDto in ticketDetailTaxesDto)
                    {
                        result.TicketDetailCalculationTaxesDto.Add(ticketDetailTaxDto);
                    }

                    //Detalle de Ticket
                    result.PostTicketCalculationDetailDto.Add(new PostTicketCalculationDetailDto
                    {
                        ProductsId = ticketDetailDto.ProductsId,
                        Quantity = ticketDetailDto.Quantity,
                        Description = product.FirstOrDefault().Description,
                        Price = decimal.Round((product.FirstOrDefault().Price) + ticketDetailTaxesDto.Sum(x => x.AmountTax), 2, MidpointRounding.AwayFromZero),
                        Amount = decimal.Round((product.FirstOrDefault().Price * ticketDetailDto.Quantity) + ticketDetailTaxesDto.Sum(x => x.AmountTax), 2, MidpointRounding.AwayFromZero),
                        FollowInventory = product.FirstOrDefault().FollowInventory
                    });



                    //Totales
                    totalProducts += ticketDetailDto.Quantity;
                    total += decimal.Round(result.PostTicketCalculationDetailDto.Sum(x=>x.Amount), 2, MidpointRounding.AwayFromZero);
                }


            }

            result.TotalProducts = totalProducts;
            result.Total = total;

            //Pago en Efectivo
            result.CashPayment = addTicketsDto.CashPayment;
            result.CashExchange = (addTicketsDto.CashPayment - total);

            return result;
        }

        private async Task<List<TicketDetailCalculationTaxesDto>> CalculateAmount(Guid membersId,
                                                                 PostTicketCalculationDetailDto postTicketDetailDto) 
        {
            List<TicketDetailCalculationTaxesDto> result = new List<TicketDetailCalculationTaxesDto>(); ;


            //Identifica los impuestos aplicados a este producto
            PagedList<Models.Entities.ProductsTaxes> productsTaxes = await _ticketsRepositories
                                                                            .GetProductsTaxes(new GetProductsTaxesDto
                                                                            {
                                                                                MembersId = membersId,
                                                                                ProductsId = postTicketDetailDto.ProductsId
                                                                            });

            if (productsTaxes.Any())
            {

                foreach (var productsTax in productsTaxes)
                {


                    Models.Entities.Taxes tax = await _ticketsRepositories.GetTax(productsTax.TaxesId);

                    if (tax.Active)
                    {
                        if (tax.Type == TaxTypeEnum.INCLUDED_IN_PRICE.ToString())
                        {
                            decimal withOutTax = postTicketDetailDto.Price * postTicketDetailDto.Quantity;

                            decimal amountWithOutTaxes = (withOutTax - (withOutTax * (productsTax.TaxRate) / 100));


                            //Detalle de Impuestos
                            result.Add(new TicketDetailCalculationTaxesDto
                            {
                                TaxRate = productsTax.TaxRate,
                                ProductsId = productsTax.ProductsId,
                                TaxesId = productsTax.TaxesId,
                                Quantity = postTicketDetailDto.Quantity,
                                Price = decimal.Round(postTicketDetailDto.Price, 2, MidpointRounding.AwayFromZero),
                                Amount = decimal.Round(withOutTax, 2, MidpointRounding.AwayFromZero),
                                AmountTax = 0,
                                Tax = withOutTax - amountWithOutTaxes
                            });
                        }

                        if (tax.Type == TaxTypeEnum.ADD_TO_PRICE.ToString())
                        {
                            decimal withOutTax = postTicketDetailDto.Price * postTicketDetailDto.Quantity;

                            decimal amountWithTaxes = (withOutTax + (withOutTax * (productsTax.TaxRate) / 100));



                            //Detalle de Impuestos
                            result.Add(new TicketDetailCalculationTaxesDto
                            {
                                TaxRate = productsTax.TaxRate,
                                ProductsId = productsTax.ProductsId,
                                TaxesId = productsTax.TaxesId,
                                Quantity = postTicketDetailDto.Quantity,
                                Price = decimal.Round(postTicketDetailDto.Price, 2, MidpointRounding.AwayFromZero),
                                Amount = decimal.Round(amountWithTaxes, 2, MidpointRounding.AwayFromZero),
                                AmountTax = amountWithTaxes - withOutTax,
                                Tax = amountWithTaxes - withOutTax
                            });
                        }
                    }


                }


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

            if (!result.Tickets.Any())
            {
                result.IsValid = false;
                result.StatusCode = 404;
                result.ResultTypeEnum = ResultTypeEnum.INFO;
                result.Message = GetAllResource.ResourceManager.GetString("Get_404_INFO_Message");

                return result;
            }


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
