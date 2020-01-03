using System;
namespace Mahzan.Business.Requests.Grupos
{
    public class PutGroupsRequest
    {
        public Guid GroupId { get; set; }
        public string Name { get; set; }
        public bool? Active { get; set; }
    }
}
