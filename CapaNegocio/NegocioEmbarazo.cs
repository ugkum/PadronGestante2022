using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;

using CapaDatos;
using CapaEntidad;

namespace CapaNegocio
{
    public class NegocioEmbarazo
    {


        DatosEmbarazo objEmbarazo = new DatosEmbarazo();

        public void RegistrarEmbarazo(EntidadEmbarazo objEE)
        {
             objEmbarazo.RegistrarEmbarazo(objEE);
        }

        public void EditarEmbarazo(EntidadEmbarazo objEE)
        {
            objEmbarazo.EditarEmbarazo(objEE);
        }

        public DataTable listarEmbarazoPorGestante(int id)
        {
            return objEmbarazo.listarEmbarazoPorGestante(id);
        }

        public DataTable listar_Condicion_Embarazo_Por_Gestante(int id)
        {
            return objEmbarazo.listar_Condicion_Embarazo_Por_Gestante(id);
        }
        public void Actualizar_Estado_Embarazo(EntidadEmbarazo objEE)
        {
             objEmbarazo.Actualizar_Estado_Embarazo(objEE);
        }

        public DataTable listar_gestante_EmbarazoEstado_Gestando_Activo()
        {
            return objEmbarazo.listar_gestante_EmbarazoEstado_Gestando_Activo();
        }

        public DataTable Listar_todos_Gestante_Activos()
        {
            return objEmbarazo.Listar_todos_Gestante_Activos();
        }
    }
}
