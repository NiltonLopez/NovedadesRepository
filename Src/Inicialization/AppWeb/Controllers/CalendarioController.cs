using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Novedades.AppWeb.Models.ViewModels;
using Novedades.BLL.Interfaces;
using Novedades.BLL.Service;
using Novedades.Models;
using System.Reflection.Metadata;

namespace Novedades.AppWeb.Controllers
{
    public class CalendarioController : Controller
    {
        private readonly ICalendarioService _calendarioService;
        private readonly IMapper mapper;

        public CalendarioController(ICalendarioService calendarioService,
                                  IMapper mapper)
        {
            _calendarioService = calendarioService;
            this.mapper = mapper;
        }

        //Método que retorna a la vista por medio de un ViewModel las fechas iniciales y finales de un calendario
        [HttpGet]

        public async Task<IActionResult> ObtenerCalendarioPorTipoNominaYClaseNomina(string tipoNomina, string claseNomina)
        {
            CalendarioResumenVM calendario = mapper.Map<CalendarioResumenVM>(await _calendarioService.ObtenerCalendarioPorTipoNominaYClaseNomina(tipoNomina, claseNomina));


            return Ok(calendario);
        }


    }
}
