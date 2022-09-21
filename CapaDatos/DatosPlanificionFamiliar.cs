using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data.SqlClient;
using System.Data;
using CapaEntidad;

namespace CapaDatos
{

    public class DatosPlanificionFamiliar : DatosConexion
    {

        public void registrarPlanificacionFamiliar(EntidadPlanificacionFamiliar objPlanFam)
        {
            Conectar();
            SqlCommand cmd = new SqlCommand("sp_registrar_plan_familiar", Conectar());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@orientacion", objPlanFam.orientacion_consejeria);
            cmd.Parameters.AddWithValue("@fecha_atencion", objPlanFam.fecha_plan);
            cmd.Parameters.AddWithValue("@metodo", objPlanFam.metodo_aplicado);
            cmd.Parameters.AddWithValue("@id_embarazo", objPlanFam.id_embarazo);
            cmd.ExecuteNonQuery();
            Desconectar();
        }

        public void EditarPlanificacionFamiliar(EntidadPlanificacionFamiliar objPlanFam)
        {
            Conectar();
            SqlCommand cmd = new SqlCommand("sp_editar_plan_familiar", Conectar());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id_planificacion", objPlanFam.id_plani_fam);
            cmd.Parameters.AddWithValue("@orientacion", objPlanFam.orientacion_consejeria);
            cmd.Parameters.AddWithValue("@fecha_atencion", objPlanFam.fecha_plan);
            cmd.Parameters.AddWithValue("@metodo", objPlanFam.metodo_aplicado);
            cmd.ExecuteNonQuery();
            Desconectar();
        }

        public void EliminarPlanificacionFamiliar(EntidadPlanificacionFamiliar objPlanFam)
        {
            Conectar();
            SqlCommand cmd = new SqlCommand("sp_eliminar_plan_familiar", Conectar());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id_planificacion", objPlanFam.id_plani_fam);
            cmd.ExecuteNonQuery();
            Desconectar();
        }

        public DataTable ListarPlanificacionFamiliar(EntidadPlanificacionFamiliar objPf)
        {
            Conectar();
            SqlDataAdapter da = new SqlDataAdapter("sp_listar_planificacion_familiar", Conectar());
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.AddWithValue("@id_embarazo", objPf.id_embarazo);
            DataTable dt = new DataTable();
            da.Fill(dt);
            Desconectar();
            return dt;
        }

    }
}
