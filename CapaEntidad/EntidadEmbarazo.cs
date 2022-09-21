using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CapaEntidad
{
    public class EntidadEmbarazo
    {

        public int id_embaazo { get; set; }
        public DateTime fecha_ultima_regla { get; set; }
        public DateTime fecha_plan_parto { get; set; }
        public string gesta { get; set; }
        public string pariedad { get; set; }
        public int id_gestante { get; set; }
        public string estado { get; set; }

    }
}
