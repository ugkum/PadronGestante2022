using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Proxies;
using System.Text;

namespace CapaEntidad
{
    public class EntidadActividad
    {

        public int id_actividad { get; set; }
        public string actividad { get; set; }
        public string nro_atencion { get; set; }
        public DateTime fecha_atencion { get; set; }
        public int id_embarazo { get; set; }
        public string resultado { get; set; }

    }
}
