using System;
namespace Mahzan.Business.Requests.Products.Post
{
    public class PostProductPhotoRequest
    {
        public string Title { get; set; }

        //public DateTime DateTime { get; set; }

        public string MIMEType { get; set; }

        public string Base64 { get; set; }

        //public Guid ProductsId { get; set; }
    }
}
