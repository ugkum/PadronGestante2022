using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class DatosEstablecimiento:DatosConexion
    {

        public DataTable ListarRed()
        {
            Conectar();
            string sql = "SELECT distinct red FROM MAESTRO_HIS_ESTABLECIMIENTO ORDER BY red ASC ";
            SqlDataAdapter da = new SqlDataAdapter(sql, Conectar());
            DataTable dt = new DataTable();
            da.Fill(dt);
            Desconectar();
            return dt;
        }

        public DataTable ListarMicrored(string red)
        {
            Conectar();
            string sql = "SELECT distinct Microred FROM MAESTRO_HIS_ESTABLECIMIENTO where red ='"+ red +"'";
            SqlDataAdapter da = new SqlDataAdapter(sql, Conectar());
            DataTable dt = new DataTable();
            da.Fill(dt);
            Desconectar();
            return dt;
        }

        public DataTable ListarEstablecimiento(string microred)
        {
            Conectar();
            SqlDataAdapter da = new SqlDataAdapter("sp_listar_establecimiento_por_Microred", Conectar());
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.AddWithValue("@microred", microred);
            DataTable dt = new DataTable();
            da.Fill(dt);
            Desconectar();
            return dt;

        }

        public DataTable ListarEstablecimientoTotalPorId(int id)
        {
            Conectar();
            SqlDataAdapter da = new SqlDataAdapter("sp_listar_establecimiento_total_por_id", Conectar());
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.AddWithValue("@id", id);
            DataTable dt = new DataTable();
            da.Fill(dt);
            Desconectar();
            return dt;

        }

        public DataTable ListarDepartamento()
        {
            Conectar();
            SqlDataAdapter da = new SqlDataAdapter("select distinct Departamento from MAESTRO_HIS_ESTABLECIMIENTO", Conectar());
            DataTable dt = new DataTable();
            da.Fill(dt);
            Desconectar();
            return dt;

        }

        public DataTable ListarProvinciaPorDep(string dep)
        {
            Conectar();
            SqlDataAdapter da = new SqlDataAdapter("select distinct Provincia from MAESTRO_HIS_ESTABLECIMIENTO where Departamento = '"+ dep +"'", Conectar());
            DataTable dt = new DataTable();
            da.Fill(dt);
            Desconectar();
            return dt;

        }

        public DataTable ListarDistritoPorProvDep(string dep, string prov)
        {
            Conectar();
            SqlDataAdapter da = new SqlDataAdapter("select distinct Distrito from MAESTRO_HIS_ESTABLECIMIENTO where Departamento = '" + dep + "' AND Provincia='"+ prov +"'", Conectar());
            DataTable dt = new DataTable();
            da.Fill(dt);
            Desconectar();
            return dt;

        }
    }
}
