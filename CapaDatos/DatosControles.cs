using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using System.Data.SqlClient;

using CapaEntidad;

namespace CapaDatos
{
    public class DatosControles:DatosConexion
    {
        public void registrarControles(EntidadControles objECon)
        {
            Conectar();
            SqlCommand cmd = new SqlCommand("sp_registrar_controles", Conectar());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandTimeout = 0;
            cmd.Parameters.AddWithValue("@num_control", objECon.num_control);
            cmd.Parameters.AddWithValue("@fecha", objECon.fecha_control);
            cmd.Parameters.AddWithValue("@edad_ges", objECon.edad_ges);
            cmd.Parameters.AddWithValue("@id_embarazo", objECon.id_embarazo);
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
                cmd.Dispose();
                Desconectar();

            }
            cmd.Dispose();
            Desconectar();
        }

        public void EditarControles(EntidadControles objECon)
        {
            Conectar();
            SqlCommand cmd = new SqlCommand("sp_editar_controles", Conectar());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id_control", objECon.id_control);
            cmd.Parameters.AddWithValue("@num_control", objECon.num_control);
            cmd.Parameters.AddWithValue("@fecha", objECon.fecha_control);
            cmd.Parameters.AddWithValue("@edad_ges", objECon.edad_ges);
            cmd.Parameters.AddWithValue("@id_embarazo", objECon.id_embarazo);
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
                cmd.Dispose();
                Desconectar();

            }
            cmd.Dispose();
            Desconectar();
        }

        public void EliminarControles(EntidadControles objECon)
        {
            Conectar();
            SqlCommand cmd = new SqlCommand("sp_eliminar_controles", Conectar());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id_control", objECon.id_control);
            cmd.Parameters.AddWithValue("@id_embarazo", objECon.id_embarazo);
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
                cmd.Dispose();
                Desconectar();

            }
            cmd.Dispose();
            Desconectar();
        }
        public DataTable mostrarSuplementacion(int idEmbarazo)
        {
            Conectar();
            SqlDataAdapter da = new SqlDataAdapter("sp_mostrar_Controles", Conectar());
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.AddWithValue("@id_embarazo", idEmbarazo);
            DataTable dt = new DataTable();
            da.Fill(dt);
            Desconectar();
            return dt;
        }
    }
}
