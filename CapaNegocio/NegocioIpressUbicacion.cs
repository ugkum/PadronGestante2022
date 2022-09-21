using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using CapaDatos;
using CapaEntidad;

namespace CapaNegocio
{
    public class NegocioIpressUbicacion
    {

        DatosUbicacion objUbicacionIpre = new DatosUbicacion();


        public void insertarUbicacion(string red, string microred)
        {
            objUbicacionIpre.insertarUbicacion(red, microred);
        }

        public void modificarUbicacion(string red, string microred)
        {
            objUbicacionIpre.modificarUbicacion(red, microred);
        }
        public DataTable ListarUbicacionIpress()
        {
            return objUbicacionIpre.ListarUbicacionIpress();
        }

    }
}
