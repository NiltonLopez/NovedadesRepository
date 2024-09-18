using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Novedades.Models
{
    public class Calendario2
    {
        public string? Compania { get; set; }

        public string? TipoNomina { get; set; }

        public string? ClaseNomina { get; set; }

        public string? Ano { get; set; }

        public string? Mes { get; set; }

        public string? Periodo { get; set; }

        public string? Descripcion { get; set; }

        public DateTime? FechaInicial { get; set; }

        public DateTime? FechaFinal { get; set; }
    }
}
