using AutoMapper;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Novedades.DAL.Interfaces;
using Novedades.DAL.SqlServer.DataContext;
using Novedades.DAL.SQLServer.Entities;
using Novedades.Models;

namespace Novedades.DAL.SqlServer.Repositories
{
    public class NovedadesHorasRepository : INovedadHorasRepository
    {
        private readonly WebContext _dbcontext;
        private readonly IMapper mapper;

        public NovedadesHorasRepository(WebContext context, IMapper mapper)
        {
            _dbcontext = context;
            this.mapper = mapper;
        }

        public async Task<bool> Actualizar(NovedadHoras modelo)
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

        public async Task<bool> Insertar(NovedadHoras modelo)
        {
            NvnwebEntidad nvnwebEntidad = mapper.Map<NvnwebEntidad>(modelo);
            await _dbcontext.Nvnwebs.AddAsync(nvnwebEntidad);

            return (await _dbcontext.SaveChangesAsync()) > 0;
        }

        public async Task<NovedadHoras> Obtener(int id)
        {
            NovedadHoras novedadEntidad = mapper.Map<NovedadHoras>(await _dbcontext.Nvnwebs.FirstOrDefaultAsync(x => x.Idnvn == id));

            return novedadEntidad;
        }

        public Task<int?> ObtenerIdUltimaNovedad()
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<NovedadHoras>> ObtenerTodos(string centroCosto, string compania)
        {
            
            try
            {
                var Query = await (from novedad in _dbcontext.Nvnwebs
                                   join concepto in _dbcontext.Cptwebs
                                   on novedad.Idcpt equals concepto.ID
                                   where (concepto.Tipo == "2"
                                   && novedad.Ccosto == centroCosto
                                   && novedad.Compania == compania)
                                   select novedad)
                           .ToListAsync();

                return mapper.Map<IEnumerable<NovedadHoras>>(Query);
            }
            catch (SqlException ex)
            {
                // Log or handle the SqlException
                Console.WriteLine($"SQL Error: {ex.Message}");
            }
            catch (Exception ex)
            {
                // Log or handle other exceptions
                Console.WriteLine($"Error: {ex.Message}");
            }

            throw new ArgumentException("Pailas");
        }

    }
}
