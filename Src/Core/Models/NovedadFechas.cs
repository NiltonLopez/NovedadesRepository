namespace Novedades.Models
{
    public class NovedadFechas : Novedad
    {
        public NovedadFechas()
        {

        }
        public NovedadFechas(int? idNovedad,
                   string? idCompania,
                   string? idEmpleado,
                   string? idCentroCosto,
                   string? tipoNomina,
                   string? claseNomina,
                   string? ano,
                   string? mes,
                   string? periodo,
                   int idConcepto,
                   string? codigoConcepto,
                   DateTime? fechaInicial,
                   DateTime? fechaFinal,
                   string? observacion) : base(idNovedad, idCompania, idEmpleado, idCentroCosto, tipoNomina, claseNomina, ano, mes, periodo, idConcepto, codigoConcepto, observacion)
        {
            FechaInicial = fechaInicial;
            FechaFinal = fechaFinal;
        }
        public NovedadFechas(string idCompania,
                             string idEmpleado,
                             int idConcepto,
                             DateTime fechaInicial,
                             DateTime fechaFinal,
                             string? observacion) : base(idCompania, idEmpleado, idConcepto, observacion)
        {
            FechaInicial = fechaInicial;
            FechaFinal = fechaFinal;
        }
        public DateTime? FechaInicial { get; set; }

        public DateTime? FechaFinal { get; set; }

    }
}
