﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Mahzan.Models.Entities;
using Mahzan.Models.Enums.Audit;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Mahzan.Models
{
    public class MahzanDbContext : DbContext
    {
        public DbSet<Audits> Audits { get; set; }
        public DbSet<Members> Members { get; set; }
        public DbSet<Groups> Groups { get; set; }
        public DbSet<Groups_Audit> Groups_Audit { get; set; }
        public DbSet<Companies> Companies { get; set; }
        public DbSet<Companies_Audit> Companies_Audit { get; set; }
        public DbSet<Stores> Stores { get; set; }
        public DbSet<Stores_Audit> Stores_Audit { get; set; }
        public DbSet<Employees> Employees { get; set; }
        public DbSet<Employees_Audit> Employees_Audit { get; set; }
        public DbSet<PointsOfSales> PointsOfSales { get; set; }
        public DbSet<PointsOfSales_Audit> PointsOfSales_Audit { get; set; }
        public DbSet<Employees_Stores> Employees_Stores { get; set; }
        public DbSet<Employees_Stores_Audit> Employees_Stores_Audit { get; set; }

        public DbSet<Products> Products { get; set; }
        public DbSet<Products_Audit> Products_Audit { get; set; }

        public DbSet<ProductsPhotos> ProductsPhotos { get; set; }

        public DbSet<ProductUnits> ProductUnits { get; set; }
        public DbSet<ProductUnits_Audit> ProductUnits_Audit { get; set; }

        public DbSet<ProductCategories> ProductCategories { get; set; }
        public DbSet<ProductCategories_Audit> ProductCategories_Audit { get; set; }

        public DbSet<Products_Store> Products_Store { get; set; }
        public DbSet<Products_Store_Audit> Products_Store_Audit { get; set; }

        public DbSet<Tickets> Tickets { get; set; }
        public DbSet<TicketDetail> TicketDetail { get; set; }


        public DbSet<PaymentTypes> PaymentTypes { get; set; }

        public DbSet<Menu> Menu { get; set; }
        public DbSet<Menu_Items> Menu_Items { get; set; }
        public DbSet<Menu_SubItems> Menu_SubItems { get; set; }

        public MahzanDbContext(DbContextOptions<MahzanDbContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Audits>()
                        .HasKey(audits => new { audits.Id });

            modelBuilder.Entity<Members>()
                        .HasKey(members => new { members.Id });

            modelBuilder.Entity<Groups>()
                        .HasKey(Groups => new { Groups.Id });

            modelBuilder.Entity<Groups_Audit>()
                        .HasKey(groups_Audit => new { groups_Audit.Id });

            modelBuilder.Entity<Companies>()
                        .HasKey(companies => new { companies.Id });

            modelBuilder.Entity<Stores>()
                        .HasKey(stores => new { stores.Id });

            modelBuilder.Entity<Stores_Audit>()
                        .HasKey(stores_audit => new { stores_audit.Id });

            modelBuilder.Entity<Employees>()
                        .HasKey(employees => new { employees.Id });

            modelBuilder.Entity<Employees_Audit>()
                        .HasKey(employees_Audit => new { employees_Audit.Id });

            modelBuilder.Entity<PointsOfSales>()
                        .HasKey(pointsOfSales => new { pointsOfSales.Id });

            modelBuilder.Entity<PointsOfSales_Audit>()
                        .HasKey(pointsOfSales_Audit => new { pointsOfSales_Audit.Id });

            modelBuilder.Entity<Employees_Stores>()
                        .HasKey(employees_Stores => new { employees_Stores.Id });

            modelBuilder.Entity<Employees_Stores_Audit>()
                        .HasKey(employees_Stores_Audit => new { employees_Stores_Audit.Id });

            modelBuilder.Entity<Products>()
                
                        .HasKey(products => new { products.Id });

            modelBuilder.Entity<Products_Audit>()
                        .HasKey(products_Audit => new { products_Audit.Id });

            modelBuilder.Entity<Products_Store>()
                        .HasKey(products_Store => new { products_Store.Id });

            modelBuilder.Entity<Products_Store_Audit>()
                        .HasKey(products_Store_Audit => new { products_Store_Audit.Id });

            modelBuilder.Entity<ProductsPhotos>()
                        .HasKey(productsPhotos => new { productsPhotos.Id });

            modelBuilder.Entity<ProductUnits>()
                        .HasKey(productUnits => new { productUnits.Id });

            modelBuilder.Entity<ProductUnits_Audit>()
                        .HasKey(productUnits_Audit => new { productUnits_Audit.Id });

            modelBuilder.Entity<ProductCategories>()
                        .HasKey(productCategories => new { productCategories.Id });

            modelBuilder.Entity<ProductCategories_Audit>()
                        .HasKey(productCategories_Audit => new { productCategories_Audit.Id });

            modelBuilder.Entity<Tickets>()
                        .HasKey(tickets => new { tickets.Id });

            modelBuilder.Entity<TicketDetail>()
                        .HasKey(ticketDetail => new { ticketDetail.Id });

            modelBuilder.Entity<PaymentTypes>()
                        .HasKey(paymentTypes => new { paymentTypes.Id });

            modelBuilder.Entity<Menu>()
                        .HasKey(menu => new { menu.Id });

            modelBuilder.Entity<Menu_Items>()
                        .HasKey(menu_Items => new { menu_Items.Id });

            modelBuilder.Entity<Menu_SubItems>()
                        .HasKey(menu_SubItems => new { menu_SubItems.Id });

        }

        public int SaveChanges(TableAuditEnum tableAuditEnum,
                               Guid aspNetUsersId)
        {
            var auditEntries = OnBeforeSaveChanges(tableAuditEnum,
                                                   aspNetUsersId);

            var result = base.SaveChanges();

            OnAfterSaveChanges(tableAuditEnum,
                               aspNetUsersId,
                               auditEntries);

            return result;

        }
        private List<AuditEntry> OnBeforeSaveChanges(TableAuditEnum tableAuditEnum,
                                                     Guid aspNetUsersId)
        {


            ChangeTracker.DetectChanges();
            var auditEntries = new List<AuditEntry>();
            foreach (var entry in ChangeTracker.Entries())
            {
                if (entry.Entity is Audits || entry.State == EntityState.Detached || entry.State == EntityState.Unchanged)
                    continue;

                var auditEntry = new AuditEntry(entry);
                auditEntry.TableName = entry.Metadata.GetTableName();
                auditEntries.Add(auditEntry);

                foreach (var property in entry.Properties)
                {
                    if (property.IsTemporary)
                    {
                        // value will be generated by the database, get the value after saving
                        auditEntry.TemporaryProperties.Add(property);
                        continue;
                    }

                    string propertyName = property.Metadata.Name;
                    if (property.Metadata.IsPrimaryKey())
                    {
                        auditEntry.KeyValues[propertyName] = property.CurrentValue;
                        continue;
                    }

                    switch (entry.State)
                    {
                        case EntityState.Added:
                            auditEntry.NewValues[propertyName] = property.CurrentValue;
                            auditEntry.Tipo = EntityState.Added;
                            break;

                        case EntityState.Deleted:
                            auditEntry.OldValues[propertyName] = property.OriginalValue;
                            auditEntry.Tipo = EntityState.Deleted;
                            break;

                        case EntityState.Modified:

                            if (property.IsModified)
                            {
                                auditEntry.OldValues[propertyName] = property.OriginalValue;
                                auditEntry.NewValues[propertyName] = property.CurrentValue;
                            }

                            auditEntry.Tipo = EntityState.Modified;
                            break;
                    }
                }
            }

            // Save audit entities that have all the modifications
            foreach (var auditEntry in auditEntries.Where(_ => !_.HasTemporaryProperties))
            {
                
                auditEntry.AspNetUserId = aspNetUsersId;

                switch (tableAuditEnum)
                {
                    case TableAuditEnum.GROUPS_AUDIT:
                        Groups_Audit.Add(auditEntry.ToGroups_Audit());
                        break;
                    case TableAuditEnum.COMPANIES_AUDIT:
                        Companies_Audit.Add(auditEntry.ToCompanies_Audit());
                        break;
                    case TableAuditEnum.STORES_AUDIT:
                        Stores_Audit.Add(auditEntry.ToStores_Audit());
                        break;
                    case TableAuditEnum.EMPLOYEES_AUDIT:
                        Employees_Audit.Add(auditEntry.ToEmployees_Audit());
                        break;
                    case TableAuditEnum.POINTSOFSALES_AUDIT:
                        PointsOfSales_Audit.Add(auditEntry.ToPointsOfSales_Audit());
                        break;
                    case TableAuditEnum.EMPLOYEES_STORES_AUDIT:
                        Employees_Stores_Audit.Add(auditEntry.ToEmployees_Stores_Audit());
                        break;
                    case TableAuditEnum.PRODUCTS_AUDIT:
                        Products_Audit.Add(auditEntry.ToProducts_Audit());
                        break;
                    case TableAuditEnum.PRODUCT_CATEGORIES_AUDIT:
                        ProductCategories_Audit.Add(auditEntry.ToProductCategories_Audit());
                        break;
                    case TableAuditEnum.PRODUCT_UNITS_AUDIT:
                        ProductUnits_Audit.Add(auditEntry.ToProductUnits_Audit());
                        break;
                    default:
                        Audits.Add(auditEntry.ToAudits());
                        break;
                }

            }

            // keep a list of entries where the value of some properties are unknown at this step
            return auditEntries.Where(_ => _.HasTemporaryProperties).ToList();
        }
        private Task OnAfterSaveChanges(TableAuditEnum tableAuditEnum,
                                        Guid aspNetUsersId,
                                        List<AuditEntry> auditEntries)
        {
            if (auditEntries == null || auditEntries.Count == 0)
                return Task.CompletedTask;

            foreach (var auditEntry in auditEntries)
            {
                // Get the final value of the temporary properties
                foreach (var prop in auditEntry.TemporaryProperties)
                {
                    if (prop.Metadata.IsPrimaryKey())
                    {
                        auditEntry.KeyValues[prop.Metadata.Name] = prop.CurrentValue;
                    }
                    else
                    {
                        auditEntry.NewValues[prop.Metadata.Name] = prop.CurrentValue;
                    }
                }

                // Save the Audit entry\
                Audits.Add(auditEntry.ToAudits());

            }

            return SaveChangesAsync();
        }
    }
}
