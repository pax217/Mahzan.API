using System;
using System.ComponentModel.DataAnnotations;
using Mahzan.Business.Enums.AspNetRoles;

namespace Mahzan.Business.Requests.Employees
{
    public class PostEmployeesRequest
    {
        public string CodeEmploye { get; set; }

        [Required(ErrorMessage = "El Primer Nombre es requerido.")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "El Segundo Nombre es requerido.")]
        public string SecondName { get; set; }
        [Required(ErrorMessage = "El Apellido Paterno es requerido.")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "El Apellido Materno es requerido.")]
        public string SureName { get; set; }
        [Required(ErrorMessage = "El Correo Electronico es requerido.")]
        [EmailAddress(ErrorMessage = "Formato de Correo Electronico no valido.")]
        public string Email { get; set; }

        public string Phone { get; set; }
        [Required(ErrorMessage = "El Usuario es requerido.")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "El Password es requerido.")]
        public string Password { get; set; }

        public RoleEnum Role { get; set; }
    }
}
