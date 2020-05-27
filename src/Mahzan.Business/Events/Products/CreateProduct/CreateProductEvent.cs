using Mahzan.Business.Events._Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mahzan.Business.Events.Products.CreateProduct
{
    public class CreateProductEvent: BaseEvent
    {
        public CreateProductDetailEvent CreateProductDetailEvent { get; set; }

        public CreateProductPhotoEvent CreateProductPhotoEvent { get; set; }

        public List<CreateProductTaxesEvent> CreateProductTaxesEvent { get; set; }
    }
}
