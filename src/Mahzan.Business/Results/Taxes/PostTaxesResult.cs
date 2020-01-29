using System;
using System.Collections.Generic;
using Mahzan.Business.Results._Base;

namespace Mahzan.Business.Results.Taxes
{
    public class PostTaxesResult:Result
    {
        public List<Models.Entities.Taxes_Stores> Taxes_Stores { get; set; }
    }
}
