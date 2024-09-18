using System;
using System.Collections.Generic;

namespace Novedades.DAL.SQLServer.Entities;

public partial class CptwebEntidad
{
    public int ID { get; set; }
    public string? Compania { get; set; }

    public string? Tipo { get; set; }

    public string? Concepto { get; set; }

    public string? Descripcion { get; set; }
}
