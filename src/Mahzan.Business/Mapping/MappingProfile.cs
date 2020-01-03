using AutoMapper;
using Mahzan.DataAccess.DTO.Groups;
using Mahzan.DataAccess.DTO.Members;
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
        }
    }
}
