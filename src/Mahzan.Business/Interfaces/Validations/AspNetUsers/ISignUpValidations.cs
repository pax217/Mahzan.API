using System;
using System.Threading.Tasks;
using Mahzan.Business.Results.AspNetUsers;
using Microsoft.AspNetCore.Identity;

namespace Mahzan.Business.Interfaces.Validations.AspNetUsers
{
    public interface ISignUpValidations
    {
        Task<SignUpResult> ValidSignUp(IdentityResult identityResult);
    }
}
