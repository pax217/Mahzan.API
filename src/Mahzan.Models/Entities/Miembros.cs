using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mahzan.Models.Entities
{
    public class Members
    {
        /// <summary>
        /// Identificador unico de Miembro
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid MembersId { get; set; }
        /// <summary>
        /// Nombre del miembro
        /// </summary>
        [Required, MaxLength(100)]
        public string Name { get; set; }
        /// <summary>
        /// Telefono del Miembro
        /// </summary>
        [Required, MaxLength(18)]
        public string Phone { get; set; }
        /// <summary>
        /// Email del Miembro
        /// </summary>
        [Required, MaxLength(50)]
        public string Email { get; set; }

        [Required]
        public string UserName { get; set; }

        [Required]
        public Guid AspNetUsersId { get; set; }

    }
}
