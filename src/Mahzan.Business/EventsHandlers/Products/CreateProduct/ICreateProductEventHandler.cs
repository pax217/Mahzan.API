using Mahzan.Business.Events.Products.CreateProduct;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Mahzan.Business.EventsHandlers.Products.CreateProduct
{
    public interface ICreateProductEventHandler
    {
        Task<Guid> Handle(CreateProductEvent createProductEvent);
    }
}
