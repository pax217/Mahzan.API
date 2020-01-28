using System;
using Mahzan.Business.Results._Base;

namespace Mahzan.Business.Results.Stores
{
    public class AddStoresResult:Result
    {
        public Models.Entities.Stores Store { get; set; }
    }
}
