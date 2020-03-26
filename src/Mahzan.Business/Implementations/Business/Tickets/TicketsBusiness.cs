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
        readonly ITicketsRepositories _ticketsRepositories;


        public TicketsBusiness(
            ITicketsRepositories ticketsRepositories)
        {
            //Repositories
            _ticketsRepositories = ticketsRepositories;
        }

        public async Task<PostTicketsResult> Add(AddTicketsDto addTicketsDto)
        {
            PostTicketsResult result = new PostTicketsResult()
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

                //Contruye Ticket
                AddTicketsDto ticketToAdd = await BuildTicketDetail(addTicketsDto);

                //Agrega Ticket/TikcetDetail
                result.Ticket = await _ticketsRepositories
                                      .AddTicket(ticketToAdd);


                ////Identifica si el producto se sigue en el inventario.
                //FollowInventory(addTicketsDto);
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

        #region Private Methods

        public async Task<AddTicketsDto> BuildTicketDetail(AddTicketsDto addTicketsDto)
        {
            AddTicketsDto result = new AddTicketsDto()
            {
                StoresId = addTicketsDto.StoresId,
                PointsOfSalesId = addTicketsDto.PointsOfSalesId,
                PaymentTypesId = addTicketsDto.PaymentTypesId,
                AspNetUserId = addTicketsDto.AspNetUserId,
                MembersId = addTicketsDto.MembersId,
                PostTicketDetailDto = new List<PostTicketDetailDto>(),
                TicketDetailTaxesDto = new List<TicketDetailTaxesDto>(),
            };

            decimal total = 0;
            int totalProducts = 0;

            foreach (var ticketDetailDto in addTicketsDto.PostTicketDetailDto)
            {

                //Busca el producto
                List<Models.Entities.Products> product = await _ticketsRepositories
                                                               .GetProduct(addTicketsDto.MembersId,
                                                                           ticketDetailDto.ProductsId);

                //Asigna Precio
                ticketDetailDto.Price = product.FirstOrDefault().Price;

                //Calcula el Monto (Con o Sin Impuesto)
                TicketDetailTaxesDto ticketDetailTaxesDto = await CalculateAmount(addTicketsDto.MembersId,
                                                                                  ticketDetailDto);


                //Detalle de Ticket
                result.PostTicketDetailDto.Add(new PostTicketDetailDto
                {
                    ProductsId = ticketDetailDto.ProductsId,
                    Quantity = ticketDetailDto.Quantity,
                    Description = product.FirstOrDefault().Description,
                    Price = product.FirstOrDefault().Price,
                    Amount = ticketDetailTaxesDto.Amount
                });

                //Detalle de Ticket con Impuestos
                if (ticketDetailTaxesDto.TaxRate!=0)
                {
                    result.TicketDetailTaxesDto.Add(ticketDetailTaxesDto);
                }


                //Totales
                totalProducts += ticketDetailDto.Quantity;
                total += product.FirstOrDefault().Price * ticketDetailDto.Quantity;

            }

            result.TotalProducts = totalProducts;
            result.Total = total;

            return result;
        }

        private async Task<TicketDetailTaxesDto> CalculateAmount(Guid membersId,
                                                                 PostTicketDetailDto postTicketDetailDto) 
        {
            TicketDetailTaxesDto result = new TicketDetailTaxesDto(); ;


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
                    result = new TicketDetailTaxesDto
                    {
                        TaxRate = tax.TaxRate,
                        Amount = tax.Taxes.TaxType == TaxTypeEnum.ADD_IN_PRICE? amountWithTaxes: withOutTax,
                        ProductsId = tax.ProductsId,
                        TaxesId = tax.TaxesId
                    };
                }

            }
            else
            {

                result.Amount += postTicketDetailDto.Price * postTicketDetailDto.Quantity;
            }


            return result; 
        } 

        //public void FollowInventory(AddTicketsDto addTicketsDto)
        //{
        //    foreach (var item in addTicketsDto.PostTicketDetailDto)
        //    {
        //        List<Models.Entities.Products> foundProduct = _ticketsRepositories
        //                                                       .GetProduct(item.ProductsId);

        //        if (foundProduct.Any())
        //        {
        //            if (foundProduct.FirstOrDefault().FollowInventory)
        //            {
        //                List<Models.Entities.Products_Store> foundProducts_Store = _ticketsRepositories
        //                                                                            .GetProductsStore(addTicketsDto.StoresId,
        //                                                                                              item.ProductsId);
        //                if (foundProducts_Store.Any())
        //                {
        //                    TakeFormStock(foundProducts_Store.FirstOrDefault().ProductsId);
        //                }
        //            }

        //        }

        //    }
        //}

        //public void TakeFormStock(Guid productsId)
        //{
        //    Models.Entities.Products_Store products_Store = _ticketsRepositories
        //                                                     .GetProductStore(productsId);
        //    if (products_Store != null)
        //    {
        //        products_Store.InStock--;


        //        _ticketsRepositories.UpdateStoreRepository(new PutProductsStoreDto
        //        {
        //            ProductsStoreId = products_Store.ProductsStoreId,
        //            InStock = products_Store.InStock
        //        });
        //    }


        //}

        #endregion
    }
}
