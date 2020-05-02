using AutoMapper;
using Mahzan.Business.Requests.Products_Store;
using Mahzan.Dapper.DTO.Clients;
using Mahzan.DataAccess.DTO.Clients;
using Mahzan.DataAccess.DTO.Companies;
using Mahzan.DataAccess.DTO.Employees;
using Mahzan.DataAccess.DTO.EmployeesStores;
using Mahzan.DataAccess.DTO.Groups;
using Mahzan.DataAccess.DTO.Members;
using Mahzan.DataAccess.DTO.PointOfSales;
using Mahzan.DataAccess.DTO.ProductCategories;
using Mahzan.DataAccess.DTO.Products;
using Mahzan.DataAccess.DTO.ProductsPhotos;
using Mahzan.DataAccess.DTO.ProductsStore;
using Mahzan.DataAccess.DTO.ProductUnits;
using Mahzan.DataAccess.DTO.Stores;
using Mahzan.DataAccess.DTO.Tickets;
using Mahzan.Models.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mahzan.Business.Mapping
{
    public class MappingProfile: Profile
    {
        public MappingProfile() 
        {
            //Clients
            CreateMap<AddClientsDto, InsertClientDto>();

            #region Members
            CreateMap<AddMembersDto, Members>();
            #endregion

            #region Groups
            CreateMap<AddGroupsDto, Groups>();
            CreateMap<PutGroupsDto, Groups>();
            #endregion

            #region Groups
            CreateMap<AddCompaniesDto, Companies>();
            #endregion

            #region Groups
            CreateMap<AddStoresDto, Stores>();
            #endregion

            #region Employees
            CreateMap<AddEmployeesDto, Employees>();
            #endregion

            #region Points Of Sales
            CreateMap<AddPointsOfSalesDto, PointsOfSales>();
            #endregion

            #region Employees of Stores
            CreateMap<AddEmployeesStoresDto, Employees_Stores>();
            #endregion

            #region Products Categories
            CreateMap<AddProductCategoriesDto, ProductCategories>();
            #endregion

            #region Products Units
            CreateMap<AddProductUnitsDto, ProductUnits>();
            #endregion


            #region Products
            //CreateMap<AddProductsDto, Products>()
            //    .ForMember(dest => dest.MembersId,
            //               opt => opt.MapFrom(src => src.MembersId))
            //    .ForMember(dest => dest.ProductCategoriesId,
            //               opt => opt.MapFrom(src => src.ProductCategoriesId))
            //    .ForMember(dest => dest.ProductUnitsId,
            //               opt => opt.MapFrom(src => src.ProductUnitsId));
            #endregion

            #region Products Units
            CreateMap<AddProductsStoreDto, Products_Store>();
            #endregion


            #region Products Photos
            CreateMap<AddProductsPhotosDto,ProductsPhotos>();
            #endregion

            #region Tickets
            CreateMap<TicketCalculationDto, Tickets>();
            #endregion
        }
    }
}
