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
    public class DatosCulminacionEmbarazo:DatosConexion
    {

        public void registrarCulminacionEmbarazo (EntidadCulminacionEmbarazo objCul)
        {
            Conectar();
            SqlCommand cmd = new SqlCommand("sp_registrar_culminacion_embarazo", Conectar());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandTimeout = 0;
            cmd.Parameters.AddWithValue("@tipo_parto", objCul.tipo_parto);
            cmd.Parameters.AddWithValue("@via", objCul.via);
            cmd.Parameters.AddWithValue("@lugar", objCul.lugar);
            cmd.Parameters.AddWithValue("@fecha", objCul.fecha_cul);
            cmd.Parameters.AddWithValue("@certificado_nac_vivo", objCul.certificado_nac_vivo);
            cmd.Parameters.AddWithValue("@tipo_certificado", objCul.tipo_cer);
            cmd.Parameters.AddWithValue("@fecha_cer", objCul.fecha_Cer);
            cmd.Parameters.AddWithValue("@id_embarazo", objCul.id_embarazo);

            cmd.ExecuteNonQuery();
            Desconectar();
        }

        public void registrarCulminacionEmbarazo_Solo_Aborto(EntidadCulminacionEmbarazo objCul)
        {
            Conectar();
            SqlCommand cmd = new SqlCommand("sp_guardar_solo_aborto", Conectar());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@tipo_parto", objCul.tipo_parto);
            cmd.Parameters.AddWithValue("@fecha", objCul.fecha_cul);
            cmd.Parameters.AddWithValue("@id_embarazo", objCul.id_embarazo);

            cmd.ExecuteNonQuery();
            Desconectar();
        }

        public void registrarCulminacionEmbarazo_Solo_Parto(EntidadCulminacionEmbarazo objCul)
        {
            Conectar();
            SqlCommand cmd = new SqlCommand("sp_guardar_solo_parto", Conectar());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@tipo_parto", objCul.tipo_parto);
            cmd.Parameters.AddWithValue("@via", objCul.via);
            cmd.Parameters.AddWithValue("@lugar", objCul.lugar);
            cmd.Parameters.AddWithValue("@CNV", objCul.certificado_nac_vivo);
            cmd.Parameters.AddWithValue("@fecha", objCul.fecha_cul);
            cmd.Parameters.AddWithValue("@id_embarazo", objCul.id_embarazo);

            cmd.ExecuteNonQuery();
            Desconectar();
        }

        public void editarCulminacionEmbarazo(EntidadCulminacionEmbarazo objCul)
        {
            Conectar();
            SqlCommand cmd = new SqlCommand("sp_editar_culminacion_embarazo", Conectar());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id_culminacion", objCul.id_culmicacion);
            cmd.Parameters.AddWithValue("@tipo_parto", objCul.tipo_parto);
            cmd.Parameters.AddWithValue("@via", objCul.via);
            cmd.Parameters.AddWithValue("@lugar", objCul.lugar);
            cmd.Parameters.AddWithValue("@fecha", objCul.fecha_cul);
            cmd.Parameters.AddWithValue("@certificado_nac_vivo", objCul.certificado_nac_vivo);
            cmd.Parameters.AddWithValue("@tipo_certificado", objCul.tipo_cer);
            cmd.Parameters.AddWithValue("@fecha_cer", objCul.fecha_Cer);
            cmd.Parameters.AddWithValue("@id_embarazo", objCul.id_embarazo);

            cmd.ExecuteNonQuery();
            Desconectar();
        }

        public void editarCulminacionEmbarazo_solo_Parto(EntidadCulminacionEmbarazo objCul)
        {
            Conectar();
            SqlCommand cmd = new SqlCommand("sp_editar_solo_parto", Conectar());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id_culminacion", objCul.id_culmicacion);
            cmd.Parameters.AddWithValue("@tipo_parto", objCul.tipo_parto);
            cmd.Parameters.AddWithValue("@via", objCul.via);
            cmd.Parameters.AddWithValue("@lugar", objCul.lugar);
            cmd.Parameters.AddWithValue("@fecha", objCul.fecha_cul);
            cmd.ExecuteNonQuery();
            Desconectar();
        }

        public void editarCulminacionEmbarazo_solo_Aborto(EntidadCulminacionEmbarazo objCul)
        {
            Conectar();
            SqlCommand cmd = new SqlCommand("sp_editar_solo_aborto", Conectar());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id_culminacion", objCul.id_culmicacion);
            cmd.Parameters.AddWithValue("@tipo_parto", objCul.tipo_parto);
            cmd.Parameters.AddWithValue("@fecha", objCul.fecha_cul);
            cmd.ExecuteNonQuery();
            Desconectar();
        }

        public void elimnarCulminacionEmbarazo(EntidadCulminacionEmbarazo objCul)
        {
            Conectar();
            SqlCommand cmd = new SqlCommand("sp_eliminar_culminacion_embarazo", Conectar());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id_culminacion", objCul.id_culmicacion);
           
            cmd.ExecuteNonQuery();
            Desconectar();
        }

        public DataTable ListarACulminacionEmbarazo(int id)
        {
            Conectar();
            SqlDataAdapter da = new SqlDataAdapter("sp_mostrar_culminacion", Conectar());
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.AddWithValue("@id_embarazo", id);
            DataTable dt = new DataTable();
            da.Fill(dt);
            Desconectar();
            return dt;
        }
    }
}
