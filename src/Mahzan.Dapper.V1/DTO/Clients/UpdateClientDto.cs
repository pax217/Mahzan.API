using Mahzan.Dapper.DTO._Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mahzan.Dapper.DTO.Clients
{
    public class UpdateClientDto:BaseDto
    {
        public Guid ClientsId { get; set; }

        public string RFC { get; set; }

        public string CommercialName { get; set; }

        public string BusinessName { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public string Notes { get; set; }

        public Guid MembersId { get; set; }
    }
}
