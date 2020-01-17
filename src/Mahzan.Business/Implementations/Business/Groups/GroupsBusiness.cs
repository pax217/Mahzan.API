using System;
using System.Threading.Tasks;
using AutoMapper;
using Mahzan.Business.Enums.Result;
using Mahzan.DataAccess.Filters.Groups;
using Mahzan.Business.Interfaces.Business.Groups;
using Mahzan.Business.Resources.Business.Groups;
using Mahzan.Business.Results.Groups;
using Mahzan.DataAccess.DTO.Groups;
using Mahzan.DataAccess.Interfaces;
using System.Linq;
using System.Collections.Generic;

namespace Mahzan.Business.Implementations.Business.Groups
{
    public class GroupsBusiness: IGroupsBusiness
    {

        readonly IGroupsRepository _groupsRepository;

        readonly IMapper _mapper;

        public GroupsBusiness(
            IGroupsRepository groupsRepository,
            IMapper mapper)
        {

            _groupsRepository = groupsRepository;
            _mapper = mapper;

        }

        public async Task<AddGroupsResult> Add(AddGroupsDto addGroupsDto)
        {
            AddGroupsResult result = new AddGroupsResult()
            {
                IsValid = true,
                StatusCode = 200,
                ResultTypeEnum = ResultTypeEnum.SUCCESS,
                Title = AddGroupsResources.ResourceManager.GetString("Add_Title"),
                Message = AddGroupsResources.ResourceManager.GetString("Add_200_SUCCESS_Message")
            };

            try
            {
                //Valida la información del grupo a agregar

                //Agrega Grupo
                _groupsRepository
                    .Add(_mapper.Map<Models.Entities.Groups>(addGroupsDto),
                         addGroupsDto.AspNetUserId,
                         addGroupsDto.TableAuditEnum);


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

        public async Task<GetGroupsResult> Get(GetGroupsDto getGroupsDto)
        {
            GetGroupsResult result = new GetGroupsResult()
            {
                IsValid = true,
                StatusCode = 200,
                ResultTypeEnum = ResultTypeEnum.SUCCESS,
                Title = GetGroupsResources.ResourceManager.GetString("Get_Title"),
                Message = GetGroupsResources.ResourceManager.GetString("Get_200_SUCCESS_Message")
            };

            try
            {

                result.Groups = _groupsRepository
                                .Get(getGroupsDto);

                if (!result.Groups.Any())
                {
                    result.ResultTypeEnum = ResultTypeEnum.INFO;
                    result.Message = GetGroupsResources.ResourceManager.GetString("Get_200_INFO_Message");

                    return result;
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

        public async Task<PutGroupsResult> Put(PutGroupsDto putGroupsDto)
        {
            PutGroupsResult result = new PutGroupsResult()
            {
                IsValid = true,
                StatusCode = 200,
                ResultTypeEnum = ResultTypeEnum.SUCCESS,
                Title = PutGroupsResources.ResourceManager.GetString("Put_Title"),
                Message = PutGroupsResources.ResourceManager.GetString("Put_200_SUCCESS_Message")
            };

            try
            {
                //Validaciones al Actualizar

                _groupsRepository
                 .Update(putGroupsDto);
                
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

        public async Task<DeleteGroupsResult> Delete(DeleteGroupsDto deleteGroupsDto)
        {
            DeleteGroupsResult result = new DeleteGroupsResult()
            {
                IsValid = true,
                StatusCode = 200,
                ResultTypeEnum = ResultTypeEnum.SUCCESS,
                Title = DeleteGroupsResources.ResourceManager.GetString("Delete_Title"),
                Message = DeleteGroupsResources.ResourceManager.GetString("Delete_200_SUCCESS_Message")
            };

            try
            {
                //Valida información al eliminar el Grupo

                _groupsRepository
                 .Delete(deleteGroupsDto);

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
