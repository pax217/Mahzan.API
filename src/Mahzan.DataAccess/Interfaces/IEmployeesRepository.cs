﻿using System;
using Mahzan.DataAccess.DTO.Employees;
using Mahzan.DataAccess.Filters.Employees;
using Mahzan.DataAccess.Paging;
using Mahzan.Models.Entities;

namespace Mahzan.DataAccess.Interfaces
{
    public interface IEmployeesRepository: IRepositoryBase<Employees>
    {
        PagedList<Employees> Get(GetEmployeesDto getEmployeesDto);

        Employees Update(PutEmployeesDto putEmployeesDto);

        Employees Delete(DeleteEmployeesDto deleteEmployeesDto);
    }
}
