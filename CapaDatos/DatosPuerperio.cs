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
    public class DatosPuerperio:DatosConexion
    {

        public void registrarAtencionPuerpera(EntidadPuerpera objPp )
        {
            Conectar();
            SqlCommand cmd = new SqlCommand("sp_registrar_purperio", Conectar());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@nro_atencion", objPp.nro_atencion);
            cmd.Parameters.AddWithValue("@fecha_atencion", objPp.fecha_atencion); 
            cmd.Parameters.AddWithValue("@valor_hbb", objPp.valor_HBV);
            cmd.Parameters.AddWithValue("@id_embarazo", objPp.id_embarazo);
            cmd.ExecuteNonQuery();
            Desconectar();
        }

        public void registrarAtencion_Puerpera_Solo_1(EntidadPuerpera objPp)
        {
            Conectar();
            SqlCommand cmd = new SqlCommand("sp_registrar_purperio_SOLO_atencion_1", Conectar());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@nro_atencion", objPp.nro_atencion);
            cmd.Parameters.AddWithValue("@fecha_atencion", objPp.fecha_atencion);
            cmd.Parameters.AddWithValue("@fecha_sup", objPp.fecha_suplementacion);
            cmd.Parameters.AddWithValue("@id_embarazo", objPp.id_embarazo);
            cmd.ExecuteNonQuery();
            Desconectar();
        }

        public void EditarAtencionPuerpera(EntidadPuerpera objPp)
        {
            Conectar();
            SqlCommand cmd = new SqlCommand("sp_editar_purperio", Conectar());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id_puerperio", objPp.id_puerpera);
            cmd.Parameters.AddWithValue("@nro_atencion", objPp.nro_atencion);
            cmd.Parameters.AddWithValue("@fecha_atencion", objPp.fecha_atencion);
            cmd.Parameters.AddWithValue("@valor_hbb", objPp.valor_HBV);
            cmd.ExecuteNonQuery();
            Desconectar();
        }

        public void EditarAtencionPuerperaSolo_1(EntidadPuerpera objPp)
        {
            Conectar();
            SqlCommand cmd = new SqlCommand("sp_Editar_purperio_SOLO_atencion_1", Conectar());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id_puerpera", objPp.id_puerpera);
            cmd.Parameters.AddWithValue("@nro_atencion", objPp.nro_atencion);
            cmd.Parameters.AddWithValue("@fecha_atencion", objPp.fecha_atencion);
            cmd.Parameters.AddWithValue("@fecha_suplementacion", objPp.fecha_suplementacion);
            cmd.ExecuteNonQuery();
            Desconectar();
        }
        public void EliminarActencionPuerpera(EntidadPuerpera objPp)
        {
            Conectar();
            SqlCommand cmd = new SqlCommand("sp_eliminar_purperio", Conectar());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id_puerperio", objPp.id_puerpera);
           
            cmd.ExecuteNonQuery();
            Desconectar();
        }

        public DataTable ListarPuerpera(int id)
        {
            Conectar();
            SqlDataAdapter da = new SqlDataAdapter("sp_mostrar_puerperio", Conectar());
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.AddWithValue("@id_embarazo", id);
            DataTable dt = new DataTable();
            da.Fill(dt);
            Desconectar();
            return dt;
        }
    }
}
