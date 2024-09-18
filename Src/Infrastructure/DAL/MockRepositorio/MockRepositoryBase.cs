namespace Novedades.DAL.MockRepositorio
{
    public class MockRepositoryBase<T>
    {
        List<T> Novedades;
        int IdentificadorAutogenerado = 0;
        public MockRepositoryBase()
        {
            Novedades = new();
        }

        public Task<bool> Actualizar(T modelo)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> Eliminar(Predicate<T> match)
        {
            return await Task.Run(() =>
            {
                var novedad = Novedades.Find(match);
                if (novedad == null)
                    return false;
                Novedades.Remove(novedad);
                return true;
            });
        }

        public async Task<bool> Insertar(T modelo)
        {
            return await Task.Run(() =>
            {
                // Aquí puedes realizar modificaciones en las propiedades de 'modelo'
                var propIdNovedad = typeof(T).GetProperty("IdNovedad");


                // Modificar la propiedad 'idNovedad' antes de la inserción
                propIdNovedad?.SetValue(modelo, IdentificadorAutogenerado);

                IdentificadorAutogenerado++;

                // Agregar el modelo modificado a la lista 'Novedades'
                Novedades.Add(modelo);

                return true; // Indicar que la inserción fue exitosa
            });
        }

        public async Task<T?> Obtener(Func<T,bool> match)
        {
            return await Task.Run(() =>
            {
                return Novedades.FirstOrDefault(match);
            });
        }

        public async Task<IEnumerable<T>> ObtenerTodos()
        {
            return await Task.Run(() =>
            {
                return Novedades;
            });
        }
    }
}
