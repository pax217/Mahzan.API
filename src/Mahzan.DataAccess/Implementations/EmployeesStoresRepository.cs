using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mahzan.DataAccess.DTO.EmployeesStores;
using Mahzan.DataAccess.Filters.EmployeesStores;
using Mahzan.DataAccess.Interfaces;
using Mahzan.DataAccess.Paging;
using Mahzan.Models;
using Mahzan.Models.Entities;
using Mahzan.Models.Enums.Expressions;
using Mahzan.Models.Expressions;


namespace Mahzan.DataAccess.Implementations
{
    public class EmployeesStoresRepository: RepositoryBase<Employees_Stores>, IEmployeesStoresRepository
    {
        public EmployeesStoresRepository(MahzanDbContext repositoryContext)
            : base(repositoryContext)
        {
        }

        public async Task<PagedList<Employees_Stores>> Get(GetEmployeesStoresDto getEmployeesStoresDto)
        {
            List<Employees_Stores> result = null;
            List<FilterExpression> filterExpressions = new List<FilterExpression>();

            if (getEmployeesStoresDto.MembersId != null)
            {
                filterExpressions.Add(new FilterExpression
                {
                    PropertyInfo = typeof(Employees_Stores).GetProperties().First(p => p.Name == "MembersId"),
                    Operator = OperationsEnum.Equals,
                    Value = getEmployeesStoresDto.MembersId
                });
            }

            if (getEmployeesStoresDto.EmployeesId != null)
            {
                filterExpressions.Add(new FilterExpression
                {
                    PropertyInfo = typeof(Employees_Stores).GetProperties().First(p => p.Name == "EmployeesId"),
                    Operator = OperationsEnum.Equals,
                    Value = getEmployeesStoresDto.EmployeesId
                });
            }


            if (filterExpressions.Any())
            {
                var deleg = ExpressionBuilder.GetExpression<Employees_Stores>(filterExpressions).Compile();

                result = _context.Set<Employees_Stores>().Where(deleg).ToList();
            }
            else
            {
                result = _context.Set<Employees_Stores>().ToList();
            }

            return await Task.Run(()=> PagedList<Employees_Stores>.ToPagedList(result,
                                                    getEmployeesStoresDto.PageNumber,
                                                    getEmployeesStoresDto.PageSize));
        }
    }
}
