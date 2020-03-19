using System;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Mahzan.Api.Context
{
    public class MahzanIdentityDbContext : IdentityDbContext<AspNetUsers>
    {
        #region Constructores

        public MahzanIdentityDbContext(DbContextOptions<MahzanIdentityDbContext> options) : base(options)
        {

        }

        #endregion

        #region Metodos Protegidos

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

        #endregion
    }
}
