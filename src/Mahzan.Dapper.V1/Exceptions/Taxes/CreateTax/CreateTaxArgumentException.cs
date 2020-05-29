using System;
using System.Collections.Generic;
using System.Text;

namespace Mahzan.Dapper.Exceptions.Taxes.CreateTax
{
    public class CreateTaxArgumentException : ArgumentException
    {
        public CreateTaxArgumentException(string message) : base(message)
        {
        }
    }
}
