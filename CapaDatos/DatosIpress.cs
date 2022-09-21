using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using System.Data.SqlClient;

using CapaEntidad;

namespace CapaDatos
{
    public class DatosIpress:DatosConexion
    {

        //mostrar ipress
        public DataTable ListarIpress()
        {
            Conectar();
            SqlDataAdapter da = new SqlDataAdapter("sp_listar_ipress", Conectar());
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataTable dt = new DataTable();
            da.Fill(dt);
            Desconectar();
            return dt;
        }
        //registro de ipress
        public void InsertarIpress(EntidadIpress objEI)
        {
            Conectar();
            SqlCommand cmd = new SqlCommand("sp_insertar_ipress", Conectar());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@renaes", objEI.renaes);
            cmd.Parameters.AddWithValue("@nombre", objEI.nombre);
            cmd.Parameters.AddWithValue("@microred", objEI.microred);
            cmd.Parameters.AddWithValue("@red", objEI.red);
            cmd.Parameters.AddWithValue("@estado", objEI.estado);
            try
            {
                cmd.ExecuteNonQuery();
                
            }
            catch (Exception)
            {


            }
            finally
            {
                Desconectar();
            }

        }

    }
}
