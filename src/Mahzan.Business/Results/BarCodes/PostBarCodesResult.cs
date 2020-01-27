using System;
using System.IO;
using Mahzan.Business.Results._Base;

namespace Mahzan.Business.Results.BarCodes
{
    public class PostBarCodesResult:Result
    {
        public MemoryStream FileStream { get; set; }
    }
}
