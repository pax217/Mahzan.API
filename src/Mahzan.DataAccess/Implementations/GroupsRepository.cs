using System;
using System.Collections.Generic;
using System.Linq;
using Mahzan.DataAccess.DTO.Groups;
using Mahzan.DataAccess.Filters.Groups;
using Mahzan.DataAccess.Interfaces;
using Mahzan.DataAccess.Paging;
using Mahzan.Models;
using Mahzan.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Mahzan.DataAccess.Implementations
{
    public class GroupsRepository : RepositoryBase<Groups>, IGroupsRepository
    {
        public GroupsRepository(MahzanDbContext repositoryContext)
            : base(repositoryContext)
        {
        }

        public PagedList<Groups> Get(GetGroupFilter getGroupFilter)
        {
            List<Groups> result = null;

            if (getGroupFilter.GroupId == Guid.Empty
                && getGroupFilter.MemberId == Guid.Empty
                && getGroupFilter.Name == null)
            {

                result = (from g in _context.Set<Groups>()
                          select g)
                         .ToList();
            }
            else
            {
                if (getGroupFilter.GroupId != Guid.Empty
                    && getGroupFilter.MemberId != Guid.Empty
                    && getGroupFilter.Name != null)
                {
                    result = (from g in _context.Set<Groups>()
                             where g.Id == getGroupFilter.GroupId
                             && g.MemberId == getGroupFilter.MemberId
                             && g.Name.Contains(getGroupFilter.Name)
                             select g)
                             .ToList();
                }
                else if (getGroupFilter.GroupId != Guid.Empty)
                {
                    result = (from g in _context.Set<Groups>()
                              where g.Id == getGroupFilter.GroupId
                              select g).ToList();
                }
                else if (getGroupFilter.MemberId != Guid.Empty)
                {
                    result = (from g in _context.Set<Groups>()
                              where g.MemberId == getGroupFilter.MemberId
                              select g)
                             .ToList();
                }
                else if (getGroupFilter.Name != null)
                {
                    result = (from g in _context.Set<Groups>()
                              where g.Name.Contains(getGroupFilter.Name)
                              select g)
                             .ToList();
                }
            }

            return PagedList<Groups>.ToPagedList(result,
                                                 getGroupFilter.PageNumber,
                                                 getGroupFilter.PageSize);
        }

        public Groups Update(PutGroupsDto putGroupsDto)
        {
            Groups groupToUpdate = (from g in _context.Set<Groups>()
                                    where g.Id.Equals(putGroupsDto.GroupId)
                                    select g)
                                   .FirstOrDefault();

            //Cambios
            if (putGroupsDto.Name != null)
            {
                groupToUpdate.Name = putGroupsDto.Name;
            }

            if (putGroupsDto.Active != null)
            {
                groupToUpdate.Active = putGroupsDto.Active.Value;
            }

            EntityEntry entry = _context.Entry(groupToUpdate);
            entry.State = EntityState.Modified;
            entry.Property("Id").IsModified = false;

            _context.Set<Groups>().Update(groupToUpdate);
            _context.SaveChanges(putGroupsDto.TableAuditEnum,
                                 putGroupsDto.AspNetUserId);

            return groupToUpdate;

        }

        public Groups Delete(DeleteGroupsDto deleteGroupsDto)
        {
            Groups groupToDelte = (from g in _context.Set<Groups>()
                                    where g.Id.Equals(deleteGroupsDto.GroupId)
                                    select g)
                                    .FirstOrDefault();

            _context.Set<Groups>().Remove(groupToDelte);
            _context.SaveChanges(deleteGroupsDto.TableAuditEnum,
                                 deleteGroupsDto.AspNetUserId);

            return groupToDelte;
        }
    }
}