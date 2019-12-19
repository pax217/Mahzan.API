using System;
using Mahzan.Business.Requests._Base;

namespace Mahzan.Business.Requests.Grupos
{
    public class AddGrupoRequest:BaseRequest
    {
        public string Nombre { get; set; }
        public bool Active { get; set; }
    }
}
