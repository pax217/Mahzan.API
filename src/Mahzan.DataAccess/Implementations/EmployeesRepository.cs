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
using Mahzan.Models.Expressions;
using Mahzan.Models.Enums.Expressions;

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
                                         where g.EmployeesId.Equals(deleteEmployeesDto.EmployeeId)
                                         select g)
                                    .FirstOrDefault();

            _context.Set<Employees>().Remove(employeeToDelte);
            _context.SaveChangesAsync(deleteEmployeesDto.TableAuditEnum,
                                 deleteEmployeesDto.AspNetUserId);

            return employeeToDelte;
        }

        public PagedList<Employees> Get(GetEmployeesDto getEmployeesDto)
        {
            List<Employees> result = null;
            List<FilterExpression> filterExpressions = new List<FilterExpression>();

            if (getEmployeesDto.MembersId != null)
            {
                filterExpressions.Add(new FilterExpression
                {
                    PropertyInfo = typeof(Employees).GetProperties().First(p => p.Name == "MembersId"),
                    Operator = OperationsEnum.Equals,
                    Value = getEmployeesDto.MembersId
                });
            }

            if (getEmployeesDto.EmployeesId != null)
            {
                filterExpressions.Add(new FilterExpression
                {
                    PropertyInfo = typeof(Employees).GetProperties().First(p => p.Name == "EmployeesId"),
                    Operator = OperationsEnum.Equals,
                    Value = getEmployeesDto.EmployeesId
                });
            }


            if (filterExpressions.Any())
            {
                var deleg = ExpressionBuilder.GetExpression<Employees>(filterExpressions).Compile();

                result = _context.Set<Employees>().Where(deleg).ToList();
            }
            else
            {
                result = _context.Set<Employees>().ToList();
            }

            return PagedList<Employees>.ToPagedList(result,
                                                    getEmployeesDto.PageNumber,
                                                    getEmployeesDto.PageSize);
        }

        public Employees Update(PutEmployeesDto putEmployeesDto)
        {
            Employees employeeToUpdate = (from g in _context.Set<Employees>()
                                          where g.EmployeesId.Equals(putEmployeesDto.EmployeeId)
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



            EntityEntry entry = _context.Entry(employeeToUpdate);
            entry.State = EntityState.Modified;
            entry.Property("EmployeesId").IsModified = false;
            entry.Property("MemberId").IsModified = false;

            _context.Set<Employees>().Update(employeeToUpdate);
            _context.SaveChangesAsync(putEmployeesDto.TableAuditEnum,
                                 putEmployeesDto.AspNetUserId);

            return employeeToUpdate;
        }
    }
}