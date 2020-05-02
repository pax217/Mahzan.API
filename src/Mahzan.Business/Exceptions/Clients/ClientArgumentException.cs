using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Mahzan.Business.Exceptions.Clients
{
    public class ClientArgumentException : ArgumentException
    {
        public ClientArgumentException(string message) : base(message) { }
    }
}
