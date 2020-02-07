using System;
using Mahzan.DataAccess.DTO._Base;

namespace Mahzan.DataAccess.DTO.Stores
{
    public class PutStoresDto:BaseDto
    {
        public Guid StoresId { get; set; }

        public string Code { get; set; }

        public string Name { get; set; }

        public string Phone { get; set; }

        public string Comment { get; set; }

        public bool? Active { get; set; }
    }
}
