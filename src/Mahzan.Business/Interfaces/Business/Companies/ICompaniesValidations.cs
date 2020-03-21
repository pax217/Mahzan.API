using Mahzan.Business.Results.Companies;
using Mahzan.DataAccess.DTO.Companies;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Mahzan.Business.Interfaces.Business.Companies
{
    public interface ICompaniesValidations
    {
        Task<AddCompaniesResult> AddCompaniesValid(AddCompaniesDto addCompaniesDto);

        Task<PutCompaniesResult> PutCompaniesValid(PutCompaniesDto putCompaniesDto);
    }
}
