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
using Mahzan.DataAccess.Paging;
using Mahzan.Models.Enums.Taxes;

namespace Mahzan.Business.Implementations.Business.Tickets
{
    public class TicketsBusiness : ITicketsBusiness
    {
        #region Properties

        private readonly ITicketsRepositories _ticketsRepositories;

        private readonly ITicketsValidations _ticketsValidations;

        #endregion

        #region Constructors
        public TicketsBusiness(
            ITicketsRepositories ticketsRepositories,
            ITicketsValidations ticketsValidations)
        {
            //Repositories
            _ticketsRepositories = ticketsRepositories;

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
                }) ;

                //Detalle de Ticket con Impuestos
                if (ticketDetailTaxesDto.TaxRate!=0)
                {
                    result.TicketDetailCalculationTaxesDto.Add(ticketDetailTaxesDto);
                }


                //Totales
                totalProducts += ticketDetailDto.Quantity;
                total += ticketDetailTaxesDto.Amount;

            }

            result.TotalProducts = totalProducts;
            result.Total = total;

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

        #endregion
    }
}
