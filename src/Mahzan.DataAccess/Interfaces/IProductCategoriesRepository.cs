﻿using System;
using System.Threading.Tasks;
using Mahzan.DataAccess.DTO.ProductCategories;
using Mahzan.Models.Entities;

namespace Mahzan.DataAccess.Interfaces
{
    public interface IProductCategoriesRepository:IRepositoryBase<ProductCategories>
    {
        Task<ProductCategories> Add(AddProductCategoriesDto addProductCategoriesDto);
    }
}
