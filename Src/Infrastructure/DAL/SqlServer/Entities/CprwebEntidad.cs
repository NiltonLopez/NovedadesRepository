using System;
using System.Collections.Generic;

namespace Novedades.DAL.SQLServer.Entities;

public partial class CprwebEntidad
{
    public string? Compania { get; set; }

    public string? ClaseNom { get; set; }

    public int? TpNov { get; set; }

    public string? Descripcion { get; set; }

    public int? FIni { get; set; }

    public int? FFin { get; set; }

    public string? HNov { get; set; }
}
