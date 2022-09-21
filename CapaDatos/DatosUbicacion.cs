using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class DatosUbicacion:DatosConexion
    {

        public void insertarUbicacion(string red, string microred)
        {
            Conectar();
            string sql = "INSERT INTO config_ipress (red,microred) values('" + red + "' , '"+ microred +"')";
            SqlCommand cmd = new SqlCommand(sql, Conectar());
            cmd.ExecuteNonQuery();
            Desconectar();
        }

        public void modificarUbicacion(string red, string microred)
        {
            Conectar();
            string sql = "update config_ipress set red='"+ red +"',microred= '" + microred + "'";
            SqlCommand cmd = new SqlCommand(sql, Conectar());
            cmd.ExecuteNonQuery();
            Desconectar();
        }
        public DataTable ListarUbicacionIpress()
        {
            Conectar();
            string sql = "SELECT * FROM config_ipress";
            SqlDataAdapter da = new SqlDataAdapter(sql, Conectar());
            DataTable dt = new DataTable();
            da.Fill(dt);
            Desconectar();
            return dt;
        }
    }
}
