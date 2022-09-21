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
            Conectar();
            string sql = "insert into DetalleUbicacion VALUES('" + dep + "','" + prov + "','" + distr + "','"+ centroPob+"','"+direccion+"', " + idGesta + ")";
            SqlCommand cmd = new SqlCommand(sql, Conectar());
            cmd.ExecuteNonQuery();
            Desconectar();
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
