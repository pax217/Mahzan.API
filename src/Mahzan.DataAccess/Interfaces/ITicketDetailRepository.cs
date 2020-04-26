﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Mahzan.DataAccess.DTO.Tickets;
using Mahzan.Models.Entities;

namespace Mahzan.DataAccess.Interfaces
{
    public interface ITicketDetailRepository: IRepositoryBase<TicketDetail>
    {
        Task<TicketDetail> AddTicketDetail(TicketDetail ticketDetail);

        Task<List<TicketDetail>> AddListTicketDetail(Tickets newTicket,
                                                     List<PostTicketCalculationDetailDto> postTicketDetailDto);
    }
}
