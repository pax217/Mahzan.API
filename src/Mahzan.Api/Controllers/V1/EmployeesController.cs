using System;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Mahzan.Api.Commands.Employees.CreateEmployee;
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
        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody]CreateEmployeeCommand command)
        {

            CreateEmployeeResult result = new CreateEmployeeResult
            {
                IsValid = true,
                ResultTypeEnum = ResultTypeEnum.SUCCESS
            };

            try
            {
                //Agrega prefijo de Miembro
                StringBuilder userNameWithPrefix = new StringBuilder();
                userNameWithPrefix.Append(UserName + "." + command.UserName);
                command.UserName = userNameWithPrefix.ToString().Trim();


                IdentityResult addUserResult = await AddUser(command);

                SignUpResult signUpValidResult = await _signUpValidations
                                                        .ValidSignUp(addUserResult);

                if (!signUpValidResult.IsValid)
                {
                    return StatusCode(signUpValidResult.StatusCode, signUpValidResult);
                }
                else
                {
                    IdentityResult AddRoleToUserResult = await AddRoleToUser(command);

                    if (AddRoleToUserResult.Succeeded)
                    {
                        var userCreated = await _userManager
                                                .FindByNameAsync(command.UserName);

                        result = await _employeesBusiness
                                        .Add(new AddEmployeesDto
                                        {
                                            CodeEmploye = command.CodeEmploye,
                                            FirstName = command.FirstName,
                                            SecondName = command.SecondName,
                                            LastName = command.LastName,
                                            SureName = command.SureName,
                                            Email = command.Email,
                                            Phone = command.Phone,
                                            Username = command.UserName,
                                            Password = command.Password,
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
                                   Name = command.FirstName + " " +
                                          command.SecondName + " " +
                                          command.LastName + " " +
                                          command.SureName + " ",
                                   Phone = command.Phone,
                                   Email = command.Email,
                                   UserName = command.UserName,
                                   AspNetUsersId = new Guid(userCreated.Id),
                                   MembersPatternId = MembersId
                               });


                        //Envia el correo de confirmación
                        await SendEmailConfirmation(command);
                    }
                    else
                    {
                        result.IsValid = false;
                        result.StatusCode = 500;
                        result.Message = "";

                    }
                }
            }
            catch (Exception)
            {

                throw;
            }    

            return Ok(result);




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

        private async Task<IdentityResult> AddUser(CreateEmployeeCommand command)
        {
            IdentityResult result = null;

            AspNetUsers aspNetUser = new AspNetUsers()
            {
                UserName = command.UserName,
                Email = command.Email,
                NormalizedEmail = command.Email,
                PhoneNumber = command.Phone
            };

            result = await _userManager
                            .CreateAsync(aspNetUser,
                                         command.Password);

            return result;
        }

        private async Task<IdentityResult> AddRoleToUser(CreateEmployeeCommand command)
        {
            IdentityResult result = null;

            var aspNetUser = await _userManager
                                    .FindByNameAsync(command.UserName);

            //Verifica si el Role existe
            if (!_roleManager.RoleExistsAsync(command.Role.ToString()).Result)
            {
                result = await _roleManager.CreateAsync(new IdentityRole()
                {
                    Name = command.Role.ToString(),
                    NormalizedName = command.Role.ToString(),
                });
            }

            //Agrega Role a Usuario
            result = await _userManager
                            .AddToRoleAsync(aspNetUser,
                                            command.Role.ToString());



            return result;
        }

        private async Task SendEmailConfirmation(CreateEmployeeCommand command)
        {

            var aspNetUser = await _userManager
                                    .FindByNameAsync(command.UserName);

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
