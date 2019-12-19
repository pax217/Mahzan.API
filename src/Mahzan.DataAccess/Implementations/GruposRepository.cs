using System;
using Mahzan.DataAccess.Interfaces;
using Mahzan.Models;
using Mahzan.Models.Entities;

namespace Mahzan.DataAccess.Implementations
{
    public class GruposRepository : RepositoryBase<Grupos>, IGruposRepository
    {
        public GruposRepository(MahzanDbContext repositoryContext)
            : base(repositoryContext)
        {
        }
    }
}