using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using System.Data.SqlClient;

using CapaDatos;
using CapaEntidad;

namespace CapaNegocio
{
    public class NegocioEstablecimiento
    {

        DatosEstablecimiento objEst = new DatosEstablecimiento();

        public DataTable ListarRed()
        {
           return objEst.ListarRed();
        }

        public DataTable ListarMicrored(string red)
        {
            return objEst.ListarMicrored(red);  
        }

        public DataTable ListarEstablecimiento(string microred)
        {
            return objEst.ListarEstablecimiento(microred);
        }

        public DataTable ListarEstablecimientoTotalPorId(int id)
        {
            return objEst.ListarEstablecimientoTotalPorId(id);
        }

        public DataTable ListarDepartamento()
        {
            return objEst.ListarDepartamento();

        }

        public DataTable ListarProvinciaPorDep(string dep)
        {
            return objEst.ListarProvinciaPorDep(dep);

        }

        public DataTable ListarDistritoPorProvDep(string dep, string prov)
        {
            return objEst.ListarDistritoPorProvDep(dep, prov);
        }
        public DataTable BuscarCodigoUnicoEss(int codigo)
        {
            return objEst.BuscarCodigoUnicoEss(codigo);
        }
    }
}
