using System;
using System.Collections.Generic;
using Mahzan.DataAccess.DTO.TaxesStores;
using Mahzan.DataAccess.Interfaces;
using Mahzan.Models;
using Mahzan.Models.Entities;

namespace Mahzan.DataAccess.Implementations
{
    public class TaxesStoresRepository: RepositoryBase<Taxes_Stores>, ITaxesStoresRepository
    {
        public TaxesStoresRepository(MahzanDbContext repositoryContext)
            : base(repositoryContext)
        {
        }

        public List<Taxes_Stores> Add(AddTaxesStoresDto addTaxesStoresDto)
        {
            List<Taxes_Stores> taxes_Stores = new List<Taxes_Stores>();

            foreach (var storeId in addTaxesStoresDto.StoresIds)
            {
                Taxes_Stores newTax_Store = new Taxes_Stores
                {
                    TaxesId = addTaxesStoresDto.TaxesId,
                    StoresId = storeId,
                    MembersId = addTaxesStoresDto.MembersId
                };

                _context.Set<Taxes_Stores>().Add(newTax_Store);
                _context.SaveChangesAsync();

                taxes_Stores.Add(newTax_Store);
            }

            return taxes_Stores;
        }
    }
}
