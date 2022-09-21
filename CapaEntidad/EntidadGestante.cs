using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CapaEntidad
{
    public class EntidadGestante
    {
        public int id_gestantes { get; set; }
        public string tipoDoc { get; set; }
        public string nroDoc { get; set; }
        public string paterno { get; set; }
        public string materno { get; set; }
        public string nombre { get; set; }
        public string nombre2 { get; set; }
        public DateTime fechaNac { get; set; }
        public int edad { get; set; }
        public string grupo_sanguineo { get; set; }
        public string tipo_sangre { get; set; }
        public string telefono { get; set; }
        public int id_ipress { get; set; }
    }
}
