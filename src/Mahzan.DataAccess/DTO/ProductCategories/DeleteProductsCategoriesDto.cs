using System;
using System.ComponentModel.DataAnnotations;
using Mahzan.DataAccess.DTO._Base;

namespace Mahzan.DataAccess.DTO.ProductCategories
{
    public class DeleteProductsCategoriesDto:BaseDto
    {
        [Required]
        public Guid ProductCategoriesId { get; set; }
    }
}
