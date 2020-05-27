using Mahzan.Business.Events.Products.CreateProduct;
using Mahzan.Business.Exceptions.Products.CreateProduct;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Mahzan.Business.Validators.Products.CreateProduct
{
    public class CreateProductValidator : ICreateProductValidator
    {
        public async Task Hanlde(CreateProductEvent createProductEvent)
        {
            //Valida que el precio no debe ser menor al costo
            if (createProductEvent.CreateProductDetailEvent.Cost
                > createProductEvent.CreateProductDetailEvent.Price)
            {
                throw new CreateProductInvalidOperationException(
                    $"El precio {createProductEvent.CreateProductDetailEvent.Price} no puede ser menor al costo {createProductEvent.CreateProductDetailEvent.Price} ."
                    );
            }
        }
    }
}
