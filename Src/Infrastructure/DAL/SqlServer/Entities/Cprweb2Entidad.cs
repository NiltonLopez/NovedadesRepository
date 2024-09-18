using System;
using System.Collections.Generic;

namespace Novedades.DAL.SqlServer.Entities;

public partial class Cprweb2Entidad
{
    public string? Compania { get; set; }

    public string? TipoNom { get; set; }

    public string? ClaseNom { get; set; }

    public string? Ano { get; set; }

    public string? Mes { get; set; }

    public string? Periodo { get; set; }

    public string? Descripcion { get; set; }

    public DateTime? FIni { get; set; }

    public DateTime? FFin { get; set; }
}
