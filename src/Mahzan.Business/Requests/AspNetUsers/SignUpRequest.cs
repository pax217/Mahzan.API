using System;
using System.ComponentModel.DataAnnotations;
using Mahzan.Business.Enums.AspNetRoles;

namespace Mahzan.Business.Requests.AspNetUsers
{
    public class SignUpRequest
    {
        [Required(ErrorMessage = "El Nombre es requerido.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "El Usuario es requerido.")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "La contraseña es requerida.")]
        public string Password { get; set; }

        [Required(ErrorMessage = "El Correo Electronico es requerido.")]
        [EmailAddress(ErrorMessage = "Formato de Correo Electronico no valido.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "El Teléfono es requerido.")]
        [MaxLength(ErrorMessage = "La longitud méxima del Teléfono es de 18.")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "El Rol es requerido.")]
        public RoleEnum Role { get; set; }
   
    }
}
