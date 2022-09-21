using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CapaEntidad
{
    public class EntidadPuerpera
    {

        public int id_puerpera { get; set; }
        public string nro_atencion { get; set; }
        public DateTime fecha_atencion { get; set; }
        public DateTime fecha_suplementacion { get; set; }
        public string valor_HBV { get; set; }
        public int id_embarazo { get; set; }
    }
}
