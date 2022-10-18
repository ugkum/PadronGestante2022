using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Globalization;

namespace CapaDatos
{
    public class DatosConexion
    {

        SqlConnection con;

       public static string servidor;
       public static string basedatos; 
       public static string usua;
       public static string pass;
        

        public SqlConnection Conectar()
        {
            try
            {
                if(usua=="" && pass == "")
                {
                    //conexion sin usuario
                    con = new SqlConnection(@"SERVER=" + servidor + ";DATABASE=" + basedatos + ";Integrated Security=SSPI");
                    Console.WriteLine("Conexion sin usuario");
                }
                else 
                {
                    //conexion con usuario
                    con = new SqlConnection(@"SERVER=" + servidor + ";DATABASE=" + basedatos + ";User=" + usua + ";Password=" + pass + "");
                    Console.WriteLine("Conexion con usuario");
                }
                //cadena conexion red
                //con = new SqlConnection(@"SERVER=UTIE\UTIE\,49500;DATABASE=BD_PADRON_GEST;User=sa;Password=root");
                con.Open();
                Console.WriteLine("Conexion Exitosa");
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
