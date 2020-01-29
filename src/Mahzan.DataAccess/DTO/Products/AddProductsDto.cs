using System;
using System.Collections.Generic;
using Mahzan.DataAccess.DTO._Base;
using Mahzan.DataAccess.DTO.ProductsStore;

namespace Mahzan.DataAccess.DTO.Products
{
    public class AddProductsDto: BaseDto 
    {
        public string SKU { get; set; }

        public string Barcode { get; set; }

        public string Description { get; set; }

        public decimal? Price { get; set; }

        public decimal? Cost { get; set; }

        public bool FollowInventory { get; set; }

        public bool AvailableInAllStores { get; set; }

        public List<Guid> TaxesIds { get; set; }

        public List<AddProductsStoreDto> AddProductsStoreDto { get; set; }
        
        public Guid? ProductCategoriesId { get; set; }

        public Guid ProductUnitsId { get; set; }
    }


}
