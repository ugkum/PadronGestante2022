using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

using CapaEntidad;

namespace CapaDatos
{
    public class DatosExamen:DatosConexion
    {

        public void insertarExamen(EntidadExamenes objExa)
        {
            Conectar();
            SqlCommand cmd = new SqlCommand("sp_insertar_examen",Conectar());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandTimeout = 0;
            cmd.Parameters.AddWithValue("@prueba",objExa.prueba);
            cmd.Parameters.AddWithValue("@num_prueba", objExa.num_prueba);
            cmd.Parameters.AddWithValue("@fecha", objExa.fecha_prueba);
            cmd.Parameters.AddWithValue("@resultado", objExa.resultado);
            cmd.Parameters.AddWithValue("@id_embarazo", objExa.id_embarazo);
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

        public void EditarExamen(EntidadExamenes objExa)
        {
            Conectar();
            SqlCommand cmd = new SqlCommand("sp_editar_examen", Conectar());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id_examen", objExa.id_examanes);
            cmd.Parameters.AddWithValue("@prueba", objExa.prueba);
            cmd.Parameters.AddWithValue("@num_prueba", objExa.num_prueba);
            cmd.Parameters.AddWithValue("@fecha", objExa.fecha_prueba);
            cmd.Parameters.AddWithValue("@resultado", objExa.resultado);
            cmd.Parameters.AddWithValue("@id_embarazo", objExa.id_embarazo);
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

        public void EliminarExamen(EntidadExamenes objExa)
        {
            Conectar();
            SqlCommand cmd = new SqlCommand("sp_eliminar_examen", Conectar());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id_examen", objExa.id_examanes);
            
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

        public DataTable MostrarExamenes(int id)
        {
            Conectar();
            SqlDataAdapter da = new SqlDataAdapter("sp_listar_examenes", Conectar());
            da.SelectCommand.CommandType=CommandType.StoredProcedure;
            da.SelectCommand.Parameters.AddWithValue("@id_Embarazo",id);
            DataTable dt = new DataTable();
            da.Fill(dt);
            Desconectar();
            return dt;
        }

    }
}
