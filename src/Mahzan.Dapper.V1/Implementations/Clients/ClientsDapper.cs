using Dapper;
using Mahzan.Dapper.DTO.Clients;
using Mahzan.Dapper.Exceptions.Clients;
using Mahzan.Dapper.Filters.Clients;
using Mahzan.Dapper.Interfaces.Clients;
using Mahzan.Dapper.Paging;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mahzan.Dapper.Implementations.Clients
{
    public class ClientsDapper: DataConnection,IClientsDapper
    {
        public ClientsDapper(IDbConnection dbConnection)
            : base(dbConnection) 
        {
        
        }

        public async Task DeleteAsync(Guid clientsId)
        {
            StringBuilder commandSelectText = new StringBuilder();

            //Valida que el Cliente no exista
            commandSelectText.Append("SELECT * FROM Clients ");
            commandSelectText.Append("WHERE ClientsId = @ClientsId ");

            IEnumerable<Models.Entities.Clients> clients;
            clients = await Connection
                            .QueryAsync<Models.Entities.Clients>
                            (commandSelectText.ToString(),
                            new
                            {
                                ClientsId = clientsId
                            });

            if (clients.Count() > 0)
            {
                throw new ClientArgumentDataException($"El cliente con ID {clientsId} no existe.");
            }


            StringBuilder commandDeleteText = new StringBuilder();
            commandDeleteText.Append("DELETE Clients ");
            commandSelectText.Append("WHERE ClientsId = @ClientsId ");

            await Connection
                  .ExecuteAsync(
                  commandSelectText.ToString(),
                  new
                  {
                      ClientsId = clientsId
                  });
        }

        public async Task<PagedList<Models.Entities.Clients>> GetWhereAsync(GetClientsDto getClientsDto)
        {

            //SQL
            StringBuilder commandText = new StringBuilder();
            commandText.Append("SELECT * FROM Clients ");
            commandText.Append("WHERE  1= 1 ");

            //Parameters
            DynamicParameters parameters = new DynamicParameters();

            //MembersId
            if (getClientsDto.MembersId!=null)
            {
                commandText.Append("AND MembersId = @MembersId ");
                parameters.Add("@MembersId", getClientsDto.MembersId, DbType.Guid);
            }

            //RFC
            if (getClientsDto.RFC != null)
            {
                commandText.Append("AND RFC = @RFC ");
                parameters.Add("@RFC", getClientsDto.RFC, DbType.String);
            }

            IEnumerable<Models.Entities.Clients> clients;
            clients = await Connection
                            .QueryAsync<Models.Entities.Clients>
                            (commandText.ToString(),
                            parameters);

            return PagedList<Models.Entities.Clients>
                   .ToPagedList
                   (clients,
                   getClientsDto.PageNumber,
                   getClientsDto.PageSize);
        }

        public async Task<Models.Entities.Clients> GetById(Guid clientsId)
        {
            StringBuilder commandSelectText = new StringBuilder();

            //Valida que el Cliente no exista
            commandSelectText.Append("SELECT * FROM Clients ");
            commandSelectText.Append("WHERE ClientsId = @ClientsId ");

            IEnumerable<Models.Entities.Clients> clients;
            clients = await Connection
                            .QueryAsync<Models.Entities.Clients>
                            (commandSelectText.ToString(),
                            new
                            {
                                ClientsId = clientsId
                            });

            return clients.FirstOrDefault();
        }

        public async Task<Guid> InsertAsync(InsertClientDto insertClientDto)
        {
            StringBuilder commandText = new StringBuilder();

            //Valida que el Cliente no exista
            commandText.Append("SELECT * FROM Clients ");
            commandText.Append("WHERE MembersId = @MembersId ");
            commandText.Append("AND RFC = @RFC");

            IEnumerable<Models.Entities.Clients> clients;
            clients = await Connection
                            .QueryAsync<Models.Entities.Clients>
                            (commandText.ToString(),
                            new
                            {
                                MembersId = insertClientDto.MembersId,
                                RFC = insertClientDto.RFC
                            });

            if (clients.Count()>0)
            {
                throw new ClientArgumentDataException($"El cliente con RFC {insertClientDto.RFC} ya existe.");
            }

            commandText.Clear();

            commandText.Append("INSERT INTO Clients ");
            commandText.Append("(");
            commandText.Append("RFC,");
            commandText.Append("CommercialName,");
            commandText.Append("BusinessName,");
            commandText.Append("Phone,");
            commandText.Append("Notes,");
            commandText.Append("MembersId");
            commandText.Append(") ");
            commandText.Append("VALUES ");
            commandText.Append("(");
            commandText.Append("@RFC,");
            commandText.Append("@CommercialName,");
            commandText.Append("@BusinessName,");
            commandText.Append("@Phone,");
            commandText.Append("@Notes,");
            commandText.Append("@MembersId");
            commandText.Append(") ");

            Guid clientsId = await Connection
                                   .ExecuteScalarAsync<Guid>
                                   (commandText.ToString(),
                                   new
                                   {
                                       RFC = insertClientDto.RFC,
                                       CommercialName = insertClientDto.CommercialName,
                                       BusinessName = insertClientDto.BusinessName,
                                       Phone = insertClientDto.Phone,
                                       Notes = insertClientDto.Notes,
                                       MembersId = insertClientDto.MembersId
                                   });

            return clientsId;
        }

        public async Task UpdateAsync(UpdateClientDto updateClientDto)
        {
            int rowsAffected;

            try
            {
                Models.Entities.Clients client = await GetById(updateClientDto.ClientsId);

                if (client ==null)
                {
                    throw new ClientArgumentDataException($"El cliente con ID {updateClientDto.ClientsId} no existe.");
                }

                //RFC
                if (updateClientDto.RFC !=null)
                {
                    client.RFC = updateClientDto.RFC;
                }

                //CommercialName
                if (updateClientDto.CommercialName != null)
                {
                    client.CommercialName = updateClientDto.CommercialName;
                }

                //BusinessName
                if (updateClientDto.BusinessName != null)
                {
                    client.BusinessName = updateClientDto.BusinessName;
                }

                //Email
                if (updateClientDto.Email != null)
                {
                    client.Email = updateClientDto.Email;
                }

                //Phone
                if (updateClientDto.Phone != null)
                {
                    client.Phone = updateClientDto.Phone;
                }

                //Email
                if (updateClientDto.Notes != null)
                {
                    client.Notes = updateClientDto.Notes;
                }

                StringBuilder commandUpdateText = new StringBuilder();
                commandUpdateText.Append("UPDATE Clients ");
                commandUpdateText.Append("SET  ");
                commandUpdateText.Append("RFC=@RFC,");
                commandUpdateText.Append("CommercialName=@CommercialName,");
                commandUpdateText.Append("BusinessName=@BusinessName,");
                commandUpdateText.Append("Email=@Email,");
                commandUpdateText.Append("Phone=@Phone,");
                commandUpdateText.Append("Notes=@Notes ");
                commandUpdateText.Append("WHERE ClientsId = @ClientsId ");

                rowsAffected = await Connection
                                     .ExecuteAsync(
                                     commandUpdateText.ToString(),
                                     new {
                                         RFC = updateClientDto.RFC,
                                         CommercialName = updateClientDto.CommercialName,
                                         BusinessName = updateClientDto.BusinessName,
                                         Email = updateClientDto.Email,
                                         Phone = updateClientDto.Phone,
                                         Notes = updateClientDto.Notes,
                                         ClientsId = updateClientDto.ClientsId,
                                     });

                if (rowsAffected == 1)
                {
                    return;
                }
                else 
                {
                    throw new Exception("No fue posible actualizar la información del Cliente.");
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
