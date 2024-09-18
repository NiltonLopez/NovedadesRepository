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
    public class NovedadValorService : INovedadService<NovedadValor>
    {
        private readonly INovedadValorRepository novedadValorRepository;


        public  NovedadValorService(INovedadValorRepository novedadValorRepository)
        {
            this.novedadValorRepository = novedadValorRepository;
        }
        public async Task<bool> ActualizarNovedad(NovedadValor modelo)
        {
            return await novedadValorRepository.Actualizar(modelo);

        }

        public async Task<bool> EliminarNovedad(int id)
        {
            return await novedadValorRepository.Eliminar(id);

        }

        public async Task<bool> InsertarNovedad(NovedadValor modelo)
        {
            if (modelo.Valor <= 0)
            {
                return false;
            }
            return await novedadValorRepository.Insertar(modelo);
        }


        public async Task<NovedadValor> ObtenerNovedadPorId(int id)
        {
            return await novedadValorRepository.Obtener(id);
        }

        public async Task<IEnumerable<NovedadValor>> ObtenerTodasNovedades(string centroCosto, string compania)
        {
            var novedadesValor = await novedadValorRepository.ObtenerTodos(centroCosto, compania);
            //TODO: Se debe agregar información de concepto para mostrarle dentro de la novedad
            return novedadesValor;
        }

        async Task<int?> INovedadService<NovedadValor>.ObtenerIdUltimaNovedad()
        {
            return await novedadValorRepository.ObtenerIdUltimaNovedad();

        }
    }
}
