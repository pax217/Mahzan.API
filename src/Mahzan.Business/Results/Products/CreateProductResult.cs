using System;
using System.ComponentModel.DataAnnotations;
using Mahzan.Business.Results._Base;

namespace Mahzan.Business.Results.Products
{
    public class CreateProductResult:Result
    {
        public Guid ProductsId { get; set; }

    }
}
