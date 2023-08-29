using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace GymTerminatorApp.Models
{
    public partial class GymAppContext : DbContext
    {
        public GymAppContext()
        {
        }

        public GymAppContext(DbContextOptions<GymAppContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Contacto> Contactos { get; set; } = null!;
        public virtual DbSet<Ejercicio> Ejercicios { get; set; } = null!;
        public virtual DbSet<Entrenador> Entrenadors { get; set; } = null!;
        public virtual DbSet<Especialidad> Especialidads { get; set; } = null!;
        public virtual DbSet<Evento> Eventos { get; set; } = null!;
        public virtual DbSet<Membresium> Membresia { get; set; } = null!;
        public virtual DbSet<Miembro> Miembros { get; set; } = null!;
        public virtual DbSet<MiembroEvento> MiembroEventos { get; set; } = null!;
        public virtual DbSet<PlanEntrenamiento> PlanEntrenamientos { get; set; } = null!;
        public virtual DbSet<PlanEntrenamientoEjercicio> PlanEntrenamientoEjercicios { get; set; } = null!;
        public virtual DbSet<PlanEntrenamientoMiembro> PlanEntrenamientoMiembros { get; set; } = null!;
        public virtual DbSet<TipoContacto> TipoContactos { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Contacto>(entity =>
            {
                entity.ToTable("Contacto");

                entity.Property(e => e.ValorContacto).HasMaxLength(100);

                entity.HasOne(d => d.Miembro)
                    .WithMany(p => p.Contactos)
                    .HasForeignKey(d => d.MiembroId)
                    .HasConstraintName("FK_Contacto_Miembro");

                entity.HasOne(d => d.TipoContacto)
                    .WithMany(p => p.Contactos)
                    .HasForeignKey(d => d.TipoContactoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Contacto_TipoContacto");
            });

            modelBuilder.Entity<Ejercicio>(entity =>
            {
                entity.ToTable("Ejercicio");

                entity.Property(e => e.Nombre).HasMaxLength(100);
            });

            modelBuilder.Entity<Entrenador>(entity =>
            {
                entity.ToTable("Entrenador");

                entity.Property(e => e.Nombre).HasMaxLength(50);

                entity.HasOne(d => d.Especialidad)
                    .WithMany(p => p.Entrenadors)
                    .HasForeignKey(d => d.EspecialidadId)
                    .HasConstraintName("FK_Entrenador_Especialidad");
            });

            modelBuilder.Entity<Especialidad>(entity =>
            {
                entity.ToTable("Especialidad");

                entity.Property(e => e.Nombre).HasMaxLength(100);
            });

            modelBuilder.Entity<Evento>(entity =>
            {
                entity.ToTable("Evento");

                entity.Property(e => e.FechaFin).HasColumnType("datetime");

                entity.Property(e => e.FechaInicio).HasColumnType("datetime");

                entity.Property(e => e.Nombre).HasMaxLength(100);
            });

            modelBuilder.Entity<Membresium>(entity =>
            {
                entity.HasKey(e => e.MembresiaId)
                    .HasName("PK__Membresi__5AE9309750903A3A");

                entity.Property(e => e.Nombre).HasMaxLength(100);

                entity.Property(e => e.Precio).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.UnidadDuracion).HasMaxLength(20);
            });

            modelBuilder.Entity<Miembro>(entity =>
            {
                entity.ToTable("Miembro");

                entity.Property(e => e.Apellido).HasMaxLength(50);

                entity.Property(e => e.Nombre).HasMaxLength(50);

                entity.HasOne(d => d.Membresia)
                    .WithMany(p => p.Miembros)
                    .HasForeignKey(d => d.MembresiaId)
                    .HasConstraintName("FK_Miembro_Membresia");
            });

            modelBuilder.Entity<MiembroEvento>(entity =>
            {
                entity.ToTable("MiembroEvento");

                entity.HasOne(d => d.Evento)
                    .WithMany(p => p.MiembroEventos)
                    .HasForeignKey(d => d.EventoId)
                    .HasConstraintName("FK_MiembroEvento_Evento");

                entity.HasOne(d => d.Miembro)
                    .WithMany(p => p.MiembroEventos)
                    .HasForeignKey(d => d.MiembroId)
                    .HasConstraintName("FK_MiembroEvento_Miembro");
            });

            modelBuilder.Entity<PlanEntrenamiento>(entity =>
            {
                entity.ToTable("PlanEntrenamiento");

                entity.Property(e => e.Nombre).HasMaxLength(30);

                entity.HasOne(d => d.Entrenador)
                    .WithMany(p => p.PlanEntrenamientos)
                    .HasForeignKey(d => d.EntrenadorId)
                    .HasConstraintName("FK_PlanEntrenamiento_Entrenador");
            });

            modelBuilder.Entity<PlanEntrenamientoEjercicio>(entity =>
            {
                entity.ToTable("PlanEntrenamientoEjercicio");

                entity.HasOne(d => d.Ejercicio)
                    .WithMany(p => p.PlanEntrenamientoEjercicios)
                    .HasForeignKey(d => d.EjercicioId)
                    .HasConstraintName("FK_PlanEjercicio_Ejercicio");

                entity.HasOne(d => d.PlanEntrenamiento)
                    .WithMany(p => p.PlanEntrenamientoEjercicios)
                    .HasForeignKey(d => d.PlanEntrenamientoId)
                    .HasConstraintName("FK_PlanEjercicio_PlanEntrenamiento");
            });

            modelBuilder.Entity<PlanEntrenamientoMiembro>(entity =>
            {
                entity.ToTable("PlanEntrenamientoMiembro");

                entity.HasOne(d => d.Miembro)
                    .WithMany(p => p.PlanEntrenamientoMiembros)
                    .HasForeignKey(d => d.MiembroId)
                    .HasConstraintName("FK_PlanEntrenamientoMiembro_Miembro");

                entity.HasOne(d => d.PlanEntrenamiento)
                    .WithMany(p => p.PlanEntrenamientoMiembros)
                    .HasForeignKey(d => d.PlanEntrenamientoId)
                    .HasConstraintName("FK_PlanEntrenamientoMiembro_PlanEntrenamiento");
            });

            modelBuilder.Entity<TipoContacto>(entity =>
            {
                entity.ToTable("TipoContacto");

                entity.Property(e => e.Nombre).HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
