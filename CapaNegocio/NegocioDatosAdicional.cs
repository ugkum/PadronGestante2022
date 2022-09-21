using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using CapaDatos;
using CapaEntidad;

namespace CapaNegocio
{
    public class NegocioDatosAdicional
    {

        Datos_DatosAdicional objDatosAdicional = new Datos_DatosAdicional();

        public void registrarDatosAdicional(EntidadDatosAdicional objDatAd)
        {
           objDatosAdicional.registrarDatosAdicional(objDatAd);
        }

        public void EditarDatosAdicional(EntidadDatosAdicional objDatAd)
        {
            objDatosAdicional.EditarDatosAdicional(objDatAd);
        }

        public void EliminarDatosAdicional(EntidadDatosAdicional objDatAd)
        {
            objDatosAdicional.EliminarDatosAdicional(objDatAd);
        }

        public DataTable ListarDatosAdicional(int id)
        {
           return objDatosAdicional.ListarDatosAdicional(id);
        }

    }
}
