using System;
using System.Collections.Generic;

namespace GymTerminatorApp.Models
{
    public partial class PlanEntrenamientoMiembro
    {
        public int PlanEntrenamientoMiembroId { get; set; }
        public int? PlanEntrenamientoId { get; set; }
        public int? MiembroId { get; set; }

        public virtual Miembro? Miembro { get; set; }
        public virtual PlanEntrenamiento? PlanEntrenamiento { get; set; }
    }
}
