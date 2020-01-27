using System;
using System.Collections.Generic;
using Mahzan.DataAccess.DTO._Base;

namespace Mahzan.DataAccess.DTO.BarCodes
{
    public class CreateBarCodesDto:BaseDto
    {
        public List<Guid> ProductsIds { get; set; }
        
    }
}
