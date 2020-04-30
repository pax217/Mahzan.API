using Dapper;
using Mahzan.Dapper.V1.DTO.Clients;
using Mahzan.Dapper.V1.Interfaces.Clients;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace Mahzan.Dapper.V1.Implementations.Clients
{
    public class ClientsDapper: DataConnection,IClientsDapper
    {
        public ClientsDapper(IDbConnection dbConnection)
            : base(dbConnection) 
        {
        
        }

        public async Task<Guid> InsertAsync(InsertClientDto insertClientDto)
        {
            StringBuilder commandText = new StringBuilder();
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
    }
}
