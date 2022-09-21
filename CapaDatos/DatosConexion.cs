using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class DatosConexion
    {

        SqlConnection con;


        public SqlConnection Conectar()
        {
            try
            {
                
                con = new SqlConnection(@"SERVER=UTIE\UTIE\,49500;DATABASE=BD_PADRON_GEST;User=sa;Password=root");
                con.Open();
            }
            catch (Exception)
            {

               
            }
            return con;
        }

        public void Desconectar()
        {
            if (con.State == System.Data.ConnectionState.Open)
            {
                con.Close();
            }
        }
    }
}
