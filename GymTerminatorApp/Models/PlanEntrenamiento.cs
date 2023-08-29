using System;
using System.Collections.Generic;

namespace GymTerminatorApp.Models
{
    public partial class PlanEntrenamiento
    {
        public PlanEntrenamiento()
        {
            PlanEntrenamientoEjercicios = new HashSet<PlanEntrenamientoEjercicio>();
            PlanEntrenamientoMiembros = new HashSet<PlanEntrenamientoMiembro>();
        }

        public int PlanEntrenamientoId { get; set; }
        public string? Nombre { get; set; }
        public string? Descripcion { get; set; }
        public int? EntrenadorId { get; set; }

        public virtual Entrenador? Entrenador { get; set; }
        public virtual ICollection<PlanEntrenamientoEjercicio> PlanEntrenamientoEjercicios { get; set; }
        public virtual ICollection<PlanEntrenamientoMiembro> PlanEntrenamientoMiembros { get; set; }
    }
}
