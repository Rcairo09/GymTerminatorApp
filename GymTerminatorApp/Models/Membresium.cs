﻿using System;
using System.Collections.Generic;

namespace GymTerminatorApp.Models
{
    public partial class Membresium
    {
        public Membresium()
        {
            MembresiaMiembros = new HashSet<MembresiaMiembro>();
        }

        public int MembresiaId { get; set; }
        public string Nombre { get; set; } = null!;
        public decimal Precio { get; set; }
        public int Duracion { get; set; }
        public string UnidadDuracion { get; set; } = null!;
        public string? Descripcion { get; set; }

        public virtual ICollection<MembresiaMiembro> MembresiaMiembros { get; set; }
    }
}
