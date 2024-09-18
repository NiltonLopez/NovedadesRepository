using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Novedades.BLL.Interfaces;
using Novedades.BLL.Service;
using Novedades.Models;

namespace Novedades.AppWeb.Controllers
{
    public class EmpleadoController : Controller
    {
        private readonly IEmpleadoService _empleadoService;
        private readonly IMapper mapper;

        public EmpleadoController(IEmpleadoService empleadoService,
                                  IMapper mapper)
        {
            _empleadoService = empleadoService;
            this.mapper = mapper;
        }

        [HttpGet]
        //Método el cuál busca coincidencias y trae la lista de empleados por el centro de costos logeado y su id similar.
        public async Task<IActionResult> BuscarEmpleadoPorIDyCentroCostoYCompania(string idEmpleado)
        {

            string? centroCostoLogeado = HttpContext.Session.GetString("centroCosto");
            string? compania = HttpContext.Session.GetString("compania");

            IEnumerable<Empleado> empleados = await _empleadoService.BuscarEmpleadoPorIDyCentroCostoYCompania(idEmpleado, centroCostoLogeado, compania);

            if (empleados != null)
            {
                // Devolver el la lista de empleados coincidentesw como JSON
                return Ok(empleados);
            }

            // Si el concepto no se encuentra, devolver un mensaje de error
            return Json(new { Error = "Empleado no encontrado" });
        }

        [HttpGet]
        //Método el cuál obtiene el empleado por su id
        public async Task<IActionResult> ObtenerEmpleadoPorId(string idEmpleado)
        {
            Empleado? empleado = await _empleadoService.ObtenerPorId(idEmpleado);

            if (empleado != null)
            {
                // Devolver el la lista de empleados coincidentesw como JSON
                return Ok(empleado);
            }

            // Si el concepto no se encuentra, devolver un mensaje de error
            return Json(new { Error = "Empleado no encontrado" });
        }


    }
}
