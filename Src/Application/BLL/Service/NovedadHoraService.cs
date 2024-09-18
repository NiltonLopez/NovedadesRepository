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
    public class NovedadHoraService : INovedadService<NovedadHoras>
    {
        private readonly INovedadHorasRepository novedadHorasRepository;

        public NovedadHoraService(INovedadHorasRepository novedadHorasRepository)
        {
            this.novedadHorasRepository = novedadHorasRepository;
        }
        public async Task<bool> ActualizarNovedad(NovedadHoras modelo)
        {
            return await novedadHorasRepository.Actualizar(modelo);

        }

        public async Task<bool> EliminarNovedad(int id)
        {
            return await novedadHorasRepository.Eliminar(id);
        }

        public async Task<bool> InsertarNovedad(NovedadHoras modelo)
        {
            if (modelo.Horas <= 0)
            {
                return false;
            }
            return await novedadHorasRepository.Insertar(modelo);
        }

        public Task<int?> ObtenerIdUltimaNovedad()
        {
            throw new NotImplementedException();
        }

        public async Task<NovedadHoras> ObtenerNovedadPorId(int id)
        {
            return await novedadHorasRepository.Obtener(id);
        }

        public async Task<IEnumerable<NovedadHoras>> ObtenerTodasNovedades(string centroCosto, string compania)
        {
            var novedadHoras = await novedadHorasRepository.ObtenerTodos(centroCosto, compania);
            //TODO: Se debe agregar información de concepto para mostrarle dentro de la novedad
            return novedadHoras;
        }
    }
}
