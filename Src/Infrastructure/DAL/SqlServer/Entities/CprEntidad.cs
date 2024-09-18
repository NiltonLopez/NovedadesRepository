using System;
using System.Collections.Generic;

namespace Novedades.DAL.SQLServer.Entities;

public partial class CprEntidad
{
    public string? TipoNom { get; set; }

    public string? ClaseNom { get; set; }

    public string? Ano { get; set; }

    public string? Mes { get; set; }

    public string? Periodo { get; set; }

    public string? Descripcion { get; set; }

    public string? Mensaje { get; set; }

    public DateTime? FIni { get; set; }

    public DateTime? FFin { get; set; }

    public string? Compania { get; set; }
}
