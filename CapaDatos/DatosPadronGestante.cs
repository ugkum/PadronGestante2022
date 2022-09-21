using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using CapaEntidad;

namespace CapaDatos
{
    public class DatosPadronGestante:DatosConexion
    {

        public DataTable ReportarPadronNominal()
        {
            Conectar();
            SqlDataAdapter da = new SqlDataAdapter("V_PADRON_GESTANTE", Conectar());
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.CommandTimeout = 0;
            DataTable dt = new DataTable();
            da.Fill(dt);
            Desconectar();
            return dt;
        }

    }
}
