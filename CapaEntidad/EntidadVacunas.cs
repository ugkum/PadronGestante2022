using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CapaEntidad
{
    public class EntidadVacunas
    {

        public int id_vacuanas { get; set; }
        public string num_vacunas { get; set; }
        public string vacuna { get; set; }
        public DateTime fecha { get; set; }
        public int id_gestante { get; set; }
        public int id_embarazo { get; set; }

    }
}
