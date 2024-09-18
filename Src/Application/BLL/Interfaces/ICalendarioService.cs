using Novedades.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Novedades.BLL.Interfaces
{
    public interface ICalendarioService
    {
        Task<Calendario2> ObtenerCalendarioPorTipoNominaYClaseNomina(string tipoNomina, string claseNomina);
    }
}
