﻿using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mahzan.Models.Entities
{
    public class PointsOfSales
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        public string Code { get; set; }

        public string Name { get; set; }

        //Stores
        public Guid StoresId { get; set; }
        public Stores Stores { get; set; }
    }
}
