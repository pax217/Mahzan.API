﻿using System;
using System.ComponentModel.DataAnnotations;

namespace Mahzan.Business.Requests.Clients
{
    public class PostClientsRequest
    {
        [Required]
        public string RFC { get; set; }

        public string CommercialName { get; set; }

        public string BusinessName { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public string Notes { get; set; }
    }
}
