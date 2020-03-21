using Mahzan.Business.Enums.Result;
using Mahzan.Business.Results._Base;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
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
    }
}
