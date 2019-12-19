using System;
using System.Threading.Tasks;
using Mahzan.Business.Results.Miembros;

namespace Mahzan.Business.Interfaces.Business
{
    public interface IMiembrosBusiness
    {
        //Task<AddMiembroResult> Add(MiembrosDto miembroDto);

        Guid Get(string userName);
    }
}
