using System;
using System.Collections.Generic;
using System.Text;

namespace Mahzan.Dapper.Exceptions.Products.CreateProduct
{
    public class CreateProductInvalidOperationException : InvalidOperationException
    {
        public CreateProductInvalidOperationException(string message) : base(message)
        {
        }
    }
}
