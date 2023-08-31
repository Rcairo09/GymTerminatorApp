using System;
using System.Collections.Generic;

namespace GymTerminatorApp.Models
{
    public partial class Miembro
    {
        public Miembro()
        {
            Contactos = new HashSet<Contacto>();
            MembresiaMiembros = new HashSet<MembresiaMiembro>();
            MiembroEventos = new HashSet<MiembroEvento>();
            PlanEntrenamientoMiembros = new HashSet<PlanEntrenamientoMiembro>();
        }

        public int MiembroId { get; set; }
        public string Nombre { get; set; } = null!;
        public string Apellido { get; set; } = null!;
        public string? UserId { get; set; }

        public virtual AspNetUser? User { get; set; }
        public virtual ICollection<Contacto> Contactos { get; set; }
        public virtual ICollection<MembresiaMiembro> MembresiaMiembros { get; set; }
        public virtual ICollection<MiembroEvento> MiembroEventos { get; set; }
        public virtual ICollection<PlanEntrenamientoMiembro> PlanEntrenamientoMiembros { get; set; }
    }
}
