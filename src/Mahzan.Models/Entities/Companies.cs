using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mahzan.Models.Entities
{
    public class Companies
    {
        #region Properties

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
        /// Indica si el registro se encuentra activo
        /// </summary>
        public bool Active { get; set; }

        #endregion

        #region Relations

        /// <summary>
        /// Llave foránea a Grupos
        /// </summary>
        public Guid GroupsId { get; set; }
        /// <summary>
        /// Navegación a Grupos
        /// </summary>
        public Groups Groups { get; set; }

        /// <summary>
        /// Llave foránea a Miembros
        /// </summary>
        public Guid MembersId { get; set; }
        #endregion
    }
}
