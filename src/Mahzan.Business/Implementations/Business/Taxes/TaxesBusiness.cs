using System;
using System.Threading.Tasks;
using Mahzan.Business.Enums.Result;
using Mahzan.Business.Interfaces.Business.Taxes;
using Mahzan.Business.Interfaces.Validations.Taxes;
using Mahzan.Business.Results.Taxes;
using Mahzan.DataAccess.Interfaces;
using Microsoft.EntityFrameworkCore.Internal;
using System.Linq;
using Mahzan.Business.Exceptions.Taxes;
using Mahzan.Dapper.Interfaces.Taxes;
using Mahzan.Dapper.DTO.Taxes;
using Mahzan.Dapper.Paging;

namespace Mahzan.Business.Implementations.Business.Taxes
{
    public class TaxesBusiness: ITaxesBusiness
    {
        //Dapper 
        private readonly ITaxesDapper _taxesDapper;


        public TaxesBusiness(
            ITaxesDapper taxesDapper)
        {
            //Dapper 
            _taxesDapper = taxesDapper;
        }

        public async Task<PostTaxesResult> Add(InsertTaxDto insertTaxDto)
        {
            PostTaxesResult result = new PostTaxesResult
            {
                IsValid = true,
                ResultTypeEnum = ResultTypeEnum.SUCCESS
            };

            result.TaxesId = await _taxesDapper
                                   .InsertAsync(insertTaxDto);

            return result;
        }

        public async Task<GetTaxesResult> GetWhere(GetTaxesDto getTaxesDto)
        {
            GetTaxesResult result = new GetTaxesResult
            {
                IsValid = true,
                ResultTypeEnum = ResultTypeEnum.SUCCESS
            };

            result.Taxes = await _taxesDapper
                                 .GetWhereAsync(getTaxesDto);

            if (!result.Taxes.Any())
            {
                throw new TaxesKeyNotFoundException($"No se encontraron Impuestos");
            }

            result.Paging = new Paging
            {
                TotalCount = result.Taxes.TotalCount,
                PageSize = result.Taxes.PageSize,
                CurrentPage = result.Taxes.CurrentPage,
                TotalPages = result.Taxes.TotalPages,
                HasNext = result.Taxes.HasNext,
                HasPrevious = result.Taxes.HasPrevious
            };

            return result;
        }
    }
}
