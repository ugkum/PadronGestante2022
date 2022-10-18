using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
namespace CapaPresentacion
{
    [Serializable()]
    public class PropiedadConexion
    {

        public string servidor { get; set; }
        public string baseDatos { get; set; }
        public string usuario { get; set; }
        public string clave { get; set; }
        public string nombrePc { get; set; }
        public string puerto { get; set; }

    }
}
