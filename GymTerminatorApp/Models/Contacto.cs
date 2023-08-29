using System;
using System.Collections.Generic;

namespace GymTerminatorApp.Models
{
    public partial class Contacto
    {
        public int ContactoId { get; set; }
        public int? MiembroId { get; set; }
        public int TipoContactoId { get; set; }
        public string ValorContacto { get; set; } = null!;

        public virtual Miembro? Miembro { get; set; }
        public virtual TipoContacto TipoContacto { get; set; } = null!;
    }
}
