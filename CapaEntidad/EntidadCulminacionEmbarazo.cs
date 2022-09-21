using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CapaEntidad
{
    public class EntidadCulminacionEmbarazo
    {

        public int id_culmicacion { get; set; }
        public string tipo_parto { get; set; }
        public string via { get; set; }
        public string lugar { get; set; }
        public DateTime fecha_cul { get; set; }
        public string certificado_nac_vivo { get; set; }
        public string tipo_cer { get; set; }
        public DateTime fecha_Cer { get; set; }

        public int id_embarazo { get; set; }

    }
}
