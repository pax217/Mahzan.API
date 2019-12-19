using System;
using System.Runtime.Serialization;

namespace Mahzan.Business.Requests._Base
{
    public class BaseRequest
    {
        [IgnoreDataMember]
        public Guid MiembroId { get; set; }
    }
}
