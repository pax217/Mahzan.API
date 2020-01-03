using System;
using Mahzan.Models.Enums.Audit;

namespace Mahzan.DataAccess.DTO._Base
{
    public class BaseDto
    {
        public Guid MemberId { get; set; }
        public Guid AspNetUserId { get; set; }
        public TableAuditEnum TableAuditEnum { get; set; }
    }
}
