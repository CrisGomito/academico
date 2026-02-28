using System;
using System.Collections.Generic;
using Academico.Modelos;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Scaffolding.Internal;

namespace Academico.Config;

public partial class SistemaAcademicoContext : DbContext
{
    public SistemaAcademicoContext()
    {
    }

    public SistemaAcademicoContext(DbContextOptions<SistemaAcademicoContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Asignaciondocente> Asignaciondocentes { get; set; }

    public virtual DbSet<Asignatura> Asignaturas { get; set; }

    public virtual DbSet<AuditoriaSistema> AuditoriaSistemas { get; set; }

    public virtual DbSet<Calificacion> Calificacions { get; set; }

    public virtual DbSet<Docente> Docentes { get; set; }

    public virtual DbSet<Estudiante> Estudiantes { get; set; }

    public virtual DbSet<Evaluacion> Evaluacions { get; set; }

    public virtual DbSet<Matricula> Matriculas { get; set; }

    public virtual DbSet<Periodoacademico> Periodoacademicos { get; set; }

    public virtual DbSet<Rol> Rols { get; set; }

    public virtual DbSet<Tipoevaluacion> Tipoevaluacions { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    public virtual DbSet<UsuarioRol> UsuarioRols { get; set; }

    public virtual DbSet<VistaAuditoriaActual> VistaAuditoriaActuals { get; set; }

    public virtual DbSet<VistaDocentesAdmin> VistaDocentesAdmins { get; set; }

    public virtual DbSet<VistaDocentesPeriodo> VistaDocentesPeriodos { get; set; }

    public virtual DbSet<VistaEstudiantesAdmin> VistaEstudiantesAdmins { get; set; }

    public virtual DbSet<VistaHistorialAuditorium> VistaHistorialAuditoria { get; set; }

    public virtual DbSet<VistaHistorialNota> VistaHistorialNotas { get; set; }

    public virtual DbSet<VistaLoginDocente> VistaLoginDocentes { get; set; }

    public virtual DbSet<VistaLoginSeguridadActual> VistaLoginSeguridadActuals { get; set; }

    public virtual DbSet<VistaPromediosEstudiante> VistaPromediosEstudiantes { get; set; }

    public virtual DbSet<VistaReporteAcademico> VistaReporteAcademicos { get; set; }

    public virtual DbSet<VistaUsuariosAdmin> VistaUsuariosAdmins { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
    {
        if (!optionsBuilder.IsConfigured)
        {
            string cadenaConexion = "server=192.168.101.11;port=3306;database=sistema_academico;uid=root;pwd=;Connection Timeout=5;";

            optionsBuilder.UseMySql(cadenaConexion, Microsoft.EntityFrameworkCore.ServerVersion.Parse("10.4.32-mariadb"));
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_general_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Asignaciondocente>(entity =>
        {
            entity.HasKey(e => e.IdAsignacion).HasName("PRIMARY");

            entity.HasOne(d => d.IdAsignaturaNavigation).WithMany(p => p.Asignaciondocentes)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_asigdoc_asignatura");

            entity.HasOne(d => d.IdDocenteNavigation).WithMany(p => p.Asignaciondocentes)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_asigdoc_docente");

            entity.HasOne(d => d.IdPeriodoNavigation).WithMany(p => p.Asignaciondocentes)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_asigdoc_periodo");
        });

        modelBuilder.Entity<Asignatura>(entity =>
        {
            entity.HasKey(e => e.IdAsignatura).HasName("PRIMARY");
        });

        modelBuilder.Entity<AuditoriaSistema>(entity =>
        {
            entity.HasKey(e => new { e.IdAuditoria, e.Fecha })
                .HasName("PRIMARY")
                .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

            entity.Property(e => e.IdAuditoria).ValueGeneratedOnAdd();
            entity.Property(e => e.Fecha).HasDefaultValueSql("current_timestamp()");
        });

        modelBuilder.Entity<Calificacion>(entity =>
        {
            entity.HasKey(e => e.IdCalificacion).HasName("PRIMARY");

            entity.Property(e => e.Activo).HasDefaultValueSql("'1'");
            entity.Property(e => e.FechaRegistro).HasDefaultValueSql("current_timestamp()");

            entity.HasOne(d => d.IdEstudianteNavigation).WithMany(p => p.Calificacions)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_calif_estudiante");

            entity.HasOne(d => d.IdEvaluacionNavigation).WithMany(p => p.Calificacions)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_calif_evaluacion");
        });

        modelBuilder.Entity<Docente>(entity =>
        {
            entity.HasKey(e => e.IdDocente).HasName("PRIMARY");

            entity.Property(e => e.CedulaHash).IsFixedLength();
            entity.Property(e => e.Estado).HasDefaultValueSql("'1'");
            entity.Property(e => e.FechaRegistro).HasDefaultValueSql("current_timestamp()");

            entity.HasOne(d => d.IdUsuarioNavigation).WithOne(p => p.Docente)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_docente_usuario");
        });

        modelBuilder.Entity<Estudiante>(entity =>
        {
            entity.HasKey(e => e.IdEstudiante).HasName("PRIMARY");

            entity.Property(e => e.CedulaHash).IsFixedLength();
            entity.Property(e => e.Estado).HasDefaultValueSql("'1'");
            entity.Property(e => e.FechaRegistro).HasDefaultValueSql("current_timestamp()");

            entity.HasOne(d => d.IdUsuarioNavigation).WithOne(p => p.Estudiante)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_estudiante_usuario");
        });

        modelBuilder.Entity<Evaluacion>(entity =>
        {
            entity.HasKey(e => e.IdEvaluacion).HasName("PRIMARY");

            entity.HasOne(d => d.IdAsignaturaNavigation).WithMany(p => p.Evaluacions)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_eval_asignatura");

            entity.HasOne(d => d.IdPeriodoNavigation).WithMany(p => p.Evaluacions)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_eval_periodo");

            entity.HasOne(d => d.IdTipoEvaluacionNavigation).WithMany(p => p.Evaluacions)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_eval_tipoeval");
        });

        modelBuilder.Entity<Matricula>(entity =>
        {
            entity.HasKey(e => e.IdMatricula).HasName("PRIMARY");

            entity.HasOne(d => d.IdAsignaturaNavigation).WithMany(p => p.Matriculas)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_mat_asignatura");

            entity.HasOne(d => d.IdEstudianteNavigation).WithMany(p => p.Matriculas)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_mat_estudiante");

            entity.HasOne(d => d.IdPeriodoNavigation).WithMany(p => p.Matriculas)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_mat_periodo");
        });

        modelBuilder.Entity<Periodoacademico>(entity =>
        {
            entity.HasKey(e => e.IdPeriodo).HasName("PRIMARY");
        });

        modelBuilder.Entity<Rol>(entity =>
        {
            entity.HasKey(e => e.IdRol).HasName("PRIMARY");
        });

        modelBuilder.Entity<Tipoevaluacion>(entity =>
        {
            entity.HasKey(e => e.IdTipoEvaluacion).HasName("PRIMARY");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.IdUsuario).HasName("PRIMARY");

            entity.Property(e => e.Codigo2fa).IsFixedLength();
            entity.Property(e => e.CorreoHash).IsFixedLength();
            entity.Property(e => e.Estado).HasDefaultValueSql("'1'");
            entity.Property(e => e.FechaCambioPassword).HasDefaultValueSql("current_timestamp()");
            entity.Property(e => e.FechaCreacion).HasDefaultValueSql("current_timestamp()");
            entity.Property(e => e.IntentosFallidos).HasDefaultValueSql("'0'");
        });

        modelBuilder.Entity<UsuarioRol>(entity =>
        {
            entity.HasKey(e => new { e.IdUsuario, e.IdRol })
                .HasName("PRIMARY")
                .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

            entity.Property(e => e.FechaAsignacion).HasDefaultValueSql("current_timestamp()");

            entity.HasOne(d => d.IdRolNavigation).WithMany(p => p.UsuarioRols).HasConstraintName("fk_ur_rol");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.UsuarioRols).HasConstraintName("fk_ur_usuario");
        });

        modelBuilder.Entity<VistaAuditoriaActual>(entity =>
        {
            entity.ToView("vista_auditoria_actual");

            entity.Property(e => e.Fecha).HasDefaultValueSql("current_timestamp()");
        });

        modelBuilder.Entity<VistaDocentesAdmin>(entity =>
        {
            entity.ToView("vista_docentes_admin");

            entity.Property(e => e.Estado).HasDefaultValueSql("'1'");
        });

        modelBuilder.Entity<VistaDocentesPeriodo>(entity =>
        {
            entity.ToView("vista_docentes_periodo");
        });

        modelBuilder.Entity<VistaEstudiantesAdmin>(entity =>
        {
            entity.ToView("vista_estudiantes_admin");

            entity.Property(e => e.Estado).HasDefaultValueSql("'1'");
        });

        modelBuilder.Entity<VistaHistorialAuditorium>(entity =>
        {
            entity.ToView("vista_historial_auditoria");

            entity.Property(e => e.Fecha).HasDefaultValueSql("current_timestamp()");
        });

        modelBuilder.Entity<VistaHistorialNota>(entity =>
        {
            entity.ToView("vista_historial_notas");

            entity.Property(e => e.Fecha).HasDefaultValueSql("current_timestamp()");
        });

        modelBuilder.Entity<VistaLoginDocente>(entity =>
        {
            entity.ToView("vista_login_docentes");

            entity.Property(e => e.FechaIngreso).HasDefaultValueSql("current_timestamp()");
        });

        modelBuilder.Entity<VistaLoginSeguridadActual>(entity =>
        {
            entity.ToView("vista_login_seguridad_actual");

            entity.Property(e => e.FechaIngreso).HasDefaultValueSql("current_timestamp()");
        });

        modelBuilder.Entity<VistaPromediosEstudiante>(entity =>
        {
            entity.ToView("vista_promedios_estudiantes");
        });

        modelBuilder.Entity<VistaReporteAcademico>(entity =>
        {
            entity.ToView("vista_reporte_academico");
        });

        modelBuilder.Entity<VistaUsuariosAdmin>(entity =>
        {
            entity.ToView("vista_usuarios_admin");

            entity.Property(e => e.Estado).HasDefaultValueSql("'1'");
            entity.Property(e => e.FechaCambioPassword).HasDefaultValueSql("current_timestamp()");
            entity.Property(e => e.FechaCreacion).HasDefaultValueSql("current_timestamp()");
            entity.Property(e => e.IntentosFallidos).HasDefaultValueSql("'0'");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
