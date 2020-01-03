﻿using System;
using Mahzan.DataAccess.DTO._Base;

namespace Mahzan.DataAccess.DTO.Companies
{
    public class PutCompaniesDto:BaseDto
    {
        public Guid CompanyId { get; set; }
        public string RFC { get; set; }
        public string CommercialName { get; set; }
        public string BusinessName { get; set; }
        public bool? Active { get; set; }
    }
}
