using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using System.Data.SqlClient;
using CapaEntidad;

namespace CapaDatos
{
    public class DatosGestantes:DatosConexion
    {

        public DataTable listarGestantes(int idIpress, string estado, string texto)
        {
            Conectar();
            SqlDataAdapter da = new SqlDataAdapter("sp_listar_gestante", Conectar());
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.AddWithValue("@id_ipress",idIpress);
            da.SelectCommand.Parameters.AddWithValue("@estado", estado);
            da.SelectCommand.Parameters.AddWithValue("@texto", texto);
            DataTable dt = new DataTable();
            da.Fill(dt);
            Desconectar();
            return dt;
        }

        public DataTable UltimoRegistro()
        {
            Conectar();
            SqlDataAdapter da = new SqlDataAdapter("sp_ultimo_registro_gestante", Conectar());
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataTable dt = new DataTable();
            da.Fill(dt);
            Desconectar();
            return dt;
        }

        public DataTable ListarNotificacionControlesGestante()
        {
            Conectar();
            SqlDataAdapter da = new SqlDataAdapter("sp_listar_controles_notificados", Conectar());
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataTable dt = new DataTable();
            da.Fill(dt);
            Desconectar();
            return dt;
        }

        public DataTable BuscarGestante_por_dni_por_ipress(string dni, int idIpress)
        {
            Conectar();
            SqlDataAdapter da = new SqlDataAdapter("sp_buscar_gestante_en_establecimiento", Conectar());
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.AddWithValue("@num_doc",dni);
            da.SelectCommand.Parameters.AddWithValue("@id_Ess",idIpress);
            DataTable dt = new DataTable();
            da.Fill(dt);
            Desconectar();
            return dt;
        }

        public DataTable BuscarGestante_por_ID_Actualizar(int idGes)
        {
            Conectar();
            SqlDataAdapter da = new SqlDataAdapter("sp_buscar_gestante_para_actualizar", Conectar());
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.AddWithValue("@idGest", idGes);
           
            DataTable dt = new DataTable();
            da.Fill(dt);
            Desconectar();
            return dt;
        }
        public DataTable BuscarGestante_por_dni(string dni)
        {
            Conectar();
            SqlDataAdapter da = new SqlDataAdapter("sp_buscar_gestante_po_dni", Conectar());
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.AddWithValue("@num_doc", dni);
           
            DataTable dt = new DataTable();
            da.Fill(dt);
            Desconectar();
            return dt;
        }

        public DataTable BuscarGestante_por_dni_para_agregar_solo_atencion(string dni)
        {
            Conectar();
            SqlDataAdapter da = new SqlDataAdapter("buscar_y_obtener_datos_de_gestante", Conectar());
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.AddWithValue("@num_doc", dni);

            DataTable dt = new DataTable();
            da.Fill(dt);
            Desconectar();
            return dt;
        }

        public DataTable buscar_gestante_en_ipress_actual(string dni, int id_ipress)
        {
            Conectar();
            SqlDataAdapter da = new SqlDataAdapter("buscar_gestante_en_ipress_actual", Conectar());
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.AddWithValue("@dni", dni);
            da.SelectCommand.Parameters.AddWithValue("@id_ipress", id_ipress);
            DataTable dt = new DataTable();
            da.Fill(dt);
            Desconectar();
            return dt;
        }

        public DataTable ReporteGeneral_Resumen()
        {
            Conectar();
            SqlDataAdapter da = new SqlDataAdapter("sp_resumen_reporte_general", Conectar());
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataTable dt = new DataTable();
            da.Fill(dt);
            Desconectar();
            return dt;
        }

        public DataSet Imprimir_Atenciones_Gestante_del_Embarazo(int codigo)
        {
            Conectar();
            SqlDataAdapter da = new SqlDataAdapter("SP_IMPRIMIR_PADRON_GESTANTE", Conectar());
            da.SelectCommand.CommandTimeout = 0;
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.AddWithValue("@CODIGO", codigo);
            DataSet dt = new DataSet();
            da.Fill(dt,"Padron");
            Desconectar();
            return dt;
        }
        public void registrarGestante(EntidadGestante objEG)
        {
            Conectar();
            SqlCommand cmd = new SqlCommand("sp_insertar_gestante", Conectar());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@tipo_doc", objEG.tipoDoc);
            cmd.Parameters.AddWithValue("@num_doc", objEG.nroDoc);
            cmd.Parameters.AddWithValue("@paterno", objEG.paterno);
            cmd.Parameters.AddWithValue("@materno", objEG.materno);
            cmd.Parameters.AddWithValue("@nombre", objEG.nombre);
            cmd.Parameters.AddWithValue("@nombre2", objEG.nombre2);
            cmd.Parameters.AddWithValue("@fecha_nac", objEG.fechaNac);
            cmd.Parameters.AddWithValue("@edad", objEG.edad);
            cmd.Parameters.AddWithValue("@grupo_sanguineo", objEG.grupo_sanguineo);
            cmd.Parameters.AddWithValue("@tipo_sangre", objEG.tipo_sangre);
            cmd.Parameters.AddWithValue("@telefono", objEG.telefono);
            cmd.Parameters.AddWithValue("@id_establecimiento", objEG.id_ipress);
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {

                cmd.Dispose();
            }
            finally
            {
                Desconectar();
            }
        }

        public void EditarGestante(EntidadGestante objEG)
        {
            Conectar();
            SqlCommand cmd = new SqlCommand("sp_editar_gestante", Conectar());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id_gestante", objEG.id_gestantes);
            cmd.Parameters.AddWithValue("@tipo_doc", objEG.tipoDoc);
            cmd.Parameters.AddWithValue("@num_doc", objEG.nroDoc);
            cmd.Parameters.AddWithValue("@paterno", objEG.paterno);
            cmd.Parameters.AddWithValue("@materno", objEG.materno);
            cmd.Parameters.AddWithValue("@nombre", objEG.nombre);
            cmd.Parameters.AddWithValue("@nombre2", objEG.nombre2);
            cmd.Parameters.AddWithValue("@fecha_nac", objEG.fechaNac);
            cmd.Parameters.AddWithValue("@edad", objEG.edad);
            cmd.Parameters.AddWithValue("@grupo_sanguineo", objEG.grupo_sanguineo);
            cmd.Parameters.AddWithValue("@tipo_sangre", objEG.tipo_sangre);
            cmd.Parameters.AddWithValue("@telefono", objEG.telefono);
            cmd.Parameters.AddWithValue("@id_establecimiento", objEG.id_ipress);
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {

                cmd.Dispose();
            }
            finally
            {
                Desconectar();
            }
        }



    }
}
