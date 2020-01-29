using System;
using System.Collections.Generic;
using Mahzan.DataAccess.DTO._Base;

namespace Mahzan.DataAccess.DTO.TaxesStores
{
    public class AddTaxesStoresDto:BaseDto
    {
        public Guid TaxesId { get; set; }

        public List<Guid> StoresIds { get; set; }
    }
}
