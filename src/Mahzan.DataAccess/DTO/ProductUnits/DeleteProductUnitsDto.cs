using System;
using Mahzan.DataAccess.DTO._Base;

namespace Mahzan.DataAccess.DTO.ProductUnits
{
    public class DeleteProductUnitsDto:BaseDto
    {
        public Guid ProductUnitsId { get; set; }
    }
}
