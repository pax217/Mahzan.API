using System;
using Mahzan.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Mahzan.Models
{
    public class MahzanDbContext: DbContext
    {
        public DbSet<Members> Members { get; set; }


        //public DbSet<Empresas> Empresas { get; set; }
        //public DbSet<Empleados> Empleados { get; set; }
        //public DbSet<Empleados_Sucursal> Empleados_Sucursal { get; set; }

        //public DbSet<Miembros> Miembros { get; set; }
        //public DbSet<Sucursales> Sucursales { get; set; }

        public MahzanDbContext(DbContextOptions<MahzanDbContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer(ConnectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Members>()
                        .HasKey(members => new { members.Id });

            //modelBuilder.Entity<Groups>()
            //            .HasKey(grupos => new { grupos.Id });

            //modelBuilder.Entity<Empresas>()
            //            .HasKey(empresas => new { empresas.Id });

            //modelBuilder.Entity<Empleados>()
            //            .HasKey(empleados => new { empleados.Id });

            //modelBuilder.Entity<Empleados_Sucursal>()
            //            .HasKey(empleados_sucursal => new {
            //                empleados_sucursal.EmpleadoId,
            //                empleados_sucursal.SucursalId,
            //                empleados_sucursal.MiembroId
            //            });



            //modelBuilder.Entity<Miembros>()
            //            .HasKey(miembros => new { miembros.Id });

            //modelBuilder.Entity<Sucursales>()
            //            .HasKey(sucursales => new { sucursales.Id });
        }
    }
}
