using System;
using System.Collections.Generic;
using System.Linq;
using Mahzan.Business.Interfaces.Business;
using Mahzan.DataAccess.Interfaces;
using Mahzan.Models.Entities;

namespace Mahzan.Business.Implementations.Business
{
    public class MiembrosBusiness: IMiembrosBusiness
    {
        readonly IMiembrosRepository _miembrosRepository;

        public MiembrosBusiness(IMiembrosRepository miembrosRepository)
        {
            _miembrosRepository = miembrosRepository;
        }


        public Guid Get(string userName)
        {
            Guid result = Guid.Empty;

            List<Miembros> miembroExistente = _miembrosRepository
                                               .ObtienePorFiltro(
                                                    x => x.UserName
                                                          .Equals(userName)
                                               );

            if (miembroExistente != null)
                result = miembroExistente.FirstOrDefault().Id;


            return result;
        }
    }
}
