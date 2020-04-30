using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mahzan.Models.Entities
{
    public class Clients
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid ClientsId { get; set; }

        public string RFC { get; set; }

        public string CommercialName { get; set; }

        public string BusinessName { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public string Notes { get; set; }


        //Memebers
        public Guid MembersId { get; set; }
        public Members Members { get; set; }
    }
}
