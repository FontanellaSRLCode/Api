using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using apiLogisticafs.Models;

namespace apiLogisticafs.Context;

public partial class LogisticafsContext : DbContext
{
    public LogisticafsContext()
    {
    }

    public LogisticafsContext(DbContextOptions<LogisticafsContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Destinatario> Destinatarios { get; set; }

    public virtual DbSet<LogEvento> LogEventos { get; set; }

    public virtual DbSet<Producto> Productos { get; set; }

    public virtual DbSet<Remitente> Remitentes { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }
  

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=tcp:fontanellasrl.database.windows.net,1433;Initial Catalog=logisticafs;Persist Security Info=False;User ID=fsdbfontanella;Password=7C3y3+7WLWWT;MultipleActiveResultSets=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Destinatario>(entity =>
        {
            entity.HasKey(e => e.DesId);

            entity.ToTable("destinatarios");

            entity.Property(e => e.DesId).HasColumnName("des_id");
            entity.Property(e => e.DeptoDest)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("depto_dest");
            entity.Property(e => e.DesCelular)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("des_celular");
            entity.Property(e => e.DesDireccion)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("des_direccion");
            entity.Property(e => e.DesNombre)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("des_nombre");
            entity.Property(e => e.DesRemId).HasColumnName("des_rem_id");
            entity.Property(e => e.DesTransporte)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("des_transporte");
            entity.Property(e => e.FechaEntregaDest)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("fecha_entrega_dest");
            entity.Property(e => e.InfoAdicionalDest)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("Info_adicional_dest");
            entity.Property(e => e.LocalidadDest)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("localidad_dest");
            entity.Property(e => e.PisoDest)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("piso_dest");
            entity.Property(e => e.ProvinciaDest)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("provincia_dest");
            entity.Property(e => e.RangoHorarioDest)
                .HasMaxLength(70)
                .IsUnicode(false)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("rango_horario_dest");
        });

        modelBuilder.Entity<LogEvento>(entity =>
        {
            entity.ToTable(tb => tb.HasTrigger("trg_UpdateFecha"));

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Evento)
                .HasMaxLength(45)
                .IsUnicode(false)
                .HasColumnName("evento");
            entity.Property(e => e.Fecha)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("fecha");
            entity.Property(e => e.Mensaje)
                .IsUnicode(false)
                .HasColumnName("mensaje");
            entity.Property(e => e.SessionId)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("sessionID");
        });

        modelBuilder.Entity<Producto>(entity =>
        {
            entity.HasKey(e => e.ProId);

            entity.ToTable("productos");

            entity.Property(e => e.ProId).HasColumnName("pro_id");
            entity.Property(e => e.ProCantidad).HasColumnName("pro_cantidad");
            entity.Property(e => e.ProDesId).HasColumnName("pro_des_id");
            entity.Property(e => e.ProDetalle)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("pro_detalle");
            entity.Property(e => e.ProDimensiones)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("pro_dimensiones");
            entity.Property(e => e.ProEmbalaje)
                .HasMaxLength(2)
                .IsUnicode(false)
                .HasColumnName("pro_embalaje");
            entity.Property(e => e.ProRemId).HasColumnName("pro_rem_id");
        });

        modelBuilder.Entity<Remitente>(entity =>
        {
            entity.HasKey(e => e.IdEnvio);

            entity.ToTable("remitente");

            entity.Property(e => e.IdEnvio).HasColumnName("id_envio");
            entity.Property(e => e.CelularEntrega)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("celular_entrega");
            entity.Property(e => e.DeptoEntrega)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("depto_entrega");
            entity.Property(e => e.DireccionRetiro)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("direccion_retiro");
            entity.Property(e => e.EmailRemitente)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("email_remitente");
            entity.Property(e => e.Estado).HasColumnName("estado");
            entity.Property(e => e.Fecha).HasColumnName("fecha");
            entity.Property(e => e.FechaCarga)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("fecha_carga");
            entity.Property(e => e.InfoAdicional)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("info_adicional");
            entity.Property(e => e.LocalidadEntrega)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("localidad_entrega");
            entity.Property(e => e.NombreEntrega)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("nombre_entrega");
            entity.Property(e => e.PisoEntrega)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("piso_entrega");
            entity.Property(e => e.ProvinciaEntrega)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("provincia_entrega");
            entity.Property(e => e.RangoHorario)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("rango_horario");
            entity.Property(e => e.RemitenteNombre)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("remitente_nombre");
            entity.Property(e => e.TelefonoRemitente)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("telefono_remitente");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.UsuId);

            entity.ToTable("usuarios");

            entity.Property(e => e.UsuId).HasColumnName("usu_id");
            entity.Property(e => e.UsuEmail)
                .HasMaxLength(70)
                .IsUnicode(false)
                .HasColumnName("usu_email");
            entity.Property(e => e.UsuNombre)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("usu_nombre");
            entity.Property(e => e.UsuPassword)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("usu_password");
            entity.Property(e => e.UsuTelefono)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("usu_telefono");
            entity.Property(e => e.UsuUsuario)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("usu_usuario");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
