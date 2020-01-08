using System;
using System.Collections.Generic;
using Mahzan.DataAccess.Filters.Companies;
using Mahzan.DataAccess.Filters.Employees;
using Mahzan.DataAccess.Interfaces;
using Mahzan.DataAccess.Paging;
using Mahzan.Models;
using Mahzan.Models.Entities;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Mahzan.DataAccess.DTO.Employees;

namespace Mahzan.DataAccess.Implementations
{
    public class EmployeesRepository : RepositoryBase<Employees>, IEmployeesRepository
    {
        public EmployeesRepository(MahzanDbContext repositoryContext)
            : base(repositoryContext)
        {
        }

        public Employees Delete(DeleteEmployeesDto deleteEmployeesDto)
        {
            Employees employeeToDelte = (from g in _context.Set<Employees>()
                                        where g.Id.Equals(deleteEmployeesDto.EmployeeId)
                                        select g)
                                    .FirstOrDefault();

            _context.Set<Employees>().Remove(employeeToDelte);
            _context.SaveChanges(deleteEmployeesDto.TableAuditEnum,
                                 deleteEmployeesDto.AspNetUserId);

            return employeeToDelte;
        }

        public PagedList<Employees> Get(GetEmployeesFilter getEmployeesFilter)
        {
            List<Employees> result = null;

            if (getEmployeesFilter.EmployeId==null
                && getEmployeesFilter.MemberId == null)
            {
                result = (from c in _context.Set<Employees>()
                          select c)
                         .ToList();
            }
            else
            {
                if (getEmployeesFilter.EmployeId != null
                    && getEmployeesFilter.MemberId != null)
                {
                    result = (from c in _context.Set<Employees>()
                              where c.Id == getEmployeesFilter.EmployeId
                              && c.MemberId == getEmployeesFilter.MemberId
                              select c)
                              .ToList();
                }
                else
                {
                    if (getEmployeesFilter.EmployeId != null)
                    {
                        result = (from c in _context.Set<Employees>()
                                  where c.Id == getEmployeesFilter.EmployeId
                                  select c)
                                  .ToList();
                    }
                    else if (getEmployeesFilter.MemberId != null)
                    {
                        result = (from c in _context.Set<Employees>()
                                  where c.MemberId == getEmployeesFilter.MemberId
                                  select c)
                                  .ToList();
                    }
                }
            }


            return PagedList<Employees>.ToPagedList(result,
                                                    getEmployeesFilter.PageNumber,
                                                    getEmployeesFilter.PageSize);
        }

        public Employees Update(PutEmployeesDto putEmployeesDto)
        {
            Employees employeeToUpdate = (from g in _context.Set<Employees>()
                                         where g.Id.Equals(putEmployeesDto.EmployeeId)
                                         select g)
                                         .FirstOrDefault();

            if (putEmployeesDto.CodeEmploye != null)
            {
                employeeToUpdate.CodeEmploye = putEmployeesDto.CodeEmploye;
            }

            if (putEmployeesDto.FirstName != null)
            {
                employeeToUpdate.FirstName = putEmployeesDto.FirstName;
            }

            if (putEmployeesDto.SecondName != null)
            {
                employeeToUpdate.SecondName = putEmployeesDto.SecondName;
            }

            if (putEmployeesDto.LastName != null)
            {
                employeeToUpdate.LastName = putEmployeesDto.LastName;
            }

            if (putEmployeesDto.SureName != null)
            {
                employeeToUpdate.SureName = putEmployeesDto.SureName;
            }

            if (putEmployeesDto.Email != null)
            {
                employeeToUpdate.Email = putEmployeesDto.Email;
            }

            if (putEmployeesDto.Phone != null)
            {
                employeeToUpdate.Phone = putEmployeesDto.Phone;
            }

            if (putEmployeesDto.Active != null)
            {
                employeeToUpdate.Active = putEmployeesDto.Active.Value;
            }

            EntityEntry entry = _context.Entry(employeeToUpdate);
            entry.State = EntityState.Modified;
            entry.Property("Id").IsModified = false;
            entry.Property("MemberId").IsModified = false;

            _context.Set<Employees>().Update(employeeToUpdate);
            _context.SaveChanges(putEmployeesDto.TableAuditEnum,
                                 putEmployeesDto.AspNetUserId);

            return employeeToUpdate;
        }
    }
}