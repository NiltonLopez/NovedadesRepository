using Novedades.Models;

namespace Novedades.DAL.Interfaces
{
    public interface ICalendarioRepository
    {
        Task<Calendario2> ObtenerCalendarioPorTipoNominaYClaseNomina(string tipoNomina, string ClaseNomina);
    }
}
