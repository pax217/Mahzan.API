using Mahzan.Business.Exceptions.Clients;
using Mahzan.Business.Interfaces.Validations.Clients;
using Mahzan.Dapper.DTO.Clients;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Mahzan.Business.Implementations.Validations.Clients
{
    public class AddClientValidations : IAddClientValidations
    {
        /// <summary>
        /// Valida información del cliente antes de Insertar.
        /// </summary>
        /// <param name="insertClientDto"></param>
        public void AddClientInfoValid(InsertClientDto insertClientDto)
        {
            if (!RFCValid(insertClientDto.RFC))
            {
                throw new ClientArgumentException($"El RFC {insertClientDto.RFC} del Cliente no es un RFC valido.");
            }

            if (!BusinessNameValid(insertClientDto.BusinessName))
            {
                throw new ClientArgumentException($"La Razón Social {insertClientDto.BusinessName} del Cliente es requerida.");

            }
        }

        /// <summary>
        /// Indica si es un RFC válido.
        /// </summary>
        /// <param name="RFC"></param>
        /// <returns></returns>
        private bool RFCValid(string RFC) 
        {
            return Regex.IsMatch(RFC,
                                 @"^([A-Z\s]{4})\d{6}([A-Z\w]{3})$",
                                 RegexOptions.IgnoreCase);


        }

        private bool BusinessNameValid(string businessName) 
        {
            return businessName == null ? false : true;
        }

    }
}
