using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Novedades.AppWeb.Models.ViewModels.AgregarNovedades
{
    public class NuevaNovedadHoraVM //Se ponen los campos que se vayan a ver en el front
    {
        [Required] //Significa que es una propiedad necesaria para la inserción de datos
        public required string IdEmpleado { get; set; }


        [Required]
        public int IdConcepto { get; set; }


        public required string CodigoConcepto { get; set; }


        [Required]
        public int Horas { get; set; }


        public string TipoNomina { get; set; }


        public string ClaseNomina { get; set; }



        public string Observacion { get; set; }

    }
}