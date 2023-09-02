using System;
using System.Collections.Generic;

namespace GymTerminatorApp.Models
{
    public partial class PlanEntrenamientoMiembro
    {
        public int PlanEntrenamientoMiembroId { get; set; }
        public int? PlanEntrenamientoId { get; set; }
        public string UserId { get; set; } = null!;

        public virtual PlanEntrenamiento? PlanEntrenamiento { get; set; }
        public virtual AspNetUser User { get; set; } = null!;
    }
}
