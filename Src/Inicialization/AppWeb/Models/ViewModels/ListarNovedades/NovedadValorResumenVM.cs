using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Novedades.AppWeb.Models.ViewModels.ListarNovedade
{
    public class NovedadValorResumenVM //Campos que se van a mostrar en el grid.
    {
        [Required] //Significa que es una propiedad necesaria para la inserción de datos
        public required string IdEmpleado { get; set; }

        public required string NombreEmpleado { get; set; } = null!;

        public required string CodigoConcepto { get; set; }

        public required string DescripcionConcepto { get; set; }


        [Required]
        public double Valor { get; set; }
        

        public string Observacion { get; set; }


        public int IdConcepto { get; set; }


        public int IdNovedad { get; set; }


        // Propiedades internas que no serán visibles en la vista


    }
}

