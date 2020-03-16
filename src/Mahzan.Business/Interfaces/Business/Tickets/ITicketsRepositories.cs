﻿using Mahzan.DataAccess.DTO.ProductsTaxes;
using Mahzan.DataAccess.DTO.Tickets;
using Mahzan.DataAccess.Paging;
using Mahzan.Models.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Mahzan.Business.Interfaces.Business.Tickets
{
    public interface ITicketsRepositories
    {
        Task<Models.Entities.Tickets> AddTicket(AddTicketsDto addTicketsDto);

        Task<PagedList<ProductsTaxes>> GetProductsTaxes(GetProductsTaxesDto getProductsTaxesDto);

        Task<List<TicketDetail>> AddTicketDetail(Models.Entities.Tickets newTicket,
                                                 List<PostTicketDetailDto> postTicketDetailDto);
    }
}
