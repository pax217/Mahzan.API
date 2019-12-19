using System;
using System.Threading.Tasks;
using Mahzan.Business.Enums.Result;
using Mahzan.Business.Interfaces.Validations.AspNetUsers;
using Mahzan.Business.Resources.Validations.AspNetUsers;
using Mahzan.Business.Results.AspNetUsers;
using Microsoft.AspNetCore.Identity;

namespace Mahzan.Business.Implementations.Validations.AspNetUsers
{
    public class SignUpValidations: ISignUpValidations
    {
        public SignUpValidations()
        {
        }

        public async Task<SignUpResult> ValidSignUp(IdentityResult identityResult)
        {
            SignUpResult result = new SignUpResult()
            {
                IsValid = true,
                StatusCode = 200,
                ResultTypeEnum = ResultTypeEnum.SUCCESS,
                Title = SignUpValidationsResources.ResourceManager.GetString("ValidSignUp_Title"),
                Message = LogInValidationsResources.ResourceManager.GetString("ValidSignUp_SUCCESS_Message")
            };



            return result;
        }
    }
}
