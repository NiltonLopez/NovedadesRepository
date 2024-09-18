using Novedades.BLL.Interfaces;
using Novedades.DAL.Interfaces;
using Novedades.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Novedades.BLL.Service
{
    public class ConceptoService : IConceptoService
    {
        private readonly IConceptoRepository conceptoRepository;

        public ConceptoService(IConceptoRepository conceptoRepository)
        {
            this.conceptoRepository = conceptoRepository;
        }


        public async Task<Concepto> ObtenerPorId(int id)
        {
            return await conceptoRepository.ObtenerConceptoPorId(id);
        }

        public async Task<string> ObtenerCodigoConceptoPorId(int id)
        {
            return await conceptoRepository.ObtenerCodigoConceptoPorId(id);
        }

        public async Task<string> ObtenerDescripcionConceptoPorId(int id)
        {
            return await conceptoRepository.ObtenerDescripcionConceptoPorId(id);
        }


        public async Task<IEnumerable<Concepto>> ObtenerTodosConceptos()
        {
            return await conceptoRepository.ObtenerTodos();
        }

    }
}
