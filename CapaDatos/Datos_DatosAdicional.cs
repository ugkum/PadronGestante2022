using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using System.Data.SqlClient;
using CapaEntidad;


namespace CapaDatos
{
    public class Datos_DatosAdicional:DatosConexion
    {

        public void registrarDatosAdicional(EntidadDatosAdicional objDatAd)
        {
            Conectar();
            SqlCommand cmd = new SqlCommand("sp_registrar_datos_adicional", Conectar());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@nombre_contacto", objDatAd.nombre);
            cmd.Parameters.AddWithValue("@telefono", objDatAd.telefono);
            cmd.Parameters.AddWithValue("@observacion", objDatAd.observacion);
            cmd.Parameters.AddWithValue("@id_embarazo", objDatAd.id_embarazo);
            cmd.ExecuteNonQuery();
            Desconectar();
        }

        public void EditarDatosAdicional(EntidadDatosAdicional objDatAd)
        {
            Conectar();
            SqlCommand cmd = new SqlCommand("sp_editar_datos_adicional", Conectar());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id_datos_adicional", objDatAd.id_datos_adicional);
            cmd.Parameters.AddWithValue("@nombre_contacto", objDatAd.nombre);
            cmd.Parameters.AddWithValue("@telefono", objDatAd.telefono);
            cmd.Parameters.AddWithValue("@observacion", objDatAd.observacion);
            cmd.ExecuteNonQuery();
            Desconectar();
        }

        public void EliminarDatosAdicional(EntidadDatosAdicional objDatAd)
        {
            Conectar();
            SqlCommand cmd = new SqlCommand("sp_eliminar_datos_adicional", Conectar());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id_datos_adicional", objDatAd.id_datos_adicional);
            cmd.ExecuteNonQuery();
            Desconectar();
        }

        public DataTable ListarDatosAdicional(int ID)
        {
            Conectar();
            SqlDataAdapter da = new SqlDataAdapter("sp_listar_Datos_adicional", Conectar());
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.AddWithValue("@id_embarazo", ID);
            DataTable dt = new DataTable();
            da.Fill(dt);
            Desconectar();
            return dt;
        }

    }
}
