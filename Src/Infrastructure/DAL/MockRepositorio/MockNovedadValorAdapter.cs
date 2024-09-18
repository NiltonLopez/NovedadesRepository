using Novedades.DAL.Interfaces;
using Novedades.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Novedades.DAL.MockRepositorio
{
    public class MockNovedadValorAdapter : MockRepositoryBase<NovedadValor>, INovedadValorRepository
    {
        public async Task<bool> Eliminar(int id)
        {
            return await base.Eliminar(x => x.IdNovedad == id);
        }

        public async Task<NovedadValor?> Obtener(int id)
        {
            return await base.Obtener(x => x.IdNovedad == id);
        }


    }
}
