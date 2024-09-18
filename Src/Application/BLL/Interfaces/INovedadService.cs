namespace Novedades.BLL.Interfaces
{
    public interface INovedadService<TEntityModel> where TEntityModel : class
    {
        Task<bool> InsertarNovedad(TEntityModel modelo);

        Task<bool> ActualizarNovedad(TEntityModel modelo);

        Task<bool> EliminarNovedad(int id);

        Task<TEntityModel> ObtenerNovedadPorId(int id);

        Task<IEnumerable<TEntityModel>> ObtenerTodasNovedades(string centroCosto, string compania);

        Task<int?> ObtenerIdUltimaNovedad();

    }
}
