using System;
using System.Threading.Tasks;
using AutoMapper;
using Mahzan.Business.Enums.Result;
using Mahzan.Business.Interfaces.Business.Clients;
using Mahzan.Business.Interfaces.Validations.Clients;
using Mahzan.Business.Requests.Clients;
using Mahzan.Business.Resources.Business.Clients;
using Mahzan.Business.Resources.Business.Groups;
using Mahzan.Business.Results.Clients;
using Mahzan.Dapper.V1.DTO.Clients;
using Mahzan.Dapper.V1.Interfaces.Clients;
using Mahzan.DataAccess.DTO.Clients;
using Mahzan.DataAccess.Interfaces;

namespace Mahzan.Business.Implementations.Business.Clients
{
    public class ClientsBusiness : IClientsBusiness
    {
        private readonly IClientsDapper _clientsDapper;

        private readonly IMapper _mapper;

        readonly IAddClientsValidations _addClientsValidations;

        readonly IClientsRepository _clientsRepository;

        public ClientsBusiness(
            IClientsDapper clientsDapper,
            IAddClientsValidations addClientsValidations,
            IClientsRepository clientsRepository,
            IMapper mapper)
        {
            //Dapper
            _clientsDapper = clientsDapper;

            //Validaciones
            _addClientsValidations = addClientsValidations;

            //Repository
            _clientsRepository = clientsRepository;

            //Mapper
            _mapper = mapper;
        }


        public async Task<PostClientsResult> Add(InsertClientDto insertClientDto)
        {
            PostClientsResult result = new PostClientsResult()
            {
                IsValid = true,
                StatusCode = 200,
                ResultTypeEnum = ResultTypeEnum.SUCCESS,
                Title = AddClientsResources.ResourceManager.GetString("Add_Title"),
                Message = AddClientsResources.ResourceManager.GetString("Add_200_SUCCESS_Message")
            };



            //Agrega el Cliente
            result.ClientsId = await _clientsDapper
                                     .InsertAsync(insertClientDto);

            return result;
        }

        public Task<DeleteClientsResult> Delete(DeleteClientDto deleteClientsDto)
        {
            throw new NotImplementedException();
        }

        public Task<GetClientsResult> Get(Dapper.V1.DTO.Clients.GetClientsDto getClientsDto)
        {
            throw new NotImplementedException();
        }

        public Task<PutClientsResult> Update(UpdateClientDto updateClientDto)
        {
            throw new NotImplementedException();
        }
    }
}
