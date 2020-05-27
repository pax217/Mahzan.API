using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mahzan.Api.Commands.Products.CreateProduct
{
    public class CreateProductPhotoCommand
    {
        public string Title { get; set; }

        public DateTime DateTime { get; set; }

        public string MIMEType { get; set; }

        public string Base64 { get; set; }

        public Guid ProductsId { get; set; }
    }
}
