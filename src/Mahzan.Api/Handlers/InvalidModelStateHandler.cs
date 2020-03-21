using Mahzan.Business.Enums.Result;
using Mahzan.Business.Results._Base;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mahzan.Api.Handlers
{
    public static class InvalidModelStateHandler
    {
        public static IActionResult Handler(ActionContext actionContext) 
        {
            var result = new Result
            {
                IsValid = false,
                Message = FormatErrors(actionContext.ModelState),
                ResultTypeEnum =ResultTypeEnum.ERROR,
                StatusCode = 400,
                Title = "Error de Validación"
            };

            return new BadRequestObjectResult(result);
        }

        private static string FormatSingle(ModelStateEntry modelStateEntry) 
        {
            var errors = modelStateEntry.Errors.Select(error => error.ErrorMessage);
            return string.Join(", ", errors);
        }

        private static string FormatErrors(ModelStateDictionary keyValuePairs) 
        {
            var pieces = keyValuePairs.Select(pair => $"{pair.Key}:{FormatSingle(pair.Value)}");

            return string.Join(", ", pieces);
        }
    }
}
