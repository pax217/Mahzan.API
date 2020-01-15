using Mahzan.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mahzan.Models
{

    public class AuditEntry
    {
        public AuditEntry(EntityEntry entry)
        {
            Entry = entry;
        }

        public EntityEntry Entry { get; }
        public string TableName { get; set; }
        public Guid AspNetUserId { get; set; }
        public EntityState Tipo { get; set; }
        public Dictionary<string, object> KeyValues { get; } = new Dictionary<string, object>();
        public Dictionary<string, object> OldValues { get; } = new Dictionary<string, object>();
        public Dictionary<string, object> NewValues { get; } = new Dictionary<string, object>();
        public List<PropertyEntry> TemporaryProperties { get; } = new List<PropertyEntry>();

        public bool HasTemporaryProperties => TemporaryProperties.Any();

        public Audits ToAudits()
        {
            var audit = new Audits();
            audit.TableName = TableName;
            audit.DateTime = DateTime.UtcNow;
            audit.KeyValues = JsonConvert.SerializeObject(KeyValues);
            audit.OldValues = OldValues.Count == 0 ? null : JsonConvert.SerializeObject(OldValues);
            audit.NewValues = NewValues.Count == 0 ? null : JsonConvert.SerializeObject(NewValues);
            return audit;
        }

        public Groups_Audit ToGroups_Audit()
        {
            var groups_Audit = new Groups_Audit();
            groups_Audit.AspNetUserId = AspNetUserId;
            groups_Audit.Type = Tipo.ToString();
            groups_Audit.DateTime = DateTime.UtcNow;
            groups_Audit.KeyValues = JsonConvert.SerializeObject(KeyValues);
            groups_Audit.OldValues = OldValues.Count == 0 ? null : JsonConvert.SerializeObject(OldValues);
            groups_Audit.NewValues = NewValues.Count == 0 ? null : JsonConvert.SerializeObject(NewValues);
            return groups_Audit;
        }

        public Companies_Audit ToCompanies_Audit()
        {
            var companies_Audit = new Companies_Audit();
            companies_Audit.AspNetUserId = AspNetUserId;
            companies_Audit.Type = Tipo.ToString();
            companies_Audit.DateTime = DateTime.UtcNow;
            companies_Audit.KeyValues = JsonConvert.SerializeObject(KeyValues);
            companies_Audit.OldValues = OldValues.Count == 0 ? null : JsonConvert.SerializeObject(OldValues);
            companies_Audit.NewValues = NewValues.Count == 0 ? null : JsonConvert.SerializeObject(NewValues);
            return companies_Audit;
        }

        public Stores_Audit ToStores_Audit()
        {
            var stores_Audit = new Stores_Audit();
            stores_Audit.AspNetUserId = AspNetUserId;
            stores_Audit.Type = Tipo.ToString();
            stores_Audit.DateTime = DateTime.UtcNow;
            stores_Audit.KeyValues = JsonConvert.SerializeObject(KeyValues);
            stores_Audit.OldValues = OldValues.Count == 0 ? null : JsonConvert.SerializeObject(OldValues);
            stores_Audit.NewValues = NewValues.Count == 0 ? null : JsonConvert.SerializeObject(NewValues);
            return stores_Audit;
        }

        public Employees_Audit ToEmployees_Audit()
        {
            var employees_Audit = new Employees_Audit();
            employees_Audit.AspNetUserId = AspNetUserId;
            employees_Audit.Type = Tipo.ToString();
            employees_Audit.DateTime = DateTime.UtcNow;
            employees_Audit.KeyValues = JsonConvert.SerializeObject(KeyValues);
            employees_Audit.OldValues = OldValues.Count == 0 ? null : JsonConvert.SerializeObject(OldValues);
            employees_Audit.NewValues = NewValues.Count == 0 ? null : JsonConvert.SerializeObject(NewValues);
            return employees_Audit;
        }

        public PointsOfSales_Audit ToPointsOfSales_Audit()
        {
            var pointsOfSales_Audit = new PointsOfSales_Audit();
            pointsOfSales_Audit.AspNetUserId = AspNetUserId;
            pointsOfSales_Audit.Type = Tipo.ToString();
            pointsOfSales_Audit.DateTime = DateTime.UtcNow;
            pointsOfSales_Audit.KeyValues = JsonConvert.SerializeObject(KeyValues);
            pointsOfSales_Audit.OldValues = OldValues.Count == 0 ? null : JsonConvert.SerializeObject(OldValues);
            pointsOfSales_Audit.NewValues = NewValues.Count == 0 ? null : JsonConvert.SerializeObject(NewValues);
            return pointsOfSales_Audit;
        }

        public Employees_Stores_Audit ToEmployees_Stores_Audit()
        {
            var employees_Stores_Audit = new Employees_Stores_Audit();
            employees_Stores_Audit.AspNetUserId = AspNetUserId;
            employees_Stores_Audit.Type = Tipo.ToString();
            employees_Stores_Audit.DateTime = DateTime.UtcNow;
            employees_Stores_Audit.KeyValues = JsonConvert.SerializeObject(KeyValues);
            employees_Stores_Audit.OldValues = OldValues.Count == 0 ? null : JsonConvert.SerializeObject(OldValues);
            employees_Stores_Audit.NewValues = NewValues.Count == 0 ? null : JsonConvert.SerializeObject(NewValues);
            return employees_Stores_Audit;
        }

        public Products_Audit ToProducts_Audit()
        {
            var products_Audit = new Products_Audit();
            products_Audit.AspNetUserId = AspNetUserId;
            products_Audit.Type = Tipo.ToString();
            products_Audit.DateTime = DateTime.UtcNow;
            products_Audit.KeyValues = JsonConvert.SerializeObject(KeyValues);
            products_Audit.OldValues = OldValues.Count == 0 ? null : JsonConvert.SerializeObject(OldValues);
            products_Audit.NewValues = NewValues.Count == 0 ? null : JsonConvert.SerializeObject(NewValues);
            return products_Audit;
        }
    }
}
