using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using CapaDatos;
using CapaEntidad;

namespace CapaNegocio
{
    public class NegocioAtencionPaciente
    {

        DatosAtencionPaciente objAtencion = new DatosAtencionPaciente();

        public void registrarAtencionGestante(int idAte, int idGes, int idEst, string his_clinica,string   estado)
        {
            objAtencion.registrarAtencionGestante(idAte, idGes, idEst, his_clinica,estado);
        }

        public DataTable ObtenerUltimoRegistroAtencion()
        {
            return   objAtencion.ObtenerUltimoRegistroAtencion();
        }
        public void registrarAtencionGestante_procedure(int idAte, int idGes, int idEst, string his_clinica, string estado)
        {
            objAtencion.registrarAtencionGestante_procedure(idAte, idGes, idEst, his_clinica, estado);
        }
        public void EditarAtencionGestante(int idGes, int idEst, string his_clinica, string estado)
        {
            objAtencion.EditarAtencionGestante(idGes,idEst,his_clinica,estado);
        }

        public void EditarAtencionGestanteEstado(int idGes, string estado)
        {
            objAtencion.EditarAtencionGestanteEstado(idGes, estado);
        }
    }
}
