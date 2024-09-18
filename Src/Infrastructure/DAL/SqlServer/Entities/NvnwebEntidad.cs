using System;
using System.Collections.Generic;

namespace Novedades.DAL.SQLServer.Entities;

public partial class NvnwebEntidad
{
    public int? Idnvn { get; set; }

    public string? Compania { get; set; }

    public string? Ccosto { get; set; }

    public string? TipoNom { get; set; }

    public string? ClaseNom { get; set; }

    public string? Ano { get; set; }

    public string? Mes { get; set; }

    public string? Periodo { get; set; }

    public string? Concepto { get; set; }

    public string? Empleado { get; set; }

    public double? Horas { get; set; }

    public double? Valor { get; set; }

    public DateTime? Fini { get; set; }

    public DateTime? Ffin { get; set; }

    public string? Observacion { get; set; }

    public int? Idcpt { get; set; }
}
