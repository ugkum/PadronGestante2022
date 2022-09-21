using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CapaEntidad
{
    public class EntidadEcografia
    {
        public string nro_eco { get; set; }
        public int id_ecografia { get; set; }
        public DateTime fecha_ecografia { get; set; }
        public string edad_gestacional { get; set; }
        public int  id_embarazo { get; set; }
    }
}
