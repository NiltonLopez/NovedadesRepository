using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Novedades.BLL.Interfaces;
using Novedades.BLL.Service;
using Novedades.Models;

namespace Novedades.AppWeb.Controllers
{
    public class ConceptoController : Controller
    {
        private readonly IConceptoService _conceptoService;
        private readonly IMapper mapper;

        public ConceptoController(IConceptoService conceptoService,
                                  IMapper mapper)
        {
            _conceptoService = conceptoService;
            this.mapper = mapper;
        }


        [HttpGet]
        // Método que recibe el ID del concepto y devuelve su TipoConcepto
        public async Task<IActionResult> ObtenerConceptoPorId(int idConcepto)
        {
            Concepto concepto = await _conceptoService.ObtenerPorId(idConcepto);

            if (concepto != null)
            {
                // Devolver el TipoConcepto como JSON
                return Ok(concepto);
            }

            // Si el concepto no se encuentra, devolver un mensaje de error
            return Json(new { Error = "Concepto no encontrado" });
        }




        [HttpGet]
        // Método que recibe el ID del concepto y devuelve su TipoConcepto
        public async Task<IActionResult> ObtenerTipoConceptoPorId(int idConcepto)
        {
            Concepto concepto = await _conceptoService.ObtenerPorId(idConcepto);

            if (concepto != null)
            {
                // Devolver el TipoConcepto como JSON
                return Json(new { TipoConcepto = concepto.Tipo });
            }

            // Si el concepto no se encuentra, devolver un mensaje de error
            return Json(new { Error = "Concepto no encontrado" });
        }


        [HttpGet]
        // Método que recibe el ID del concepto y devuelve su TipoConcepto
        public async Task<IActionResult> ObtenerCodigoConceptoPorIdConcepto(int id)
        {
            string codigoConcepto = await _conceptoService.ObtenerCodigoConceptoPorId(id);

            if (codigoConcepto != null)
            {
                // Devolver el codigoConcepto como JSON
                return Json(new { codigoConcepto = codigoConcepto });
            }

            // Si el concepto no se encuentra, devolver un mensaje de error
            return Json(new { Error = "Concepto no encontrado" });
        }

    }
}
