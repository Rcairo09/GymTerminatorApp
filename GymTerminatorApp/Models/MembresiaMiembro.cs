using System;
using System.Collections.Generic;

namespace GymTerminatorApp.Models
{
    public partial class MembresiaMiembro
    {
        public int MembresiaMiembroId { get; set; }
        public int MembresiaId { get; set; }
        public DateTime FechaAdquisicion { get; set; }
        public string UserId { get; set; } = null!;

        public virtual Membresium Membresia { get; set; } = null!;
        public virtual AspNetUser User { get; set; } = null!;
    }
}
