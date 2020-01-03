﻿using System;
using Mahzan.DataAccess.DTO._Base;

namespace Mahzan.DataAccess.DTO.Companies
{
    public class AddCompaniesDto:BaseDto
    {
        public string RFC { get; set; }
        public string CommercialName { get; set; }
        public string BusinessName { get; set; }
        public bool Active { get; set; }
        public Guid GrupoId { get; set; }
    }
}
