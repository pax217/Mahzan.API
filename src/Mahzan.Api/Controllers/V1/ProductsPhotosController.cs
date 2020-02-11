using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Mahzan.Api.Controllers._Base;
using Mahzan.Business.Interfaces.Business.Members;
using Mahzan.Business.Interfaces.Business.ProductsPhotos;
using Mahzan.Business.Results.ProductsPhotos;
using Mahzan.DataAccess.DTO.ProductsPhotos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Mahzan.Api.Controllers.V1
{
    [Route("v{version:apiVersion}/[controller]")]
    [ApiController]
    public class ProductsPhotosController : BaseController
    {
        readonly IProductsPhotosBusiness _productsPhotosBusiness;

        public ProductsPhotosController(
        IMembersBusiness miembrosBusiness,
        IProductsPhotosBusiness productsPhotosBusiness)
        : base(miembrosBusiness)
        {
            _productsPhotosBusiness = productsPhotosBusiness;
        }

        // POST api/values
        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpPost]
        public async Task<IActionResult> Post(Guid productId,IFormFile formFile)
        {


            PostProductsPhotosResult result = await _productsPhotosBusiness
                                                     .Add(new AddProductsPhotosDto
                                                     {
                                                         ProductId = productId,
                                                         Title = formFile.FileName,
                                                         DateTime = DateTime.Now,
                                                         MIMEType = formFile.ContentType,
                                                         Base64 = FormFileToBase64(formFile),
                                                         AspNetUserId = AspNetUserId,
                                                         MembersId = MembersId
                                                     });

            return StatusCode(result.StatusCode, result);
        }


        #region Private Methods

        private string FormFileToBase64(IFormFile formFile)
        {
            string result = string.Empty;

            if (formFile.Length > 0)
            {
                using (var ms = new MemoryStream())
                {
                    formFile.CopyTo(ms);
                    var fileBytes = ms.ToArray();
                    result = Convert.ToBase64String(fileBytes);
                    // act on the Base64 data
                }
            }

            return result;
        }

        #endregion
    }
}
