using System;
using Mahzan.DataAccess.DTO._Base;

namespace Mahzan.DataAccess.DTO.Groups
{
    public class DeleteGroupsDto:BaseDto
    {
        public Guid GroupsId { get; set; }

        public bool? Active { get; set; }
    }
}
