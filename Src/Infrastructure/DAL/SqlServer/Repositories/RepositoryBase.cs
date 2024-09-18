using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Novedades.DAL.SqlServer.DataContext;
using Novedades.DAL.SQLServer.Entities;
using Novedades.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using ZstdSharp;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Novedades.DAL.SqlServer.Repositories
{
    public class RepositoryBase<TEntityModel> where TEntityModel : class
    {
        private readonly WebContext context;
        private readonly Mapper mapper;

        public RepositoryBase(WebContext context, Mapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<bool> Insertar(Novedad modelo)
        {
                // Validar datos de entrada
                if (modelo == null)
                {
                    throw new ArgumentException("la novedad es obligatoria.");
                }
                await context.Nvnwebs.AddAsync(mapper.Map<NvnwebEntidad>(modelo));
                await context.SaveChangesAsync();
                return true; // Indicar que la inserción fue exitosa
        }

        public async Task<bool> Eliminar(int idNovedad)
        {

            NvnwebEntidad modelo = mapper.Map<NvnwebEntidad>(await context.Nvnwebs.FirstOrDefaultAsync(x => x.Idnvn == idNovedad));

            context.Nvnwebs.Remove(modelo);
            context.SaveChanges();

            return true;

        }

        public Task<bool> Actualizar(TEntityModel modelo)
        {
            throw new NotImplementedException();
        }

        public async Task<TEntityModel> Obtener(int id)
        {
            NvnwebEntidad novedadEntidad = await context.Nvnwebs.FirstOrDefaultAsync(x => x.Idnvn == id);
            if (novedadEntidad == null)
                throw new ArgumentException("la novedad no se encontró.");


            return mapper.Map<TEntityModel>(novedadEntidad);
        }

        public async Task<IEnumerable<TEntityModel>> ObtenerTodos(TEntityModel modelo)
        {
            var queryNovedadSQL = await context.Nvnwebs.ToListAsync();
            return mapper.Map<IEnumerable<TEntityModel>>(queryNovedadSQL);
        }

    }
}
