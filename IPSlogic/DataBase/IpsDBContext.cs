using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace IPSlogic.DataBase
{
    public partial class IpsDBContext : DbContext
    {
        public IpsDBContext()
        {
        }

        public IpsDBContext(DbContextOptions<IpsDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Citum> Cita { get; set; }
        public virtual DbSet<Ciudade> Ciudades { get; set; }
        public virtual DbSet<Convenio> Convenios { get; set; }
        public virtual DbSet<Ep> Eps { get; set; }
        public virtual DbSet<Ip> Ips { get; set; }
        public virtual DbSet<Medico> Medicos { get; set; }
        public virtual DbSet<Persona> Personas { get; set; }
        public virtual DbSet<Servicio> Servicios { get; set; }
        public virtual DbSet<Triage> Triages { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=DESKTOP-CODMQ93; Database=IpsDB;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Modern_Spanish_CI_AS");

            modelBuilder.Entity<Citum>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.ContraseñaUsuario)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.EstadoCita).HasColumnName("Estado_cita");

                entity.Property(e => e.Fecha).HasColumnType("date");

                entity.Property(e => e.Hora).HasColumnType("datetime");

                entity.Property(e => e.IdIps)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.IdTriage)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.LicenciaMedico)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.ObservacionMedica)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("Observacion_medica");

                entity.Property(e => e.TipoCita).HasColumnName("Tipo_cita");

                entity.HasOne(d => d.ContraseñaUsuarioNavigation)
                    .WithMany(p => p.Cita)
                    .HasForeignKey(d => d.ContraseñaUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Cita_Usuario");

                entity.HasOne(d => d.IdIpsNavigation)
                    .WithMany(p => p.Cita)
                    .HasForeignKey(d => d.IdIps)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Cita_Ips");

                entity.HasOne(d => d.IdTriageNavigation)
                    .WithMany(p => p.Cita)
                    .HasForeignKey(d => d.IdTriage)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Cita_Triage");

                entity.HasOne(d => d.LicenciaMedicoNavigation)
                    .WithMany(p => p.Cita)
                    .HasForeignKey(d => d.LicenciaMedico)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Cita_Medico");
            });

            modelBuilder.Entity<Ciudade>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.NombreCiudad)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("Nombre_ciudad");
            });

            modelBuilder.Entity<Convenio>(entity =>
            {
                entity.ToTable("Convenio");

                entity.Property(e => e.Id)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.NombreConvenio)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Nombre_convenio");

                entity.Property(e => e.PorcentajeDescuento).HasColumnName("Porcentaje_descuento");

                entity.Property(e => e.TipoAfiliacion).HasColumnName("Tipo_afiliacion");
            });

            modelBuilder.Entity<Ep>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.Ciudad)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.HorarioAfiliados)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("Horario_afiliados");

                entity.Property(e => e.HorarioParticulares)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("Horario_particulares");
            });

            modelBuilder.Entity<Ip>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.Direccion)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.IdCiudad)
                    .IsRequired()
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.IdEps)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.IdPago)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.IdServicios)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.Sede)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Telefono)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdCiudadNavigation)
                    .WithMany(p => p.Ips)
                    .HasForeignKey(d => d.IdCiudad)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Ips_Ciudades");

                entity.HasOne(d => d.IdEpsNavigation)
                    .WithMany(p => p.Ips)
                    .HasForeignKey(d => d.IdEps)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Ips_Eps");
            });

            modelBuilder.Entity<Medico>(entity =>
            {
                entity.HasKey(e => e.Licencia);

                entity.ToTable("Medico");

                entity.Property(e => e.Licencia)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.IdServicio)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.NumeroDocumentoPersona)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("Numero_documentoPersona");

                entity.Property(e => e.Turno)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdServicioNavigation)
                    .WithMany(p => p.Medicos)
                    .HasForeignKey(d => d.IdServicio)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Medico_Servicios");

                entity.HasOne(d => d.NumeroDocumentoPersonaNavigation)
                    .WithMany(p => p.Medicos)
                    .HasForeignKey(d => d.NumeroDocumentoPersona)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Medico_Persona");
            });

            modelBuilder.Entity<Persona>(entity =>
            {
                entity.HasKey(e => e.NumeroDocumento);

                entity.ToTable("Persona");

                entity.Property(e => e.NumeroDocumento)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("Numero_documento");

                entity.Property(e => e.Apellidos)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Direccion)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.FechaNacimiento)
                    .HasColumnType("date")
                    .HasColumnName("Fecha_nacimiento");

                entity.Property(e => e.Nombres)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Telefono)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.TipoDocumento)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("Tipo_documento");
            });

            modelBuilder.Entity<Servicio>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.Descuento).HasColumnType("money");

                entity.Property(e => e.Especialidad)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.MetodoPago).HasColumnName("Metodo_pago");

                entity.Property(e => e.TarifaAfiliado).HasColumnName("Tarifa_afiliado");

                entity.Property(e => e.TarifaParticular).HasColumnName("Tarifa_particular");
            });

            modelBuilder.Entity<Triage>(entity =>
            {
                entity.ToTable("Triage");

                entity.Property(e => e.Id)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.ContactoPositivoCovid).HasColumnName("COntacto_positivo_covid");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.Contraseña);

                entity.ToTable("Usuario");

                entity.Property(e => e.Contraseña)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("contraseña");

                entity.Property(e => e.IdConvenio)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.NumeroDocumentoPersona)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("Numero_documentoPersona");

                entity.HasOne(d => d.IdConvenioNavigation)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.IdConvenio)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Usuario_Convenio");

                entity.HasOne(d => d.NumeroDocumentoPersonaNavigation)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.NumeroDocumentoPersona)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Usuario_Persona");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
