using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Novedades.DAL.SqlServer.Entities;
using Novedades.DAL.SQLServer.Entities;

namespace Novedades.DAL.SqlServer.DataContext;

public partial class WebContext : DbContext
{
    public WebContext()
    {
    }

    public WebContext(DbContextOptions<WebContext> options)
        : base(options)
    {
    }

    public virtual DbSet<CcoEntidad> Ccos { get; set; }

    public virtual DbSet<CprEntidad> Cprs { get; set; }

    public virtual DbSet<CprwebEntidad> Cprwebs { get; set; }

    public virtual DbSet<Cprweb2Entidad> Cprweb2s { get; set; }


    public virtual DbSet<CptwebEntidad> Cptwebs { get; set; }

    public virtual DbSet<EmpEntidad> Emps { get; set; }

    public virtual DbSet<NvnwebEntidad> Nvnwebs { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Server = 172.16.16.8\\sqlexpress, 1089; Database=Web; User Id=excel1 Password=3x3l401; Integrated Security=true;TrustServerCertificate=true; ");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.UseCollation("Latin1_General_CI_AS_KS_WS");

        modelBuilder.Entity<CcoEntidad>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Cco", "dbo");

            entity.Property(e => e.Ccosto)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("ccosto");
            entity.Property(e => e.Compania)
                .HasMaxLength(2)
                .IsUnicode(false)
                .HasColumnName("compania");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(60)
                .IsUnicode(false)
                .HasColumnName("descripcion");
        });

        modelBuilder.Entity<CprEntidad>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Cpr", "dbo");

            entity.Property(e => e.Ano)
                .HasMaxLength(4)
                .IsUnicode(false)
                .HasColumnName("ano");
            entity.Property(e => e.ClaseNom)
                .HasMaxLength(2)
                .IsUnicode(false)
                .HasColumnName("clase_nom");
            entity.Property(e => e.Compania)
                .HasMaxLength(2)
                .IsUnicode(false)
                .HasColumnName("compania");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("descripcion");
            entity.Property(e => e.FFin).HasColumnName("f_fin");
            entity.Property(e => e.FIni).HasColumnName("f_ini");
            entity.Property(e => e.Mensaje)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("mensaje");
            entity.Property(e => e.Mes)
                .HasMaxLength(2)
                .IsUnicode(false)
                .HasColumnName("mes");
            entity.Property(e => e.Periodo)
                .HasMaxLength(2)
                .IsUnicode(false)
                .HasColumnName("periodo");
            entity.Property(e => e.TipoNom)
                .HasMaxLength(2)
                .IsUnicode(false)
                .HasColumnName("tipo_nom");
        });

        modelBuilder.Entity<Cprweb2Entidad>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("cprweb2", "dbo");

            entity.Property(e => e.Ano)
                .HasMaxLength(4)
                .IsUnicode(false)
                .HasColumnName("ano");
            entity.Property(e => e.ClaseNom)
                .HasMaxLength(4)
                .IsUnicode(false)
                .HasColumnName("clase_nom");
            entity.Property(e => e.Compania)
                .HasMaxLength(2)
                .IsUnicode(false)
                .HasColumnName("compania");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("descripcion");
            entity.Property(e => e.FFin)
                .HasColumnType("datetime")
                .HasColumnName("f_fin");
            entity.Property(e => e.FIni)
                .HasColumnType("datetime")
                .HasColumnName("f_ini");
            entity.Property(e => e.Mes)
                .HasMaxLength(2)
                .IsUnicode(false)
                .HasColumnName("mes");
            entity.Property(e => e.Periodo)
                .HasMaxLength(2)
                .IsUnicode(false)
                .HasColumnName("periodo");
            entity.Property(e => e.TipoNom)
                .HasMaxLength(4)
                .IsUnicode(false)
                .HasColumnName("tipo_nom");
        });

        modelBuilder.Entity<CprwebEntidad>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("cprweb", "dbo");

            entity.Property(e => e.ClaseNom)
                .HasMaxLength(2)
                .IsUnicode(false)
                .HasColumnName("Clase_nom");
            entity.Property(e => e.Compania)
                .HasMaxLength(2)
                .IsUnicode(false)
                .HasColumnName("compania");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(60)
                .IsUnicode(false);
            entity.Property(e => e.FFin).HasColumnName("f_fin");
            entity.Property(e => e.FIni).HasColumnName("f_ini");
            entity.Property(e => e.HNov)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("H_Nov");
            entity.Property(e => e.TpNov).HasColumnName("Tp_Nov");
        });

        modelBuilder.Entity<CptwebEntidad>(entity =>
        {
            entity
                .ToTable("cptweb", "dbo");

            entity
                .HasKey(e => e.ID);

            entity.Property(e => e.ID)
             .ValueGeneratedOnAdd()
                  .HasColumnName("ID");

            entity.Property(e => e.Compania)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("compania");
            entity.Property(e => e.Concepto)
                .HasMaxLength(4)
                .IsUnicode(false)
                .HasColumnName("concepto");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(60)
                .IsUnicode(false)
                .HasColumnName("descripcion");
            entity.Property(e => e.Tipo)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("tipo");
        });

        modelBuilder.Entity<EmpEntidad>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("emp", "dbo");

            entity.Property(e => e.Apellido)
                .HasMaxLength(160)
                .IsUnicode(false)
                .HasColumnName("apellido");
            entity.Property(e => e.Area)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("area");
            entity.Property(e => e.Banco)
                .HasMaxLength(4)
                .IsUnicode(false)
                .HasColumnName("banco");
            entity.Property(e => e.BancoG)
                .HasMaxLength(4)
                .IsUnicode(false)
                .HasColumnName("banco_g");
            entity.Property(e => e.Barrio)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("barrio");
            entity.Property(e => e.CarnetEmpr)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("carnet_empr");
            entity.Property(e => e.Ccosto)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("ccosto");
            entity.Property(e => e.CdgCcf)
                .HasMaxLength(4)
                .IsUnicode(false)
                .HasColumnName("cdg_ccf");
            entity.Property(e => e.Cdgcia)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("cdgcia");
            entity.Property(e => e.Celular)
                .HasMaxLength(34)
                .IsUnicode(false)
                .HasColumnName("celular");
            entity.Property(e => e.CesNograv).HasColumnName("ces_nograv");
            entity.Property(e => e.CesSigrav).HasColumnName("ces_sigrav");
            entity.Property(e => e.Ciudad)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("ciudad");
            entity.Property(e => e.CiudadN)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("ciudad_n");
            entity.Property(e => e.Clase)
                .HasMaxLength(2)
                .IsUnicode(false)
                .HasColumnName("clase");
            entity.Property(e => e.ClaseDocto)
                .HasMaxLength(6)
                .IsUnicode(false)
                .HasColumnName("clase_docto");
            entity.Property(e => e.ClaseEmp)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("clase_emp");
            entity.Property(e => e.ClaseNom)
                .HasMaxLength(4)
                .IsUnicode(false)
                .HasColumnName("clase_nom");
            entity.Property(e => e.ClaseVac)
                .HasMaxLength(4)
                .IsUnicode(false)
                .HasColumnName("clase_vac");
            entity.Property(e => e.Compania)
                .HasMaxLength(2)
                .IsUnicode(false)
                .HasColumnName("compania");
            entity.Property(e => e.CtaBco)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("cta_bco");
            entity.Property(e => e.CtaBcoG)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("cta_bco_g");
            entity.Property(e => e.DiasPrueba).HasColumnName("dias_prueba");
            entity.Property(e => e.DirOfc)
                .HasMaxLength(60)
                .IsUnicode(false)
                .HasColumnName("dir_ofc");
            entity.Property(e => e.Direccion)
                .HasMaxLength(60)
                .IsUnicode(false)
                .HasColumnName("direccion");
            entity.Property(e => e.Distrito)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("distrito");
            entity.Property(e => e.Division)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("division");
            entity.Property(e => e.DoctoIdent)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("docto_ident");
            entity.Property(e => e.Dpto)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("dpto");
            entity.Property(e => e.EMail)
                .HasMaxLength(80)
                .IsUnicode(false)
                .HasColumnName("e_mail");
            entity.Property(e => e.Empleado)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("empleado");
            entity.Property(e => e.EstCivil)
                .HasMaxLength(2)
                .IsUnicode(false)
                .HasColumnName("est_civil");
            entity.Property(e => e.EstSbf)
                .HasMaxLength(3)
                .IsUnicode(false)
                .HasColumnName("est_sbf");
            entity.Property(e => e.Estado)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("estado");
            entity.Property(e => e.ExpedidoEn)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("expedido_en");
            entity.Property(e => e.Extension)
                .HasMaxLength(8)
                .IsUnicode(false)
                .HasColumnName("extension");
            entity.Property(e => e.FAntiguedad)
                .HasColumnType("datetime")
                .HasColumnName("f_antiguedad");
            entity.Property(e => e.FIngreso)
                .HasColumnType("datetime")
                .HasColumnName("f_ingreso");
            entity.Property(e => e.FJubilado)
                .HasColumnType("datetime")
                .HasColumnName("f_jubilado");
            entity.Property(e => e.FNace)
                .HasColumnType("datetime")
                .HasColumnName("f_nace");
            entity.Property(e => e.FRetiro)
                .HasColumnType("datetime")
                .HasColumnName("f_retiro");
            entity.Property(e => e.FUltRetiro)
                .HasColumnType("datetime")
                .HasColumnName("f_ult_retiro");
            entity.Property(e => e.FUltSalar)
                .HasColumnType("datetime")
                .HasColumnName("f_ult_salar");
            entity.Property(e => e.FVac)
                .HasColumnType("datetime")
                .HasColumnName("f_vac");
            entity.Property(e => e.FVcmtContr)
                .HasColumnType("datetime")
                .HasColumnName("f_vcmt_contr");
            entity.Property(e => e.FactPrest).HasColumnName("fact_prest");
            entity.Property(e => e.FchL50)
                .HasColumnType("datetime")
                .HasColumnName("fch_l50");
            entity.Property(e => e.Formapago)
                .HasMaxLength(16)
                .IsUnicode(false)
                .HasColumnName("formapago");
            entity.Property(e => e.Grupo)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("grupo");
            entity.Property(e => e.GrupoRh)
                .HasMaxLength(3)
                .IsUnicode(false)
                .HasColumnName("grupo_rh");
            entity.Property(e => e.Horario)
                .HasMaxLength(4)
                .IsUnicode(false)
                .HasColumnName("horario");
            entity.Property(e => e.Idempleadoor)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("idempleadoor");
            entity.Property(e => e.IndPLiq)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("ind_p_liq");
            entity.Property(e => e.IndRetroact)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("ind_retroact");
            entity.Property(e => e.Jornada)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("jornada");
            entity.Property(e => e.Libreta)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("libreta");
            entity.Property(e => e.NHrsP).HasColumnName("n_hrs_p");
            entity.Property(e => e.Nacionalidad)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("nacionalidad");
            entity.Property(e => e.Nivel)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("nivel");
            entity.Property(e => e.Nombre)
                .HasMaxLength(160)
                .IsUnicode(false)
                .HasColumnName("nombre");
            entity.Property(e => e.NroHijos).HasColumnName("nro_hijos");
            entity.Property(e => e.Oficio)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("oficio");
            entity.Property(e => e.PCargo).HasColumnName("p_cargo");
            entity.Property(e => e.PorcRfte).HasColumnName("porc_rfte");
            entity.Property(e => e.Procedimto)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("procedimto");
            entity.Property(e => e.PropCta)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("prop_cta");
            entity.Property(e => e.Proyecto)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("proyecto");
            entity.Property(e => e.RelLaboral)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("rel_laboral");
            entity.Property(e => e.RelSindical)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("rel_sindical");
            entity.Property(e => e.Seccion)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("seccion");
            entity.Property(e => e.Sexo)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("sexo");
            entity.Property(e => e.SldCcf).HasColumnName("sld_ccf");
            entity.Property(e => e.Subdivision)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("subdivision");
            entity.Property(e => e.Subgrupo)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("subgrupo");
            entity.Property(e => e.SucCia)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("suc_cia");
            entity.Property(e => e.Sucursal)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("sucursal");
            entity.Property(e => e.SucursalG)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("sucursal_g");
            entity.Property(e => e.TeleOfc)
                .HasMaxLength(35)
                .IsUnicode(false)
                .HasColumnName("tele_ofc");
            entity.Property(e => e.Telefono)
                .HasMaxLength(35)
                .IsUnicode(false)
                .HasColumnName("telefono");
            entity.Property(e => e.Tercero)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("tercero");
            entity.Property(e => e.TipoCotizante)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("tipo_cotizante");
            entity.Property(e => e.TipoCta)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("tipo_cta");
            entity.Property(e => e.TipoNom)
                .HasMaxLength(4)
                .IsUnicode(false)
                .HasColumnName("tipo_nom");
            entity.Property(e => e.TpContr)
                .HasMaxLength(4)
                .IsUnicode(false)
                .HasColumnName("tp_contr");
            entity.Property(e => e.Turno)
                .HasMaxLength(4)
                .IsUnicode(false)
                .HasColumnName("turno");
            entity.Property(e => e.Ubicacion)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("ubicacion");
            entity.Property(e => e.VarTra01).HasColumnName("var_tra_01");
            entity.Property(e => e.VarTra02).HasColumnName("var_tra_02");
            entity.Property(e => e.VarTra03).HasColumnName("var_tra_03");
            entity.Property(e => e.VarTra04).HasColumnName("var_tra_04");
            entity.Property(e => e.VarTra05).HasColumnName("var_tra_05");
            entity.Property(e => e.VarTra06).HasColumnName("var_tra_06");
            entity.Property(e => e.VarTra07).HasColumnName("var_tra_07");
            entity.Property(e => e.VarTra08).HasColumnName("var_tra_08");
            entity.Property(e => e.VarTra09).HasColumnName("var_tra_09");
            entity.Property(e => e.VarTra10).HasColumnName("var_tra_10");
        });

        modelBuilder.Entity<NvnwebEntidad>(entity =>
        {
            entity
                .ToTable("nvnweb", "dbo");

            entity
                .HasKey(e => e.Idnvn);

            entity.Property(e => e.Idnvn)
             .ValueGeneratedOnAdd()
                  .HasColumnName("idnvn");
            entity.Property(e => e.Ano)
                .HasMaxLength(4)
                .IsUnicode(false)
                .HasColumnName("ano");
            entity.Property(e => e.Ccosto)
                .HasMaxLength(3)
                .IsUnicode(false)
                .HasColumnName("ccosto");
            entity.Property(e => e.ClaseNom)
                .HasMaxLength(2)
                .IsUnicode(false)
                .HasColumnName("clase_nom");
            entity.Property(e => e.Compania)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("compania");
            entity.Property(e => e.Concepto)
                .HasMaxLength(4)
                .IsUnicode(false)
                .HasColumnName("concepto");
            entity.Property(e => e.Empleado)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("empleado");
            entity.Property(e => e.Ffin)
                .HasColumnType("datetime")
                .HasColumnName("ffin");
            entity.Property(e => e.Fini)
                .HasColumnType("datetime")
                .HasColumnName("fini");
            entity.Property(e => e.Horas).HasColumnName("horas");
            entity.Property(e => e.Idcpt).HasColumnName("idcpt");
            entity.Property(e => e.Mes)
                .HasMaxLength(2)
                .IsUnicode(false)
                .HasColumnName("mes");
            entity.Property(e => e.Observacion)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Periodo)
                .HasMaxLength(2)
                .IsUnicode(false)
                .HasColumnName("periodo");
            entity.Property(e => e.TipoNom)
                .HasMaxLength(2)
                .IsUnicode(false)
                .HasColumnName("tipo_nom");
            entity.Property(e => e.Valor).HasColumnName("valor");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
