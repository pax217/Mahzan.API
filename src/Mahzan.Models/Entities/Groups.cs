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
        public Guid Id { get; set; }
        /// <summary>
        /// Nombre del miembro
        /// </summary>
        [Required, MaxLength(100)]
        public string Name { get; set; }
        /// <summary>
        /// Indica si el resgitro esta activo
        /// </summary>
        [Required]
        public bool Active { get; set; }
        /// <summary>
        /// Identificador único del Miembro
        /// </summary>
        [Required]
        public Guid MemberId { get; set; }

    }
}
