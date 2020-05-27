using System;
using System.Collections.Generic;
using System.Text;

namespace Mahzan.Business.Events.Products.CreateProduct
{
    public class CreateProductPhotoEvent
    {
        public string Title { get; set; }

        public DateTime DateTime { get; set; }

        public string MIMEType { get; set; }

        public string Base64 { get; set; }

    }
}
