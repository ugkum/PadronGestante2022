using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using CapaDatos;
using CapaEntidad;

namespace CapaNegocio
{
    public class NegocioIpress
    {

        //objeto de la clase DatosIpress
        DatosIpress objDIpress = new DatosIpress();

        //mostrar ipress
        public DataTable ListarIpress()
        {
            return objDIpress.ListarIpress();
        }
        //registro de ipress
        public void InsertarIpress(EntidadIpress objEI)
        {
            objDIpress.InsertarIpress(objEI);
        }

    }
}
