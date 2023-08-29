using System;
using System.Collections.Generic;

namespace GymTerminatorApp.Models
{
    public partial class TipoContacto
    {
        public TipoContacto()
        {
            Contactos = new HashSet<Contacto>();
        }

        public int TipoContactoId { get; set; }
        public string Nombre { get; set; } = null!;

        public virtual ICollection<Contacto> Contactos { get; set; }
    }
}
