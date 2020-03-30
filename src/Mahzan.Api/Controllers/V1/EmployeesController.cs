﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Mahzan.Api.Context;
using Mahzan.Api.Controllers._Base;
using Mahzan.Api.Services;
using Mahzan.Business.Enums.Result;
using Mahzan.Business.Interfaces.Business.Employees;
using Mahzan.Business.Interfaces.Business.Members;
using Mahzan.Business.Interfaces.Validations.AspNetUsers;
using Mahzan.Business.Requests.Employees;
using Mahzan.Business.Results.AspNetUsers;
using Mahzan.Business.Results.Employees;
using Mahzan.DataAccess.DTO.Employees;
using Mahzan.DataAccess.DTO.Members;
using Mahzan.DataAccess.Filters.Employees;
using Mahzan.DataAccess.Paging;
using Mahzan.Models.Enums.Audit;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Configuration;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Mahzan.Api.Controllers.V1
{
    [Route("v{version:apiVersion}/[controller]")]
    [ApiController]
    public class EmployeesController : BaseController
    {
        readonly UserManager<AspNetUsers> _userManager;

        readonly IEmployeesBusiness _employeesBusiness;

        readonly RoleManager<IdentityRole> _roleManager;

        readonly ISignUpValidations _signUpValidations;

        readonly IEmailSender _emailSender;

        private readonly IMembersBusiness _miembrosBusiness;

        public IConfiguration _config
        {
            get
            {
                return new ConfigurationBuilder()
                        .AddJsonFile("appsettings.json")
                        .Build();
            }
        }

        public EmployeesController(
            IMembersBusiness membersBusiness,
            IEmployeesBusiness employeesBusiness,
            UserManager<AspNetUsers> userManager,
            RoleManager<IdentityRole> roleManager,
            IEmailSender emailSender,
            ISignUpValidations signUpValidations)
            : base(membersBusiness)
        {
            //Business
            _employeesBusiness = employeesBusiness;
            _miembrosBusiness = membersBusiness;

            //Validaciónes
            _signUpValidations = signUpValidations;

            //Identity
            _roleManager = roleManager;
            _userManager = userManager;

            //Services
            _emailSender = emailSender;
        }

        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpPost]
        public async Task<IActionResult> Post(PostEmployeesRequest postEmployeesRequest)
        {

            PostEmployeesResult result =new PostEmployeesResult{};

            //Agrega prefijo de Miembro
            StringBuilder userNameWithPrefix = new StringBuilder();
            userNameWithPrefix.Append(UserName + "." + postEmployeesRequest.UserName);
            postEmployeesRequest.UserName = userNameWithPrefix.ToString().Trim();


            IdentityResult addUserResult = await AddUser(postEmployeesRequest);

            SignUpResult signUpValidResult = await _signUpValidations
                                                    .ValidSignUp(addUserResult);

            if (!signUpValidResult.IsValid)
            {
                return StatusCode(signUpValidResult.StatusCode, signUpValidResult);
            }
            else
            {
                IdentityResult AddRoleToUserResult = await AddRoleToUser(postEmployeesRequest);

                if (AddRoleToUserResult.Succeeded)
                {
                    var userCreated = await _userManager
                                            .FindByNameAsync(postEmployeesRequest.UserName);

                    result = await _employeesBusiness
                                    .Add(new AddEmployeesDto
                                    {
                                        CodeEmploye = postEmployeesRequest.CodeEmploye,
                                        FirstName = postEmployeesRequest.FirstName,
                                        SecondName = postEmployeesRequest.SecondName,
                                        LastName = postEmployeesRequest.LastName,
                                        SureName = postEmployeesRequest.SureName,
                                        Email = postEmployeesRequest.Email,
                                        Phone = postEmployeesRequest.Phone,
                                        Username = postEmployeesRequest.UserName,
                                        Password = postEmployeesRequest.Password,
                                        MembersId = MembersId,
                                        AspNetUsersId = new Guid(userCreated.Id),
                                        AspNetUserId = AspNetUserId,
                                        TableAuditEnum = TableAuditEnum.EMPLOYEES_AUDIT
                                    });

                    //Agrega MembersPatternId
                    //Crea Miembro
                    await _miembrosBusiness
                           .Add(new AddMembersDto()
                           {
                               Name = postEmployeesRequest.FirstName + " " +
                                      postEmployeesRequest.SecondName + " " +
                                      postEmployeesRequest.LastName + " " +
                                      postEmployeesRequest.SureName + " ",
                               Phone = postEmployeesRequest.Phone,
                               Email = postEmployeesRequest.Email,
                               UserName = postEmployeesRequest.UserName,
                               AspNetUsersId = new Guid(userCreated.Id),
                               MembersPatternId = MembersId
                           });


                    //Envia el correo de confirmación
                    await SendEmailConfirmation(postEmployeesRequest);
                }
                else
                {
                    result.IsValid = false;
                    result.StatusCode = 500;
                    result.Message = AddRoleToUserResult.Errors.FirstOrDefault().Description;

                }
            }


            return StatusCode(result.StatusCode, result);
        }

        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] GetEmployeesFilter getEmployeesFilter)
        {
            GetEmployeesResult result = await _employeesBusiness
                                         .Get(new GetEmployeesDto {
                                             EmployeesId = getEmployeesFilter.EmployeId,
                                             PageNumber = getEmployeesFilter.PageNumber,
                                             PageSize = getEmployeesFilter.PageSize,
                                             MembersId = MembersId
                                         });


            result.Paging = new Paging()
            {
                TotalCount = result.Employees.TotalCount,
                PageSize = result.Employees.PageSize,
                CurrentPage = result.Employees.CurrentPage,
                TotalPages = result.Employees.TotalPages,
                HasNext = result.Employees.HasNext,
                HasPrevious = result.Employees.HasPrevious
            };

            return StatusCode(result.StatusCode, result);
        }

        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpPut]
        public async Task<IActionResult> Put(PutEmployeesRequest putEmployeeRequest)
        {
            PutEmployeesResult result = await _employeesBusiness
                                               .Update(new PutEmployeesDto
                                               {
                                                   EmployeeId = putEmployeeRequest.EmployeeId,
                                                   CodeEmploye = putEmployeeRequest.CodeEmploye,
                                                   FirstName = putEmployeeRequest.FirstName,
                                                   SecondName = putEmployeeRequest.SecondName,
                                                   LastName = putEmployeeRequest.LastName,
                                                   SureName = putEmployeeRequest.SureName,
                                                   Email = putEmployeeRequest.Email,
                                                   Active = putEmployeeRequest.Active
                                               });

            return StatusCode(result.StatusCode, result);
        }

        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpDelete]
        public async Task<IActionResult> Delete(Guid EmployeeId)
        {
            DeleteEmployeesResult result = await _employeesBusiness
                                   .Delete(new DeleteEmployeesDto
                                   {
                                       EmployeeId = EmployeeId
                                   });
            
            //Elimina el Usuario creado para el Empleado
            if(result.IsValid)
            {
                var user = await _userManager.FindByIdAsync(result.Employee.AspNetUsersId.ToString());

                if(user!=null)
                {
                    await _userManager.DeleteAsync(user);
                }

            }

            return StatusCode(result.StatusCode, result);
        }


        #region Private Methods

        private async Task<IdentityResult> AddUser(PostEmployeesRequest postEmployeesRequest)
        {
            IdentityResult result = null;

            AspNetUsers aspNetUser = new AspNetUsers()
            {
                UserName = postEmployeesRequest.UserName,
                Email = postEmployeesRequest.Email,
                NormalizedEmail = postEmployeesRequest.Email,
                PhoneNumber = postEmployeesRequest.Phone
            };

            result = await _userManager
                            .CreateAsync(aspNetUser,
                                         postEmployeesRequest.Password);

            return result;
        }

        private async Task<IdentityResult> AddRoleToUser(PostEmployeesRequest postEmployeesRequest)
        {
            IdentityResult result = null;

            var aspNetUser = await _userManager
                                    .FindByNameAsync(postEmployeesRequest.UserName);

            //Verifica si el Role existe
            if (!_roleManager.RoleExistsAsync(postEmployeesRequest.Role.ToString()).Result)
            {
                result = await _roleManager.CreateAsync(new IdentityRole()
                {
                    Name = postEmployeesRequest.Role.ToString(),
                    NormalizedName = postEmployeesRequest.Role.ToString(),
                });
            }

            //Agrega Role a Usuario
            result = await _userManager
                            .AddToRoleAsync(aspNetUser,
                                            postEmployeesRequest.Role.ToString());



            return result;
        }

        private async Task SendEmailConfirmation(PostEmployeesRequest postEmployeesRequest)
        {

            var aspNetUser = await _userManager
                                    .FindByNameAsync(postEmployeesRequest.UserName);

            //Verificación de Email
            var code = await _userManager.GenerateEmailConfirmationTokenAsync(aspNetUser);
            code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));

            var callbackUrl = Url.Page(
                "/V1/AspNetUsers/ConfirmEmail",
                pageHandler: null,
                values: new { id = aspNetUser.Id, code = code },
                protocol: Request.Scheme);

            //Nota: Investigar por que solo obtiene el controlador Agerga
            callbackUrl = callbackUrl.Replace("SignUp", "ConfirmEmail");

            await _emailSender.SendEmailAsync(aspNetUser.Email, "Confirm your email",
                $"Please confirm your account by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>.");

        }

        #endregion
    }
}
