using System;
using Mahzan.DataAccess.DTO._Base;

namespace Mahzan.DataAccess.DTO.Clients
{
    public class AddClientsDto:BaseDto
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Notes { get; set; }
    }
}
