using System;
using System.ComponentModel.DataAnnotations;
using Mahzan.Business.Requests._Base;

namespace Mahzan.Business.Requests.Groups{
    public class AddGroupsRequest
    {
        [Required]
        public string Name { get; set; }
    }
}
