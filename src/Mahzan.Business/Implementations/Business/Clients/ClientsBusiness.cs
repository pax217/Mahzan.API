using System;
using System.Threading.Tasks;
using Mahzan.Business.Enums.Result;
using Mahzan.Business.Interfaces.Business.Clients;
using Mahzan.Business.Interfaces.Validations.Clients;
using Mahzan.Business.Requests.Clients;
using Mahzan.Business.Resources.Business.Clients;
using Mahzan.Business.Resources.Business.Groups;
using Mahzan.Business.Results.Clients;
using Mahzan.DataAccess.DTO.Clients;
using Mahzan.DataAccess.Interfaces;

namespace Mahzan.Business.Implementations.Business.Clients
{
    public class ClientsBusiness : IClientsBusiness
    {
        readonly IAddClientsValidations _addClientsValidations;

        readonly IClientsRepository _clientsRepository;

        public ClientsBusiness(
            IAddClientsValidations addClientsValidations,
            IClientsRepository clientsRepository)
        {
            //Validaciones
            _addClientsValidations = addClientsValidations;

            //Repository
            _clientsRepository = clientsRepository;
        }

        public async Task<PostClientsResult> Add(AddClientsDto addClientsDto)
        {
            PostClientsResult result = new PostClientsResult()
            {
                IsValid = true,
                StatusCode = 200,
                ResultTypeEnum = ResultTypeEnum.SUCCESS,
                Title = AddClientsResources.ResourceManager.GetString("Add_Title"),
                Message = AddClientsResources.ResourceManager.GetString("Add_200_SUCCESS_Message")
            };

            try
            {
                //Validaciones al agregar un cliente
                PostClientsResult resulAddValidations = await _addClientsValidations.AddClientsValid(addClientsDto);

                if (!resulAddValidations.IsValid)
                {
                    return resulAddValidations;
                }

                //Agrega el Cliente
                result.Clients = await _clientsRepository.Add(addClientsDto);
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

        public Task<DeleteClientsResult> Delete(DeleteClientsDto deleteClientsDto)
        {
            throw new NotImplementedException();
        }

        public Task<GetClientsResult> Get(GetClientsDto getClientsDto)
        {
            throw new NotImplementedException();
        }

        public Task<PutClientsResult> Update(PutClientsDto putClientsDto)
        {
            throw new NotImplementedException();
        }
    }
}
