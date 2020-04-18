using System;
using System.ComponentModel.DataAnnotations;
using Mahzan.Business.Results._Base;

namespace Mahzan.Business.Results.Products
{
    public class PostProductsResult:Result
    {
        public Models.Entities.Products Product { get; set; }

    }
}
