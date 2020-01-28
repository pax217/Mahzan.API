﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mahzan.Models.Entities
{
    public class ProductsTaxes
    {
        public Guid ProductsId { get; set; }

        public Guid TaxesId { get; set; }

        public Guid MembersId { get; set; }
    }
}
