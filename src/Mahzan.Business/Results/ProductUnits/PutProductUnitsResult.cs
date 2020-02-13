using System;
using Mahzan.Business.Results._Base;

namespace Mahzan.Business.Results.ProductUnits
{
    public class PutProductUnitsResult:Result
    {
        public Models.Entities.ProductUnits ProductUnits { get; set; }
    }
}
