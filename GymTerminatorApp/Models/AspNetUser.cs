﻿using System;
using System.Collections.Generic;

namespace GymTerminatorApp.Models
{
    public partial class AspNetUser
    {
        public AspNetUser()
        {
            AspNetUserClaims = new HashSet<AspNetUserClaim>();
            AspNetUserLogins = new HashSet<AspNetUserLogin>();
            AspNetUserTokens = new HashSet<AspNetUserToken>();
            MembresiaMiembros = new HashSet<MembresiaMiembro>();
            MiembroEventos = new HashSet<MiembroEvento>();
            PlanEntrenamientoMiembros = new HashSet<PlanEntrenamientoMiembro>();
            Roles = new HashSet<AspNetRole>();
        }

        public string Id { get; set; } = null!;
        public string? UserName { get; set; }
        public string? NormalizedUserName { get; set; }
        public string? Email { get; set; }
        public string? NormalizedEmail { get; set; }
        public bool EmailConfirmed { get; set; }
        public string? PasswordHash { get; set; }
        public string? SecurityStamp { get; set; }
        public string? ConcurrencyStamp { get; set; }
        public string? PhoneNumber { get; set; }
        public bool PhoneNumberConfirmed { get; set; }
        public bool TwoFactorEnabled { get; set; }
        public DateTimeOffset? LockoutEnd { get; set; }
        public bool LockoutEnabled { get; set; }
        public int AccessFailedCount { get; set; }
        public string Discriminator { get; set; } = null!;


        public virtual ICollection<AspNetUserClaim> AspNetUserClaims { get; set; }
        public virtual ICollection<AspNetUserLogin> AspNetUserLogins { get; set; }
        public virtual ICollection<AspNetUserToken> AspNetUserTokens { get; set; }
        public virtual ICollection<MembresiaMiembro> MembresiaMiembros { get; set; }
        public virtual ICollection<MiembroEvento> MiembroEventos { get; set; }
        public virtual ICollection<PlanEntrenamientoMiembro> PlanEntrenamientoMiembros { get; set; }

        public virtual ICollection<AspNetRole> Roles { get; set; }
    }
}
