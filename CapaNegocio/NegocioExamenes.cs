using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using CapaDatos;
using CapaEntidad;

namespace CapaNegocio
{
    public class NegocioExamenes
    {

        DatosExamen objExamen = new DatosExamen();

        public void insertarExamen(EntidadExamenes objExa)
        {
           objExamen.insertarExamen(objExa);
        }

        public void EditarExamen(EntidadExamenes objExa)
        {
            objExamen.EditarExamen(objExa);
        }
        public void EliminarExamen(EntidadExamenes objExa)
        {
            objExamen.EliminarExamen(objExa);
        }

        public DataTable MostrarExamenes(int id)
        {
            return objExamen.MostrarExamenes(id);
        }
    }

}
