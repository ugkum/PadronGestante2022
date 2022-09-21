using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data.SqlClient;
using System.Data;

using CapaEntidad;

namespace CapaDatos
{
    public class DatosActividad:DatosConexion
    {

        public void registrarActividad(EntidadActividad objAc)
        {
            Conectar();
            SqlCommand cmd = new SqlCommand("sp_registrar_actividad", Conectar());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@actividad", objAc.actividad);
            cmd.Parameters.AddWithValue("@nroAtencion", objAc.nro_atencion);
            cmd.Parameters.AddWithValue("@fecha_atencion", objAc.fecha_atencion);
            cmd.Parameters.AddWithValue("@id_embarazo", objAc.id_embarazo);
            cmd.Parameters.AddWithValue("@resultado", objAc.resultado);
            cmd.ExecuteNonQuery();
            Desconectar();
        }

        public void EditarActividad(EntidadActividad objAc)
        {
            Conectar();
            SqlCommand cmd = new SqlCommand("sp_editar_actividad", Conectar());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id_actividad", objAc.id_actividad);
            cmd.Parameters.AddWithValue("@actividad", objAc.actividad);
            cmd.Parameters.AddWithValue("@nroAtencion", objAc.nro_atencion);
            cmd.Parameters.AddWithValue("@fecha_atencion", objAc.fecha_atencion);
            cmd.Parameters.AddWithValue("@resultado", objAc.resultado);
            cmd.ExecuteNonQuery();
            Desconectar();
        }

        public void EliminarActividad(EntidadActividad objAc)
        {
            Conectar();
            SqlCommand cmd = new SqlCommand("sp_eliminar_actividad", Conectar());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id_actividad", objAc.id_actividad);
          
            cmd.ExecuteNonQuery();
            Desconectar();
        }

        public DataTable ListarActividad(int id)
        {
            Conectar();
            SqlDataAdapter da = new SqlDataAdapter("sp_mostrar_actividad", Conectar());
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.AddWithValue("@id_embarazo",id);
            DataTable dt = new DataTable();
            da.Fill(dt);
            Desconectar();  
            return dt;
        }

    }
}
