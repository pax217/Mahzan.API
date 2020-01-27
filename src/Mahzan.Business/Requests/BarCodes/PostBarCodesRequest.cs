using System;
using System.Collections.Generic;

namespace Mahzan.Business.Requests.BarCodes
{
    public class PostBarCodesRequest
    {
        public List<Guid> ProductsIds { get; set; }
    }
}
