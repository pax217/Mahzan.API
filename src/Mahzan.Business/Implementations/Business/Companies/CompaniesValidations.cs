using Mahzan.Business.Interfaces.Business.Companies;
using Mahzan.Business.Interfaces.Validations.Companies;
using Mahzan.Business.Results.Companies;
using Mahzan.DataAccess.DTO.Companies;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Mahzan.Business.Implementations.Business.Companies
{
    public class CompaniesValidations : ICompaniesValidations
    {
        private readonly IAddCompaniesValidations _addCompaniesValidations;

        private readonly IPutCompaniesValidations _putCompaniesValidations;

        public CompaniesValidations(
            IAddCompaniesValidations addCompaniesValidations,
            IPutCompaniesValidations putCompaniesValidations) 
        {
            _addCompaniesValidations = addCompaniesValidations;
            _putCompaniesValidations = putCompaniesValidations;
        }

        public async Task<AddCompaniesResult> AddCompaniesValid(AddCompaniesDto addCompaniesDto)
        {
            return await _addCompaniesValidations
                         .AddCompaniesValid(addCompaniesDto);
        }

        public async Task<PutCompaniesResult> PutCompaniesValid(PutCompaniesDto putCompaniesDto)
        {
            return await _putCompaniesValidations
                         .PutCompaniesValid(putCompaniesDto);
        }
    }
}
