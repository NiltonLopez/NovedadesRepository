//using Novedades.Models;
//using Novedades.DAL.Interfaces;

//namespace Novedades.DAL.MockRepositorio
//{
//    public class MockEmpleadoAdaptador : IEmpleadoRepository
//    {
//        List<Empleado> Empleados;

//        public MockEmpleadoAdaptador()
//        {
//            Empleados = new()
//            {
//                new Empleado("1","Nilton López"),
//                new Empleado("2","Álvaro Ballesteros"),
//                new Empleado("3","Alejandro Osorio"),
//                new Empleado("4","Juan Esteban"),
//            };
//        }

//        public async Task<Empleado?> ObtenerEmpleadoPorId(string IdEmpleado)
//        {
//            return await Task.Run(() =>
//            {
//                return Empleados.FirstOrDefault(x => x.Id == IdEmpleado);
//            });
//        }

//    }
//}
