using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using CapaEntidad;
using CapaDatos;

namespace CapaNegocio
{
    public class NegocioPadronGestante
    {
        DatosPadronGestante objPadron = new DatosPadronGestante();

        public DataTable ReportarPadronNominal()
        {
           return objPadron.ReportarPadronNominal();

        }
    }
}
