using System;
using System.Collections.Generic;
using Mahzan.DataAccess.DTO.TaxesStores;
using Mahzan.Models.Entities;

namespace Mahzan.DataAccess.Interfaces
{
    public interface ITaxesStoresRepository: IRepositoryBase<Taxes_Stores>
    {
        List<Taxes_Stores> Add(AddTaxesStoresDto addTaxesStoresDto);
    }
}
