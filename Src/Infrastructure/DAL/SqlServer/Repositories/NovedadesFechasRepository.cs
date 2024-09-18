using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Novedades.DAL.Interfaces;
using Novedades.DAL.SqlServer.DataContext;
using Novedades.DAL.SQLServer.Entities;
using Novedades.Models;

namespace Novedades.DAL.SqlServer.Repositories
{
    public class NovedadesFechasRepository : INovedadFechasRepository
    {
        private readonly WebContext _dbcontext;
        private readonly IMapper mapper;

        public NovedadesFechasRepository(WebContext context,
                                        IMapper mapper)
        {
            _dbcontext = context;
            this.mapper = mapper;
        }
        public async Task<bool> Actualizar(NovedadFechas modelo)
        {
            _dbcontext.Nvnwebs.Update(mapper.Map<NvnwebEntidad>(modelo));

            return (await _dbcontext.SaveChangesAsync()) > 0;
        }

        public async Task<bool> Eliminar(int id)
        {
            NvnwebEntidad modelo = await _dbcontext.Nvnwebs.FindAsync(id);
            _dbcontext.Nvnwebs.Remove(modelo);
            
            return (await _dbcontext.SaveChangesAsync()) > 0;
        }

        public async Task<bool> Insertar(NovedadFechas modelo)
        {
            _dbcontext.Nvnwebs.Add(mapper.Map<NvnwebEntidad>(modelo));

            return (await _dbcontext.SaveChangesAsync()) > 0;
        }

        public async Task<NovedadFechas> Obtener(int id)
        {
            NovedadFechas  novedadEntidad = mapper.Map<NovedadFechas>(await _dbcontext.Nvnwebs.FirstOrDefaultAsync(x => x.Idnvn == id)); 

            return novedadEntidad;
        }

        public Task<int?> ObtenerIdUltimaNovedad()
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<NovedadFechas>> ObtenerTodos(string centroCosto, string compania)
        {
            var Query = await (from novedad in _dbcontext.Nvnwebs
                               join concepto in _dbcontext.Cptwebs
                               on novedad.Idcpt equals concepto.ID
                               where (concepto.Tipo == "3" ||
                                      concepto.Tipo == "4") 
                                      && novedad.Ccosto == centroCosto
                                      && novedad.Compania == compania
                               select novedad)
                           .ToListAsync();

            return mapper.Map<IEnumerable<NovedadFechas>>(Query);
        }
    }
}
