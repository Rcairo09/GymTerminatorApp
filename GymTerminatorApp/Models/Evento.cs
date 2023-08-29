using System;
using System.Collections.Generic;

namespace GymTerminatorApp.Models
{
    public partial class Evento
    {
        public Evento()
        {
            MiembroEventos = new HashSet<MiembroEvento>();
        }

        public int EventoId { get; set; }
        public string Nombre { get; set; } = null!;
        public string? Descripcion { get; set; }
        public DateTime? FechaInicio { get; set; }
        public DateTime? FechaFin { get; set; }

        public virtual ICollection<MiembroEvento> MiembroEventos { get; set; }
    }
}
