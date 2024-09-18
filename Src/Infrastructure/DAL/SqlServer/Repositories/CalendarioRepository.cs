using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Novedades.DAL.Interfaces;
using Novedades.DAL.SqlServer.DataContext;
using Novedades.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Novedades.DAL.SqlServer.Repositories
{
    public class CalendarioRepository : ICalendarioRepository
    {
        private readonly WebContext _webContext;
        private readonly IMapper mapper;

        public CalendarioRepository(WebContext webContext
                                    ,IMapper mapper)
        {
            _webContext = webContext;
            this.mapper = mapper;
        }
        public async Task<Calendario2> ObtenerCalendarioPorTipoNominaYClaseNomina(string tipoNomina, string ClaseNomina)
        {
            Calendario2 calendarioActual = mapper.Map<Calendario2>(await _webContext.Cprweb2s.FirstOrDefaultAsync(x => x.TipoNom == tipoNomina
                                                                                                                    && x.ClaseNom == ClaseNomina));
            return calendarioActual;
        }
    }
}
