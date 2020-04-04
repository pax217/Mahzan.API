using Mahzan.Business.Interfaces.Business.Tickets;
using Mahzan.DataAccess.DTO.ProductsTaxes;
using Mahzan.DataAccess.DTO.Tickets;
using Mahzan.DataAccess.Paging;
using Moq;
using System;
using System.Collections.Generic;

namespace Mahzan.Factories.Implemantations.Business.Tickets
{
    public static class AddNewTicketFactory
    {
        /// <summary>
        /// Obtiene Información valida para generar Ticket
        /// </summary>
        /// <returns></returns>
        public static TicketCalculationDto GetAddTicketsDtoValid() 
        {
            return new TicketCalculationDto
            {
                StoresId = new Guid("50A9A317-2055-4BEA-95A3-DA648E67FC78"),
                PointsOfSalesId = new Guid ("99B0C2C3-8621-4791-B59A-D4988EE94640"),
                PaymentTypesId = new Guid("74557D9B-A59A-49A3-BBE3-57065844A1EA"),
                PostTicketCalculationDetailDto = new List<PostTicketCalculationDetailDto>(){
                    new PostTicketCalculationDetailDto{
                        ProductsId = new Guid("27C07004-2046-4958-A601-906787FD4376"),
                        Quantity =1,
                    },
                    new PostTicketCalculationDetailDto{
                        ProductsId = new Guid("69A87869-70BB-4736-8594-B1C197C25C63"),
                        Quantity =1,
                    },
                }
            };
        }

        /// <summary>
        /// Crea Mock Tickets Repositories
        /// </summary>
        /// <param name="addTicketsDto"></param>
        /// <returns></returns>
        public static Mock<ITicketsRepositories> CreateMockITicketsRepositories(TicketCalculationDto addTicketsDto) 
        {
            Mock<ITicketsRepositories> mock = new Mock<ITicketsRepositories>();

            Models.Entities.Tickets newTicket = GetNewTicketValid();

            //Nuevo Ticket Valido
            mock.Setup(p => p.AddTicket(addTicketsDto))
                .ReturnsAsync(newTicket);

            //Impuestos
            mock.Setup(p => p.GetProductsTaxes(It.IsAny<GetProductsTaxesDto>()))
                .ReturnsAsync(GetReturnProductsTaxes());

            //Detalle de Ticket
            mock.Setup(p => p.AddTicketDetail(newTicket, 
                                              addTicketsDto.PostTicketCalculationDetailDto))
                .ReturnsAsync(GetReturnTicketDetail());

            //Productos existentes
            //mock.Setup(p => p.GetProduct(It.IsAny<Guid>()))
            //    .Returns(GetProducts());

            //Productos en tienda
            mock.Setup(p => p.GetProductsStore(It.IsAny<Guid>(),
                                               It.IsAny<Guid>()))
                .Returns(GetProductsStore);
                

            return mock;
        }

        /// <summary>
        /// Obtiene un nuevo ticket valido
        /// </summary>
        /// <returns></returns>
        private static Models.Entities.Tickets GetNewTicketValid() 
        {
            return new Models.Entities.Tickets
            {
                TicketsId = new Guid("f783b38a-6ee8-47a7-b0ef-544393df3697"),
                CreatedAt = DateTime.Now,
                Total = 25.5M,
                AspNetUsersId = new Guid("2860c2bf-a0f5-4b9d-8b05-37a22c79640e"),
                PointsOfSalesId = new Guid("99B0C2C3-8621-4791-B59A-D4988EE94640"),
                PaymentTypesId = new Guid("74557D9B-A59A-49A3-BBE3-57065844A1EA")
            };
        }

        /// <summary>
        /// Obtiene objeto de respuesta para Impuesto de Productos
        /// </summary>
        /// <returns></returns>
        private static PagedList<Models.Entities.ProductsTaxes> GetReturnProductsTaxes() 
        {
            return new PagedList<Models.Entities.ProductsTaxes>(new List<Models.Entities.ProductsTaxes>(),0,0,0);
        }

        /// <summary>
        /// Obtiene objeto de respuesta para Detalle de Ticket
        /// </summary>
        /// <returns></returns>
        private static List<Models.Entities.TicketDetail> GetReturnTicketDetail() 
        {
            return new List<Models.Entities.TicketDetail>()
            {
                new Models.Entities.TicketDetail {
                    TicketDetailId = new Guid("d2e6500a-312d-4cf9-9663-acff974c9d81"),
                    ProductsId = new Guid("27C07004-2046-4958-A601-906787FD4376"),
                    Quantity = 1,
                    Description ="Jabón Zote 250 g.",
                    Price = 25.60M,
                    Amount = 25.60M,
                    TicketsId  = new Guid("f783b38a-6ee8-47a7-b0ef-544393df3697")
                },
                new Models.Entities.TicketDetail {
                    TicketDetailId = new Guid("aac45a97-6a6b-4681-89b0-4bc1fc74be76"),
                    ProductsId = new Guid("69A87869-70BB-4736-8594-B1C197C25C63"),
                    Quantity = 1,
                    Description ="Shampoo Crece 1 L.",
                    Price = 25.60M,
                    Amount = 25.60M,
                    TicketsId  = new Guid("f783b38a-6ee8-47a7-b0ef-544393df3697")
                },
            };
        }

        //private static List<Models.Entities.Products> GetProducts() 
        //{
        //    return new List<Models.Entities.Products>()
        //    {
        //        new Models.Entities.Products
        //        {
        //            ProductsId = new Guid("27C07004-2046-4958-A601-906787FD4376"),
        //            SKU = string.Empty,
        //            Barcode ="0123456789123",
        //            Description ="Jabón Zote 250 g.",
        //            Price = 25.65M,
        //            Cost = 22.48M,
        //            FollowInventory = true,
        //            AvailableInAllStores = true
        //        },
        //        //new Models.Entities.Products
        //        //{
        //        //    ProductsId = new Guid("69A87869-70BB-4736-8594-B1C197C25C63"),
        //        //    SKU = string.Empty,
        //        //    Barcode ="0123456789124",
        //        //    Description ="Shampoo Crece 1 L.",
        //        //    Price = 22.80M,
        //        //    Cost = 22.80M,
        //        //    FollowInventory = true,
        //        //    AvailableInAllStores = true
        //        //}
        //    };
        //}

        private static List<Models.Entities.Products_Store> GetProductsStore() 
        {
            return new List<Models.Entities.Products_Store>
            {
                new Models.Entities.Products_Store
                {
                    ProductsStoreId = new Guid("f0440cbb-c494-4600-8e68-46899c123935"),
                    Price = 25.65M,
                    Cost = 22.48M,
                    InStock = 10,
                    LowStock = 2,
                    OptimumStock = 5,
                    ProductsId = new Guid("27C07004-2046-4958-A601-906787FD4376"),
                    StoresId = new Guid("50A9A317-2055-4BEA-95A3-DA648E67FC78")
                },
                new Models.Entities.Products_Store
                {
                    ProductsStoreId = new Guid("b7f2645b-1fb4-4ea6-9562-d3dce054b125"),
                    Price = 22.80M,
                    Cost = 22.80M,
                    InStock = 8,
                    LowStock = 1,
                    OptimumStock = 4,
                    ProductsId = new Guid("69A87869-70BB-4736-8594-B1C197C25C63"),
                    StoresId = new Guid("50A9A317-2055-4BEA-95A3-DA648E67FC78")
                }
            };
        }
    }
}
