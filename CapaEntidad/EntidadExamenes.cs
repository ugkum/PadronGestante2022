using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CapaEntidad
{
    public class EntidadExamenes
    {

        public int id_examanes { get; set; }
        public string prueba { get; set; }
        public string num_prueba { get; set; }
        public DateTime fecha_prueba { get; set; }
        public string resultado { get; set; }
        public int id_embarazo { get; set; }

    }
}
