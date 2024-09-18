using AutoMapper;
using Novedades.DAL.SqlServer.Entities;
using Novedades.DAL.SQLServer.Entities;
using Novedades.Models;

namespace Novedades.DAL.SqlServer.Mappers
{
    public class ProfileSQL : Profile
    {
        public ProfileSQL()
        {
            CreateMap<NovedadValor, NvnwebEntidad>()
               .ForMember(dest => dest.Idnvn, opt => opt.Ignore())
                .ForMember(dest => dest.Compania, opt => opt.MapFrom(src => src.IdCompania))
                .ForMember(dest => dest.Idcpt, opt => opt.MapFrom(src => src.IdConcepto))
                .ForMember(dest => dest.Concepto, opt => opt.MapFrom(src => src.CodigoConcepto))
                .ForMember(dest => dest.Empleado, opt => opt.MapFrom(src => src.IdEmpleado))
                .ForMember(dest => dest.Ccosto, opt => opt.MapFrom(src => src.IdCentroCosto))
                .ForMember(dest => dest.TipoNom, opt => opt.MapFrom(src => src.TipoNomina))
                .ForMember(dest => dest.ClaseNom, opt => opt.MapFrom(src => src.ClaseNomina));

            CreateMap<NvnwebEntidad, NovedadValor>()
               .ForMember(dest => dest.IdNovedad, opt => opt.MapFrom(src => src.Idnvn))
               .ForMember(dest => dest.IdCompania, opt => opt.MapFrom(src => src.Compania))
               .ForMember(dest => dest.IdConcepto, opt => opt.MapFrom(src => src.Idcpt))
               .ForMember(dest => dest.CodigoConcepto, opt => opt.MapFrom(src => src.Concepto))
               .ForMember(dest => dest.IdEmpleado, opt => opt.MapFrom(src => src.Empleado))
               .ForMember(dest => dest.IdCentroCosto, opt => opt.MapFrom(src => src.Ccosto))
               .ForMember(dest => dest.TipoNomina, opt => opt.MapFrom(src => src.TipoNom))
               .ForMember(dest => dest.ClaseNomina, opt => opt.MapFrom(src => src.ClaseNom));

            CreateMap<NvnwebEntidad, NovedadHoras>()
                .ForMember(dest => dest.IdNovedad, opt => opt.MapFrom(src => src.Idnvn))
                .ForMember(dest => dest.IdCompania, opt => opt.MapFrom(src => src.Compania))
                .ForMember(dest => dest.IdConcepto, opt => opt.MapFrom(src => src.Idcpt))
                .ForMember(dest => dest.CodigoConcepto, opt => opt.MapFrom(src => src.Concepto))
                .ForMember(dest => dest.IdEmpleado, opt => opt.MapFrom(src => src.Empleado))
                .ForMember(dest => dest.IdCentroCosto, opt => opt.MapFrom(src => src.Ccosto))
                .ForMember(dest => dest.TipoNomina, opt => opt.MapFrom(src => src.TipoNom))
                .ForMember(dest => dest.ClaseNomina, opt => opt.MapFrom(src => src.ClaseNom));

            CreateMap<NovedadHoras, NvnwebEntidad>()
                .ForMember(dest => dest.Idnvn, opt => opt.Ignore())
                .ForMember(dest => dest.Compania, opt => opt.MapFrom(src => src.IdCompania))
                .ForMember(dest => dest.Idcpt, opt => opt.MapFrom(src => src.IdConcepto))
                .ForMember(dest => dest.Concepto, opt => opt.MapFrom(src => src.CodigoConcepto))
                .ForMember(dest => dest.Empleado, opt => opt.MapFrom(src => src.IdEmpleado))
                .ForMember(dest => dest.Ccosto, opt => opt.MapFrom(src => src.IdCentroCosto))
                .ForMember(dest => dest.TipoNom, opt => opt.MapFrom(src => src.TipoNomina))
                .ForMember(dest => dest.ClaseNom, opt => opt.MapFrom(src => src.ClaseNomina));

            CreateMap<NvnwebEntidad, NovedadFechas>()
                .ForMember(dest => dest.IdNovedad, opt => opt.MapFrom(src => src.Idnvn))
                .ForMember(dest => dest.IdCompania, opt => opt.MapFrom(src => src.Compania))
                .ForMember(dest => dest.IdConcepto, opt => opt.MapFrom(src => src.Idcpt))
                .ForMember(dest => dest.CodigoConcepto, opt => opt.MapFrom(src => src.Concepto))
                .ForMember(dest => dest.IdEmpleado, opt => opt.MapFrom(src => src.Empleado))
                .ForMember(dest => dest.IdCentroCosto, opt => opt.MapFrom(src => src.Ccosto))
                .ForMember(dest => dest.TipoNomina, opt => opt.MapFrom(src => src.TipoNom))
                .ForMember(dest => dest.ClaseNomina, opt => opt.MapFrom(src => src.ClaseNom))
                .ForMember(dest => dest.FechaInicial, opt => opt.MapFrom(src => src.Fini))
                .ForMember(dest => dest.FechaFinal, opt => opt.MapFrom(src => src.Ffin));

            CreateMap<NovedadFechas, NvnwebEntidad>()
                .ForMember(dest => dest.Idnvn, opt => opt.Ignore())
                .ForMember(dest => dest.Compania, opt => opt.MapFrom(src => src.IdCompania))
                .ForMember(dest => dest.Idcpt, opt => opt.MapFrom(src => src.IdConcepto))
                .ForMember(dest => dest.Concepto, opt => opt.MapFrom(src => src.CodigoConcepto))
                .ForMember(dest => dest.Empleado, opt => opt.MapFrom(src => src.IdEmpleado))
                .ForMember(dest => dest.Ccosto, opt => opt.MapFrom(src => src.IdCentroCosto))
                .ForMember(dest => dest.TipoNom, opt => opt.MapFrom(src => src.TipoNomina))
                .ForMember(dest => dest.ClaseNom, opt => opt.MapFrom(src => src.ClaseNomina))
                .ForMember(dest => dest.Fini, opt => opt.MapFrom(src => src.FechaInicial))
                .ForMember(dest => dest.Ffin, opt => opt.MapFrom(src => src.FechaFinal));

            CreateMap<EmpEntidad, Empleado>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Empleado))
                .ForMember(dest => dest.Nombre, opt => opt.MapFrom(src => src.Nombre))
                .ForMember(dest => dest.Apellido, opt => opt.MapFrom(src => src.Apellido))
                .ForMember(dest => dest.IdCentroCosto, opt => opt.MapFrom(src => src.Ccosto))
                .ForMember(dest => dest.TipoNomina, opt => opt.MapFrom(src => src.TipoNom))
                .ForMember(dest => dest.ClaseNomina, opt => opt.MapFrom(src => src.ClaseNom))
                .ReverseMap();

            CreateMap<CptwebEntidad, Concepto>()
                .ForMember(dest => dest.IdConcepto, opt => opt.MapFrom(src => src.ID))
                .ForMember(dest => dest.CodigoConcepto, opt => opt.MapFrom(src => src.Concepto))
                .ForMember(dest => dest.Descripcion, opt => opt.MapFrom(src => src.Descripcion))
                .ForMember(dest => dest.IdCompañia, opt => opt.MapFrom(src => src.Compania))
                .ForMember(dest => dest.Tipo, opt => opt.MapFrom(src => src.Tipo))
                .ReverseMap();

            CreateMap<Cprweb2Entidad, Calendario2>()
                .ForMember(dest => dest.TipoNomina, opt => opt.MapFrom(src => src.TipoNom))
                .ForMember(dest => dest.ClaseNomina, opt => opt.MapFrom(src => src.ClaseNom))
                .ForMember(dest => dest.FechaInicial, opt => opt.MapFrom(src => src.FIni))
                .ForMember(dest => dest.FechaFinal, opt => opt.MapFrom(src => src.FFin))
                .ReverseMap();
        }


    }
}
