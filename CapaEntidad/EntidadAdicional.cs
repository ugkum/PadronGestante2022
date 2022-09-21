using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CapaEntidad
{
    public class EntidadAdicional
    {
        public int id_adicional { get; set; }
        public string tipoSeguro { get; set; }
        public string nivel_instruccion { get; set; }
        public string lengua { get; set; }
        public string estado_civil { get; set; }
        public string etnia { get; set; }
        public int id_gestante { get; set; }
    }
}
