using System;
using System.Collections.Generic;
using System.Text;

namespace Mahzan.Dapper.Exceptions.Taxes
{
    public class TaxArgumentException : ArgumentException
    {
        public TaxArgumentException(string message) : base(message) { }
    }
}
