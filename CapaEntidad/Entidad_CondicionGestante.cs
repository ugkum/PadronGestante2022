using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CapaEntidad
{
    public class Entidad_CondicionGestante
    {

        public int id_condicion_ges { get; set; }
        public string parto_aborto { get; set; }
        public string via { get; set; }
        public string lugar { get; set; }
        public DateTime fecha_parto_aborto { get; set; }
        public string cnv { get; set; }
        public DateTime fecha_CNV { get; set; }
        public int id_embarazo { get; set; }

    }
}
