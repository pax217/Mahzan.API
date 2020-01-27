using System;
namespace Mahzan.Business.Requests.Clients
{
    public class PostClientsRequest
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Notes { get; set; }
    }
}
