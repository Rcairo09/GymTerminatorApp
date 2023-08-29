using System;
using System.Collections.Generic;

namespace GymTerminatorApp.Models
{
    public partial class Ejercicio
    {
        public Ejercicio()
        {
            PlanEntrenamientoEjercicios = new HashSet<PlanEntrenamientoEjercicio>();
        }

        public int EjercicioId { get; set; }
        public string Nombre { get; set; } = null!;
        public string? Descripcion { get; set; }

        public virtual ICollection<PlanEntrenamientoEjercicio> PlanEntrenamientoEjercicios { get; set; }
    }
}
