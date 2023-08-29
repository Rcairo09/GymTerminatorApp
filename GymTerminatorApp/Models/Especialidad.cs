using System;
using System.Collections.Generic;

namespace GymTerminatorApp.Models
{
    public partial class Especialidad
    {
        public Especialidad()
        {
            Entrenadors = new HashSet<Entrenador>();
        }

        public int EspecialidadId { get; set; }
        public string Nombre { get; set; } = null!;

        public virtual ICollection<Entrenador> Entrenadors { get; set; }
    }
}
