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

namespace Mahzan.DataAccess.Implementations
{
    public class CompaniesRepository: RepositoryBase<Companies>, ICompaniesRepository
    {
        public CompaniesRepository(MahzanDbContext repositoryContext)
            : base(repositoryContext)
        {
        }

        public PagedList<Companies> Get(GetCompaniesFilter getCompaniesFilter)
        {
            List<Companies> result = null;

            if (getCompaniesFilter.MemberId == null
                && getCompaniesFilter.BusinessName == null)
            {
                result = (from c in _context.Set<Companies>()
                          select c)
                         .ToList();
            }
            else
            {
                if (getCompaniesFilter.MemberId!=null
                    && getCompaniesFilter.BusinessName == null)
                {
                    result = (from c in _context.Set<Companies>()
                              where c.MemberId.Equals(getCompaniesFilter.MemberId)
                              && c.BusinessName.Contains(getCompaniesFilter.BusinessName)
                              select c)
                              .ToList();
                }
                else if(getCompaniesFilter.MemberId != null)
                {
                    result = (from c in _context.Set<Companies>()
                              where c.MemberId.Equals(getCompaniesFilter.MemberId)
                              select c)
                              .ToList();
                }
                else if (getCompaniesFilter.BusinessName != null)
                {
                    result = (from c in _context.Set<Companies>()
                              where c.BusinessName.Equals(getCompaniesFilter.BusinessName)
                              select c)
                              .ToList();
                }
            }

            return PagedList<Companies>.ToPagedList(result,
                                                    getCompaniesFilter.PageNumber,
                                                    getCompaniesFilter.PageSize);
        }

        public Companies Update(PutCompaniesDto putCompaniesDto)
        {
            Companies companyToUpdate = (from g in _context.Set<Companies>()
                                         where g.Id.Equals(putCompaniesDto.CompanyId)
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

            if (putCompaniesDto.BusinessName!=null)
            {
                companyToUpdate.BusinessName = putCompaniesDto.BusinessName;
            }

            if (putCompaniesDto.BusinessName != null)
            {
                companyToUpdate.BusinessName = putCompaniesDto.BusinessName;
            }

            if (putCompaniesDto.Active != null)
            {
                companyToUpdate.Active = putCompaniesDto.Active.Value;
            }

            EntityEntry entry = _context.Entry(companyToUpdate);
            entry.State = EntityState.Modified;
            entry.Property("Id").IsModified = false;
            entry.Property("MemberId").IsModified = false;
            entry.Property("GroupId").IsModified = false;

            _context.Set<Companies>().Update(companyToUpdate);
            _context.SaveChanges(putCompaniesDto.TableAuditEnum,
                                 putCompaniesDto.AspNetUserId);

            return companyToUpdate;
        }

        public Companies Delete(DeleteCompaniesDto deleteCompaniesDto)
        {
            Companies companyToDelte = (from g in _context.Set<Companies>()
                                   where g.Id.Equals(deleteCompaniesDto.CompanyId)
                                   select g)
                                    .FirstOrDefault();

            _context.Set<Companies>().Remove(companyToDelte);
            _context.SaveChanges(deleteCompaniesDto.TableAuditEnum,
                                 deleteCompaniesDto.AspNetUserId);

            return companyToDelte;
        }
    }
}
