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


                //Calcula Monto Total
                List<PostTicketDetailDto> detailTicketCalculate = await CalculateTotal(addTicketsDto);

                addTicketsDto.PostTicketDetailDto = detailTicketCalculate;

                //Agrega ticket
                result.Ticket = await _ticketsRepositories
                                      .AddTicket(addTicketsDto);

                //Agrega detalle de Ticket
                result.TicketDetail = await _ticketsRepositories
                                            .AddTicketDetail(result.Ticket,
                                                             addTicketsDto.PostTicketDetailDto);

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

        public async Task<List<PostTicketDetailDto>> CalculateTotal(AddTicketsDto addTicketsDto)
        {
            List<PostTicketDetailDto> result = new List<PostTicketDetailDto>();


            foreach (var ticketDetail in addTicketsDto.PostTicketDetailDto)
            {
                //Aplica impuesto
                PagedList<Models.Entities.ProductsTaxes> productsTaxes = await _ticketsRepositories
                                                                                .GetProductsTaxes(new GetProductsTaxesDto
                                                                                {
                                                                                    MembersId = addTicketsDto.MembersId,
                                                                                    ProductsId = ticketDetail.ProductsId
                                                                                });
                decimal amountWithTaxes = 0;

                if (productsTaxes.Any())
                {
                    foreach (var tax in productsTaxes)
                    {
                        decimal withOutTax = ticketDetail.Price * ticketDetail.Quantity;

                        amountWithTaxes += (withOutTax + (withOutTax * (tax.Taxes.TaxRate) / 100));
                    }

                    ticketDetail.Amount = amountWithTaxes;
                }
                else
                {
                    ticketDetail.Amount += ticketDetail.Price * ticketDetail.Quantity;
                }

                result.Add(ticketDetail);
            }

            return result;
        }

        //public void FollowInventory(AddTicketsDto addTicketsDto)
        //{
        //    foreach (var item in addTicketsDto.PostTicketDetailDto)
        //    {
        //        List<Models.Entities.Products> foundProduct = _productsRepository
        //                                                       .Get(x => x.ProductsId == item.ProductsId);

        //        if (foundProduct.Any())
        //        {
        //            if (foundProduct.FirstOrDefault().FollowInventory)
        //            {
        //                List<Models.Entities.Products_Store> foundProducts_Store = _productsStoreRepository
        //                                                                            .Get(x => x.StoresId == addTicketsDto.StoresId
        //                                                                            && x.ProductsId == item.ProductsId);
        //                if (foundProducts_Store.Any())
        //                {
        //                    TakeFormStock(foundProducts_Store.FirstOrDefault().ProductsId);
        //                }
        //            }

        //        }

        //    }
        //}

        //public void TakeFormStock(Guid ProductsId)
        //{
        //    Models.Entities.Products_Store products_Store = _productsStoreRepository
        //                                                     .Get(x => x.ProductsId == ProductsId)
        //                                                     .FirstOrDefault();
        //    if (products_Store != null)
        //    {
        //        products_Store.InStock--;


        //        _productsStoreRepository.Update(new PutProductsStoreDto
        //        {
        //            ProductsStoreId = products_Store.Id,
        //            InStock = products_Store.InStock
        //        });
        //    }


        //}
        #endregion
    }
}
