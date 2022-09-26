using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using CapaDatos;
using CapaEntidad;
using System.Data.SqlClient;
using System.Data.Sql;
using System.Data;

namespace CapaDatos
{
    public class DatosDetalleUbicacion:DatosConexion
    {

        public void RegistrarUbicacion(string dep, string prov, string distr, string centroPob ,string direccion, int idGesta)
        {
            
            string sql = "insert into DetalleUbicacion VALUES('" + dep + "','" + prov + "','" + distr + "','"+ centroPob+"','"+direccion+"', " + idGesta + ")";
            SqlCommand cmd = new SqlCommand(sql, Conectar());
            cmd.ResetCommandTimeout();
            cmd.CommandTimeout = 0;
            Conectar();
            cmd.ExecuteNonQuery();
            Desconectar();
        }

        public void RegistrarUbicacion_procedure(string dep, string prov, string distr, string centroPob, string direccion, int idGesta)
        {

            Conectar();
            SqlCommand cmd = new SqlCommand("sp_insertar_detalle_ubicacion", Conectar());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandTimeout = 0;
            cmd.Parameters.AddWithValue("@depa",dep);
            cmd.Parameters.AddWithValue("@prov", prov);
            cmd.Parameters.AddWithValue("@dis", distr);
            cmd.Parameters.AddWithValue("@cp", centroPob);
            cmd.Parameters.AddWithValue("@direccion", direccion);
            cmd.Parameters.AddWithValue("@idgesta", idGesta);

            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {

                Desconectar();
                cmd.Dispose();
            }
            finally
            {
                Desconectar();
            }
            
        }


        public void EditarUbicacion(string dep, string prov, string distr, string centroPob,string direccion, int idGesta)
        {
            Conectar();
            string sql = "UPDATE DetalleUbicacion set departamento='" + dep + "',provincia='" + prov + "',distrito='" + distr + "', Centro_pob='"+ centroPob +"', Direccion_Actual='"+ direccion+"' where id_gestante=" + idGesta + "";
            SqlCommand cmd = new SqlCommand(sql, Conectar());
            cmd.ExecuteNonQuery();
            Desconectar();
        }
    }
}
