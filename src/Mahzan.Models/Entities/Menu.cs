using System;
using System.Collections.Generic;
using System.Text;

namespace Mahzan.Models.Entities
{
    public class Menu
    {
        public Guid RoleId { get; set; }

        public Guid MenuItemId { get; set; }

        public Guid MenuSubItemId { get; set; }

    }
}
