using Novedades.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Novedades.DAL.Interfaces
{
    public interface IEmpleadoRepository
    {
        Task<Empleado> ObtenerPorId(string idEmpleado);

        Task<string> ObtenerNombrePorId(string idEmpleado);

        Task<IEnumerable<Empleado>> ObtenerTodos();

        Task<IEnumerable<Empleado>> BuscarEmpleadoPorIDyCentroCostoYCompania(string idEmpleado, string centroCostoLogeado, string compania);
    }
}
