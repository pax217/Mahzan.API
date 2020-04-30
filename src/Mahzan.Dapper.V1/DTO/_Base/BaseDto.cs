using Mahzan.Models.Enums.Audit;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mahzan.Dapper.V1.DTO._Base
{
    public class BaseDto
    {
        public Guid MembersId { get; set; }
        public Guid AspNetUserId { get; set; }
        public TableAuditEnum TableAuditEnum { get; set; }
    }
}
