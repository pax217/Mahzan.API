using System;
using System.ComponentModel.DataAnnotations;

namespace Mahzan.Business.Requests.Stores
{
    public class PutStoresRequest
    {
        [Required]
        public Guid StoresId { get; set; }

        public string Code { get; set; }

        public string Name { get; set; }

        public string Phone { get; set; }

        public string Comment { get; set; }
    }
}
