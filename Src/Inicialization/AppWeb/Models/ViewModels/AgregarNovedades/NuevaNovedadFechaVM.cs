using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Novedades.AppWeb.Models.ViewModels.AgregarNovedades
{
    public class NuevaNovedadFechaVM //Se ponen los campos que se vayan a ver
    {
        [Required] //Significa que es una propiedad necesaria para la inserción de datos
        public required string IdEmpleado { get; set; }


        [Required]
        public int IdConcepto { get; set; }


        public string CodigoConcepto { get; set; }


        [Required]
        public DateTime FechaInicial { get; set; }


        [Required]
        public DateTime FechaFinal { get; set; }


        public string TipoNomina { get; set; }


        public string ClaseNomina { get; set; }


        public string Observacion { get; set; }

    }
}
