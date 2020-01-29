using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mahzan.Business.Enums.Result;
using Mahzan.Business.Interfaces.Business.Tickets;
using Mahzan.Business.Resources.Business.Tickets;
using Mahzan.Business.Results.Tickets;
using Mahzan.DataAccess.DTO.ProductsStore;
using Mahzan.DataAccess.DTO.Tickets;
using Mahzan.DataAccess.Interfaces;

namespace Mahzan.Business.Implementations.Business.Tickets
{
    public class TicketsBusiness : ITicketsBusiness
    {
        readonly ITicketDetailRepository _ticketDetailRepository;

        readonly ITicketsRepository _ticketsRepository;

        readonly IProductsRepository _productsRepository;

        readonly IProductsStoreRepository _productsStoreRepository;

        public TicketsBusiness(
            ITicketDetailRepository ticketDetailRepository,
            ITicketsRepository ticketsRepository,
            IProductsRepository productsRepository,
            IProductsStoreRepository productsStoreRepository)
        {
            _ticketDetailRepository = ticketDetailRepository;
            _ticketsRepository = ticketsRepository;
            _productsRepository = productsRepository;
            _productsStoreRepository = productsStoreRepository;
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
                addTicketsDto.Total = CalculateTotal(addTicketsDto.PostTicketDetailDto);

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

        public decimal CalculateTotal(List<PostTicketDetailDto> postTicketDetailDtos)
        {
            decimal result = 0;

            foreach (var ticketDetail in postTicketDetailDtos)
            {
                //Obtener productos y calcular el total.
                result += ticketDetail.Amount;
            }

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
