using System;
using System.Collections.Generic;
using System.Text;

namespace Mahzan.Business.Exceptions.Products.CreateProduct
{
    public class CreateProductInvalidOperationException : InvalidOperationException
    {
        public CreateProductInvalidOperationException(string message) : base(message)
        {
        }
    }
}
