using Mahzan.Business.Events.Products.CreateProduct;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Mahzan.Business.Validators.Products.CreateProduct
{
    public interface ICreateProductValidator
    {
        Task Hanlde(CreateProductEvent createProductEvent);
    }
}
