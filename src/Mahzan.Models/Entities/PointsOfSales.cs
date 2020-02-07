using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mahzan.Models.Entities
{
    public class PointsOfSales
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid PointsOfSalesId { get; set; }

        public string Code { get; set; }

        public string Name { get; set; }

        //Stores
        public Guid StoresId { get; set; }

        public Guid MembersId { get; set; }
    }
}
