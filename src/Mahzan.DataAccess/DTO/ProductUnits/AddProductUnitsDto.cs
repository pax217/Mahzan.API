using System;
using Mahzan.DataAccess.DTO._Base;

namespace Mahzan.DataAccess.DTO.ProductUnits
{
    public class AddProductUnitsDto:BaseDto
    {
        public string Abbreviation { get; set; }

        public string Description { get; set; }
    }
}
