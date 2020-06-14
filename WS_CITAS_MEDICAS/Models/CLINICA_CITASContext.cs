using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WS_CITAS_MEDICAS.Models
{
    public partial class CLINICA_CITASContext : DbContext
    {
        public CLINICA_CITASContext(DbContextOptions<CLINICA_CITASContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Citas> Citas { get; set; }
        public virtual DbSet<Especialidades> Especialidades { get; set; }
        public virtual DbSet<Horarios> Horarios { get; set; }
        public virtual DbSet<Medicos> Medicos { get; set; }
        public virtual DbSet<MedicosEspecialidades> MedicosEspecialidades { get; set; }
        public virtual DbSet<Pacientes> Pacientes { get; set; }
        public virtual DbSet<Usuarios> Usuarios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Citas>(entity =>
            {
                entity.ToTable("CITAS");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Activo)
                    .IsRequired()
                    .HasColumnName("ACTIVO")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Estado)
                    .IsRequired()
                    .HasColumnName("ESTADO")
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.Fechaatencion)
                    .HasColumnName("FECHAATENCION")
                    .HasColumnType("date");

                entity.Property(e => e.Fechamodificacion)
                    .HasColumnName("FECHAMODIFICACION")
                    .HasColumnType("datetime");

                entity.Property(e => e.Fecharegistro)
                    .HasColumnName("FECHAREGISTRO")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Finatencion).HasColumnName("FINATENCION");

                entity.Property(e => e.Inicioatencion).HasColumnName("INICIOATENCION");

                entity.Property(e => e.Medicoid).HasColumnName("MEDICOID");

                entity.Property(e => e.Observaciones)
                    .HasColumnName("OBSERVACIONES")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Pacienteid).HasColumnName("PACIENTEID");

                entity.Property(e => e.Usuariomodificacion)
                    .HasColumnName("USUARIOMODIFICACION")
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.Usuarioregistro)
                    .HasColumnName("USUARIOREGISTRO")
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.HasOne(d => d.Medico)
                    .WithMany(p => p.Citas)
                    .HasForeignKey(x => x.Medicoid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MEDICOS_CITAS");

                entity.HasOne(d => d.Paciente)
                    .WithMany(p => p.Citas)
                    .HasForeignKey(x => x.Pacienteid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PACIENTES_CITAS");
            });

            modelBuilder.Entity<Especialidades>(entity =>
            {
                entity.ToTable("ESPECIALIDADES");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Activo)
                    .HasColumnName("ACTIVO")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Descripcion)
                    .HasColumnName("DESCRIPCION")
                    .HasMaxLength(500);

                entity.Property(e => e.Fechamodificacion)
                    .HasColumnName("FECHAMODIFICACION")
                    .HasColumnType("datetime");

                entity.Property(e => e.Fecharegistro)
                    .HasColumnName("FECHAREGISTRO")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasColumnName("NOMBRE")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Usuariomodificacion)
                    .HasColumnName("USUARIOMODIFICACION")
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.Usuarioregistro)
                    .HasColumnName("USUARIOREGISTRO")
                    .HasMaxLength(25)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Horarios>(entity =>
            {
                entity.ToTable("HORARIOS");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Activo)
                    .IsRequired()
                    .HasColumnName("ACTIVO")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Fechaatencion)
                    .HasColumnName("FECHAATENCION")
                    .HasColumnType("date");

                entity.Property(e => e.Fechamodificacion)
                    .HasColumnName("FECHAMODIFICACION")
                    .HasColumnType("datetime");

                entity.Property(e => e.Fecharegistro)
                    .HasColumnName("FECHAREGISTRO")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Finatencion).HasColumnName("FINATENCION");

                entity.Property(e => e.Inicioatencion).HasColumnName("INICIOATENCION");

                entity.Property(e => e.Medicoid).HasColumnName("MEDICOID");

                entity.Property(e => e.Usuariomodificacion)
                    .HasColumnName("USUARIOMODIFICACION")
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.Usuarioregistro)
                    .HasColumnName("USUARIOREGISTRO")
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.HasOne(d => d.Medico)
                    .WithMany(p => p.Horarios)
                    .HasForeignKey(x => x.Medicoid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MEDICOS_HORARIOS");
            });

            modelBuilder.Entity<Medicos>(entity =>
            {
                entity.ToTable("MEDICOS");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Activo)
                    .HasColumnName("ACTIVO")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Apellidos)
                    .IsRequired()
                    .HasColumnName("APELLIDOS")
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.Correo)
                    .HasColumnName("CORREO")
                    .HasMaxLength(50);

                entity.Property(e => e.Direccion)
                    .HasColumnName("DIRECCION")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Dni)
                    .HasColumnName("DNI")
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Fechamodificacion)
                    .HasColumnName("FECHAMODIFICACION")
                    .HasColumnType("datetime");

                entity.Property(e => e.Fechanacimiento)
                    .HasColumnName("FECHANACIMIENTO")
                    .HasColumnType("date");

                entity.Property(e => e.Fecharegistro)
                    .HasColumnName("FECHAREGISTRO")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Nombres)
                    .IsRequired()
                    .HasColumnName("NOMBRES")
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.Numcolegiatura)
                    .HasColumnName("NUMCOLEGIATURA")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Sexo)
                    .HasColumnName("SEXO")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Telefono)
                    .HasColumnName("TELEFONO")
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.Usuariomodificacion)
                    .HasColumnName("USUARIOMODIFICACION")
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.Usuarioregistro)
                    .HasColumnName("USUARIOREGISTRO")
                    .HasMaxLength(25)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<MedicosEspecialidades>(entity =>
            {
                entity.ToTable("MEDICOS_ESPECIALIDADES");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Activo)
                    .HasColumnName("ACTIVO")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Especialidadid).HasColumnName("ESPECIALIDADID");

                entity.Property(e => e.Fechamodificacion)
                    .HasColumnName("FECHAMODIFICACION")
                    .HasColumnType("datetime");

                entity.Property(e => e.Fecharegistro)
                    .HasColumnName("FECHAREGISTRO")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Medicoid).HasColumnName("MEDICOID");

                entity.Property(e => e.Usuariomodificacion)
                    .HasColumnName("USUARIOMODIFICACION")
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.Usuarioregistro)
                    .HasColumnName("USUARIOREGISTRO")
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.HasOne(d => d.Especialidad)
                    .WithMany(p => p.MedicosEspecialidades)
                    .HasForeignKey(x => x.Especialidadid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ESPECIALIDADES");

                entity.HasOne(d => d.Medico)
                    .WithMany(p => p.MedicosEspecialidades)
                    .HasForeignKey(x => x.Medicoid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MEDICOS");
            });

            modelBuilder.Entity<Pacientes>(entity =>
            {
                entity.ToTable("PACIENTES");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Activo)
                    .IsRequired()
                    .HasColumnName("ACTIVO")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Apellidos)
                    .IsRequired()
                    .HasColumnName("APELLIDOS")
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.Direccion)
                    .IsRequired()
                    .HasColumnName("DIRECCION")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Dni)
                    .IsRequired()
                    .HasColumnName("DNI")
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Fechamodificacion)
                    .HasColumnName("FECHAMODIFICACION")
                    .HasColumnType("datetime");

                entity.Property(e => e.Fechanacimiento)
                    .HasColumnName("FECHANACIMIENTO")
                    .HasColumnType("date");

                entity.Property(e => e.Fecharegistro)
                    .HasColumnName("FECHAREGISTRO")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Nombres)
                    .IsRequired()
                    .HasColumnName("NOMBRES")
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.Sexo)
                    .IsRequired()
                    .HasColumnName("SEXO")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Telefono)
                    .IsRequired()
                    .HasColumnName("TELEFONO")
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.Usuariomodificacion)
                    .HasColumnName("USUARIOMODIFICACION")
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.Usuarioregistro)
                    .HasColumnName("USUARIOREGISTRO")
                    .HasMaxLength(25)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Usuarios>(entity =>
            {
                entity.ToTable("USUARIOS");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Activo)
                    .IsRequired()
                    .HasColumnName("ACTIVO")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Clave)
                    .IsRequired()
                    .HasColumnName("CLAVE")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Medicoid).HasColumnName("MEDICOID");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasColumnName("NOMBRE")
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
