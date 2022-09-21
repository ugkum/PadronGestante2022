using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using CapaDatos;
using CapaEntidad;
using System.Data;

namespace CapaNegocio
{
    public class NegocioAdicional
    {
        DatosAdicional objAdicional = new DatosAdicional();

        public DataTable listarAdicionalGestante(int idGestante)
        {
            return objAdicional.listarAdicionalGestante(idGestante);
        }
        public void registrarAdicional(EntidadAdicional objA)
        {
            objAdicional.registrarAdicional(objA);
        }
        public void EditarAdicional(EntidadAdicional objA)
        {
            objAdicional.EditarAdicional(objA);
        }
    }
}
