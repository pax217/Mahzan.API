using System;
using System.ComponentModel.DataAnnotations;
using Mahzan.DataAccess.Filters._Base;

namespace Mahzan.DataAccess.Filters.Menu
{
    public class GetMenuFilter: FilterBase
    {
        [Required]
        public Guid RoleId { get; set; }
    }
}
