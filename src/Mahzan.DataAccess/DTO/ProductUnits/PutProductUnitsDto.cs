using System;
using Mahzan.DataAccess.DTO._Base;

namespace Mahzan.DataAccess.DTO.ProductUnits
{
    public class PutProductUnitsDto:BaseDto
    {
        public Guid ProductUnitsId { get; set; }

        public string Abbreviation { get; set; }

        public string Description { get; set; }
    }
}
