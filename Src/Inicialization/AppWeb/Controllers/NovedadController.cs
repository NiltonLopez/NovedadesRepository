using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Novedades.AppWeb.Models.ViewModels;
using Novedades.AppWeb.Models.ViewModels.AgregarNovedades;
using Novedades.AppWeb.Models.ViewModels.ListarNovedade;
using Novedades.BLL.Interfaces;
using Novedades.BLL.Service;
using Novedades.Models;

namespace Novedades.AppWeb.Controllers
{
    public class NovedadController : Controller
    {
        private readonly INovedadService<NovedadValor> _novedadValorService;
        private readonly INovedadService<NovedadHoras> _novedadHorasService;
        private readonly INovedadService<NovedadFechas> _novedadFechasService;
        private readonly IEmpleadoService _empleadoService;
        private readonly IConceptoService _conceptoService;
        private readonly ICalendarioService _calendarioService;
        private readonly IMapper mapper;

        public NovedadController(IEmpleadoService empleadoService,
                              IConceptoService conceptoService,
                              ICalendarioService calendarioService,
                              INovedadService<NovedadValor> novedadValorService,
                              INovedadService<NovedadHoras> novedadHorasService,
                              INovedadService<NovedadFechas> novedadFechasService,
                              IMapper mapper)
        {
            _empleadoService = empleadoService;
            _conceptoService = conceptoService;
            _calendarioService = calendarioService;
            _novedadValorService = novedadValorService;
            _novedadHorasService = novedadHorasService;
            _novedadFechasService = novedadFechasService;
            this.mapper = mapper;
        }


        #region EndPoints de novedadedes de tipo Valor
        [HttpPost]
        public async Task<IActionResult> InsertarNovedadValor([FromBody] NuevaNovedadValorVM modelo)
        {

            try
            {
                NovedadValor NuevoModeloValor = mapper.Map<NovedadValor>(modelo);
                Calendario2 calendario = await _calendarioService.ObtenerCalendarioPorTipoNominaYClaseNomina(NuevoModeloValor.TipoNomina, NuevoModeloValor.ClaseNomina);

                // Asignamos valores adicionales que no vienen del cliente
                NuevoModeloValor.Periodo = calendario.Periodo;
                NuevoModeloValor.Ano = (DateTime.UtcNow.Year).ToString();
                NuevoModeloValor.Mes = (DateTime.UtcNow.Month).ToString();
                NuevoModeloValor.IdCentroCosto = HttpContext.Session.GetString("centroCosto");
                NuevoModeloValor.IdCompania = HttpContext.Session.GetString("compania");

                bool respuesta = await _novedadValorService.InsertarNovedad(NuevoModeloValor);

                return StatusCode(StatusCodes.Status200OK, NuevoModeloValor);

            }
            catch (Exception ex)
            {

                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }

        }


        //Endpoint
        [HttpGet]
        public async Task<IActionResult> ObtenerNovedadesValor()
        {

            string? centroCosto = HttpContext.Session.GetString("centroCosto");
            string? compania = HttpContext.Session.GetString("compania");

            IEnumerable<NovedadValorResumenVM> NovedadesValor = mapper.Map<IEnumerable<NovedadValorResumenVM>>(await _novedadValorService.ObtenerTodasNovedades(centroCosto, compania));

            foreach (NovedadValorResumenVM item in NovedadesValor)
            {
                item.DescripcionConcepto = await _conceptoService.ObtenerDescripcionConceptoPorId(item.IdConcepto);
                item.NombreEmpleado = await _empleadoService.ObtenerNombrePorId(item.IdEmpleado);
            }

            return Ok(NovedadesValor);

        }

        [HttpGet]
        public async Task<IActionResult> ObtenerUltimaNovedadValor()
        {

            NovedadValorResumenVM novedadValor = mapper.Map<NovedadValorResumenVM>(await _novedadValorService.ObtenerIdUltimaNovedad());
            return Ok(novedadValor);

        }


        [HttpDelete]
        public async Task<IActionResult> EliminarNovedadValor([FromQuery] int idNovedad)
        {

            bool respuesta = await _novedadValorService.EliminarNovedad(idNovedad);

            return StatusCode(StatusCodes.Status200OK, new { valor = respuesta });
        }
        #endregion


