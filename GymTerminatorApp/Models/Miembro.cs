using System;
using System.Collections.Generic;

namespace GymTerminatorApp.Models
{
    public partial class Miembro
    {
        public Miembro()
        {
            Contactos = new HashSet<Contacto>();
            MiembroEventos = new HashSet<MiembroEvento>();
            PlanEntrenamientoMiembros = new HashSet<PlanEntrenamientoMiembro>();
        }

        public int MiembroId { get; set; }
        public string Nombre { get; set; } = null!;
        public string Apellido { get; set; } = null!;
        public int? MembresiaId { get; set; }

        public virtual Membresium? Membresia { get; set; }
        public virtual ICollection<Contacto> Contactos { get; set; }
        public virtual ICollection<MiembroEvento> MiembroEventos { get; set; }
        public virtual ICollection<PlanEntrenamientoMiembro> PlanEntrenamientoMiembros { get; set; }
    }
}
