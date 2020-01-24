using System;
using Mahzan.Business.Results._Base;

namespace Mahzan.Business.Results.PaymentTypes
{
    public class PostPaymentTypesResult:Result
    {
        public Models.Entities.PaymentTypes PaymentTypes { get; set; }
    }
}
