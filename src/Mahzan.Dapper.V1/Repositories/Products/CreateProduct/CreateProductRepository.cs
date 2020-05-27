using Mahzan.Dapper.DTO.Products.CreateProduct;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using System.Transactions;
using Dapper;
using System.Text;
using Mahzan.Dapper.Rules.Products.CreateProduct;

namespace Mahzan.Dapper.Repositories.Products.CreateProduct
{
    public class CreateProductRepository : DataConnection, ICreateProductRepository
    {
        private readonly ICreateProductRules _createProductRules;

        public CreateProductRepository(
            IDbConnection dbConnection, 
            ICreateProductRules createProductRules)
            : base(dbConnection)
        {
            _createProductRules = createProductRules;
        }

        public async Task<Guid> Handle(CreateProductDto createProductDto)
        {
            Guid productsId = Guid.Empty;


            //Rules
            await _createProductRules.Handle(createProductDto);

            using (var transaction = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                //Product
                productsId = await HandleInsertProduct(createProductDto);

                //ProductPhoto
                await HandleInsertProductPhoto(
                    productsId, 
                    createProductDto.CreateProductPhotoDto);

                //ProductTaxes
                await HandleInsertProductTaxes(
                    productsId,
                    createProductDto.MembersId,
                    createProductDto.CreateProductTaxesDto);

                transaction.Complete();
            }

            return productsId;
        }

        #region :: Private Methods ::

        private async Task<Guid> HandleInsertProduct(CreateProductDto createProductDto) 
        {
            Guid productsId = Guid.Empty;

            StringBuilder sql = new StringBuilder();
            sql.Append("INSERT INTO Products");
            sql.Append("(");
            sql.Append("SKU,");
            sql.Append("Barcode,");
            sql.Append("Description,");
            sql.Append("Price,");
            sql.Append("Cost,");
            sql.Append("FollowInventory,");
            //sql.Append("AvailableInAllStores");
            sql.Append("MembersId,");
            sql.Append("ProductCategoriesId,");
            sql.Append("ProductUnitsId,");
            sql.Append("CommercialMargin,");
            sql.Append("CommercialMarginPercentaje");
            sql.Append(") ");
            sql.Append("OUTPUT INSERTED.ProductsId ");
            sql.Append("VALUES");
            sql.Append("(");
            sql.Append("@SKU,");
            sql.Append("@Barcode,");
            sql.Append("@Description,");
            sql.Append("@Price,");
            sql.Append("@Cost,");
            sql.Append("@FollowInventory,");
            //sql.Append("@AvailableInAllStores");
            sql.Append("@MembersId,");
            sql.Append("@ProductCategoriesId,");
            sql.Append("@ProductUnitsId,");
            sql.Append("@CommercialMargin,");
            sql.Append("@CommercialMarginPercentaje");
            sql.Append(");");


            productsId = await Connection
                .ExecuteScalarAsync<Guid>(
                sql.ToString(),
                new
                {
                    SKU = createProductDto.CreateProductDetailDto.SKU,
                    Barcode = createProductDto.CreateProductDetailDto.Barcode,
                    Description = createProductDto.CreateProductDetailDto.Description,
                    Price = createProductDto.CreateProductDetailDto.Price,
                    Cost = createProductDto.CreateProductDetailDto.Cost,
                    FollowInventory = createProductDto.CreateProductDetailDto.FollowInventory,
                    MembersId = createProductDto.MembersId,
                    ProductCategoriesId = createProductDto.CreateProductDetailDto.ProductCategoriesId,
                    ProductUnitsId = createProductDto.CreateProductDetailDto.ProductUnitsId,
                    CommercialMargin = createProductDto.CreateProductDetailDto.CommercialMargin,
                    CommercialMarginPercentaje = createProductDto.CreateProductDetailDto.CommercialMarginPercentaje
                });


            return productsId;
        }

        private async Task HandleInsertProductPhoto(
            Guid productsId,
            CreateProductPhotoDto createProductPhotoDto)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("INSERT INTO ProductsPhotos");
            sql.Append("(");
            sql.Append("Title,");
            sql.Append("DateTime,");
            sql.Append("MIMEType,");
            sql.Append("Base64,");
            sql.Append("ProductsId");
            sql.Append(") ");
            sql.Append("VALUES");
            sql.Append("(");
            sql.Append("@Title,");
            sql.Append("@DateTime,");
            sql.Append("@MIMEType,");
            sql.Append("@Base64,");
            sql.Append("@ProductsId");
            sql.Append(");");


            await Connection
                .ExecuteScalarAsync<Guid>(
                sql.ToString(),
                new
                {
                    Title = createProductPhotoDto.Title,
                    DateTime = createProductPhotoDto.DateTime,
                    MIMEType = createProductPhotoDto.MIMEType,
                    Base64 = createProductPhotoDto.Base64,
                    ProductsId = productsId
                });
        }

        private async Task HandleInsertProductTaxes(
            Guid productsId,
            Guid membersId,
            List<CreateProductTaxesDto> createProductTaxesDto)
        {
            if (createProductTaxesDto!=null)
            {
                foreach (var createProductTaxDto in createProductTaxesDto)
                {
                    StringBuilder sql = new StringBuilder();
                    sql.Append("INSERT INTO ProductsTaxes");
                    sql.Append("(");
                    sql.Append("ProductsId,");
                    sql.Append("TaxRate,");
                    sql.Append("MembersId,");
                    sql.Append("TaxesId");
                    sql.Append(") ");
                    sql.Append("VALUES");
                    sql.Append("(");
                    sql.Append("@ProductsId,");
                    sql.Append("@TaxRate,");
                    sql.Append("@MembersId,");
                    sql.Append("@TaxesId");
                    sql.Append(");");


                    await Connection
                        .ExecuteScalarAsync<Guid>(
                        sql.ToString(),
                        new
                        {
                            ProductsId = productsId,
                            TaxRate = createProductTaxDto.TaxRate,
                            MembersId = membersId,
                            TaxesId = createProductTaxDto.TaxesId
                        });
                }
            }
        }

        #endregion
    }
}
