using System;
using System.Collections.Generic;

namespace Novedades.Models;

public partial class Novedad
{
    public Novedad()
    {
        
    }
    public Novedad(int? idNovedad,
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
                   string? observacion)
    {
        IdNovedad = idNovedad;
        IdCompania = idCompania;
        IdEmpleado = idEmpleado;
        IdCentroCosto = idCentroCosto;
        TipoNomina = tipoNomina;
        ClaseNomina = claseNomina;
        Ano = ano;
        Mes = mes;
        Periodo = periodo;
        IdConcepto = idConcepto;
        CodigoConcepto = codigoConcepto;
        Observacion = observacion;
    }
    public Novedad(string? idCompania,
                   string? idEmpleado,
                   int idConcepto,
                   string? observacion)
    {
        IdCompania = idCompania;
        IdEmpleado = idEmpleado;
        IdConcepto = idConcepto;
        Observacion = observacion;
    }

    public int? IdNovedad { get; set; }

    public string? IdCompania { get; set; } = null!;

    public string IdEmpleado { get; set; } = null!;
    public string? IdCentroCosto { get; set; }
    public string? TipoNomina { get; set; }
    public string? ClaseNomina { get; set; }
    public string? Ano { get; set; }
    public string? Mes { get; set;  }
    public string? Periodo { get; set; }
    public int IdConcepto { get; set; }
    public string? CodigoConcepto { get; set; }
    public string? Observacion { get; set; }


}
