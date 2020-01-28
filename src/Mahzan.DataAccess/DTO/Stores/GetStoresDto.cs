using System;
using Mahzan.DataAccess.DTO._Base;

namespace Mahzan.DataAccess.DTO.Stores
{
    public class GetStoresDto:BaseDto
    {
        public Guid StoresId { get; set; }

        public string Code { get; set; }

        public string Name { get; set; }

        public Guid CompaniesId { get; set; }
    }
}
