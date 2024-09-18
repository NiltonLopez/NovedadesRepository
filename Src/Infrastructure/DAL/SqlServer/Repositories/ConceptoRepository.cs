using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Novedades.DAL.Interfaces;
using Novedades.DAL.SqlServer.DataContext;
using Novedades.DAL.SQLServer.Entities;
using Novedades.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Novedades.DAL.SqlServer.Repositories
{
    public class ConceptoRepository : IConceptoRepository
    {
        private readonly WebContext _dbcontext;
        private readonly IMapper mapper;

        public ConceptoRepository(WebContext dbcontext,
                                  IMapper mapper)
        {
            _dbcontext = dbcontext;
            this.mapper = mapper;
        }

        public async Task<Concepto> ObtenerConceptoPorId(int idConcepto)
        {
            Concepto concepto = mapper.Map<Concepto>(await _dbcontext.Cptwebs.FirstOrDefaultAsync(x => x.ID == idConcepto));

            if (concepto == null)
            {
                throw new ArgumentException("Concepto no Encontrado");
            }

            return concepto;
        }

        public async Task<string> ObtenerCodigoConceptoPorId(int id)
        {
            CptwebEntidad concepto = await _dbcontext.Cptwebs.FirstOrDefaultAsync(x => x.ID.Equals(id));

            string codigoConcepto = concepto.Concepto;

            return codigoConcepto;
        }

        public async Task<string> ObtenerDescripcionConceptoPorId(int id)
        {
            CptwebEntidad concepto = await _dbcontext.Cptwebs.FirstOrDefaultAsync(x => x.ID.Equals(id));

            string descripcionConcepto = concepto.Descripcion;

            return descripcionConcepto;
        }

        public async Task<IEnumerable<Concepto>> ObtenerTodos()
        {
            List<CptwebEntidad> conceptos = await _dbcontext.Cptwebs.ToListAsync();

            IEnumerable<Concepto> conceptosMapeados = mapper.Map<IEnumerable<Concepto>>(conceptos);

            return mapper.Map<IEnumerable<Concepto>>(conceptos);
        }
    }
}
