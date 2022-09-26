using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using System.Data.SqlClient;

using CapaDatos;
using CapaEntidad;

namespace CapaDatos
{
    public class DatosSuplementacion : DatosConexion
    {

        public void registrarSuplementacion(EntidadSuplementacion objESup)
        {
            Conectar();
            SqlCommand cmd = new SqlCommand("insertar_suplementacion", Conectar());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandTimeout = 0;
            cmd.Parameters.AddWithValue("@suplementacion", objESup.suplementacion);
            cmd.Parameters.AddWithValue("@num_sup", objESup.num_suplementacion);
            cmd.Parameters.AddWithValue("@fecha_sup", objESup.fecha_suplementacion);
            cmd.Parameters.AddWithValue("@id_embarazo", objESup.id_embarazo);
           int n= cmd.ExecuteNonQuery();
            
            Desconectar();
        }

        public void EditarSuplementacion(EntidadSuplementacion objESup)
        {
            Conectar();
            SqlCommand cmd = new SqlCommand("editar_suplementacion", Conectar());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id_suplemen", objESup.id_suplementacion);
            cmd.Parameters.AddWithValue("@suplementacion", objESup.suplementacion);
            cmd.Parameters.AddWithValue("@num_sup", objESup.num_suplementacion);
            cmd.Parameters.AddWithValue("@fecha_sup", objESup.fecha_suplementacion);
            cmd.Parameters.AddWithValue("@id_embarazo", objESup.id_embarazo);
            cmd.ExecuteNonQuery();
            Desconectar();
        }

        public void EliminarSuplementacion(EntidadSuplementacion objESup)
        {
            Conectar();
            SqlCommand cmd = new SqlCommand("eliminar_suplementacion", Conectar());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id_suplemen", objESup.id_suplementacion);
            cmd.Parameters.AddWithValue("@id_embarazo", objESup.id_embarazo);
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

        public DataTable mostrarSuplementacion(int idEmbarazo, string tipoSup)
        {
            Conectar();
            SqlDataAdapter da = new SqlDataAdapter("mostrar_suplementacion", Conectar());
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.AddWithValue("@id_embarazo", idEmbarazo);
            da.SelectCommand.Parameters.AddWithValue("@tipo", tipoSup);
            DataTable dt = new DataTable();
            da.Fill(dt);
            Desconectar();
            return dt;
        }

    }
}
