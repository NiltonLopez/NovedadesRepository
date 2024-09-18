using Novedades.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Novedades.BLL.Interfaces
{
    public interface IEmpleadoService
    {
        Task<Empleado?> ObtenerPorId(string idEmpleado);

        Task<string> ObtenerNombrePorId(string idNombrePorId);

        Task<IEnumerable<Empleado>> ObtenerTodos();

        Task<IEnumerable<Empleado>> BuscarEmpleadoPorIDyCentroCostoYCompania(string idEmpleado, string CentroCostoLogeado, string compania);
    }
}
