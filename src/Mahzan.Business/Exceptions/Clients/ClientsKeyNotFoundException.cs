using System;
using System.Collections.Generic;
using System.Text;

namespace Mahzan.Business.Exceptions.Clients
{
    public class ClientsKeyNotFoundException: KeyNotFoundException
    {
        public ClientsKeyNotFoundException(string message) : base(message) { }
    }
}
