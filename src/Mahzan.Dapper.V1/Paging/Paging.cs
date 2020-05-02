﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Mahzan.Dapper.Paging
{
    public class Paging
    {
        public int TotalCount { get; set; }
        public int PageSize { get; set; }
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
        public bool HasNext { get; set; }
        public bool HasPrevious { get; set; }
    }
}
