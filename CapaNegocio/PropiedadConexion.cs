using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using CapaDatos;
using CapaEntidad;

namespace CapaNegocio
{
    public class PropiedadConexion
    {
       public static string servidor;
       public static string basedatos;
       public static string usua;
       public static string pass;

       
        
        
        public SqlConnection Conectar()
        {
            DatosConexion objConexiones = new DatosConexion();
            DatosConexion.basedatos = basedatos;
            DatosConexion.servidor = servidor;
            DatosConexion.usua = usua;
            DatosConexion.pass = pass;
            return objConexiones.Conectar();
        }

    }
}
