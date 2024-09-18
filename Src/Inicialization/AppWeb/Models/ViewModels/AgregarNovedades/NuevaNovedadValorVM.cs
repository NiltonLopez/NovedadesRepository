using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Novedades.AppWeb.Models.ViewModels.AgregarNovedades
{
    public class NuevaNovedadValorVM //Se ponen los campos que se pretender mostrar al cliente (la vista)
    {
        [Required] //Significa que es una propiedad necesaria para la inserción de datos
        public required string IdEmpleado { get; set; }



        [Required]
        public int IdConcepto { get; set; }


        public string CodigoConcepto { get; set; }


        [Required]
        public double Valor { get; set; }


        public string Observacion { get; set; }


        public string TipoNomina { get; set; }


        public string ClaseNomina { get; set; }


    }
}
