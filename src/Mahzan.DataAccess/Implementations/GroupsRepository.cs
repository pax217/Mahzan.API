using System;
using System.Collections.Generic;
using System.Linq;
using Mahzan.DataAccess.DTO.Groups;
using Mahzan.DataAccess.Filters.Groups;
using Mahzan.DataAccess.Interfaces;
using Mahzan.DataAccess.Paging;
using Mahzan.Models;
using Mahzan.Models.Entities;
using Mahzan.Models.Enums.Expressions;
using Mahzan.Models.Expressions;
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

        public PagedList<Groups> Get(GetGroupsDto getGroupsDto)
        {
            List<Groups> result = null;
            List<FilterExpression> filterExpressions = new List<FilterExpression>();

            if (getGroupsDto.MembersId != null)
            {
                filterExpressions.Add(new FilterExpression
                {
                    PropertyInfo = typeof(Groups).GetProperties().First(p => p.Name == "MemberId"),
                    Operator = OperationsEnum.Equals,
                    Value = getGroupsDto.MembersId
                });
            }

            if (getGroupsDto.GroupId != null)
            {
                filterExpressions.Add(new FilterExpression
                {
                    PropertyInfo = typeof(Groups).GetProperties().First(p => p.Name == "Id"),
                    Operator = OperationsEnum.Equals,
                    Value = getGroupsDto.GroupId
                });
            }

            if (getGroupsDto.Name != null)
            {
                filterExpressions.Add(new FilterExpression
                {
                    PropertyInfo = typeof(Groups).GetProperties().First(p => p.Name == "Name"),
                    Operator = OperationsEnum.Contains,
                    Value = getGroupsDto.Name
                });
            }

            if (filterExpressions.Any())
            {
                var deleg = ExpressionBuilder.GetExpression<Groups>(filterExpressions).Compile();

                result = _context.Set<Groups>().Where(deleg).ToList();
            }
            else
            {
                result = _context.Set<Groups>().ToList();
            }

            return PagedList<Groups>.ToPagedList(result,
                                                 getGroupsDto.PageNumber,
                                                 getGroupsDto.PageSize);
        }

        public Groups Update(PutGroupsDto putGroupsDto)
        {
            Groups groupToUpdate = (from g in _context.Set<Groups>()
                                    where g.Id.Equals(putGroupsDto.GroupsId)
                                    select g)
                                   .FirstOrDefault();

            //Cambios
            if (putGroupsDto.Name != null)
            {
                groupToUpdate.Name = putGroupsDto.Name;
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
                                    where g.Id.Equals(deleteGroupsDto.GroupsId)
                                    select g)
                                    .FirstOrDefault();

            _context.Set<Groups>().Remove(groupToDelte);
            _context.SaveChanges(deleteGroupsDto.TableAuditEnum,
                                 deleteGroupsDto.AspNetUserId);

            return groupToDelte;
        }
    }
}