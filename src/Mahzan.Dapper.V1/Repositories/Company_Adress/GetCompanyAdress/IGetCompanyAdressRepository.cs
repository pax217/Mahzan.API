using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Mahzan.Dapper.Repositories.Company_Adress.GetCompanyAdress
{
    public interface IGetCompanyAdressRepository
    {
        Task<Models.Entities.Company_Adress> GetByPointsOfSalesId(Guid pointsOfSalesId);
    }
}
