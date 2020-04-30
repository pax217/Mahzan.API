using System;
using System.Collections.Generic;
using System.Text;

namespace Mahzan.Dapper.V1.Exceptions.Clients
{
    public class InvalidClientArgumentDataException:ArgumentException
    {
        public InvalidClientArgumentDataException(string message) : base(message) { }
    }
}
