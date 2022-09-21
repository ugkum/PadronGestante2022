using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CapaEntidad
{
    public class EntidadFormulaObstetrica
    {

        public int id_formula { get; set; }
        public  string gestante { get; set; }
        public string pariedad { get; set; }
        public int id_embarazo { get; set; }

    }
}
