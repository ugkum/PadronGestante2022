using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using CapaEntidad;
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class DatosAdicional:DatosConexion
    {


        //limpiaando base de datos
        public bool LimpiarGestante()
        {
            Conectar();
            string sql = "truncate table gestante " +
                "truncate table atencion " +
                "truncate table detalleUbicacion " +
                "truncate table adicional " +
                "truncate table embarazo " +
                "truncate table actividad " +
                "truncate table controles " +
                "truncate table ecografia " +
                "truncate table examenes " +
                "truncate table formula_obstetrica " +
                "truncate table vacunas " +
                "truncate table suplementacion " +
                "truncate table panificacion_familiar " +
                "truncate table puerperio ";
            SqlCommand cmd = new SqlCommand(sql, Conectar());
            
            cmd.CommandTimeout = 0;
            try
            {
               int res = cmd.ExecuteNonQuery();
                if(res>0)
                {
                    return true;
                }
              
                    return false;
                
            }
            catch (Exception)
            {
               
                cmd.Dispose();
                return false;
            }
            finally
            {
                Desconectar();
            }
           
        }

        public DataTable listarAdicionalGestante(int idGestante)
        {
            Conectar();
            SqlDataAdapter da = new SqlDataAdapter("sp_listar_adicional", Conectar());
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            
            da.SelectCommand.Parameters.AddWithValue("@id_ges", idGestante);
            DataTable dt = new DataTable();
            da.Fill(dt);
            Desconectar();
            return dt;
        }

        public void registrarAdicional(EntidadAdicional objA)
        {
            Conectar();
            SqlCommand cmd = new SqlCommand("sp_insertar_adicinal", Conectar());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandTimeout = 0;
            cmd.Parameters.AddWithValue("@tipo_seguro", objA.tipoSeguro);
            cmd.Parameters.AddWithValue("@nivel_instruccion", objA.nivel_instruccion);
            cmd.Parameters.AddWithValue("@lengua",objA.lengua);
            cmd.Parameters.AddWithValue("@estado_civil", objA.estado_civil);
            cmd.Parameters.AddWithValue("@etnia", objA.etnia);
            cmd.Parameters.AddWithValue("@id_gestante", objA.id_gestante);
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

        public void EditarAdicional(EntidadAdicional objA)
        {
            Conectar();
            SqlCommand cmd = new SqlCommand("sp_editar_adicional", Conectar());
            
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@tipo_seguro", objA.tipoSeguro);
            cmd.Parameters.AddWithValue("@nivel_instruccion", objA.nivel_instruccion);
            cmd.Parameters.AddWithValue("@lengua", objA.lengua);
            cmd.Parameters.AddWithValue("@estado_civil", objA.estado_civil);
            cmd.Parameters.AddWithValue("@etnia", objA.etnia);
            cmd.Parameters.AddWithValue("@id_gestante", objA.id_gestante);
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
