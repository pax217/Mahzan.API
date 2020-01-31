using System;
using Mahzan.DataAccess.DTO._Base;

namespace Mahzan.DataAccess.DTO.Companies
{
    public class DeleteCompaniesDto:BaseDto
    {
        public Guid CompaniesId { get; set; }
    }
}
