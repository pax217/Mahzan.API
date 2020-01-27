using System;
using System.Threading.Tasks;
using Mahzan.Business.Results.BarCodes;
using Mahzan.DataAccess.DTO.BarCodes;

namespace Mahzan.Business.Interfaces.Business.BarCodes
{
    public interface IBarCodesBusiness
    {
        Task<PostBarCodesResult> Create(CreateBarCodesDto createBarCodesDto);
    }
}
