using System;
using Mahzan.DataAccess.DTO._Base;

namespace Mahzan.DataAccess.DTO.Products
{
    public class GetProductsDto:BaseDto
    {
        public string Barcode { get; set; }
    }
}
