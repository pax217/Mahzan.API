using Mahzan.DataAccess.DTO.Products;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Mahzan.Business.Interfaces.Business.Products.Add
{
    public interface IGetProductCommercialMaginService
    {
        AddProductsDto GetCommercialMargin(AddProductsDto addProductsDto);
    }
}
