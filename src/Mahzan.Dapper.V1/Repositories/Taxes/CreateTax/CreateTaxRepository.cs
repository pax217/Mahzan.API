using Dapper;
using Mahzan.Dapper.DTO.Taxes;
using Mahzan.Dapper.Rules.Taxes.CreateTax;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace Mahzan.Dapper.Repositories.Taxes.CreateTax
{
    public class CreateTaxRepository : DataConnection, ICreateTaxRepository
    {
        private readonly ICreateTaxRules _createTaxRules;

        public CreateTaxRepository(
            IDbConnection dbConnection,
            ICreateTaxRules createTaxRules) : base(dbConnection)
        {
            _createTaxRules = createTaxRules;
        }

        public async Task Handle(CreateTaxDto createTaxDto)
        {
            //Rules
            await _createTaxRules.Handle(createTaxDto);

            //Create Tax
            StringBuilder commandInsertText = new StringBuilder();
            commandInsertText.Append("INSERT INTO Taxes ");
            commandInsertText.Append("(");
            commandInsertText.Append("Type,");
            commandInsertText.Append("Name,");
            commandInsertText.Append("TaxRateVariable,");
            commandInsertText.Append("TaxRatePercentage,");
            commandInsertText.Append("Active,");
            commandInsertText.Append("Printed,");
            commandInsertText.Append("MembersId");
            commandInsertText.Append(") ");
            commandInsertText.Append("OUTPUT Inserted.TaxesId ");
            commandInsertText.Append("VALUES ");
            commandInsertText.Append("(");
            commandInsertText.Append("@Type,");
            commandInsertText.Append("@Name,");
            commandInsertText.Append("@TaxRateVariable,");
            commandInsertText.Append("@TaxRatePercentage,");
            commandInsertText.Append("@Active,");
            commandInsertText.Append("@Printed,");
            commandInsertText.Append("@MembersId");
            commandInsertText.Append("); ");



            int rowsAffected = await Connection
                       .ExecuteAsync
                       (commandInsertText.ToString(),
                       new
                       {
                           Name = createTaxDto.Name,
                           Type = createTaxDto.Type.ToString(),
                           TaxRateVariable = createTaxDto.TaxRateVariable,
                           TaxRatePercentage = createTaxDto.TaxRatePercentage,
                           Active = createTaxDto.Active,
                           Printed = createTaxDto.Printed,
                           MembersId = createTaxDto.MembersId
                       });
        }
    }
}
