using System;
using Mahzan.DataAccess.Interfaces;
using Mahzan.Models;
using Mahzan.Models.Entities;

namespace Mahzan.DataAccess.Implementations
{
    public class MiembrosRepository:RepositoryBase<Miembros>,IMiembrosRepository
    {
        public MiembrosRepository(MahzanDbContext repositoryContext)
            : base(repositoryContext)
        {
        }
    }
}
