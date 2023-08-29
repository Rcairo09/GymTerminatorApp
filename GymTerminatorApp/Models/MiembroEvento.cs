using System;
using System.Collections.Generic;

namespace GymTerminatorApp.Models
{
    public partial class MiembroEvento
    {
        public int MiembroEventoId { get; set; }
        public int? MiembroId { get; set; }
        public int? EventoId { get; set; }

        public virtual Evento? Evento { get; set; }
        public virtual Miembro? Miembro { get; set; }
    }
}
