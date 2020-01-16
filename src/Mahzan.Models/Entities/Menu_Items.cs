using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Mahzan.Models.Entities
{
    public class Menu_Items
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public string Section { get; set; }
        public string Title { get; set; }
        public bool? Root { get; set; }
        public string Icon { get; set; }
        public string Page { get; set; }
        public string Bullet { get; set; }
        public int Order { get; set; }

        public List<Menu_SubItems> Menu_SubItems { get; set; }
    }
}
