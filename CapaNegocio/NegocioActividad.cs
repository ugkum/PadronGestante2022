using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using CapaDatos;

using CapaEntidad;

namespace CapaNegocio
{
    public class NegocioActividad
    {

        DatosActividad objActividad = new DatosActividad();

        public void registrarActividad(EntidadActividad objAc)
        {
            objActividad.registrarActividad(objAc);
        }

        public void EditarActividad(EntidadActividad objAc)
        {
            objActividad.EditarActividad(objAc);
        }

        public void EliminarActividad(EntidadActividad objAc)
        {
            objActividad.EliminarActividad(objAc);
        }

        public DataTable ListarActividad(int id)
        {
            return objActividad.ListarActividad(id);
        }

    }
}
