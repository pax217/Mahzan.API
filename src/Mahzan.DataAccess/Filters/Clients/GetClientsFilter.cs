using System;
namespace Mahzan.DataAccess.Filters.Clients
{
    public class GetClientsFilter
    {
        public Guid? ClientsId { get; set; }

        public string RFC { get; set; }

        public string BusinessName { get; set; }
    }
}
