using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using CapaEntidad;
using CapaDatos;

namespace CapaNegocio
{
    public class NegocioControles
    {

        DatosControles objControles = new DatosControles();

        public void registrarControles(EntidadControles objECon)
        {
            objControles.registrarControles(objECon);
        }

        public void EditarControles(EntidadControles objECon)
        {
            objControles.EditarControles(objECon);
        }

        public void EliminarControles(EntidadControles objECon)
        {
            objControles.EliminarControles(objECon);
        }
        public DataTable mostrarSuplementacion(int idEmbarazo)
        {
           return objControles.mostrarSuplementacion(idEmbarazo);
        }

    }
}
