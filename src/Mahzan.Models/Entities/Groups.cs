using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mahzan.Models.Entities
{
    public class Groups
    {
        #region Properties

        /// <summary>
        /// Identificador único de Grupo
        /// </summary>
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid GroupsId { get; set; }

        /// <summary>
        /// Nombre del Grupo
        /// </summary>
        [Required, MaxLength(100)]
        public string Name { get; set; }

        /// <summary>
        /// Identificador único del  Miembro
        /// </summary>
        [Required]
        public Guid MembersId { get; set; }

        /// <summary>
        /// Indica si el registro se encuentra activo
        /// </summary>
        [Required]
        public bool Active { get; set; }

        #endregion
    }
}
