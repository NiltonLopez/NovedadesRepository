using Novedades.DAL.SqlServer.DataContext;
using Novedades.Models;
using AutoMapper;
using Novedades.DAL.SqlServer.Entities;

namespace Novedades.DAL.SqlServer.Repositories
{
    public class NovedadesRepository : IGenericRepository<Novedad>
    {
        private readonly WebContext _dbcontext;
        private readonly IMapper mapper;


        public NovedadesRepository(WebContext context, IMapper mapper)
        {
            _dbcontext = context;
            this.mapper = mapper;
        }
        public async Task<bool> Actualizar(Novedad modelo)
        {
            _dbcontext.Nvnwebs.Update(mapper.Map<NvnwebEntidad>(modelo));
            await _dbcontext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Eliminar(int id)
        {
            NvnwebEntidad modeloParaElimiar = _dbcontext.Nvnwebs.First(x => x.Idnvn == id);

            if (modeloParaElimiar == null)
            {
                throw new ArgumentException("Producto no encontrado");
            }

            _dbcontext.Nvnwebs.Remove(modeloParaElimiar);
            await _dbcontext.SaveChangesAsync();
            return true;

        }

        public async Task<bool> Insertar(Novedad modelo)
        {
            var novedad = Novedades.Find(modelo);
            if (novedad == null)
                return false;
            Novedades.Remove(novedad);
            return true;

        }

        public async Task<Novedad?> Obtener(int id)
        {
            throw new NotImplementedException();

        }

        public async Task<IEnumerable<Novedad>> ObtenerTodos()
        {
            throw new NotImplementedException();

        }
    }
}
