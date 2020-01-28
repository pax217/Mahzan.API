using System;
using System.Threading.Tasks;
using Mahzan.Business.Results.Companies;
using Mahzan.DataAccess.DTO.Companies;

namespace Mahzan.Business.Interfaces.Validations.Companies
{
    public interface IAddCompaniesValidations
    {
        Task<AddCompaniesResult> AddCompaniesValid(AddCompaniesDto addCompaniesDto);
    }
}
