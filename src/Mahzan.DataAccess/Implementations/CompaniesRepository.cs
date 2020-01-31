using System;
using System.Collections.Generic;
using Mahzan.DataAccess.Filters.Companies;
using Mahzan.DataAccess.Interfaces;
using Mahzan.DataAccess.Paging;
using Mahzan.Models;
using Mahzan.Models.Entities;
using System.Linq;
using Mahzan.DataAccess.DTO.Companies;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore;
using Mahzan.Models.Expressions;
using Mahzan.Models.Enums.Expressions;

namespace Mahzan.DataAccess.Implementations
{
    public class CompaniesRepository : RepositoryBase<Companies>, ICompaniesRepository
    {
        public CompaniesRepository(MahzanDbContext repositoryContext)
            : base(repositoryContext)
        {
        }

        public PagedList<Companies> Get(GetCompaniesDto getCompaniesDto)
        {
            List<Companies> result = null;
            List<FilterExpression> filterExpressions = new List<FilterExpression>();

            if (getCompaniesDto.MembersId != null)
            {
                filterExpressions.Add(new FilterExpression
                {
                    PropertyInfo = typeof(Companies).GetProperties().First(p => p.Name == "MembersId"),
                    Operator = OperationsEnum.Equals,
                    Value = getCompaniesDto.MembersId
                });
            }

            if (getCompaniesDto.CompaniesId != null)
            {
                filterExpressions.Add(new FilterExpression
                {
                    PropertyInfo = typeof(Companies).GetProperties().First(p => p.Name == "CompaniesId"),
                    Operator = OperationsEnum.Equals,
                    Value = getCompaniesDto.CompaniesId
                });
            }


            if (getCompaniesDto.RFC != null)
            {
                filterExpressions.Add(new FilterExpression
                {
                    PropertyInfo = typeof(Companies).GetProperties().First(p => p.Name == "RFC"),
                    Operator = OperationsEnum.Equals,
                    Value = getCompaniesDto.RFC
                });
            }

            //CommercialName
            if (getCompaniesDto.CommercialName != null)
            {
                filterExpressions.Add(new FilterExpression
                {
                    PropertyInfo = typeof(Companies).GetProperties().First(p => p.Name == "CommercialName"),
                    Operator = OperationsEnum.Contains,
                    Value = getCompaniesDto.CommercialName
                });
            }

            //BusinessName
            if (getCompaniesDto.BusinessName != null)
            {
                filterExpressions.Add(new FilterExpression
                {
                    PropertyInfo = typeof(Companies).GetProperties().First(p => p.Name == "BusinessName"),
                    Operator = OperationsEnum.Contains,
                    Value = getCompaniesDto.BusinessName
                });
            }

            //GroupsId
            if (getCompaniesDto.GroupsId != null)
            {
                filterExpressions.Add(new FilterExpression
                {
                    PropertyInfo = typeof(Companies).GetProperties().First(p => p.Name == "GroupsId"),
                    Operator = OperationsEnum.Equals,
                    Value = getCompaniesDto.GroupsId
                });
            }

            if (filterExpressions.Any())
            {
                var deleg = ExpressionBuilder.GetExpression<Companies>(filterExpressions).Compile();

                result = _context.Set<Companies>().Where(deleg).ToList();
            }
            else
            {
                result = _context.Set<Companies>().ToList();
            }

            return PagedList<Companies>.ToPagedList(result,
                                                    getCompaniesDto.PageNumber,
                                                    getCompaniesDto.PageSize);
        }

        public Companies Update(PutCompaniesDto putCompaniesDto)
        {
            Companies companyToUpdate = (from g in _context.Set<Companies>()
                                         where g.CompaniesId.Equals(putCompaniesDto.CompaniesId)
                                         select g)
                                         .FirstOrDefault();

            if (putCompaniesDto.RFC != null)
            {
                companyToUpdate.RFC = putCompaniesDto.RFC;
            }

            if (putCompaniesDto.CommercialName != null)
            {
                companyToUpdate.CommercialName = putCompaniesDto.CommercialName;
            }

            if (putCompaniesDto.BusinessName != null)
            {
                companyToUpdate.BusinessName = putCompaniesDto.BusinessName;
            }

            if (putCompaniesDto.BusinessName != null)
            {
                companyToUpdate.BusinessName = putCompaniesDto.BusinessName;
            }

            if (putCompaniesDto.GroupsId != null)
            {
                companyToUpdate.GroupsId = putCompaniesDto.GroupsId.Value;
            }


            EntityEntry entry = _context.Entry(companyToUpdate);
            entry.State = EntityState.Modified;
            entry.Property("CompaniesId").IsModified = false;
            entry.Property("MembersId").IsModified = false;

            _context.Set<Companies>().Update(companyToUpdate);
            _context.SaveChangesAsync(putCompaniesDto.TableAuditEnum,
                                 putCompaniesDto.AspNetUserId);

            return companyToUpdate;
        }

        public Companies Delete(DeleteCompaniesDto deleteCompaniesDto)
        {
            Companies companyToDelte = (from g in _context.Set<Companies>()
                                        where g.CompaniesId.Equals(deleteCompaniesDto.CompaniesId)
                                        select g)
                                    .FirstOrDefault();

            _context.Set<Companies>().Remove(companyToDelte);
            _context.SaveChangesAsync(deleteCompaniesDto.TableAuditEnum,
                                 deleteCompaniesDto.AspNetUserId);

            return companyToDelte;
        }

        public Companies Add(AddCompaniesDto addCompaniesDto)
        {
            Companies newCompany = new Companies
            {
                RFC = addCompaniesDto.RFC,
                CommercialName = addCompaniesDto.CommercialName,
                BusinessName = addCompaniesDto.BusinessName,
                GroupsId = addCompaniesDto.GroupsId,
                MembersId = addCompaniesDto.MembersId
            };

            _context.Set<Companies>().Add(newCompany);
            _context.SaveChangesAsync(addCompaniesDto.TableAuditEnum,
                                 addCompaniesDto.AspNetUserId);

            return newCompany;
        }
    }
}
