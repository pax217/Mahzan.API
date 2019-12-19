using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mahzan.Models.Entities
{
    public class Grupos
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
        public string Nombre { get; set; }
        /// <summary>
        /// Indica si el resgitro esta activo
        /// </summary>
        [Required]
        public bool Activo { get; set; }
        /// <summary>
        /// Identificador único del Miembro
        /// </summary>
        [Required]
        public Guid MiembroId { get; set; }
    }
}
