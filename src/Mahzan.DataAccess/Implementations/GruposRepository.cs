﻿using System;
using Mahzan.DataAccess.Interfaces;
using Mahzan.Models;
using Mahzan.Models.Entities;

namespace Mahzan.DataAccess.Implementations
{
    public class GruposRepository : RepositoryBase<Groups>, IGroupsRepository
    {
        public GruposRepository(MahzanDbContext repositoryContext)
            : base(repositoryContext)
        {
        }
    }
}