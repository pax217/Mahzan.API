using System;
using System.Threading.Tasks;
using Mahzan.Business.Results.AspNetUsers;
using Microsoft.AspNetCore.Identity;

namespace Mahzan.Business.Interfaces.Validations.AspNetUsers
{
    public interface ILogInValidations
    {
        Task<LogInResult> ValidSignInManager(object aspNetUser,
                                             SignInResult signInResult);
    }
}
