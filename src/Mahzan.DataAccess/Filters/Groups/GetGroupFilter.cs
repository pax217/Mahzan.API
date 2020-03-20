using System;
using Mahzan.DataAccess.Filters._Base;

namespace Mahzan.DataAccess.Filters.Groups
{
    public class GetGroupFilter:FilterBase
    {
        public Guid? GroupsId { get; set; }
        public string Name { get; set; }
        public bool? Active { get; set; }
    }
}
