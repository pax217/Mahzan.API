using System;
using System.Linq;
using System.Threading.Tasks;
using Mahzan.Business.Enums.Result;
using Mahzan.Business.Interfaces.Validations.Products;
using Mahzan.Business.Resources.Validations.Products;
using Mahzan.Business.Results.Products;
using Mahzan.DataAccess.DTO.Products;
using Mahzan.DataAccess.Interfaces;

namespace Mahzan.Business.Implementations.Validations.Products
{
    public class AddProductsValidations : IAddProductsValidations
    {
        readonly IProductsRepository _productsRepository;

        public AddProductsValidations(
            IProductsRepository productsRepository)
        {
            _productsRepository = productsRepository;
        }

        public async Task<PostProductsResult> AddProductsValid(AddProductsDto addProductsDto)
        {
            PostProductsResult result = new PostProductsResult()
            {
                IsValid = true,
                StatusCode = 200,
                ResultTypeEnum = ResultTypeEnum.SUCCESS,
                Title = AddProductsValidationsResources.ResourceManager.GetString("AddMembersValid_Title"),
                Message = AddProductsValidationsResources.ResourceManager.GetString("AddMembersValid_200_SUCCESS_Message")
            };

            //Valida el códido de barras
            //if (_productsRepository.Get( x=> x.MembersId == addProductsDto.MembersId
            //                              && x.Barcode == addProductsDto.Barcode).Any())
            //{
            //    result.IsValid = false;
            //    result.StatusCode = 500;
            //    result.ResultTypeEnum = ResultTypeEnum.WARNING;
            //    result.Message = AddProductsValidationsResources.ResourceManager.GetString("AddProductsValid_500_WARNING_Message_Barcode");

            //    return result;
            //}

            return result;
        }


    }
}
