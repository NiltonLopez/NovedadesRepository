using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Novedades.Models
{
    public class Empleado
    {
        public Empleado()
        {
            
        }
        public Empleado(string idEmpleado,
                        string nombre,
                        string apellido,
                        string tipoNomina,
                        string claseNomina,
                        string idCentroCosto)
        {
            Id = idEmpleado;
            Nombre = nombre;
            Apellido = apellido;
            TipoNomina = tipoNomina;
            ClaseNomina = claseNomina;
            IdCentroCosto = idCentroCosto;
        }

        public string? Id { get; set; }
        public string? Nombre { get; set; }
        public string? Apellido { get; set; }
        public string? TipoNomina { get; set; }
        public string? ClaseNomina { get; set; }
        public string? IdCentroCosto { get; set; }
    }
}
