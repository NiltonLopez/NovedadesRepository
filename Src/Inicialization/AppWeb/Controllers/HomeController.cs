using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.IdentityModel.Tokens;
using Novedades.AppWeb.Models;
using Novedades.AppWeb.Models.ViewModels;
using Novedades.BLL.Interfaces;
using Novedades.Models;

//using Novedades.DAL.Mongo;
using System.Diagnostics;

namespace Novedades.AppWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly IConceptoService _conceptoService;
        private readonly IMapper mapper;

        public HomeController(IConceptoService conceptoService,
                              IMapper mapper)
        {
            _conceptoService = conceptoService;
            this.mapper = mapper;
        }


        [HttpGet]
        //Método el cuál obtiene los conceptos creados
        public async Task<IActionResult> ObtenerConceptos()
        {
            IEnumerable<Concepto> conceptos = await _conceptoService.ObtenerTodosConceptos();

            List<SelectListItem> selectListItems
                = new();

            foreach (var item in conceptos)
            {
                selectListItems.Add(new SelectListItem() { Text = item.Descripcion, Value = item.IdConcepto.ToString(), Selected = false });
            }

            ViewBag.conceptos = selectListItems;

            return View();
        }



        public async Task<IActionResult> Index(string centroCosto, string compania)
        {

            if (centroCosto.IsNullOrEmpty() || compania.IsNullOrEmpty())
            {
                HttpContext.Session.SetString("centroCosto", "000223");
                HttpContext.Session.SetString("compania", "02");

                return await ObtenerConceptos();
            }

            HttpContext.Session.SetString("centroCosto", centroCosto);
            HttpContext.Session.SetString("compania", compania);

            return await ObtenerConceptos();
        }


        public IActionResult Login()
        {
            return View();
        }


        public IActionResult Home()
        {
            return View();
        }


        public IActionResult Historial()
        {
            return View();
        }


        public IActionResult Privacy()
        {
            return View();
        }


        public IActionResult Entrar(string usuario, string contrasena)
        {
            if (usuario.Equals("a") && contrasena.Equals("a"))
            {
                return View("Home");
            }
            else
            {
                ViewBag.ErrorMessage = "Usuario o contraseña incorrectos. Inténtalo de nuevo.";
                return View("Login");
            }
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}