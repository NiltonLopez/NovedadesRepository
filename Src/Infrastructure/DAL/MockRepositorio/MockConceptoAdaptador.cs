using Novedades.DAL.Interfaces;
using Novedades.Models;

namespace Novedades.DAL.MockRepositorio
{
    public class MockConceptoAdaptador : IConceptoRepository
    {

        List<Concepto> Conceptos;

        public MockConceptoAdaptador()
        {
            Conceptos = new()
            {
                new Concepto(1,"1","1","AGUINALDO", "VALOR"),
                new Concepto(2,"1","2", "HORAS EXTRAS", "HORAS"),
                new Concepto(3,"2","3","VACACIONES", "FECHAS"),
                new Concepto(4,"2","4","BONIFICACIÓN ", "VALOR"),
                new Concepto(5,"1","5","SALIDA TEMPRANO", "HORAS"),
                new Concepto(6,"1","6","VIAJE DE TRABAJO", "FECHAS"),
            };

        }

        public async Task<Concepto?> ObtenerConceptoPorId(int conceptoId)
        {
            return await Task.Run(() => 
            {
                return Conceptos.FirstOrDefault(x => x.IdConcepto == conceptoId);
            });
        }

        public Task<string?> ObtenerDescripcionConceptoPorId(int conceptoId)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Concepto>> ObtenerTodos()
        {
            return await Task.Run(() =>
            {
                return Conceptos;
            });
        }

    }
}
