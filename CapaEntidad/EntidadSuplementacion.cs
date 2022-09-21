using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CapaEntidad
{
    public class EntidadSuplementacion
    {

        public int id_suplementacion { get; set; }
        public string suplementacion { get; set; }
        public string num_suplementacion { get; set; }
        public DateTime fecha_suplementacion { get; set; }
        public int id_embarazo { get; set; }

    }
}
