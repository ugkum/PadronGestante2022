using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using System.Data.SqlClient;

using CapaEntidad;

namespace CapaDatos
{
    public class DatosEcografia:DatosConexion
    {

        
        public void RegistrarEcografia(EntidadEcografia objEco)
        {
            Conectar();
            SqlCommand cmd = new SqlCommand("sp_insertar_ecografia", Conectar());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@nro_eco", objEco.nro_eco);
            cmd.Parameters.AddWithValue("@fecha", objEco.fecha_ecografia);
            cmd.Parameters.AddWithValue("@edad_ges", objEco.edad_gestacional);
            cmd.Parameters.AddWithValue("@id_embarazo", objEco.id_embarazo);
           
            cmd.ExecuteNonQuery();
            Desconectar();
        }

        public void EditarEcografia(EntidadEcografia objEco)
        {
            Conectar();
            SqlCommand cmd = new SqlCommand("sp_editar_ecografia", Conectar());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@nro_eco", objEco.nro_eco);
            cmd.Parameters.AddWithValue("@id_ecografia", objEco.id_ecografia);
            cmd.Parameters.AddWithValue("@fecha", objEco.fecha_ecografia);
            cmd.Parameters.AddWithValue("@edad_ges", objEco.edad_gestacional);
            cmd.Parameters.AddWithValue("@id_embarazo", objEco.id_embarazo);

            cmd.ExecuteNonQuery();
            Desconectar();
        }
        public void EliminarEcografia(EntidadEcografia objEco)
        {
            Conectar();
            SqlCommand cmd = new SqlCommand("sp_eliminar_ecografia", Conectar());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id_ecografia", objEco.id_ecografia);
            cmd.Parameters.AddWithValue("@id_embarazo", objEco.id_embarazo);

            cmd.ExecuteNonQuery();
            Desconectar();
        }

        public DataTable ListarEcografia(EntidadEcografia objEn)
        {
            Conectar();
            SqlDataAdapter da = new SqlDataAdapter("sp_listar_ecografia",Conectar());
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.AddWithValue("@id_embarazo", objEn.id_embarazo);
            DataTable dt = new DataTable();
            da.Fill(dt);
            Desconectar();
            return dt;
        }
    }
}
