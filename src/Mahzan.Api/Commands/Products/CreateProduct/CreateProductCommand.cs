using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mahzan.Api.Commands.Products.CreateProduct
{
    public class CreateProductCommand
    {
        public CreateProductDetailCommand CreateProductDetailCommand { get; set; }

        public CreateProductPhotoCommand CreateProductPhotoCommand { get; set; }

        public List<CreateProductTaxesCommand> CreateProductTaxesCommand { get; set; }
    }
}
