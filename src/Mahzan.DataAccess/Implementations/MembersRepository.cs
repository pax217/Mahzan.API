using System;
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
    }
}
