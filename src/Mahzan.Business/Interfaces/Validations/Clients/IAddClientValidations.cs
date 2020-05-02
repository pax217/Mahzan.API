using Mahzan.Dapper.DTO.Clients;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Mahzan.Business.Interfaces.Validations.Clients
{
    public interface IAddClientValidations
    {
       void AddClientInfoValid(InsertClientDto insertClientDto);
    }
}
