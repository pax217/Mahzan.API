using System;
using System.Collections.Generic;
using System.Text;

namespace Mahzan.Business.Exceptions.Taxes
{
    public class TaxesKeyNotFoundException: KeyNotFoundException
    {
        public TaxesKeyNotFoundException(string message) : base(message) { }
    }
}
