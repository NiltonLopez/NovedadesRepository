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
    public class CalendarioService : ICalendarioService
    {
        private readonly ICalendarioRepository calendarioRepository;

        public CalendarioService(ICalendarioRepository calendarioRepository)
        {
            this.calendarioRepository = calendarioRepository;
        }

        public async Task<Calendario2> ObtenerCalendarioPorTipoNominaYClaseNomina(string tipoNomina, string claseNomina)
        {
            return await calendarioRepository.ObtenerCalendarioPorTipoNominaYClaseNomina(tipoNomina, claseNomina);
        }
    }
}
