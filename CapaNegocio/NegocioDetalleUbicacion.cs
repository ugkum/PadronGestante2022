using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using CapaDatos;
using CapaEntidad;

namespace CapaNegocio
{
    public class NegocioDetalleUbicacion
    {

        DatosDetalleUbicacion objDetUbicacion = new DatosDetalleUbicacion();    

        public void RegistrarUbicacion(string dep, string prov, string distr, string centroPob,string direccion, int idGesta)
        {
           objDetUbicacion.RegistrarUbicacion(dep,prov,distr,centroPob,direccion,idGesta);
        }

        public void EditarUbicacion(string dep, string prov, string distr, string centroPob,string direccion, int idGesta)
        {
            objDetUbicacion.EditarUbicacion(dep, prov, distr, centroPob, direccion,  idGesta);
        }

    }
}
