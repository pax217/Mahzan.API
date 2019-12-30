using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mahzan.Business.Enums.Result;
using Mahzan.Business.Interfaces.Business;
using Mahzan.Business.Interfaces.Validations.Miembros;
using Mahzan.Business.Resources.Business.Miembros;
using Mahzan.Business.Results.Miembros;
using Mahzan.DataAccess.DTO.Miembros;
using Mahzan.DataAccess.Interfaces;
using Mahzan.Models.Entities;

namespace Mahzan.Business.Implementations.Business
{
    public class MiembrosBusiness: IMiembrosBusiness
    {
        readonly IMembersRepository _membersRepository;

        readonly IAddMiembrosValidations _addMiembrosValidations;

        public MiembrosBusiness(
            IMembersRepository miembrosRepository,
            IAddMiembrosValidations addValidations
            )
        {
            _membersRepository = miembrosRepository;
            _addMiembrosValidations = addValidations;
        }


        public Guid Get(string userName)
        {
            Guid result = Guid.Empty;

            List<Members> miembroExistente = _membersRepository
                                               .ObtienePorFiltro(
                                                    x => x.UserName
                                                          .Equals(userName)
                                               );

            if (miembroExistente != null)
                result = miembroExistente.FirstOrDefault().Id;


            return result;
        }

        public async Task<AddMiembroResult> Add(AddMiembrosDto addMiembrosDto)
        {
            AddMiembroResult result = new AddMiembroResult()
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
                AddMiembroResult AddMiembroValidResult = await _addMiembrosValidations
                                                                .AddMiembroValid(addMiembrosDto);

                if (!AddMiembroValidResult.IsValid)
                {
                    return AddMiembroValidResult;
                }


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
