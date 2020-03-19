using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mahzan.Models.Entities
{
    public class Groups
    {
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
        public Guid MembersId { get; set; }

        /// <summary>
        /// Indica si se encuentra activo
        /// </summary>
        public bool Active { get; set; }
    }
}
