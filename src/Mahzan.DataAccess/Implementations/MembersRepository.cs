using System;
using System.Threading.Tasks;
using Mahzan.DataAccess.DTO.Members;
using Mahzan.DataAccess.Interfaces;
using Mahzan.Models;
using Mahzan.Models.Entities;

namespace Mahzan.DataAccess.Implementations
{
    public class MembersRepository:RepositoryBase<Members>,IMembersRepository
    {
        public MembersRepository(MahzanDbContext repositoryContext)
            : base(repositoryContext)
        {
        }

        public async Task<Members> Add(AddMembersDto addMembersDto)
        {
            Members newMember = new Members
            {
                Name = addMembersDto.Name,
                Phone = addMembersDto.Phone,
                Email = addMembersDto.Email,
                UserName = addMembersDto.UserName,
                MembersPatternId = addMembersDto.MembersPatternId,
                AspNetUsersId = addMembersDto.AspNetUsersId
            };

            _context.Set<Members>().Add(newMember);
            await _context.SaveChangesAsync();


            return newMember;
        }
    }
}
