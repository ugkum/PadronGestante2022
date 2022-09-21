using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using CapaEntidad;
using CapaDatos;
using System.Data.SqlClient;

namespace CapaNegocio
{
    public class NegocioGestantes
    {
        DatosGestantes objGes = new DatosGestantes();
        public DataTable listarGestantes(int idIpress, string estado, string texto)
        {

            return objGes.listarGestantes(idIpress, estado, texto);

        }

        public DataSet Imprimir_Atenciones_Gestante_del_Embarazo(int codigo)
        {
            return objGes.Imprimir_Atenciones_Gestante_del_Embarazo(codigo);
        }
        public DataTable ListarNotificacionControlesGestante()
        {
            return objGes.ListarNotificacionControlesGestante();
        }
        public DataTable UltimoRegistro()
        {
            return objGes.UltimoRegistro();
        }
        public DataTable BuscarGestante_por_dni_por_ipress(string dni, int idIpress)
        {
            return objGes.BuscarGestante_por_dni_por_ipress(dni, idIpress);
        }
        public DataTable BuscarGestante_por_dni(string dni)
        {
            return objGes.BuscarGestante_por_dni(dni);
        }
        public DataTable ReporteGeneral_Resumen()
        {
            return objGes.ReporteGeneral_Resumen();
        }
        public DataTable BuscarGestante_por_dni_para_agregar_solo_atencion(string dni)
        {
            return objGes.BuscarGestante_por_dni_para_agregar_solo_atencion(dni);
        }
        public void registrarGestante(EntidadGestante objEG)
        {
            objGes.registrarGestante(objEG);
        }
        public DataTable buscar_gestante_en_ipress_actual(string dni, int id_ipress)
        {
            return objGes.buscar_gestante_en_ipress_actual(dni, id_ipress);
        }
        public DataTable BuscarGestante_por_ID_Actualizar(int idGes)
        {
            return objGes.BuscarGestante_por_ID_Actualizar(idGes);
        }
        public void EditarGestante(EntidadGestante objEG)
        {
            objGes.EditarGestante(objEG);
        }
    }
}
