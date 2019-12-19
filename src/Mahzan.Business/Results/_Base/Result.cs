using System;
using Mahzan.Business.Enums.Result;

namespace Mahzan.Business.Results._Base
{
    public class Result
    {
        public bool IsValid { get; set; }
        public int StatusCode { get; set; }
        public ResultTypeEnum ResultTypeEnum { get; set; }
        public string Title { get; set; }
        public string Message { get; set; }
    }
}
