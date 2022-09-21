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

        public void registrarAtencionGestante(int idGes, int idEst, string his_clinica, string estado)
        {
            Conectar();
            string sql = "Insert into atencion values(" + idGes + " , " + idEst + ",'"+ his_clinica +"','"+estado +"')";
            SqlCommand cmd = new SqlCommand(sql, Conectar());
            cmd.ExecuteNonQuery();
            Desconectar();
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
