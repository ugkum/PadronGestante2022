using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using CapaDatos;
using CapaEntidad;

namespace CapaNegocio
{
    public class NegocioCulminacionEmbarazo
    {

        DatosCulminacionEmbarazo objCulEmbarazo = new DatosCulminacionEmbarazo();

        public void registrarCulminacionEmbarazo(EntidadCulminacionEmbarazo objCul)
        {
           objCulEmbarazo.registrarCulminacionEmbarazo(objCul); 
        }
        public void registrarCulminacionEmbarazo_Solo_Aborto(EntidadCulminacionEmbarazo objCul)
        {
            objCulEmbarazo.registrarCulminacionEmbarazo_Solo_Aborto(objCul);
        }
        public void registrarCulminacionEmbarazo_Solo_Parto(EntidadCulminacionEmbarazo objCul)
        {
            objCulEmbarazo.registrarCulminacionEmbarazo_Solo_Parto(objCul);
        }
        public void editarCulminacionEmbarazo(EntidadCulminacionEmbarazo objCul)
        {
          objCulEmbarazo.editarCulminacionEmbarazo(objCul);
        }
        public void editarCulminacionEmbarazo_solo_Parto(EntidadCulminacionEmbarazo objCul)
        {
            objCulEmbarazo.editarCulminacionEmbarazo_solo_Parto(objCul);
        }
        public void editarCulminacionEmbarazo_solo_Aborto(EntidadCulminacionEmbarazo objCul)
        {
            objCulEmbarazo.editarCulminacionEmbarazo_solo_Aborto(objCul);
        }
        public void elimnarCulminacionEmbarazo(EntidadCulminacionEmbarazo objCul)
        {
            objCulEmbarazo.elimnarCulminacionEmbarazo(objCul);
        }

        public DataTable ListarACulminacionEmbarazo(int id)
        {
            return objCulEmbarazo.ListarACulminacionEmbarazo(id);
        }

    }
}
