using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Data.Sql;

using CapaDatos;
using CapaEntidad;

namespace CapaDatos
{
    public class DatosEmbarazo:DatosConexion
    {

        public void RegistrarEmbarazo(EntidadEmbarazo objEE)
        {
            Conectar();
            SqlCommand cmd = new SqlCommand("sp_registrar_embarazo", Conectar());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandTimeout = 0;
            cmd.Parameters.AddWithValue("@idEm", objEE.id_embaazo);
            cmd.Parameters.AddWithValue("@FUR", objEE.fecha_ultima_regla);
            cmd.Parameters.AddWithValue("@FPP", objEE.fecha_plan_parto);
            cmd.Parameters.AddWithValue("@gesta", objEE.gesta);
            cmd.Parameters.AddWithValue("@pariedad", objEE.pariedad);
            cmd.Parameters.AddWithValue("@ID_ATENCION", objEE.id_gestante);
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
                cmd.Dispose();
                Desconectar();
            }
            finally
            {
                Desconectar();
            }
        }

        public void EditarEmbarazo(EntidadEmbarazo objEE)
        {
            Conectar();
            string sql = @"UPDATE embarazo SET 
            FUR='" + objEE.fecha_ultima_regla + "'," +
            "FPP='" + objEE.fecha_plan_parto + "', " +
            "Gesta='"+objEE.gesta+"',"+
            "Pariedad='" + objEE.pariedad + "'" +
            "WHERE id_embarazo= " + objEE.id_embaazo + "";
            SqlCommand cmd = new SqlCommand(sql, Conectar());
            cmd.ExecuteNonQuery();
            Desconectar();
        }

        public void Actualizar_Estado_Embarazo(EntidadEmbarazo objEE)
        {
            Conectar();
            SqlCommand cmd = new SqlCommand("sp_actualizar_estado_embarazo", Conectar());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id_embarazo", objEE.id_embaazo);
            cmd.Parameters.AddWithValue("@estado", objEE.estado);
            cmd.ExecuteNonQuery();
            Desconectar();
        }

        public DataTable listarEmbarazoPorGestante(int id)
        {
            Conectar();
            SqlDataAdapter da = new SqlDataAdapter("sp_listar_embarazo_por_gestante", Conectar());
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.AddWithValue("@id", id);
            DataTable dt = new DataTable();
            da.Fill(dt);
            Desconectar();
            return dt;
        }

        //Metodo para buscar estado del embarazo de gestante//Solo usado en principal, donde se lista gestante para asignar su condicion
        public DataTable listar_Condicion_Embarazo_Por_Gestante(int id)
        {
            Conectar();
            SqlDataAdapter da = new SqlDataAdapter("sp_buscar_codicion_embarazo_por_gestante", Conectar());
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.AddWithValue("@atencion", id);
            DataTable dt = new DataTable();
            da.Fill(dt);
            Desconectar();
            return dt;
        }

        //Reporte general
        public DataTable listar_gestante_EmbarazoEstado_Gestando_Activo()
        {
            Conectar();
            SqlDataAdapter da = new SqlDataAdapter("gestante_con_embarazo_activos", Conectar());
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataTable dt = new DataTable();
            da.Fill(dt);
            Desconectar();
            return dt;
        }

        //
        public DataTable Listar_todos_Gestante_Activos()
        {
            Conectar();
            SqlDataAdapter da = new SqlDataAdapter("Listar_todos_Gestante_Activos", Conectar());
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataTable dt = new DataTable();
            da.Fill(dt);
            Desconectar();
            return dt;
        }
    }
}
