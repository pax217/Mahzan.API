using System;
using Mahzan.DataAccess.Filters._Base;

namespace Mahzan.DataAccess.Filters.Groups
{
    public class GetGroupFilter:FilterBase
    {
        public Guid GroupId { get; set; }
        public Guid MemberId { get; set; }
        public string Name { get; set; }
    }
}
