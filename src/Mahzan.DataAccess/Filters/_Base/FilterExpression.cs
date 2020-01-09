using System;
using System.Reflection;
using Mahzan.Models.Enums.Expressions;

namespace Mahzan.DataAccess.Filters._Base
{
    public class FilterExpression
    {
        public PropertyInfo PropertyInfo { get; set; }
        public string PropertyName { get; set; }
        public OperationsEnum Operator { get; set; }
        public object Value { get; set; }
    }
}
