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
    public class EmpleadoService : IEmpleadoService
    {
        private readonly IEmpleadoRepository empleadoRepository;


        public EmpleadoService(IEmpleadoRepository empleadoRepository)
        {
            this.empleadoRepository = empleadoRepository;
        }

        public async Task<IEnumerable<Empleado>> BuscarEmpleadoPorIDyCentroCostoYCompania(string idEmpleado, string CentroCostoLogeado, string compania)
        {
            return await empleadoRepository.BuscarEmpleadoPorIDyCentroCostoYCompania(idEmpleado, CentroCostoLogeado, compania);
        }

        public async Task<string> ObtenerNombrePorId(string idNombrePorId)
        {
            return await empleadoRepository.ObtenerNombrePorId(idNombrePorId);
        }

        public async Task<Empleado?> ObtenerPorId(string idEmpleado)
        {
            return await empleadoRepository.ObtenerPorId(idEmpleado);
        }

        public async Task<IEnumerable<Empleado>> ObtenerTodos()
        {
            return await empleadoRepository.ObtenerTodos();
        }
    }
}
