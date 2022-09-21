using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CapaEntidad
{
    public class EntidadUbicacion
    {

        public int id_ubicacion { get; set; }
        public string departamento { get; set; }
        public string provincia { get; set; }
        public string distrito { get; set; }
        public string centro_poblado { get; set; }
        public string direccion_actual { get; set; }
        public int id_gestante { get; set; }
    }
}
