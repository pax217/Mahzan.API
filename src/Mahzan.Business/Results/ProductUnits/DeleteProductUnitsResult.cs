using System;
using Mahzan.Business.Results._Base;

namespace Mahzan.Business.Results.ProductUnits
{
    public class DeleteProductUnitsResult:Result
    {
        public Models.Entities.ProductUnits ProductUnits { get; set; }
    }
}
