using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using CapaDatos;
using CapaEntidad;

namespace CapaNegocio
{
    public class NegocioSuplementacion
    {

        DatosSuplementacion objSupleme = new DatosSuplementacion();

        public void registrarSuplementacion(EntidadSuplementacion objESup)
        {
           objSupleme.registrarSuplementacion(objESup);
        }

        public void EditarSuplementacion(EntidadSuplementacion objESup)
        {
            objSupleme.EditarSuplementacion(objESup);
        }

        public void EliminarSuplementacion(EntidadSuplementacion objESup)
        {
            objSupleme.EliminarSuplementacion(objESup);
        }

        public DataTable mostrarSuplementacion(int idEmbarazo, string tipoSup)
        {
           return objSupleme.mostrarSuplementacion(idEmbarazo, tipoSup);
        }

    }
}
