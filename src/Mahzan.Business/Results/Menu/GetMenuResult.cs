using System;
using System.Collections.Generic;
using Mahzan.Business.Results._Base;
using Newtonsoft.Json;

namespace Mahzan.Business.Results.Menu
{
    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public class GetMenuResult : Result
    {
        public Aside Aside { get; set; }
    }

    public class Aside
    {
        public List<Items> Items { get; set; }
}

    public class Items
    {
        public string Section { get; set; }

        public string Title { get; set; }

        public string Icon { get; set; }

        public string Bullet { get; set; }

        public string Page { get; set; }

        public bool? Root { get; set; }

        public List<SubMenu> SubMenu { get; set; }
    }

    public class SubMenu
    {

        public string Title { get; set; }

        public string Page { get; set; }
    }
}