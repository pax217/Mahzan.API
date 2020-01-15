using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mahzan.Models.Entities
{
    public class ProductsPhotos
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        public string Title { get; set; }

        public DateTime DateTime { get; set; }

        public string MIMEType { get; set; }

        public string Base64 { get; set; }

        public bool Active { get; set; }

        public Guid ProductId { get; set; }
    }
}
