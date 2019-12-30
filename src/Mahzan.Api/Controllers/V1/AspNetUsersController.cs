using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Mahzan.Business.Enums.Result;
using Mahzan.Business.Requests.AspNetUsers;
using Mahzan.Business.Results.AspNetUsers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Identity;
using Mahzan.Api.Context;
using Mahzan.Business.Interfaces.Validations.AspNetUsers;
using Microsoft.AspNetCore.WebUtilities;
using Mahzan.Api.Services;
using System.Text.Encodings.Web;
using Mahzan.Business.Interfaces.Business;
using Mahzan.DataAccess.DTO.Miembros;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Mahzan.Api.Controllers.V1
{
    [Route("v{version:apiVersion}/[controller]/[action]")]
    [ApiController]
    public class AspNetUsersController : Controller
    {
        #region ReadOnly Properties
        readonly UserManager<AspNetUsers> _userManager;
        readonly SignInManager<AspNetUsers> _signInManager;
        readonly RoleManager<IdentityRole> _roleManager;

        readonly ILogInValidations _logInValidations;
        readonly ISignUpValidations _signUpValidations;
        readonly IMiembrosBusiness _miembrosBusiness;

        readonly IEmailSender _emailSender;

        #endregion

        #region Public Properties

        public IConfiguration _config
        {
            get
            {
                return new ConfigurationBuilder()
                        .AddJsonFile("appsettings.json")
                        .Build();
            }
        }

        #endregion

        #region Constructor

        public AspNetUsersController(UserManager<AspNetUsers> userManager,
                                     SignInManager<AspNetUsers> signInManager,
                                     RoleManager<IdentityRole> roleManager,
                                     ILogInValidations logInValidations,
                                     ISignUpValidations signUpValidations,
                                     IMiembrosBusiness miembrosBusiness,
                                     IEmailSender emailSender)
        {
            //Identity
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;

            //Validaciónes
            _logInValidations = logInValidations;
            _signUpValidations = signUpValidations;

            //Services
            _emailSender = emailSender;

            //Business
            _miembrosBusiness = miembrosBusiness;
        }
        #endregion

        #region Public Methods

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> LogIn([FromQuery]LogInRequest loginRequest)
        {
            LogInResult result = new LogInResult()
            {
                IsValid = true,
                StatusCode = 200,
                ResultTypeEnum = ResultTypeEnum.SUCCESS,
                Title = "Inicio de Sesión",
                Message = "Se ha iniciado correctamente la sesión."
            };

            try
            {
                //Busca si el usuario existe
                var aspNetUser = await _userManager
                                        .FindByNameAsync(loginRequest.UserName);

                //Indica su sus datos son correctos para el incio de sesión
                var signInResult = await _signInManager
                                          .PasswordSignInAsync(loginRequest.UserName,
                                                               loginRequest.Password,
                                                               true,
                                                               false);

                LogInResult signInValidResult = await _logInValidations
                                                       .ValidSignInManager(aspNetUser,
                                                                           signInResult);

                if (!signInValidResult.IsValid)
                {
                    return StatusCode(signInValidResult.StatusCode, signInValidResult);
                }
                else
                {
                    //Obtiene Token
                    result.Token = await GetToken(loginRequest);

                    //Obtiene Role
                    result.Role = _userManager
                                   .GetRolesAsync(aspNetUser)
                                   .GetAwaiter()
                                   .GetResult()
                                   .FirstOrDefault();
                }


            }
            catch (Exception ex)
            {
                result.IsValid = false;
                result.StatusCode = 500;
                result.ResultTypeEnum = ResultTypeEnum.ERROR;
                result.Message = ex.Message;
            }

            return StatusCode(result.StatusCode, result);
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> ConfirmEmail(string id,
                                                      string code)
        {
            var aspNetUser = await _userManager
                                    .FindByIdAsync(id);

            var codeDecodedBytes = WebEncoders.Base64UrlDecode(code);
            var codeDecoded = Encoding.UTF8.GetString(codeDecodedBytes);

            var result = _userManager.ConfirmEmailAsync(aspNetUser, codeDecoded);

            return Content("Se ha confirmado correctamente tu Email.");
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> SignUp(SignUpRequest signUpRequest)
        {
            SignUpResult result = new SignUpResult()
            {
                IsValid = true,
                StatusCode = 200,
                ResultTypeEnum = ResultTypeEnum.SUCCESS,
                Title = "Registro de Usuario",
                Message = "Se ha reistrado correctamente tu usuario."
            };

            try
            {
                IdentityResult addUserResult = await AddUser(signUpRequest);

                SignUpResult signUpValidResult = await _signUpValidations
                                                        .ValidSignUp(addUserResult);

                if (!signUpValidResult.IsValid)
                {
                    return StatusCode(signUpValidResult.StatusCode, signUpValidResult);
                }
                else
                {
                    IdentityResult AddRoleToUserResult = await AddRoleToUser(signUpRequest);

                    if (AddRoleToUserResult.Succeeded)
                    {
                        //Crea Miembro
                        await _miembrosBusiness
                               .Add(new AddMiembrosDto()
                               {
                                   Name = signUpRequest.Name,
                                   Phone = signUpRequest.Phone,
                                   Email = signUpRequest.Email,
                                   UserName = signUpRequest.UserName,
                               });

                        //Envia el correo de confirmación
                        await SendEmailConfirmation(signUpRequest);
                    }

                }

            }
            catch (Exception ex)
            {
                result.IsValid = false;
                result.StatusCode = 500;
                result.ResultTypeEnum = ResultTypeEnum.ERROR;
                result.Message = ex.Message;
            }

            return StatusCode(result.StatusCode, result);
        }


        #endregion

        #region Private Methods

        private async Task<string> GetToken(LogInRequest logInRequest)
        {

            string result = string.Empty;

            Claim[] claims = {
                new Claim(JwtRegisteredClaimNames.Sub, logInRequest.UserName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            SymmetricSecurityKey key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));

            var token = new JwtSecurityToken(
                issuer: "http://oec.com",
                audience: "http://oec.com",
                expires: DateTime.UtcNow.AddHours(1),
                claims: claims,
                signingCredentials: new SigningCredentials(key, SecurityAlgorithms.HmacSha256)
                );

            result = new JwtSecurityTokenHandler().WriteToken(token);

            return result;
        }

        private async Task<IdentityResult> AddUser(SignUpRequest signUpRequest)
        {
            IdentityResult result = null;

            AspNetUsers aspNetUser = new AspNetUsers()
            {
                UserName = signUpRequest.UserName,
                Email = signUpRequest.Email,
                NormalizedEmail = signUpRequest.Email,
                PhoneNumber = signUpRequest.Phone
            };

            result = await _userManager
                            .CreateAsync(aspNetUser,
                                         signUpRequest.Password);

            return result;
        }

        private async Task<IdentityResult> AddRoleToUser(SignUpRequest signUpRequest)
        {
            IdentityResult result = null;

            var aspNetUser = await _userManager
                                    .FindByNameAsync(signUpRequest.UserName);

            //Verifica si el Role existe
            if (!_roleManager.RoleExistsAsync(signUpRequest.Role.ToString()).Result)
            {
                result = await _roleManager.CreateAsync(new IdentityRole()
                {
                    Name = signUpRequest.Role.ToString(),
                    NormalizedName = signUpRequest.Role.ToString(),
                });
            }

            //Agrega Role a Usuario
            result = await _userManager
                            .AddToRoleAsync(aspNetUser,
                                            signUpRequest.Role.ToString());



            return result;
        }

        private async Task SendEmailConfirmation(SignUpRequest signUpRequest)
        {

            var aspNetUser = await _userManager
                                    .FindByNameAsync(signUpRequest.UserName);

            //Verificación de Email
            var code = await _userManager.GenerateEmailConfirmationTokenAsync(aspNetUser);
            code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));

            var callbackUrl = Url.Page(
                "/V1/AspNetUsers/ConfirmEmail",
                pageHandler: null,
                values: new {id = aspNetUser.Id, code = code },
                protocol: Request.Scheme);

            //Nota: Investigar por que solo obtiene el controlador Agerga
            callbackUrl = callbackUrl.Replace("SignUp", "ConfirmEmail");

            await _emailSender.SendEmailAsync(aspNetUser.Email, "Confirm your email",
                $"Please confirm your account by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>.");

        }

        #endregion
    }
}
