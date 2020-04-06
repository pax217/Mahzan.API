using Mahzan.Business.Results._Base;
using Mahzan.DataAccess.Paging;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mahzan.Business.Results.PaymentTypes
{
    public class GetPaymentTypesResult:Result
    {
        public PagedList<Models.Entities.PaymentTypes> PaymentTypes { get; set; }
        public Paging Paging { get; set; }
    }
}
