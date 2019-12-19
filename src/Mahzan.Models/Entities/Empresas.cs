using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mahzan.Models.Entities
{
    public class Empresas
    {
        /// <summary>
        /// Identificador único del Empresa
        /// </summary>
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        /// <summary>
        /// Registro Federal de Contribuyentes
        /// </summary>
        [Required, MaxLength(13)]
        public string RFC { get; set; }
        /// <summary>
        /// Nombre Comercial de la Empresa
        /// </summary>
        [MaxLength(100)]
        public string NombreComercial { get; set; }
        /// <summary>
        /// Razón Social de la Empresa
        /// </summary>
        [Required, MaxLength(250)]
        public string RazonSocial { get; set; }
        /// <summary>
        /// Indica si el registro esta activo
        /// </summary>
        [Required]
        public bool Activo { get; set; }
        /// <summary>
        /// Indica a que Grupo pertenece la Empresa
        /// </summary>
        [Required]
        public Guid GrupoId { get; set; }
        /// <summary>
        /// Identificador único del Miembro
        /// </summary>
        [Required]
        public Guid MiembroId { get; set; }
    }
}
