using System;
using Mahzan.DataAccess.DTO._Base;

namespace Mahzan.DataAccess.DTO.ProductsPhotos
{
    public class AddProductsPhotosDto:BaseDto
    {
        public string Title { get; set; }

        public DateTime DateTime { get; set; }

        public string MIMEType { get; set; }

        public string Base64 { get; set; }

        public Guid ProductId { get; set; }
    }
}
