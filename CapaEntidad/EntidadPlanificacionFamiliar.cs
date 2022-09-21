using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CapaEntidad
{
    public class EntidadPlanificacionFamiliar
    {

        public int id_plani_fam { get; set; }
        public string orientacion_consejeria { get; set; }

        public DateTime fecha_plan { get; set; }
        public string metodo_aplicado { get; set; }
        public int id_embarazo { get; set; }
    }
}
