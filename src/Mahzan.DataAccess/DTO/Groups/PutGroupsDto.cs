using System;
using System.ComponentModel.DataAnnotations;
using Mahzan.DataAccess.DTO._Base;

namespace Mahzan.DataAccess.DTO.Groups
{
    public class PutGroupsDto:BaseDto
    {
        [Required]
        public Guid GroupsId { get; set; }

        public string Code { get; set; }

        public string Name { get; set; }

        public string Phone { get; set; }

        public string Comment { get; set; }

        public bool? Active { get; set; }
    }
}
