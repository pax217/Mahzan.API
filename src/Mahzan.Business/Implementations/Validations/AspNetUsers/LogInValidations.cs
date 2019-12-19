using System;
using System.Threading.Tasks;
using Mahzan.Business.Enums.Result;
using Mahzan.Business.Interfaces.Validations.AspNetUsers;
using Mahzan.Business.Resources.Validations.AspNetUsers;
using Mahzan.Business.Results.AspNetUsers;
using Microsoft.AspNetCore.Identity;

namespace Mahzan.Business.Implementations.Validations.AspNetUsers
{
    public class LogInValidations: ILogInValidations
    {

        public LogInValidations()
        {
        }

        public async Task<LogInResult> ValidSignInManager(object aspNetUser,
                                                          SignInResult signInResult)
        {
            LogInResult result = new LogInResult()
            {
                IsValid = true,
                StatusCode = 200,
                ResultTypeEnum = ResultTypeEnum.SUCCESS,
                Title = LogInValidationsResources.ResourceManager.GetString("ValidSignInManager_Title"),
                Message = LogInValidationsResources.ResourceManager.GetString("ValidSignInManager_SUCCESS_Message")
            };

            //Indica si el usaurio existe
            if (aspNetUser==null)
            {
                result.IsValid = false;
                result.StatusCode = 400;
                result.ResultTypeEnum = ResultTypeEnum.ERROR;
                result.Message = LogInValidationsResources.ResourceManager.GetString("ValidSignInManager_400_ERROR_Message_AspNetUser");

                return result;
            }


            //Indica si la cuenta ha sido bloqueda. 
            if (signInResult.IsLockedOut)
            {
                result.IsValid = false;
                result.StatusCode = 400;
                result.ResultTypeEnum = ResultTypeEnum.ERROR;
                result.Message = LogInValidationsResources.ResourceManager.GetString("ValidSignInManager_400_ERROR_Message_IsLockedOut");

                return result;
             }

            return result;
        }
    }
}
