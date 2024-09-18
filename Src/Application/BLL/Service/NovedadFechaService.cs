using Novedades.BLL.Interfaces;
using Novedades.DAL.Interfaces;
using Novedades.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Novedades.BLL.Service
{
    public class NovedadFechaService : INovedadService<NovedadFechas>
    {
        private readonly INovedadFechasRepository novedadFechasRepository;

        public NovedadFechaService(INovedadFechasRepository novedadFechasRepository)
        {
            this.novedadFechasRepository = novedadFechasRepository;
        }

        public async Task<bool> ActualizarNovedad(NovedadFechas modelo)
        {
            return await novedadFechasRepository.Actualizar(modelo);
        }

        public async Task<bool> EliminarNovedad(int id)
        {
            return await novedadFechasRepository.Eliminar(id);
        }

        public async Task<bool> InsertarNovedad(NovedadFechas modelo)
        {
            return await novedadFechasRepository.Insertar(modelo);
        }

        public Task<int?> ObtenerIdUltimaNovedad()
        {
            throw new NotImplementedException();
        }

        public async Task<NovedadFechas> ObtenerNovedadPorId(int id)
        {
            return await novedadFechasRepository.Obtener(id);
        }

        public async Task<IEnumerable<NovedadFechas>> ObtenerTodasNovedades(string centroCosto, string compania)
        {
            var novedadFechas = await novedadFechasRepository.ObtenerTodos(centroCosto, compania);
            //TODO: Se debe agregar información de concepto para mostrarle dentro de la novedad
            return novedadFechas;
        }
    }
}
