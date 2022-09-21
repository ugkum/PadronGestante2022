using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using System.Data.SqlClient;

using CapaDatos;
using CapaEntidad;

namespace CapaNegocio
{
    public class NegocioEcografia
    {

        DatosEcografia objEcografia = new DatosEcografia();

        public void RegistrarEcografia(EntidadEcografia objEco)
        {
            objEcografia.RegistrarEcografia(objEco);
        }

        public void EditarEcografia(EntidadEcografia objEco)
        {
            objEcografia.EditarEcografia(objEco);
        }

        public void EliminarEcografia(EntidadEcografia objEco)
        {
            objEcografia.EliminarEcografia(objEco);
        }
        public DataTable ListarEcografia(EntidadEcografia objEn)
        {
            return objEcografia.ListarEcografia(objEn);
        }

    }
}
