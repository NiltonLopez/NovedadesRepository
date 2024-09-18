using Novedades.DAL.Interfaces;
using Novedades.Models;

namespace Novedades.DAL.MockRepositorio
{
    public class MockNovedadHorasAdaptador : MockRepositoryBase<NovedadHoras>, INovedadHorasRepository
    {
        public async Task<bool> Eliminar(int id)
        {
            return await base.Eliminar(x => x.IdNovedad == id);
        }

        public async Task<NovedadHoras?> Obtener(int id)
        {
            return await base.Obtener(x => x.IdNovedad == id);
        }
    }
}