        #region EndPoints de novedades de tipo Horas
        [HttpPost]
        public async Task<IActionResult> InsertarNovedadHoras([FromBody] NuevaNovedadHoraVM modelo)
        {
            try
            {
                NovedadHoras NuevoModeloHoras = mapper.Map<NovedadHoras>(modelo);

                // Asignamos valores adicionales que no vienen del cliente
                NuevoModeloHoras.Ano = (DateTime.UtcNow.Year).ToString();
                NuevoModeloHoras.Mes = (DateTime.UtcNow.Month).ToString();
                NuevoModeloHoras.IdCentroCosto = HttpContext.Session.GetString("centroCosto");
                NuevoModeloHoras.IdCompania = HttpContext.Session.GetString("compania");

                bool respuesta = await _novedadHorasService.InsertarNovedad(NuevoModeloHoras);

                return StatusCode(StatusCodes.Status200OK, NuevoModeloHoras);

            }
            catch (Exception ex)
            {

                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }

        [HttpGet]
        public async Task<IActionResult> ObtenerNovedadesHoras()
        {

            string? centroCosto = HttpContext.Session.GetString("centroCosto");
            string? compania = HttpContext.Session.GetString("compania");

            IEnumerable<NovedadHorasResumenVM> NovedadesHoras = mapper.Map<IEnumerable<NovedadHorasResumenVM>>(await _novedadHorasService.ObtenerTodasNovedades(centroCosto, compania));

            foreach (NovedadHorasResumenVM item in NovedadesHoras)
            {
                item.NombreEmpleado = await _empleadoService.ObtenerNombrePorId(item.IdEmpleado);
                item.DescripcionConcepto = await _conceptoService.ObtenerDescripcionConceptoPorId(item.IdConcepto);
            }
            return Ok(NovedadesHoras);
        }

        [HttpGet]
        public async Task<IActionResult> ObtenerUltimaNovedadHoras()
        {

            NovedadHorasResumenVM novedadHoras = mapper.Map<NovedadHorasResumenVM>(await _novedadHorasService.ObtenerIdUltimaNovedad());
            return Ok(novedadHoras);

        }

        [HttpDelete]
        public async Task<IActionResult> EliminarNovedadHoras([FromQuery] int idNovedad)
        {

            bool respuesta = await _novedadHorasService.EliminarNovedad(idNovedad);

            return StatusCode(StatusCodes.Status200OK, new { valor = respuesta });
        }
        #endregion


        #region EndPoints de novedades de tipo Fechas
        [HttpPost]
        public async Task<IActionResult> InsertarNovedadFechas([FromBody] NuevaNovedadFechaVM modelo)
        {
            try
            {
                NovedadFechas NuevoModeloFechas = mapper.Map<NovedadFechas>(modelo);

                // Asignamos valores adicionales que no vienen del cliente
                NuevoModeloFechas.Ano = (DateTime.UtcNow.Year).ToString();
                NuevoModeloFechas.Mes = (DateTime.UtcNow.Month).ToString();
                NuevoModeloFechas.IdCentroCosto = HttpContext.Session.GetString("centroCosto");
                NuevoModeloFechas.IdCompania = HttpContext.Session.GetString("compania");

                bool respuesta = await _novedadFechasService.InsertarNovedad(NuevoModeloFechas);

                return StatusCode(StatusCodes.Status200OK, NuevoModeloFechas);

            }
            catch (Exception ex)
            {

                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }

        [HttpGet]
        public async Task<IActionResult> ObtenerNovedadesFechas()
        {

            string? centroCosto = HttpContext.Session.GetString("centroCosto");
            string? compania = HttpContext.Session.GetString("compania");

            IEnumerable<NovedadFechasResumenVM> NovedadesFechas = mapper.Map<IEnumerable<NovedadFechasResumenVM>>(await _novedadFechasService.ObtenerTodasNovedades(centroCosto, compania));

            foreach (NovedadFechasResumenVM item in NovedadesFechas)
            {
                item.NombreEmpleado = await _empleadoService.ObtenerNombrePorId(item.IdEmpleado);
                item.DescripcionConcepto = await _conceptoService.ObtenerDescripcionConceptoPorId(item.IdConcepto);
            }
            return Ok(NovedadesFechas);
        }

        [HttpGet]
        public async Task<IActionResult> ObtenerUltimaNovedadFechas()
        {

            NovedadFechasResumenVM novedadFechas = mapper.Map<NovedadFechasResumenVM>(await _novedadHorasService.ObtenerIdUltimaNovedad());
            return Ok(novedadFechas);

        }


        [HttpDelete]
        public async Task<IActionResult> EliminarNovedadFechas([FromQuery] int idNovedad)
        {

            bool respuesta = await _novedadFechasService.EliminarNovedad(idNovedad);

            return StatusCode(StatusCodes.Status200OK, new { valor = respuesta });
        }
        #endregion

        [HttpGet]
        public async Task<IActionResult> ObtenerIdUltimaNovedad()
        {
            int? idNovedad = await _novedadValorService.ObtenerIdUltimaNovedad();
            return Ok(idNovedad);
        }
    }
}
