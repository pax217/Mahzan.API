using System;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Mahzan.Business.Enums.Result;
using Mahzan.Business.Interfaces.Business.Stores;
using Mahzan.Business.Requests.Stores;
using Mahzan.Business.Resources.Business.Stores;
using Mahzan.Business.Results.Stores;
using Mahzan.DataAccess.DTO.Stores;
using Mahzan.DataAccess.Filters.Stores;
using Mahzan.DataAccess.Interfaces;

namespace Mahzan.Business.Implementations.Business.Stores
{
    public class StoresBusiness : IStoresBusiness
    {
        readonly IStoresRepository _storesRepository;

        readonly IMapper _mapper;

        public StoresBusiness(
            IStoresRepository storesRepository,
            IMapper mapper)
        {
            _storesRepository = storesRepository;
            _mapper = mapper;
        }

        public async Task<AddStoresResult> Add(AddStoresDto addStoresDto)
        {
            AddStoresResult result = new AddStoresResult
            {
                IsValid = true,
                StatusCode = 200,
                ResultTypeEnum = ResultTypeEnum.SUCCESS,
                Title = AddStoresResources.ResourceManager.GetString("Add_Title"),
                Message = AddStoresResources.ResourceManager.GetString("Add_200_SUCCESS_Message")

            };

            try
            {
                //Validaciones al agregar la tienda

                //Agrega Tienda
                _storesRepository
                    .Add(_mapper.Map<Models.Entities.Stores>(addStoresDto),
                         addStoresDto.AspNetUserId,
                         addStoresDto.TableAuditEnum);
                       


            }
            catch (Exception ex)
            {
                result.IsValid = false;
                result.StatusCode = 500;
                result.ResultTypeEnum = ResultTypeEnum.ERROR;
                result.Message = ex.Message;
            }

            return result;
        }

        public async Task<DeleteStoresResult> Delete(DeleteStoresDto deleteStoresDto)
        {
            DeleteStoresResult result = new DeleteStoresResult
            {
                IsValid = true,
                StatusCode = 200,
                ResultTypeEnum = ResultTypeEnum.SUCCESS,
                Title = DeleteStoresResources.ResourceManager.GetString("Delete_Title"),
                Message = DeleteStoresResources.ResourceManager.GetString("Delete_200_SUCCESS_Message")

            };

            try
            {
                //Validaciones al eliminar Tienda

                //Elimina Tienda
                _storesRepository
                    .Delete(deleteStoresDto);

            }
            catch (Exception ex)
            {
                result.IsValid = false;
                result.StatusCode = 500;
                result.ResultTypeEnum = ResultTypeEnum.ERROR;
                result.Message = ex.Message;
            }

            return result;
        }

        public async Task<GetStoresResult> Get(GetStoresFilter getStoresFilter)
        {
            GetStoresResult result = new GetStoresResult
            {
                IsValid = true,
                StatusCode = 200,
                ResultTypeEnum = ResultTypeEnum.SUCCESS,
                Title = GetStoresResources.ResourceManager.GetString("Add_Title"),
                Message = GetStoresResources.ResourceManager.GetString("Add_200_SUCCESS_Message")

            };

            try
            {
                result.Stores = _storesRepository
                                 .Get(getStoresFilter);

                if (result.Stores.Any())
                {
                    result.ResultTypeEnum = ResultTypeEnum.INFO;
                    result.Message = GetStoresResources.ResourceManager.GetString("Get_200_INFO_Message");

                    return result;
                }

            }
            catch (Exception ex)
            {
                result.IsValid = false;
                result.StatusCode = 500;
                result.ResultTypeEnum = ResultTypeEnum.ERROR;
                result.Message = ex.Message;
            }

            return result;
        }

        public async Task<PutStoresResult> Update(PutStoresDto putStoresDto)
        {
            PutStoresResult result = new PutStoresResult
            {
                IsValid = true,
                StatusCode = 200,
                ResultTypeEnum = ResultTypeEnum.SUCCESS,
                Title = PutStoresResources.ResourceManager.GetString("Put_Title"),
                Message = PutStoresResources.ResourceManager.GetString("Put_200_SUCCESS_Message")

            };

            try
            {
                //Validaciones de la actualziación

                _storesRepository
                    .Update(putStoresDto);

            }
            catch (Exception ex)
            {
                result.IsValid = false;
                result.StatusCode = 500;
                result.ResultTypeEnum = ResultTypeEnum.ERROR;
                result.Message = ex.Message;
            }

            return result;
        }
    }
}
