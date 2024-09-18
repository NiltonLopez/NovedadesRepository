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
    public class EmpleadoRepository : IEmpleadoRepository
    {
        private readonly WebContext _dbcontext;
        private readonly IMapper mapper;

        public EmpleadoRepository(WebContext dbcontext,
                                  IMapper mapper)
        {
            _dbcontext = dbcontext;
            this.mapper = mapper;
        }
        public async Task<Empleado> ObtenerPorId(string idEmpleado)
        {
            Empleado empleado = mapper.Map<Empleado>(await _dbcontext.Emps.FirstOrDefaultAsync(emp => emp.Empleado == idEmpleado)); 

            if (empleado == null)
            throw new ArgumentException("Empleado No encontrado");

            return empleado;
        }

        public async Task<string> ObtenerNombrePorId(string idEmpleado)
        {
            EmpEntidad empleado = await _dbcontext.Emps.FirstOrDefaultAsync(x => x.Empleado == idEmpleado);

            string nombreEmpleado = empleado.Nombre +" "+ empleado.Apellido;

            return nombreEmpleado;
        }

        public async Task<IEnumerable<Empleado>> ObtenerTodos()
        {
            try
            {
                List<EmpEntidad> empleados = await _dbcontext.Emps.ToListAsync();

                IEnumerable<Empleado> empleadosMapeados = mapper.Map<IEnumerable<Empleado>>(await _dbcontext.Emps.ToListAsync());

                return mapper.Map<IEnumerable<Empleado>>(empleados);
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex);
                return null;
            }
            
            
        }

        public async Task<IEnumerable<Empleado>> BuscarEmpleadoPorIDyCentroCostoYCompania(string idEmpleado, string centroCostoLogeado, string compania)
        {
                // Suponiendo que tu clase DbContext se llama DBContext y tiene un DbSet llamado Emps
                List<EmpEntidad> empleados = await _dbcontext.Emps
                    .Where(e => e.Empleado.Contains(idEmpleado) && e.Ccosto == centroCostoLogeado && e.Compania == compania)
                    .ToListAsync();

                // Mapeamos los resultados a la clase Empleado
                IEnumerable<Empleado> empleadosMapeados = mapper.Map<IEnumerable<Empleado>>(empleados);

                return empleadosMapeados;        

        }


    }
}
