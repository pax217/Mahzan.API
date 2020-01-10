using AutoMapper;
using Mahzan.DataAccess.DTO.Companies;
using Mahzan.DataAccess.DTO.Employees;
using Mahzan.DataAccess.DTO.Groups;
using Mahzan.DataAccess.DTO.Members;
using Mahzan.DataAccess.DTO.PointOfSales;
using Mahzan.DataAccess.DTO.Stores;
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
            #region Members
            CreateMap<AddMembersDto, Members>();
            #endregion

            #region Groups
            CreateMap<AddGroupsDto, Groups>();
            CreateMap<PutGroupsDto, Groups>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.GroupId));
            #endregion

            #region Groups
            CreateMap<AddCompaniesDto, Companies>()
                .ForMember(dest => dest.GroupId,
                           opt => opt.MapFrom(src =>src.GrupoId));
            #endregion

            #region Groups
            CreateMap<AddStoresDto, Stores>()
                .ForMember(dest => dest.CompanyId,
                           opt => opt.MapFrom(src => src.CompanyId));
            #endregion

            #region Employees
            CreateMap<AddEmployeesDto, Employees>();
            #endregion

            #region Points Of Sales
            CreateMap<AddPointsOfSalesDto, PointsOfSales>()
                 .ForMember(dest => dest.StoreId,
                            opt => opt.MapFrom(src => src.StoreId)); ;
            #endregion
        }
    }
}
