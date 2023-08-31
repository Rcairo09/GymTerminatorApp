using System;
using System.Collections.Generic;

namespace GymTerminatorApp.Models
{
    public partial class MembresiaMiembro
    {
        public int MembresiaMiembroId { get; set; }
        public int MembresiaId { get; set; }
        public int MiembroId { get; set; }
        public DateTime FechaAdquisicion { get; set; }

        public virtual Membresium Membresia { get; set; } = null!;
        public virtual Miembro Miembro { get; set; } = null!;
    }
}
