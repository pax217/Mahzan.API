using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mahzan.Models.Entities
{
    public class Companies
    {
        /// <summary>
        /// Identificador único del Empresa
        /// </summary>
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid CompaniesId { get; set; }
        /// <summary>
        /// Registro Federal de Contribuyentes
        /// </summary>
        [Required, MaxLength(13)]
        public string RFC { get; set; }
        /// <summary>
        /// Nombre Comercial de la Empresa
        /// </summary>
        [MaxLength(100)]
        public string CommercialName { get; set; }
        /// <summary>
        /// Razón Social de la Empresa
        /// </summary>
        [Required, MaxLength(250)]
        public string BusinessName { get; set; }
        /// <summary>
        /// Indica si el registro esta activo
        /// </summary>
        [Required]
        public bool Active { get; set; }


        //Groups
        public Guid GroupsId { get; set; }

        public Groups Groups { get; set; }

    }
}
