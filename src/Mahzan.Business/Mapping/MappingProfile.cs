using AutoMapper;
using Mahzan.DataAccess.DTO.Miembros;
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
            CreateMap<AddMiembrosDto, Members>();
            #endregion
        }
    }
}
