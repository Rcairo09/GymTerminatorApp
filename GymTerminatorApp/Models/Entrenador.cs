using System;
using System.Collections.Generic;

namespace GymTerminatorApp.Models
{
    public partial class Entrenador
    {
        public Entrenador()
        {
            PlanEntrenamientos = new HashSet<PlanEntrenamiento>();
        }

        public int EntrenadorId { get; set; }
        public string Nombre { get; set; } = null!;
        public int? EspecialidadId { get; set; }

        public virtual Especialidad? Especialidad { get; set; }
        public virtual ICollection<PlanEntrenamiento> PlanEntrenamientos { get; set; }
    }
}
