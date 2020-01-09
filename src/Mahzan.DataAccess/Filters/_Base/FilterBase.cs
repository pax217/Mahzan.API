﻿using System;
using System.Reflection;
using Mahzan.Models.Enums.Expressions;

namespace Mahzan.DataAccess.Filters._Base
{
    public class FilterBase
    {
        const int maxPageSize = 50;
        public int PageNumber { get; set; } = 1;

        private int _pageSize = 10;
        public int PageSize
        {
            get
            {
                return _pageSize;
            }
            set
            {
                _pageSize = (value > maxPageSize) ? maxPageSize : value;
            }
        }
    }
}
