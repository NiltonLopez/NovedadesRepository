using System;
using System.Collections.Generic;

namespace Novedades.DAL.SQLServer.Entities;

public partial class EmpEntidad
{
    public string? Empleado { get; set; }

    public string? Apellido { get; set; }

    public string? Nombre { get; set; }

    public string? Sexo { get; set; }

    public DateTime? FIngreso { get; set; }

    public DateTime? FAntiguedad { get; set; }

    public string? Area { get; set; }

    public string? Oficio { get; set; }

    public string? TipoNom { get; set; }

    public string? ClaseNom { get; set; }

    public string? Turno { get; set; }

    public string? Horario { get; set; }

    public string? RelLaboral { get; set; }

    public string? RelSindical { get; set; }

    public string? Grupo { get; set; }

    public string? Subgrupo { get; set; }

    public string? Procedimto { get; set; }

    public double? PorcRfte { get; set; }

    public string? DoctoIdent { get; set; }

    public string? ClaseDocto { get; set; }

    public string? ExpedidoEn { get; set; }

    public string? Formapago { get; set; }

    public string? Banco { get; set; }

    public string? Sucursal { get; set; }

    public string? CtaBco { get; set; }

    public string? TipoCta { get; set; }

    public string? PropCta { get; set; }

    public string? BancoG { get; set; }

    public string? SucursalG { get; set; }

    public string? CtaBcoG { get; set; }

    public string Dpto { get; set; } = null!;

    public string? Ccosto { get; set; }

    public string? Estado { get; set; }

    public DateTime? FNace { get; set; }

    public int? PCargo { get; set; }

    public int? NroHijos { get; set; }

    public DateTime? FRetiro { get; set; }

    public string? EstCivil { get; set; }

    public DateTime? FUltSalar { get; set; }

    public string? IndPLiq { get; set; }

    public string? IndRetroact { get; set; }

    public double? CesSigrav { get; set; }

    public double? CesNograv { get; set; }

    public DateTime? FJubilado { get; set; }

    public string? TpContr { get; set; }

    public DateTime? FVcmtContr { get; set; }

    public string? GrupoRh { get; set; }

    public DateTime? FUltRetiro { get; set; }

    public DateTime? FVac { get; set; }

    public double? FactPrest { get; set; }

    public string? Jornada { get; set; }

    public double? NHrsP { get; set; }

    public string? ClaseVac { get; set; }

    public string? Tercero { get; set; }

    public int? DiasPrueba { get; set; }

    public DateTime? FchL50 { get; set; }

    public string? CdgCcf { get; set; }

    public string? EstSbf { get; set; }

    public double? SldCcf { get; set; }

    public string? Direccion { get; set; }

    public string? Telefono { get; set; }

    public string? Extension { get; set; }

    public string? Ciudad { get; set; }

    public string? Barrio { get; set; }

    public string? Libreta { get; set; }

    public string? Distrito { get; set; }

    public string? Clase { get; set; }

    public string? CarnetEmpr { get; set; }

    public string? Ubicacion { get; set; }

    public string? Nivel { get; set; }

    public string? Seccion { get; set; }

    public string? SucCia { get; set; }

    public double? VarTra01 { get; set; }

    public double? VarTra02 { get; set; }

    public double? VarTra03 { get; set; }

    public double? VarTra04 { get; set; }

    public double? VarTra05 { get; set; }

    public double? VarTra06 { get; set; }

    public double? VarTra07 { get; set; }

    public double? VarTra08 { get; set; }

    public double? VarTra09 { get; set; }

    public double? VarTra10 { get; set; }

    public string? Cdgcia { get; set; }

    public string? CiudadN { get; set; }

    public string? ClaseEmp { get; set; }

    public string? EMail { get; set; }

    public string? Celular { get; set; }

    public string? TeleOfc { get; set; }

    public string? DirOfc { get; set; }

    public string? Idempleadoor { get; set; }

    public string? Nacionalidad { get; set; }

    public string? Division { get; set; }

    public string? Subdivision { get; set; }

    public string? Proyecto { get; set; }

    public string? TipoCotizante { get; set; }

    public string Compania { get; set; } = null!;
}
