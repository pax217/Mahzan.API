using System;
using Mahzan.DataAccess.DTO._Base;

namespace Mahzan.DataAccess.DTO.ProductCategories
{
    public class PutProductCategoriesDto:BaseDto
    {
        public Guid ProductCategoriesId { get; set; }

        public string Description { get; set; }

        public string Color { get; set; }
    }
}
