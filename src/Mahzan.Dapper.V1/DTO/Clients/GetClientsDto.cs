using Mahzan.Dapper.DTO._Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mahzan.Dapper.DTO.Clients
{
    public class GetClientsDto:BaseDto
    {
        public Guid? ClientsId { get; set; }

        public string RFC { get; set; }

        public string BusinessName { get; set; }

        public string Email { get; set; }
    }
}
