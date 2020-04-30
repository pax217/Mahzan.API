using Mahzan.Dapper.V1.DTO._Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mahzan.Dapper.V1.DTO.Clients
{
    public class InsertClientDto:BaseDto
    {
        public string RFC { get; set; }
        public string CommercialName { get; set; }
        public string BusinessName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Notes { get; set; }
    }
}
