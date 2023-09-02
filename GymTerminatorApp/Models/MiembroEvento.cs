using System;
using System.Collections.Generic;

namespace GymTerminatorApp.Models
{
    public partial class MiembroEvento
    {
        public int MiembroEventoId { get; set; }
        public int? EventoId { get; set; }
        public string UserId { get; set; } = null!;

        public virtual Evento? Evento { get; set; }
        public virtual AspNetUser User { get; set; } = null!;
    }
}
