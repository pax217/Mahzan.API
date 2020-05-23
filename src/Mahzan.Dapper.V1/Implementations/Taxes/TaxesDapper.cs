using Dapper;
using Mahzan.Dapper.DTO.Taxes;
using Mahzan.Dapper.Exceptions.Taxes;
using Mahzan.Dapper.Interfaces.Taxes;
using Mahzan.Dapper.Paging;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mahzan.Dapper.Implementations.Taxes
{
    public class TaxesDapper: DataConnection,ITaxesDapper
    {
        public TaxesDapper(IDbConnection dbConnection)
            : base(dbConnection)
        {

        }

        public async Task DeleteAsync(DeleteTaxDto insertTaxDto)
        {
            StringBuilder commandSelectText = new StringBuilder();

            //Valida que el Cliente no exista
            commandSelectText.Append("SELECT * FROM Taxes ");
            commandSelectText.Append("WHERE TaxesId = @TaxesId ");

            IEnumerable<Models.Entities.Taxes> taxes;
            taxes = await Connection
                            .QueryAsync<Models.Entities.Taxes>
                            (commandSelectText.ToString(),
                            new
                            {
                                TaxesId = insertTaxDto.TaxesId
                            });

            if (taxes.Count() > 0)
            {
                throw new TaxArgumentException($"El impuesto con ID {insertTaxDto.TaxesId} no existe.");
            }


            StringBuilder commandDeleteText = new StringBuilder();
            commandDeleteText.Append("DELETE Taxes ");
            commandSelectText.Append("WHERE TaxesId = @TaxesId ");

            await Connection
                  .ExecuteAsync(
                  commandSelectText.ToString(),
                  new
                  {
                      TaxesId = insertTaxDto.TaxesId
                  });

        }

        public async Task<Models.Entities.Taxes> GetByIdAsync(Guid taxesId)
        {
            StringBuilder commandSelectText = new StringBuilder();

            //Valida que el Cliente no exista
            commandSelectText.Append("SELECT * FROM Taxes ");
            commandSelectText.Append("WHERE TaxesId = @TaxesId ");

            IEnumerable<Models.Entities.Taxes> taxes;
            taxes = await Connection
                            .QueryAsync<Models.Entities.Taxes>
                            (commandSelectText.ToString(),
                            new
                            {
                                TaxesId = taxesId
                            });

            return taxes.FirstOrDefault();
        }

        public async Task<PagedList<Models.Entities.Taxes>> GetWhereAsync(GetTaxesDto getTaxesDto)
        {
            //SQL
            StringBuilder commandText = new StringBuilder();
            commandText.Append("SELECT * FROM Taxes ");
            commandText.Append("WHERE  1= 1 ");

            //Parameters
            DynamicParameters parameters = new DynamicParameters();

            //MembersId
            if (getTaxesDto.MembersId != null)
            {
                commandText.Append("AND MembersId = @MembersId ");
                parameters.Add("@MembersId", getTaxesDto.MembersId, DbType.Guid);
            }

            //TaxesId
            if (getTaxesDto.TaxesId != null)
            {
                commandText.Append("AND TaxesId = @TaxesId ");
                parameters.Add("@TaxesId", getTaxesDto.TaxesId, DbType.Guid);
            }

            IEnumerable<Models.Entities.Taxes> taxes;
            taxes = await Connection
                            .QueryAsync<Models.Entities.Taxes>
                            (commandText.ToString(),
                            parameters);

            return PagedList<Models.Entities.Taxes>
                   .ToPagedList
                   (taxes,
                   getTaxesDto.PageNumber,
                   getTaxesDto.PageSize);
        }

        public async Task<Guid> InsertAsync(InsertTaxDto insertTaxDto)
        {
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
                                Name = insertTaxDto.Name,
                                MembersId = insertTaxDto.MembersId
                            });

            if (taxes.Any())
            {
                throw new TaxArgumentException($"El impuesto con el nombre {insertTaxDto.Name} ya existe.");
            }

            StringBuilder commandInsertText = new StringBuilder();
            commandInsertText.Append("INSERT INTO Taxes ");
            commandInsertText.Append("(");
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
            commandInsertText.Append("@Name,");
            commandInsertText.Append("@TaxRateVariable,");
            commandInsertText.Append("@TaxRatePercentage,");
            commandInsertText.Append("@Active,");
            commandInsertText.Append("@Printed,");
            commandInsertText.Append("@MembersId");
            commandInsertText.Append("); ");



            Guid clientsId = await Connection
                       .ExecuteScalarAsync<Guid>
                       (commandInsertText.ToString(),
                       new
                       {
                           Name = insertTaxDto.Name,
                           TaxRateVariable = insertTaxDto.TaxRateVariable,
                           TaxRatePercentage = insertTaxDto.TaxRatePercentage,
                           Active = insertTaxDto.Active,
                           Printed = insertTaxDto.Printed,
                           MembersId = insertTaxDto.MembersId
                       });

            return clientsId;
        }

        public async Task UpdateAsync(UpdateTaxDto updateTaxDto)
        {
            int rowsAffected;

            try
            {
                Models.Entities.Taxes tax = await GetByIdAsync(updateTaxDto.TaxesId);

                if (tax == null)
                {
                    throw new TaxArgumentException($"El Impuesto con ID {updateTaxDto.TaxesId} no existe.");
                }

                //Name
                if (updateTaxDto.Name != null)
                {
                    tax.Name = updateTaxDto.Name;
                }

                //TaxRateVariable
                if (updateTaxDto.TaxRateVariable != null)
                {
                    tax.TaxRateVariable = updateTaxDto.TaxRateVariable.Value;
                }

                //BusinessName
                if (updateTaxDto.TaxRatePercentage != null)
                {
                    tax.TaxRatePercentage = updateTaxDto.TaxRatePercentage.Value;
                }

                //Email
                if (updateTaxDto.Active != null)
                {
                    tax.Active = updateTaxDto.Active.Value;
                }

                //Phone
                if (updateTaxDto.Printed != null)
                {
                    tax.Printed = updateTaxDto.Printed.Value;
                }


                StringBuilder commandUpdateText = new StringBuilder();
                commandUpdateText.Append("UPDATE Taxes ");
                commandUpdateText.Append("SET  ");
                commandUpdateText.Append("Name=@Name,");
                commandUpdateText.Append("TaxRateVariable=@TaxRateVariable,");
                commandUpdateText.Append("TaxRatePercentage=@TaxRatePercentage,");
                commandUpdateText.Append("Active=@Active,");
                commandUpdateText.Append("Printed=@Printed,");
                commandUpdateText.Append("WHERE ClientsId = @ClientsId ");
                commandUpdateText.Append("AND MembersId = @MembersId ");

                rowsAffected = await Connection
                                     .ExecuteAsync(
                                     commandUpdateText.ToString(),
                                     new
                                     {
                                         TaxesId = updateTaxDto.TaxesId,
                                         Name = updateTaxDto.Name,
                                         TaxRateVariable = updateTaxDto.TaxRateVariable,
                                         TaxRatePercentage = updateTaxDto.TaxRatePercentage,
                                         Active = updateTaxDto.Active,
                                         Printed = updateTaxDto.Printed,
                                         MembersId = updateTaxDto.MembersId,
                                     });

                if (rowsAffected == 1)
                {
                    return;
                }
                else
                {
                    throw new Exception("No fue posible actualizar la información del Impuesto.");
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
