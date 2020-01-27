using System;
using System.Linq;
using System.Threading.Tasks;
using Mahzan.Business.Enums.Result;
using Mahzan.Business.Interfaces.Validations.Clients;
using Mahzan.Business.Resources.Validations.Clients;
using Mahzan.Business.Results.Clients;
using Mahzan.DataAccess.DTO.Clients;
using Mahzan.DataAccess.Interfaces;
using Mahzan.DataAccess.Paging;

namespace Mahzan.Business.Implementations.Validations.Clients
{
    public class AddClientsValidations : IAddClientsValidations
    {
        readonly IClientsRepository _clientsRepository;


        public AddClientsValidations(IClientsRepository clientsRepository)
        {
            _clientsRepository = clientsRepository;
        }

        public async Task<PostClientsResult> AddClientsValid(AddClientsDto addClientsDto)
        {
            PostClientsResult result = new PostClientsResult()
            {
                IsValid = true,
                StatusCode = 200,
                ResultTypeEnum = ResultTypeEnum.SUCCESS,
                Title = AddClietsValidationsResources.ResourceManager.GetString("Add_Valid_Title"),
                Message = AddClietsValidationsResources.ResourceManager.GetString("Add_Valid_200_SUCCESS_Message")
            };

            //Valid Name
            PagedList<Models.Entities.Clients> clients = _clientsRepository.Get(new GetClientsDto
            {
                MembersId = addClientsDto.MembersId,
                Name = addClientsDto.Name
            });

            if (clients.Any())
            {
                result.IsValid = false;
                result.StatusCode = 500;
                result.ResultTypeEnum = ResultTypeEnum.WARNING;
                result.Message = AddClietsValidationsResources.ResourceManager.GetString("Add_Valid_500_WARNING_Message_Name");

                return result;
            }

            return result;
        }
    }
}
