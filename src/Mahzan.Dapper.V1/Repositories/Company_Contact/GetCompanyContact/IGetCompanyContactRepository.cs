using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Mahzan.Dapper.Repositories.Company_Contact.GetCompanyContact
{
    public interface IGetCompanyContactRepository
    {
        Task<Models.Entities.Company_Contact> GetByPointsOfSalesId(Guid PointsOfSalesId);
    }
}
