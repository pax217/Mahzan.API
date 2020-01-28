using System;
using Mahzan.Business.Results._Base;

namespace Mahzan.Business.Results.Groups
{
    public class AddGroupsResult:Result
    {
        public Models.Entities.Groups Group { get; set; }
    }
}
