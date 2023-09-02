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

        public virtual DbSet<AspNetRole> AspNetRoles { get; set; } = null!;
        public virtual DbSet<AspNetRoleClaim> AspNetRoleClaims { get; set; } = null!;
        public virtual DbSet<AspNetUser> AspNetUsers { get; set; } = null!;
        public virtual DbSet<AspNetUserClaim> AspNetUserClaims { get; set; } = null!;
        public virtual DbSet<AspNetUserLogin> AspNetUserLogins { get; set; } = null!;
        public virtual DbSet<AspNetUserToken> AspNetUserTokens { get; set; } = null!;
        public virtual DbSet<Ejercicio> Ejercicios { get; set; } = null!;
        public virtual DbSet<Entrenador> Entrenadors { get; set; } = null!;
        public virtual DbSet<Especialidad> Especialidads { get; set; } = null!;
        public virtual DbSet<Evento> Eventos { get; set; } = null!;
        public virtual DbSet<MembresiaMiembro> MembresiaMiembros { get; set; } = null!;
        public virtual DbSet<Membresium> Membresia { get; set; } = null!;
        public virtual DbSet<MiembroEvento> MiembroEventos { get; set; } = null!;
        public virtual DbSet<PlanEntrenamiento> PlanEntrenamientos { get; set; } = null!;
        public virtual DbSet<PlanEntrenamientoEjercicio> PlanEntrenamientoEjercicios { get; set; } = null!;
        public virtual DbSet<PlanEntrenamientoMiembro> PlanEntrenamientoMiembros { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AspNetRole>(entity =>
            {
                entity.HasIndex(e => e.NormalizedName, "RoleNameIndex")
                    .IsUnique()
                    .HasFilter("([NormalizedName] IS NOT NULL)");

                entity.Property(e => e.Name).HasMaxLength(256);

                entity.Property(e => e.NormalizedName).HasMaxLength(256);
            });

            modelBuilder.Entity<AspNetRoleClaim>(entity =>
            {
                entity.HasIndex(e => e.RoleId, "IX_AspNetRoleClaims_RoleId");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetRoleClaims)
                    .HasForeignKey(d => d.RoleId);
            });

            modelBuilder.Entity<AspNetUser>(entity =>
            {
                entity.HasIndex(e => e.NormalizedEmail, "EmailIndex");

                entity.HasIndex(e => e.NormalizedUserName, "UserNameIndex")
                    .IsUnique()
                    .HasFilter("([NormalizedUserName] IS NOT NULL)");

                entity.Property(e => e.Discriminator).HasDefaultValueSql("(N'')");

                entity.Property(e => e.Email).HasMaxLength(256);

                entity.Property(e => e.NormalizedEmail).HasMaxLength(256);

                entity.Property(e => e.NormalizedUserName).HasMaxLength(256);

                entity.Property(e => e.UserName).HasMaxLength(256);

                entity.HasMany(d => d.Roles)
                    .WithMany(p => p.Users)
                    .UsingEntity<Dictionary<string, object>>(
                        "AspNetUserRole",
                        l => l.HasOne<AspNetRole>().WithMany().HasForeignKey("RoleId"),
                        r => r.HasOne<AspNetUser>().WithMany().HasForeignKey("UserId"),
                        j =>
                        {
                            j.HasKey("UserId", "RoleId");

                            j.ToTable("AspNetUserRoles");

                            j.HasIndex(new[] { "RoleId" }, "IX_AspNetUserRoles_RoleId");
                        });
            });

            modelBuilder.Entity<AspNetUserClaim>(entity =>
            {
                entity.HasIndex(e => e.UserId, "IX_AspNetUserClaims_UserId");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserClaims)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserLogin>(entity =>
            {
                entity.HasKey(e => new { e.LoginProvider, e.ProviderKey });

                entity.HasIndex(e => e.UserId, "IX_AspNetUserLogins_UserId");

                entity.Property(e => e.LoginProvider).HasMaxLength(128);

                entity.Property(e => e.ProviderKey).HasMaxLength(128);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserLogins)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserToken>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.LoginProvider, e.Name });

                entity.Property(e => e.LoginProvider).HasMaxLength(128);

                entity.Property(e => e.Name).HasMaxLength(128);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserTokens)
                    .HasForeignKey(d => d.UserId);
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

            modelBuilder.Entity<MembresiaMiembro>(entity =>
            {
                entity.ToTable("MembresiaMiembro");

                entity.Property(e => e.FechaAdquisicion).HasColumnType("date");

                entity.Property(e => e.UserId).HasMaxLength(450);

                entity.HasOne(d => d.Membresia)
                    .WithMany(p => p.MembresiaMiembros)
                    .HasForeignKey(d => d.MembresiaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MembresiaMiembro_Membresia");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.MembresiaMiembros)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MembresiaMiembro_Usuario");
            });

            modelBuilder.Entity<Membresium>(entity =>
            {
                entity.HasKey(e => e.MembresiaId)
                    .HasName("PK__Membresi__5AE9309750903A3A");

                entity.Property(e => e.Nombre).HasMaxLength(100);

                entity.Property(e => e.Precio).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.UnidadDuracion).HasMaxLength(20);
            });

            modelBuilder.Entity<MiembroEvento>(entity =>
            {
                entity.ToTable("MiembroEvento");

                entity.Property(e => e.UserId).HasMaxLength(450);

                entity.HasOne(d => d.Evento)
                    .WithMany(p => p.MiembroEventos)
                    .HasForeignKey(d => d.EventoId)
                    .HasConstraintName("FK_MiembroEvento_Evento");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.MiembroEventos)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MiembroEvento_Usuario");
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

                entity.Property(e => e.UserId).HasMaxLength(450);

                entity.HasOne(d => d.PlanEntrenamiento)
                    .WithMany(p => p.PlanEntrenamientoMiembros)
                    .HasForeignKey(d => d.PlanEntrenamientoId)
                    .HasConstraintName("FK_PlanEntrenamientoMiembro_PlanEntrenamiento");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.PlanEntrenamientoMiembros)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PlanEntrenamientoMiembro_Usuario");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
