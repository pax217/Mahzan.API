using Mahzan.Business.Events.Taxes.CreateTax;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Mahzan.Business.EventsHandlers.Taxes.CreateTax
{
    public interface ICreateTaxEventHandler
    {
        Task Handle(CreateTaxEvent createTaxEvent);
    }
}
