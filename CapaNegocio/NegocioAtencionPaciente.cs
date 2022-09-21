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

        public void registrarAtencionGestante(int idGes, int idEst, string his_clinica,string   estado)
        {
            objAtencion.registrarAtencionGestante(idGes, idEst, his_clinica,estado);
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
