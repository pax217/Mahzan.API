using System;
using System.Collections.Generic;
using System.Linq;
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

        public PagedList<Employees_Stores> Get(GetEmployeesStoresFilter getEmployeesStoresFilter)
        {
            List<Employees_Stores> result = null;
            List<FilterExpression> filterExpressions = new List<FilterExpression>();

            if (getEmployeesStoresFilter.EmployeeId != null)
            {
                filterExpressions.Add(new FilterExpression
                {
                    PropertyInfo = typeof(Employees_Stores).GetProperties().First(p => p.Name == "EmployeeId"),
                    Operator = OperationsEnum.Equals,
                    Value = getEmployeesStoresFilter.EmployeeId
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

            return PagedList<Employees_Stores>.ToPagedList(result,
                                                    getEmployeesStoresFilter.PageNumber,
                                                    getEmployeesStoresFilter.PageSize);
        }
    }
}
