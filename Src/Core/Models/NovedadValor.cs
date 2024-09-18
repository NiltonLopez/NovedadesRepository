namespace Novedades.Models
{
    public class NovedadValor : Novedad
    {
        public NovedadValor(int? idNovedad,
                   string? idCompania,
                   string? idEmpleado,
                   string? idCentroCosto,
                   string? tipoNomina,
                   string? claseNomina,
                   string? ano,
                   string? mes,
                   string? periodo,
                   int idConcepto,
                   string codigoConcepto,
                   double? valor,
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
            Valor = valor;
        }
        public NovedadValor(string idCompania,
                            string idEmpleado,
                            int idConcepto,
                            double valor,
                            string? observacion) : base(idCompania,
                                                        idEmpleado,
                                                        idConcepto,
                                                        observacion)
        {
            Valor = valor;
        }

        public NovedadValor()
        {
        }

        public double? Valor { get; set; }


    }
}
