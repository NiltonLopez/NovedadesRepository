using Novedades.DAL.Interfaces;
using Novedades.Models;

namespace Novedades.DAL.MockRepositorio
{
    public class MockNovedadFechaAdaptador : MockRepositoryBase<NovedadFechas>, INovedadFechasRepository
    {
        public async Task<bool> Eliminar(int id)
        {
            return await base.Eliminar(x => x.IdNovedad == id);
        }

        public async Task<NovedadFechas?> Obtener(int id)
        {
            return await base.Obtener(x => x.IdNovedad == id);
        }
    }
}
