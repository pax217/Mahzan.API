using Mahzan.Api.Exeptions;
using Mahzan.Business.Enums.Result;
using Mahzan.Business.Results._Base;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Mahzan.Api.Filters
{
    public class UnhandledExceptionFilter : ActionFilterAttribute, IExceptionFilter
    {
        private readonly ILogger<UnhandledExceptionFilter> _logger;

        public UnhandledExceptionFilter(ILogger<UnhandledExceptionFilter> logger) 
        {
            _logger = logger;
        }

        public void OnException(ExceptionContext context)
        {
            var error = context.Exception;

            //Arguments Error
            if (error is ServiceArgumentException serviceArgumentException)
            {
                HandleServiceArgumentDataException(context, serviceArgumentException);
                return;
            }

            //Key Not Found
            if (error is ServiceKeyNotFoundException serviceKeyNotFoundException)
            {
                HandleServiceKeyNotFoundException(context, serviceKeyNotFoundException);
                return;
            }

            if (error is InvalidOperationException serviceInvalidOperationException)
            {
                HandleInvalidOperationException(context, serviceInvalidOperationException);
                return;
            }
            

            _logger.LogError(error, "Error ocurrido");

            var result = new Result
            {
                IsValid = false,
                ResultTypeEnum = ResultTypeEnum.ERROR,
                Title ="Error No Controlado",
                Message = error.Message
            };

            context.Result = new BadRequestObjectResult(result);
        }

        private void HandleInvalidOperationException(
            ExceptionContext context, 
            InvalidOperationException serviceInvalidOperationException)
        {
            Result responseBase = new Result
            {
                IsValid = false,
                ResultTypeEnum = ResultTypeEnum.WARNING,
                Title = "Operación no valida.",
                Message = serviceInvalidOperationException.Message
            };

            context.Result = new ObjectResult(responseBase)
            {
                StatusCode = (int)HttpStatusCode.Conflict
            };
        }

        private void HandleServiceKeyNotFoundException(
            ExceptionContext context, 
            ServiceKeyNotFoundException serviceKeyNotFoundException)
        {
            Result responseBase = new Result
            {
                IsValid = false,
                ResultTypeEnum = ResultTypeEnum.INFO,
                Title = "Datos no encontrados.",
                Message = serviceKeyNotFoundException.Message
            };

            context.Result = new ObjectResult(responseBase)
            {
                StatusCode = (int)HttpStatusCode.Conflict
            };
        }

        private void HandleServiceArgumentDataException(
            ExceptionContext context, 
            ServiceArgumentException serviceArgumentException)
        {
            Result responseBase = new Result
            {
                IsValid = false,
                ResultTypeEnum = ResultTypeEnum.WARNING,
                Title="Argumento no valido.",
                Message = serviceArgumentException.Message
            };

            context.Result = new ObjectResult(responseBase)
            {
                StatusCode = (int)HttpStatusCode.Conflict
            };
        }
    }
}
