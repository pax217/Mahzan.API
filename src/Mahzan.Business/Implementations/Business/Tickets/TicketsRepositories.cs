using Mahzan.Business.Interfaces.Business.Tickets;
using Mahzan.DataAccess.DTO.ProductsStore;
using Mahzan.DataAccess.DTO.ProductsTaxes;
using Mahzan.DataAccess.DTO.Tickets;
using Mahzan.DataAccess.Interfaces;
using Mahzan.DataAccess.Paging;
using Mahzan.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mahzan.Business.Implementations.Business.Tickets
{
    public class TicketsRepositories: ITicketsRepositories
    {
        readonly ITicketDetailRepository _ticketDetailRepository;

        readonly ITicketsRepository _ticketsRepository;

        readonly IProductsRepository _productsRepository;

        readonly IProductsStoreRepository _productsStoreRepository;

        readonly IProductsTaxesRepository _productsTaxesRepository;

        public TicketsRepositories(
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

        public async Task<Models.Entities.Tickets> AddTicket(AddTicketsDto addTicketsDto)
        {
            return await _ticketsRepository
                         .Add(addTicketsDto);
        }

        public async Task<PagedList<ProductsTaxes>> GetProductsTaxes(GetProductsTaxesDto getProductsTaxesDto)
        {
            return await _productsTaxesRepository
                         .Get(getProductsTaxesDto);
        }

        public async Task<List<TicketDetail>> AddTicketDetail(Models.Entities.Tickets newTicket,
                                                              List<PostTicketDetailDto> postTicketDetailDto) 
        {
           return  await _ticketDetailRepository
                         .Add(newTicket,
                              postTicketDetailDto);
        }

        public List<Models.Entities.Products> GetProducts(Guid productsId)
        {
            return  _productsRepository
                     .Get(x => x.ProductsId == productsId);
        }

        public List<Products_Store> GetProductsStore(Guid storesId, Guid productsId)
        {
            return _productsStoreRepository
                    .Get(
                        x =>
                        x.StoresId == storesId
                        &&
                        x.ProductsId == productsId
                    );
        }

        public Products_Store GetProductStore(Guid productsId)
        {
            return _productsStoreRepository
                    .Get(x => x.ProductsId == productsId)
                    .FirstOrDefault();
        }

        public void UpdateStoreRepository(PutProductsStoreDto putProductsStoreDto) 
        {
            _productsStoreRepository
            .Update(putProductsStoreDto);
        }
    }
}
