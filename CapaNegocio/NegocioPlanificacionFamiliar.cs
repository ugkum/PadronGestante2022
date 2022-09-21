using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using CapaDatos;
using CapaEntidad;

namespace CapaNegocio
{
    public class NegocioPlanificacionFamiliar
    {

        DatosPlanificionFamiliar objPlanFamiliar = new DatosPlanificionFamiliar();

        public void registrarPlanificacionFamiliar(EntidadPlanificacionFamiliar objPlanFam)
        {
            objPlanFamiliar.registrarPlanificacionFamiliar(objPlanFam);
        }

        public void EditarPlanificacionFamiliar(EntidadPlanificacionFamiliar objPlanFam)
        {
            objPlanFamiliar.EditarPlanificacionFamiliar(objPlanFam);
        }

        public void EliminarPlanificacionFamiliar(EntidadPlanificacionFamiliar objPlanFam)
        {
            objPlanFamiliar.EliminarPlanificacionFamiliar(objPlanFam);
        }

        public DataTable ListarPlanificacionFamiliar(EntidadPlanificacionFamiliar objPf)
        {
            return objPlanFamiliar.ListarPlanificacionFamiliar(objPf);
        }

    }
}
