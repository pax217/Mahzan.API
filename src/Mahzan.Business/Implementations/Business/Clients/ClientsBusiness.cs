using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using AutoMapper;
using Mahzan.Business.Enums.Result;
using Mahzan.Business.Exceptions.Clients;
using Mahzan.Business.Interfaces.Business.Clients;
using Mahzan.Business.Interfaces.Validations.Clients;
using Mahzan.Business.Requests.Clients;
using Mahzan.Business.Resources.Business.Clients;
using Mahzan.Business.Resources.Business.Groups;
using Mahzan.Business.Results.Clients;
using Mahzan.Dapper.DTO.Clients;
using Mahzan.Dapper.Interfaces.Clients;
using Mahzan.DataAccess.DTO.Clients;
using Mahzan.DataAccess.Interfaces;
using Microsoft.EntityFrameworkCore.Internal;

namespace Mahzan.Business.Implementations.Business.Clients
{
    public class ClientsBusiness : IClientsBusiness
    {
        private readonly IClientsDapper _clientsDapper;

        private readonly IAddClientValidations _addClientValidations;

        private readonly IMapper _mapper;

        public ClientsBusiness(
            IClientsDapper clientsDapper,
            IAddClientValidations addClientValidations,
            IMapper mapper)
        {
            //Dapper
            _clientsDapper = clientsDapper;

            //Validaciones
            _addClientValidations = addClientValidations;

            //Mapper
            _mapper = mapper;
        }


        public async Task<PostClientsResult> Add(InsertClientDto insertClientDto)
        {
            PostClientsResult result = new PostClientsResult 
            { 
                IsValid= true,
                ResultTypeEnum = ResultTypeEnum.SUCCESS,
            };

            //Valida formato de RFC
            _addClientValidations.AddClientInfoValid(insertClientDto);

            result.ClientsId = await _clientsDapper
                                     .InsertAsync(insertClientDto);

            return result;
        }

        public Task<DeleteClientsResult> Delete(DeleteClientDto deleteClientsDto)
        {
            throw new NotImplementedException();
        }

        public async Task<GetClientsResult> Get(Dapper.DTO.Clients.GetClientsDto getClientsDto)
        {
            GetClientsResult result = new GetClientsResult
            {
                IsValid = true,
                ResultTypeEnum = ResultTypeEnum.SUCCESS,
            };

            result.Clients = await _clientsDapper
                                   .GetWhereAsync(getClientsDto);

            if (!result.Clients.Any())
            {
                throw new ClientsKeyNotFoundException($"No se encontró información de Clientes");
            }

            return result;
        }


        public Task<PutClientsResult> Update(UpdateClientDto updateClientDto)
        {
            throw new NotImplementedException();
        }
    }
}
