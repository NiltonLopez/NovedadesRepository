using Novedades.Models;

namespace Novedades.DAL.Interfaces
{
    public interface IConceptoRepository 
    {
        Task<Concepto> ObtenerConceptoPorId(int conceptoId);

        Task<string> ObtenerCodigoConceptoPorId(int id);

        Task<string> ObtenerDescripcionConceptoPorId(int id);


        Task<IEnumerable<Concepto>> ObtenerTodos();
    }
}
