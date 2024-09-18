using AutoMapper;
using Novedades.DAL.SqlServer.Entities;
using Novedades.Models;

namespace Novedades.DAL.SqlServer.Mappers
{
    public static class MapUtilSQL
    {
        public static NovedadEntidad Map(this NovedadModel novedadModel)
        {
            return new()
            {
                IdNvn = novedadModel.IdNvn,
                IdEmpleado = novedadModel.IdEmpleado,
                IdCompania = novedadModel.IdCompania,
                IdConcepto = novedadModel.IdConcepto,
                IdEmpresa = novedadModel.IdEmpresa,
                FechaInicial = novedadModel.FechaInicial,
                FechaFinal = novedadModel.FechaFinal,
                Horas = novedadModel.Horas,
                Valor = novedadModel.Valor,
                Observacion = novedadModel.Observacion
            };
        }

        public static NovedadModel Map(this NovedadEntidad novedadEntidad)
        {
            return new(novedadEntidad.IdNvn)
            {
                IdNvn = novedadEntidad.IdNvn,
                IdEmpleado = novedadEntidad.IdEmpleado,
                IdCompania = novedadEntidad.IdCompania,
                IdConcepto = novedadEntidad.IdConcepto,
                IdEmpresa = novedadEntidad.IdEmpresa,
                FechaInicial = novedadEntidad.FechaInicial,
                FechaFinal = novedadEntidad.FechaFinal,
                Horas = novedadEntidad.Horas,
                Valor = novedadEntidad.Valor,
                Observacion = novedadEntidad.Observacion
            };
        }
    }
}
