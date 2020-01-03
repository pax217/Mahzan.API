using System;
using System.ComponentModel.DataAnnotations;
using Mahzan.DataAccess.DTO._Base;

namespace Mahzan.DataAccess.DTO.Groups
{
    public class PutGroupsDto:BaseDto
    {
        [Required]
        public Guid GroupId { get; set; }

        public string Name { get; set; }

        public bool? Active { get; set; }
    }
}
