using Dapper;
using Mahzan.Dapper.DTO.Products.CreateProduct;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Internal;
using System.Linq;
using Mahzan.Dapper.Exceptions.Products.CreateProduct;

namespace Mahzan.Dapper.Rules.Products.CreateProduct
{
    public class CreateProductRules : DataConnection, ICreateProductRules
    {
        public CreateProductRules(
            IDbConnection dbConnection) 
            : base(dbConnection)
        {
        }

        public async Task Handle(CreateProductDto createProductDto)
        {
            //Valida que no exista el producto con el mismo código de barras.
            if (await ProductExistBarcode(
                createProductDto.CreateProductDetailDto.Barcode,
                createProductDto.MembersId))
            {
                throw new CreateProductInvalidOperationException(
                    $"El producto con código de barras {createProductDto.CreateProductDetailDto.Barcode} ya existe."
                    );
            }

        }

        private async Task<bool> ProductExistBarcode(
            string barcode,
            Guid membersId)
        {
            bool result = false;

            StringBuilder sql = new StringBuilder();
            sql.Append("SELECT * FROM Products ");
            sql.Append("WHERE MembersId= @MembersId ");
            sql.Append("AND Barcode= @Barcode ");

            IEnumerable<Models.Entities.Products> products;
            products = await Connection
                .QueryAsync<Models.Entities.Products>(
                sql.ToString(),
                new {
                    MembersId = membersId,
                    Barcode = barcode
                }
                );

            if (products.Any())
            {
                result = true;
            }

            return result;
        }
    }
}
