using System.Drawing;

namespace Novedades.Models
{
    public class NovedadHoras : Novedad
    {
        public NovedadHoras(int? idNovedad,
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
                   double? horas,
                   string? observacion) : base(idNovedad,
                                               idCompania,
                                               idEmpleado,
                                               idCentroCosto,
                                               tipoNomina,
                                               claseNomina,
                                               ano,
                                               mes,
                                               periodo,
                                               idConcepto,
                                               codigoConcepto,
                                               observacion)
        {
            Horas = horas;
        }
        public NovedadHoras(string idCompania,
                            string idEmpleado,
                            int idConcepto,
                            double horas,
                            string? observacion) : base(idCompania, idEmpleado, idConcepto, observacion)
        {
            Horas = horas;
        }

        public NovedadHoras()
        {
        }

        public double? Horas { get; set; }

    }
}
