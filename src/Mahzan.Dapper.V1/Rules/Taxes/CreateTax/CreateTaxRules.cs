using Dapper;
using Mahzan.Dapper.DTO.Taxes;
using Mahzan.Dapper.Exceptions.Taxes.CreateTax;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mahzan.Dapper.Rules.Taxes.CreateTax
{
    public class CreateTaxRules : DataConnection, ICreateTaxRules
    {
        public CreateTaxRules(
            IDbConnection dbConnection) 
            : base(dbConnection)
        {
        }

        public async Task Handle(CreateTaxDto createTaxDto)
        {
            //Valida que el nombre del impuesto no exista.
            if (await TaxNameExist(createTaxDto))
            {
                throw new CreateTaxArgumentException($"El impuesto con el nombre {createTaxDto.Name} ya existe.");
            }
        }

        public async Task<bool> TaxNameExist(CreateTaxDto createTaxDto) 
        {
            bool result = false;

            StringBuilder commandSelectText = new StringBuilder();

            //Valida que el Impuesto no exista
            commandSelectText.Append("SELECT * FROM Taxes ");
            commandSelectText.Append("WHERE MembersId = @MembersId ");
            commandSelectText.Append("AND Name = @Name");

            IEnumerable<Models.Entities.Taxes> taxes;
            taxes = await Connection
                            .QueryAsync<Models.Entities.Taxes>
                            (commandSelectText.ToString(),
                            new
                            {
                                Name = createTaxDto.Name,
                                MembersId = createTaxDto.MembersId
                            });

            if (taxes.Any())
            {
                result = true;
            }

            return result;
        }
    }
}
