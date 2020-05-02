using System;
using System.Collections.Generic;
using System.Text;

namespace Mahzan.Dapper.Exceptions.Clients
{
    public class ClientArgumentDataException:ArgumentException
    {
        public ClientArgumentDataException(string message) : base(message) { }
    }
}
