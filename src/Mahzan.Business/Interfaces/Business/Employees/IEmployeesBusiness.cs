﻿using System;
using System.Threading.Tasks;
using Mahzan.Business.Requests.Employees;
using Mahzan.Business.Results.Employees;
using Mahzan.DataAccess.DTO.Employees;
using Mahzan.DataAccess.Filters.Companies;
using Mahzan.DataAccess.Filters.Employees;

namespace Mahzan.Business.Interfaces.Business.Employees
{
    public interface IEmployeesBusiness
    {
        Task<PostEmployeesResult> Add(AddEmployeesDto addEmployeesDto);

        Task<GetEmployeesResult> Get(GetEmployeesFilter getEmployeesFilter);

        Task<PutEmployeesResult> Update(PutEmployeesDto putEmployeesDto);

        Task<DeleteEmployeesResult> Delete(DeleteEmployeesDto deleteEmployeesDto);
    }
}
