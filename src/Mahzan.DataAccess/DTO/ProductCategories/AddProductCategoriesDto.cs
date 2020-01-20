using System;
using Mahzan.DataAccess.DTO._Base;

namespace Mahzan.DataAccess.DTO.ProductCategories
{
    public class AddProductCategoriesDto:BaseDto
    {
        public string Description { get; set; }

        public string Color { get; set; }
    }
}
