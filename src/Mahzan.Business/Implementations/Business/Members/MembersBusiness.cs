﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Mahzan.Business.Enums.Result;
using Mahzan.Business.Interfaces.Business;
using Mahzan.Business.Interfaces.Business.Members;
using Mahzan.Business.Interfaces.Validations.Miembros;
using Mahzan.Business.Resources.Business.Miembros;
using Mahzan.Business.Results.Members;
using Mahzan.DataAccess.DTO.Miembros;
using Mahzan.DataAccess.Interfaces;


namespace Mahzan.Business.Implementations.Business.Members
{
    public class MembersBusiness: IMembersBusiness
    {
        readonly IMembersRepository _membersRepository;

        readonly IAddMembersValidations _addMiembrosValidations;

        readonly IMapper _mapper;

        public MembersBusiness(
            IMembersRepository miembrosRepository,
            IAddMembersValidations addValidations,
            IMapper mapper
            )
        {
            _membersRepository = miembrosRepository;
            _addMiembrosValidations = addValidations;
            _mapper = mapper;
        }


        public Guid Get(string userName)
        {
            Guid result = Guid.Empty;

            List<Models.Entities.Members> miembroExistente = _membersRepository
                                                              .Get(
                                                                x => x.UserName
                                                                      .Equals(userName)
                                                              );

            if (miembroExistente != null)
                result = miembroExistente.FirstOrDefault().Id;


            return result;
        }

        public async Task<AddMembersResult> Add(AddMiembrosDto addMiembrosDto)
        {
            AddMembersResult result = new AddMembersResult()
            {
                IsValid = true,
                StatusCode =200,
                ResultTypeEnum = ResultTypeEnum.SUCCESS,
                Title = AddMiembrosResources.ResourceManager.GetString("Add_Title"),
                Message= AddMiembrosResources.ResourceManager.GetString("Add_200_SUCCESS_Message"),
            };

            try
            {
                //Valida Datos de Miembro
                AddMembersResult AddMiembroValidResult = await _addMiembrosValidations
                                                                .AddMembersValid(addMiembrosDto);

                if (!AddMiembroValidResult.IsValid)
                {
                    return AddMiembroValidResult;
                }

                //Guarda en Base de Datos
                _membersRepository
                 .Add(_mapper.Map<Models.Entities.Members>(addMiembrosDto));

            }
            catch (Exception ex)
            {
                result.IsValid = false;
                result.StatusCode = 500;
                result.ResultTypeEnum = ResultTypeEnum.ERROR;
                result.Message = ex.Message;
            }

            return result;
        }
    }
}
