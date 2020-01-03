using System;
using System.ComponentModel.DataAnnotations;
using Mahzan.Business.Requests._Base;

namespace Mahzan.Business.Requests.Grupos
{
    public class DeleteGroupsRequest
    {
        [Required]
        public Guid GroupId { get; set; }
    }
}
