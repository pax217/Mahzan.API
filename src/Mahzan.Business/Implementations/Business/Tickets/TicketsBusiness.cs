﻿using System;
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
        readonly ITicketDetailRepository _ticketDetailRepository;

        readonly ITicketsRepository _ticketsRepository;

        readonly IProductsRepository _productsRepository;

        readonly IProductsStoreRepository _productsStoreRepository;

        readonly IProductsTaxesRepository _productsTaxesRepository;

        public TicketsBusiness(
            ITicketDetailRepository ticketDetailRepository,
            ITicketsRepository ticketsRepository,
            IProductsRepository productsRepository,
            IProductsStoreRepository productsStoreRepository,
            IProductsTaxesRepository productsTaxesRepository)
        {
            //Repositories
            _ticketDetailRepository = ticketDetailRepository;
            _ticketsRepository = ticketsRepository;
            _productsRepository = productsRepository;
            _productsStoreRepository = productsStoreRepository;
            _productsTaxesRepository = productsTaxesRepository;
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

            Models.Entities.Tickets newTicket = new Models.Entities.Tickets();

            try
            {
                //Validaciones de Ticket


                //Calcula Monto Total
                List<PostTicketDetailDto> detailTicketCalculate = CalculateTotal(addTicketsDto);

                addTicketsDto.PostTicketDetailDto = detailTicketCalculate;

                //Agrega ticket
                Models.Entities.Tickets addedTicket = await _ticketsRepository
                                                             .Add(addTicketsDto);

                //Agrega detalle de Ticket
                await _ticketDetailRepository
                       .Add(addedTicket,
                            addTicketsDto.PostTicketDetailDto);

                //Identifica si el producto se sigue en el inventario.
                FollowInventory(addTicketsDto);
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

        public List<PostTicketDetailDto> CalculateTotal(AddTicketsDto addTicketsDto)
        {
            List<PostTicketDetailDto> result = new List<PostTicketDetailDto>();


            foreach (var ticketDetail in addTicketsDto.PostTicketDetailDto)
            {
                //Aplica impuesto
                PagedList<Models.Entities.ProductsTaxes> productsTaxes = _productsTaxesRepository
                                                                        .Get(new GetProductsTaxesDto
                                                                        {
                                                                            MembersId = addTicketsDto.MembersId,
                                                                            ProductsId = ticketDetail.ProductsId
                                                                        });

                if (productsTaxes.Any())
                {
                    foreach (var tax in productsTaxes)
                    {
                        decimal withOutTax = ticketDetail.Price * ticketDetail.Quantity;
                        ticketDetail.Amount += (withOutTax + (withOutTax * (tax.Taxes.TaxRate) / 100));
                    }
                }
                else
                {
                    ticketDetail.Amount += ticketDetail.Price * ticketDetail.Quantity;
                }

                result.Add(ticketDetail);
            }



            //foreach (var ticketDetail in addTicketsDto.PostTicketDetailDto)
            //{
            //    //Aplica impuesto
            //    PagedList<Models.Entities.ProductsTaxes> productsTaxes = _productsTaxesRepository
            //                                                            .Get(new GetProductsTaxesDto
            //                                                            {
            //                                                                MembersId = addTicketsDto.MembersId,
            //                                                                ProductsId = ticketDetail.ProductsId
            //                                                            });

            //    if (productsTaxes.Any())
            //    {
            //        if (productsTaxes.FirstOrDefault().Taxes.TaxType
            //            == TaxTypeEnum.ADD_IN_PRICE)
            //        {
            //            //Obtener productos y calcular el total.
            //            result += ticketDetail.Amount + (ticketDetail.Amount * (productsTaxes.FirstOrDefault().Taxes.TaxRate)/100);
            //        }
            //        else
            //        {
            //            //Obtener productos y calcular el total.
            //            result += ticketDetail.Amount;
            //        }

            //    }
            //    else
            //    {
            //        //Obtener productos y calcular el total.
            //        result += ticketDetail.Amount;
            //    }

            //}

            return result;
        }

        public void FollowInventory(AddTicketsDto addTicketsDto)
        {
            foreach (var item in addTicketsDto.PostTicketDetailDto)
            {
                List<Models.Entities.Products> foundProduct = _productsRepository
                                                               .Get(x => x.ProductsId == item.ProductsId);

                if (foundProduct.Any())
                {
                    if (foundProduct.FirstOrDefault().FollowInventory)
                    {
                        List<Models.Entities.Products_Store> foundProducts_Store = _productsStoreRepository
                                                                                    .Get(x => x.StoresId == addTicketsDto.StoresId
                                                                                    && x.ProductsId == item.ProductsId);
                        if (foundProducts_Store.Any())
                        {
                            TakeFormStock(foundProducts_Store.FirstOrDefault().ProductsId);
                        }
                    }

                }

            }
        }

        public void TakeFormStock(Guid ProductsId)
        {
            Models.Entities.Products_Store products_Store = _productsStoreRepository
                                                             .Get(x => x.ProductsId == ProductsId)
                                                             .FirstOrDefault();
            if (products_Store != null)
            {
                products_Store.InStock--;


                _productsStoreRepository.Update(new PutProductsStoreDto
                {
                    ProductsStoreId = products_Store.Id,
                    InStock = products_Store.InStock
                });
            }


        }
        #endregion
    }
}
