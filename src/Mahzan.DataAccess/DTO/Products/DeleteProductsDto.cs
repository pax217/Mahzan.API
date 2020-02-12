using System;
using System.ComponentModel.DataAnnotations;
using Mahzan.DataAccess.DTO._Base;

namespace Mahzan.DataAccess.DTO.Products
{
    public class DeleteProductsDto:BaseDto
    {
        [Required]
        public Guid ProductsId { get; set; }
    }
}
