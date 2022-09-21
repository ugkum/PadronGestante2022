using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using CapaDatos;
using CapaEntidad;

namespace CapaNegocio
{
    public class NegocioPuerperio
    {
        DatosPuerperio objPuerpera = new DatosPuerperio();

        public void registrarAtencionPuerpera(EntidadPuerpera objPp)
        {
           objPuerpera.registrarAtencionPuerpera(objPp);
        }

        public void registrarAtencion_Puerpera_Solo_1(EntidadPuerpera objPp)
        {
            objPuerpera.registrarAtencion_Puerpera_Solo_1(objPp);
        }

        public void EditarAtencionPuerpera(EntidadPuerpera objPp)
        {
            objPuerpera.EditarAtencionPuerpera(objPp);
        }

        public void EditarAtencionPuerperaSolo_1(EntidadPuerpera objPp)
        {
            objPuerpera.EditarAtencionPuerperaSolo_1(objPp);
        }
        public void EliminarActencionPuerpera(EntidadPuerpera objPp)
        {
            objPuerpera.EliminarActencionPuerpera(objPp);
        }

        public DataTable ListarPuerpera(int id)
        {
            return objPuerpera.ListarPuerpera(id);
        }
    }
}
