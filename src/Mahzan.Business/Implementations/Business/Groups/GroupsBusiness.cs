using System;
using System.Threading.Tasks;
using AutoMapper;
using Mahzan.Business.Enums.Result;
using Mahzan.Business.Interfaces.Business.Groups;
using Mahzan.Business.Resources.Business.Groups;
using Mahzan.Business.Results.Groups;
using Mahzan.DataAccess.DTO.Groups;
using Mahzan.DataAccess.Interfaces;

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
    }
}
