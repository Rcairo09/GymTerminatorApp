using System;
using System.Collections.Generic;

namespace GymTerminatorApp.Models
{
    public partial class PlanEntrenamientoEjercicio
    {
        public int PlanEntrenamientoEjercicioId { get; set; }
        public int? PlanEntrenamientoId { get; set; }
        public int? EjercicioId { get; set; }

        public virtual Ejercicio? Ejercicio { get; set; }
        public virtual PlanEntrenamiento? PlanEntrenamiento { get; set; }
    }
}
