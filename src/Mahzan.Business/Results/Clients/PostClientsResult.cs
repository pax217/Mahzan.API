using System;
using Mahzan.Business.Results._Base;

namespace Mahzan.Business.Results.Clients
{
    public class PostClientsResult:Result
    {
        public Models.Entities.Clients Clients { get; set; }
    }
}
