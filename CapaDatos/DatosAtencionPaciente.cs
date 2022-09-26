using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using System.Data.SqlClient;
using CapaEntidad;

namespace CapaDatos
{
    public class DatosAtencionPaciente:DatosConexion    
    {

        public void registrarAtencionGestante(int idAte, int idGes, int idEst, string his_clinica, string estado)
        {
            Conectar();
            string sql = "Insert into atencion values("+ idAte +"," + idGes + " , " + idEst + ",'"+ his_clinica +"','"+estado +"')";
            SqlCommand cmd = new SqlCommand(sql, Conectar());
            cmd.CommandTimeout = 0;
            cmd.ExecuteNonQuery();
            Desconectar();
        }

        public void registrarAtencionGestante_procedure(int idAte, int idGes, int idEst, string his_clinica, string estado)
        {
            Conectar();
            SqlCommand cmd = new SqlCommand("sp_registrar_atencion", Conectar());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandTimeout = 0;
            cmd.Parameters.AddWithValue("@idA", idAte);
            cmd.Parameters.AddWithValue("@idGes", idGes);
            cmd.Parameters.AddWithValue("@idEss", idEst);
            cmd.Parameters.AddWithValue("@Hc", his_clinica);
            cmd.Parameters.AddWithValue("@Estado", estado);
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                Desconectar();
                cmd.Dispose();
            }
            finally
            {
                Desconectar();
            }
        }

        public void EditarAtencionGestante(int idGes, int idEst, string his_clinica, string estado)
        {
            Conectar();
            string sql = "update atencion set id_establecimiento= " + idEst + ", HistoriaClinica='" + his_clinica+"', Estado='"+ estado +"' where id_gestante=" + idGes + "";
            SqlCommand cmd = new SqlCommand(sql, Conectar());
            cmd.ExecuteNonQuery();
            Desconectar();
        }

        public void EditarAtencionGestanteEstado(int idGes, string estado)
        {
            Conectar();
            string sql = "update atencion set Estado='" + estado + "' where id_gestante=" + idGes + "";
            SqlCommand cmd = new SqlCommand(sql, Conectar());
            cmd.ExecuteNonQuery();
            Desconectar();
        }

    }
}
