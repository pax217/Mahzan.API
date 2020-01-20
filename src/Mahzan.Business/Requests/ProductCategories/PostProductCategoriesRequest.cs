using System;
using System.ComponentModel.DataAnnotations;

namespace Mahzan.Business.Requests.ProductCategories
{
    public class PostProductCategoriesRequest
    {
        [Required]
        public string Description { get; set; }

        public string Color { get; set; }
    }
}
