using System;
using Mahzan.DataAccess.DTO._Base;

namespace Mahzan.DataAccess.DTO.Groups
{
    public class GetGroupsDto:BaseDto
    {
        public Guid? GroupsId { get; set; }
        public string Name { get; set; }
        public bool? Active { get; set; }
    }
}
