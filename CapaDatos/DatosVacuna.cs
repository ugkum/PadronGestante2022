using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

using CapaEntidad;

namespace CapaDatos
{
    public class DatosVacuna:DatosConexion
    {

        public void registrarVacunas(EntidadVacunas objEVac)
        {
            Conectar();
            SqlCommand cmd = new SqlCommand("sp_insertar_vacuna", Conectar());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandTimeout = 0;
            cmd.Parameters.AddWithValue("@num_vacuna", objEVac.num_vacunas);
            cmd.Parameters.AddWithValue("@vacuna", objEVac.vacuna);
            cmd.Parameters.AddWithValue("@fecha", objEVac.fecha);
            cmd.Parameters.AddWithValue("@id_gestante", objEVac.id_gestante);
            cmd.Parameters.AddWithValue("@id_embarazo", objEVac.id_embarazo);
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

        public void editarVacunas(EntidadVacunas objEVac)
        {
            Conectar();
            SqlCommand cmd = new SqlCommand("sp_editar_vacuna", Conectar());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id_vacuna", objEVac.id_vacuanas);
            cmd.Parameters.AddWithValue("@num_vacuna", objEVac.num_vacunas);
            cmd.Parameters.AddWithValue("@vacuna", objEVac.vacuna);
            cmd.Parameters.AddWithValue("@fecha", objEVac.fecha);
            cmd.Parameters.AddWithValue("@id_gestante", objEVac.id_gestante);
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
        public void eliminarVacunas(EntidadVacunas objEVac)
        {
            Conectar();
            SqlCommand cmd = new SqlCommand("sp_eliminar_vacuna", Conectar());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id_vacuna", objEVac.id_vacuanas);
           
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

        public DataTable mostrarVacunas(int idGestante)
        {
            Conectar();
            SqlDataAdapter da = new SqlDataAdapter("sp_mostrar_vacuna", Conectar());
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.AddWithValue("@id_gestante", idGestante);
            DataTable dt = new DataTable();
            da.Fill(dt);
            Desconectar();
            return dt;
        }
    }
}
