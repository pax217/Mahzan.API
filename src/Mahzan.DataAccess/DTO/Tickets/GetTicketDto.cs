﻿using Mahzan.DataAccess.DTO._Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mahzan.DataAccess.DTO.Tickets
{
    public class GetTicketDto:BaseDto
    {
        public Guid ticketsId { get; set; }
    }
}
