using System;
using Mahzan.DataAccess.DTO._Base;

namespace Mahzan.DataAccess.DTO.Companies
{
    public class GetCompaniesDto : BaseDto
    {
        public string RFC { get; set; }

        public string BusinessName { get; set; }

        public Guid? GroupsId { get; set; }
    }
}
