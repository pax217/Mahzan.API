using System;
using Mahzan.DataAccess.DTO._Base;

namespace Mahzan.DataAccess.DTO.Stores
{
    public class DeleteStoresDto:BaseDto
    {
        public Guid StoresId { get; set; }
    }
}
