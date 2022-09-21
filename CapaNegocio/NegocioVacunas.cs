using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data.SqlClient;
using System.Data.Sql;
using System.Data;

using CapaDatos;
using CapaEntidad;

namespace CapaNegocio
{
    public class NegocioVacunas
    {

        DatosVacuna objVacuna = new DatosVacuna();

        public void registrarVacunas(EntidadVacunas objEVac)
        {
           objVacuna.registrarVacunas(objEVac);
        }

        public void editarVacunas(EntidadVacunas objEVac)
        {
            objVacuna.editarVacunas(objEVac);
        }
        public void eliminarVacunas(EntidadVacunas objEVac)
        {
            objVacuna.eliminarVacunas(objEVac);
        }

        public DataTable mostrarVacunas(int idGestante)
        {
           return objVacuna.mostrarVacunas(idGestante);
        }

    }
}
