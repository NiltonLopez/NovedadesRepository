using Novedades.Models;

namespace Novedades.BLL.Interfaces
{
    public interface IConceptoService
    {
        Task<Concepto> ObtenerPorId(int id);

        Task<string> ObtenerCodigoConceptoPorId(int id);

        Task<string> ObtenerDescripcionConceptoPorId(int id);

        Task<IEnumerable<Concepto>> ObtenerTodosConceptos();



    }
}
