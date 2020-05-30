using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Mahzan.Dapper.Repositories.Companies.GetCompany
{
    public interface IGetCompanyRepository
    {
        Task<Models.Entities.Companies> GetByPointsOfSalesId(Guid pointsOfSalesId);
    }
}
