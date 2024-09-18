namespace Novedades.Models
{
    public class Concepto
    {
        public Concepto()
        {
            
        }
        public Concepto(int idConcepto,
                        string idCompañia,
                        string codigoConcepto,
                        string? descripcion,
                        string tipo)
        {
            IdConcepto = idConcepto;
            IdCompañia = idCompañia;
            CodigoConcepto = codigoConcepto;
            Descripcion = descripcion;
            Tipo = tipo;
        }

        public int IdConcepto { get; set; }
        public string IdCompañia { get; set; }
        public string CodigoConcepto { get; set; }
        public string Descripcion { get; set; }
        public string Tipo { get; set; }
    }
}
