using AutoMapper;
using Novedades.AppWeb.Models.ViewModels;
using Novedades.AppWeb.Models.ViewModels.AgregarNovedades;
using Novedades.AppWeb.Models.ViewModels.ListarNovedade;
using Novedades.BLL.Interfaces;
using Novedades.Models;

namespace Novedades.AppWeb.AutoMapper
{
    public class ProfileVM : Profile
    {
        public ProfileVM()
        {
            #region Mapeo de ViewModel de Inserción

            CreateMap<NovedadValor, NuevaNovedadValorVM>().ReverseMap();

            CreateMap<NovedadHoras, NuevaNovedadHoraVM>().ReverseMap();

            CreateMap<NovedadFechas, NuevaNovedadFechaVM>().ReverseMap();

            #endregion

            #region Mapeo de ViewModel de Visualizacion

            CreateMap<NovedadValor, NovedadValorResumenVM>().ReverseMap();

            CreateMap<NovedadHoras, NovedadHorasResumenVM>().ReverseMap();

            CreateMap<NovedadFechas, NovedadFechasResumenVM>().ReverseMap();

            CreateMap<Calendario2, CalendarioResumenVM>().ReverseMap();

            #endregion



        }
    }
}
