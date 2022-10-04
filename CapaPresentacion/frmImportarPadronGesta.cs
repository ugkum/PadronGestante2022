using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using CapaEntidad;
using CapaNegocio;

namespace CapaPresentacion
{
    public partial class frmImportarPadronGesta : Form
    {
        public frmImportarPadronGesta()
        {
            InitializeComponent();
        }

        private void panelCargar_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void btnCargar_Click(object sender, EventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();

            if (op.ShowDialog() == DialogResult.OK)
            {
                lblUbicacion.Text= op.FileName;
                lblNombre.Text=op.SafeFileName;
               
                System.IO.FileInfo info = new System.IO.FileInfo(op.FileName);
                lblTamanio.Text = info.Length.ToString();

                //cargar en la data
                dataGridView1.DataSource = LoadXLS(op.FileName, "Hoja2");
            }
        }

        private void lblCargar_Click(object sender, EventArgs e)
        {
            btnCargar_Click(sender, e);
        }

        private void panelCargar_MouseClick(object sender, MouseEventArgs e)
        {
            btnCargar_Click(sender, e);
        }

        //metodo importar xlsx
        private DataTable LoadXLS(string strFile, String sheetName)
        {
            DataTable dtXLS = new DataTable(sheetName);

            try
            {
                string strConnectionString = "";

                if (strFile.Trim().EndsWith(".xlsx"))
                {

                    strConnectionString = string.Format("Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties=\"Excel 12.0 Xml;HDR=YES;IMEX=1\";", strFile);

                }
                else if (strFile.Trim().EndsWith(".xls"))
                {

                    strConnectionString = string.Format("Provider=Microsoft.Jet.OLEDB.4.0;Data Source={0};Extended Properties=\"Excel 8.0;HDR=Yes;IMEX=1\";", strFile);

                }

                OleDbConnection SQLConn = new OleDbConnection(strConnectionString);

                SQLConn.Open();

                OleDbDataAdapter SQLAdapter = new OleDbDataAdapter();

                //importar nombre archivo, hoja, columna, valor
                //string sql = "SELECT * FROM [" + sheetName + "$] WHERE " + column + " = " + value;
                //importar solo por nombr earchivo
                string sql = "SELECT * FROM [" + sheetName + "$]";

                OleDbCommand selectCMD = new OleDbCommand(sql, SQLConn);

                SQLAdapter.SelectCommand = selectCMD;

                SQLAdapter.Fill(dtXLS);

                SQLConn.Close();
            }

            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }

            return dtXLS;

        }

        int idGestante=1;
        int idAtencion = 1;
        int idEmbarazo = 1;
        private void btnImportar_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                idGestante=idGestante+1;
                int idIpress=0;
                //Obtener ID IPRESS POR CODIGO_UNICO
                int codigoUnico = dataGridView1.Rows[i].Cells[15].Value.ToString() == null ? 0 : int.Parse(dataGridView1.Rows[i].Cells[15].Value.ToString());
                NegocioEstablecimiento objess = new NegocioEstablecimiento();
                DataTable dtIpress = objess.BuscarCodigoUnicoEss(codigoUnico);
                if(dtIpress.Rows.Count > 0)
                {
                    idIpress = int.Parse(dtIpress.Rows[0][0].ToString());
                }
              
                //1: datos gestante
                EntidadGestante objGestante = new EntidadGestante();
                NegocioGestantes objGesta = new NegocioGestantes();
                objGestante.id_gestantes = idGestante;
                if (dataGridView1.Rows[i].Cells[7].Value.ToString() == "") { objGestante.tipoDoc = ""; } else { objGestante.tipoDoc = dataGridView1.Rows[i].Cells[7].Value.ToString(); }
                if (dataGridView1.Rows[i].Cells[8].Value.ToString() == "") { objGestante.nroDoc = ""; } else { objGestante.nroDoc = dataGridView1.Rows[i].Cells[8].Value.ToString(); }
                if (dataGridView1.Rows[i].Cells[1].Value.ToString() == "") { objGestante.paterno = ""; } else { objGestante.paterno = dataGridView1.Rows[i].Cells[1].Value.ToString(); }
                if (dataGridView1.Rows[i].Cells[2].Value.ToString() == "") { objGestante.materno = ""; } else { objGestante.materno = dataGridView1.Rows[i].Cells[2].Value.ToString(); }
                if (dataGridView1.Rows[i].Cells[3].Value.ToString() == "") { objGestante.nombre = ""; } else { objGestante.nombre = dataGridView1.Rows[i].Cells[3].Value.ToString(); }
                if (dataGridView1.Rows[i].Cells[4].Value.ToString() == "") { objGestante.nombre2 = ""; } else { objGestante.nombre2 = dataGridView1.Rows[i].Cells[4].Value.ToString(); }
                if (dataGridView1.Rows[i].Cells[5].Value.ToString() == "") { objGestante.fechaNac = DateTime.Now; } else { objGestante.fechaNac = DateTime.Parse(dataGridView1.Rows[i].Cells[5].Value.ToString()); }
                if (dataGridView1.Rows[i].Cells[6].Value.ToString() == "") { objGestante.edad = 0; } else { objGestante.edad = int.Parse( dataGridView1.Rows[i].Cells[6].Value.ToString()); }
                if (dataGridView1.Rows[i].Cells[75].Value.ToString() == "") { objGestante.grupo_sanguineo = ""; } else { objGestante.grupo_sanguineo = dataGridView1.Rows[i].Cells[75].Value.ToString(); }
                if (dataGridView1.Rows[i].Cells[76].Value.ToString() == "") { objGestante.tipo_sangre = ""; } else { objGestante.tipo_sangre = dataGridView1.Rows[i].Cells[76].Value.ToString(); }
                if (dataGridView1.Rows[i].Cells[9].Value.ToString() == "") { objGestante.telefono = ""; } else { objGestante.telefono = dataGridView1.Rows[i].Cells[9].Value.ToString(); }
                objGestante.id_ipress = idIpress;

                objGesta.registrarGestante(objGestante);//registramos gestante
               
                //2: Datos Adicional de Gestante
                EntidadAdicional objAdi = new EntidadAdicional();
                NegocioAdicional objAdicional = new NegocioAdicional();
                if (dataGridView1.Rows[i].Cells[19].Value.ToString() == "") { objAdi.tipoSeguro = ""; } else { objAdi.tipoSeguro = dataGridView1.Rows[i].Cells[19].Value.ToString();}
                if (dataGridView1.Rows[i].Cells[20].Value.ToString() == "") { objAdi.nivel_instruccion = ""; } else { objAdi.nivel_instruccion = dataGridView1.Rows[i].Cells[20].Value.ToString(); }
                if (dataGridView1.Rows[i].Cells[21].Value.ToString() == "") { objAdi.lengua = ""; } else { objAdi.lengua = dataGridView1.Rows[i].Cells[21].Value.ToString(); }
                if (dataGridView1.Rows[i].Cells[22].Value.ToString() == "") { objAdi.estado_civil = ""; } else { objAdi.estado_civil = dataGridView1.Rows[i].Cells[22].Value.ToString(); }
                if (dataGridView1.Rows[i].Cells[14].Value.ToString() == "") { objAdi.etnia = ""; } else { objAdi.etnia = dataGridView1.Rows[i].Cells[14].Value.ToString(); }       
                objAdi.id_gestante=objGestante.id_gestantes;
                objAdicional.registrarAdicional(objAdi);//registramos datos adicional de la gestante

                //3: datos de la ubicacion de la gestante
                NegocioDetalleUbicacion objUbicacion = new NegocioDetalleUbicacion();
                string departamento = "AMAZONAS";
                string provincia;
                string distrito;
                string centro_poblado;
                string direccion_actual;
                if (dataGridView1.Rows[i].Cells[11].Value.ToString() == "") { provincia = ""; } else {  provincia= dataGridView1.Rows[i].Cells[11].Value.ToString(); }
                if (dataGridView1.Rows[i].Cells[12].Value.ToString() == "") { distrito = ""; } else { distrito = dataGridView1.Rows[i].Cells[12].Value.ToString(); }
                if (dataGridView1.Rows[i].Cells[13].Value.ToString() == "") { centro_poblado = ""; } else { centro_poblado = dataGridView1.Rows[i].Cells[13].Value.ToString(); }
                if (dataGridView1.Rows[i].Cells[10].Value.ToString() == "") { direccion_actual = ""; } else { direccion_actual = dataGridView1.Rows[i].Cells[10].Value.ToString(); }
                objUbicacion.RegistrarUbicacion_procedure(departamento,provincia,distrito,centro_poblado,direccion_actual,objGestante.id_gestantes);//registrmos detalle ubicacion de la gestabte

                //4: Datos de la atencion
                NegocioAtencionPaciente objAtencion = new NegocioAtencionPaciente();
                string HistoriaClinica;
                if (dataGridView1.Rows[i].Cells[0].Value.ToString() == "") { HistoriaClinica = ""; } else {HistoriaClinica= dataGridView1.Rows[i].Cells[0].Value.ToString(); }
                string estadoAtencion = "ACTIVO";
                idAtencion += 1;
                objAtencion.registrarAtencionGestante_procedure(idAtencion, objGestante.id_gestantes, idIpress, HistoriaClinica, estadoAtencion);//registramos donde se atiende la gestante

                //5: crear embarazo
                EntidadEmbarazo objEm = new EntidadEmbarazo();
                NegocioEmbarazo objEmbarazo = new NegocioEmbarazo();
                idEmbarazo+=1;
                objEm.id_embaazo=idEmbarazo;
                if (dataGridView1.Rows[i].Cells[25].Value.ToString() == "") { objEm.fecha_ultima_regla = DateTime.Now; } else { objEm.fecha_ultima_regla =DateTime.Parse( dataGridView1.Rows[i].Cells[25].Value.ToString()); }
                if (dataGridView1.Rows[i].Cells[26].Value.ToString() == "") { objEm.fecha_plan_parto = DateTime.Now; } else { objEm.fecha_plan_parto = DateTime.Parse(dataGridView1.Rows[i].Cells[26].Value.ToString()); }
                if (dataGridView1.Rows[i].Cells[23].Value.ToString() == "") { objEm.gesta = ""; } else { objEm.gesta = dataGridView1.Rows[i].Cells[23].Value.ToString(); }
                if (dataGridView1.Rows[i].Cells[24].Value.ToString() == "") { objEm.pariedad = ""; } else { objEm.pariedad  = dataGridView1.Rows[i].Cells[24].Value.ToString(); }
                objEm.id_gestante = idAtencion;
                objEmbarazo.RegistrarEmbarazo(objEm);

                //6:crear controles
                EntidadControles eControl = new EntidadControles();
                NegocioControles objControl = new NegocioControles();
                int celdaActualFC = 27;
                int celdaActualEdadG = 28;
                for(int numControl = 1; numControl < 14; numControl++)
                {
                    if (numControl == 1) { eControl.num_control = "1RA"; }
                    if (numControl == 2) { eControl.num_control = "2DA"; }
                    if (numControl == 3) { eControl.num_control = "3RA"; }
                    if (numControl == 4) { eControl.num_control = "4TA"; }
                    if (numControl == 5) { eControl.num_control = "5TA"; }
                    if (numControl == 6) { eControl.num_control = "6TA"; }
                    if (numControl == 7) { eControl.num_control = "7MA"; }
                    if (numControl == 8) { eControl.num_control = "8VA"; }
                    if (numControl == 9) { eControl.num_control = "9NA"; }
                    if (numControl == 10) { eControl.num_control = "10MA"; }
                    if (numControl == 11) { eControl.num_control = "11RA"; }
                    if (numControl == 12) { eControl.num_control = "12DA"; }
                    if (numControl == 13) { eControl.num_control = "13RA"; }
                   

                    if (dataGridView1.Rows[i].Cells[celdaActualFC].Value.ToString() == "" || dataGridView1.Rows[i].Cells[celdaActualEdadG].Value.ToString() == "")
                    {
                        celdaActualFC+=2;
                        celdaActualEdadG+=2;
                        continue;
                    }
                        eControl.fecha_control =DateTime.Parse( dataGridView1.Rows[i].Cells[celdaActualFC].Value.ToString());
                        eControl.edad_ges = dataGridView1.Rows[i].Cells[celdaActualEdadG].Value.ToString();
                        eControl.id_embarazo = idEmbarazo;
                   
                    //Todo esta correcto REGISTRAMOS CONTROL LA GESTANTE
                    objControl.registrarControles(eControl);
                    //incrementamos celdas
                    celdaActualFC+=2;
                    celdaActualEdadG+=2;
                }

                //7: Registro de examenes
                EntidadExamenes objExa = new EntidadExamenes();
                NegocioExamenes objExamenes = new NegocioExamenes();
                int fechaExamen = 53;
                int fechaResultadoExamen = 54;
                string nombreExamen = "";
                int numeroExa = 0;
                for(int examen = 1 ; examen < 14; examen++)
                {
                    numeroExa += 1;
                    if (fechaExamen >= 53 && fechaExamen <= 56) { nombreExamen = "SIFILIS"; }
                    if (fechaExamen >= 57 && fechaExamen <= 60) { nombreExamen = "VIH"; }
                    if (fechaExamen >= 61 && fechaExamen <= 64) { nombreExamen = "ORINA"; }
                    if (fechaExamen >= 65 && fechaExamen <= 66) { nombreExamen = "HEPATITIS"; }
                    if (fechaExamen >= 67 && fechaExamen <= 70) { nombreExamen = "HEMOGLOBINA"; }
                    if (fechaExamen >= 71 && fechaExamen <= 74) { nombreExamen = "GLUCOSA(mg/dl)"; }
                    if (fechaExamen >= 75 && fechaExamen <= 80) { nombreExamen = "PROTEINA"; }

                    if (dataGridView1.Rows[i].Cells[fechaExamen].Value.ToString() == "" || dataGridView1.Rows[i].Cells[fechaResultadoExamen].Value.ToString() == "")
                    {
                      
                        if (nombreExamen == "GLUCOSA(mg/dl)" && numeroExa == 2)
                        { fechaExamen += 4; fechaResultadoExamen += 4; }
                        else { fechaExamen += 2; fechaResultadoExamen += 2; }
                        if (nombreExamen == "HEPATITIS") { numeroExa = 0; }
                        if (numeroExa == 2) { numeroExa = 0; }

                        //examen++;
                        continue;
                    }
                    
                    
                    objExa.prueba = nombreExamen;
                    if (nombreExamen == "HEPATITIS") { objExa.num_prueba = ""; } else { objExa.num_prueba = numeroExa.ToString(); }
                    objExa.fecha_prueba = DateTime.Parse(dataGridView1.Rows[i].Cells[fechaExamen].Value.ToString());
                    objExa.resultado = dataGridView1.Rows[i].Cells[fechaResultadoExamen].Value.ToString();
                    objExa.id_embarazo =idEmbarazo;
                    //guardar examen
                    objExamenes.insertarExamen(objExa);

                    //incrementmos celdas
                    if (nombreExamen == "GLUCOSA(mg/dl)" && numeroExa == 2)
                    { fechaExamen += 4; fechaResultadoExamen += 4; }
                    else { fechaExamen += 2; fechaResultadoExamen += 2;  }

                    if (nombreExamen == "HEPATITIS"){numeroExa = 0;}
                   
                    if(numeroExa == 2) { numeroExa = 0; }
                }

                //8: ECOGRAFIA
                EntidadEcografia objEco = new EntidadEcografia();
                NegocioEcografia objEcografia = new NegocioEcografia();

                int fechaEco =81;
                int EdadGEco =82;
                int numeroEco = 0;
                for (int eco = 1; eco < 3; eco++)
                {
                    numeroEco += 1;
                    if (dataGridView1.Rows[i].Cells[fechaEco].Value.ToString() == "" || dataGridView1.Rows[i].Cells[EdadGEco].Value.ToString() == "")
                    {
                        fechaEco += 2;
                        EdadGEco += 2;
                        continue;
                    }
                    objEco.nro_eco = numeroEco.ToString();
                    objEco.fecha_ecografia = DateTime.Parse(dataGridView1.Rows[i].Cells[fechaEco].Value.ToString());
                    objEco.edad_gestacional = dataGridView1.Rows[i].Cells[EdadGEco].Value.ToString();
                    objEco.id_embarazo = idEmbarazo;
                    fechaEco += 2;
                    EdadGEco += 2;
                    objEcografia.RegistrarEcografia(objEco);
                }

                //:9 VACUNAS
                EntidadVacunas objVacu = new EntidadVacunas();
                NegocioVacunas objVacunas = new NegocioVacunas();
                int fechaVacuna = 85;
                string tipoVacuna = "";
                int nroVacuna = 0;
                for (int vacu = 1; vacu < 7; vacu++)
                {
                    nroVacuna += 1;
                    if (fechaVacuna >= 85 && fechaVacuna <= 86) { tipoVacuna = "DT"; }
                    if (fechaVacuna ==87) { tipoVacuna = "DPTA"; }
                    if (fechaVacuna ==88) { tipoVacuna = "INFLUENZA"; }
                    if (fechaVacuna >= 89 && fechaVacuna <= 90) { tipoVacuna = "COVID19"; }

                    if (dataGridView1.Rows[i].Cells[fechaVacuna].Value.ToString() == "" )
                    {
                        fechaVacuna += 1;
                        if (nroVacuna == 2) { nroVacuna = 0; }
                        continue;
                    }

                    objVacu.vacuna = tipoVacuna;
                    objVacu.fecha = DateTime.Parse(dataGridView1.Rows[i].Cells[fechaVacuna].Value.ToString());
                    if(tipoVacuna=="DPTA" || tipoVacuna == "INFLUENZA") { objVacu.num_vacunas = ""; } else{objVacu.num_vacunas = nroVacuna.ToString();}
                    if (nroVacuna == 2) { nroVacuna = 0; }
                    objVacu.id_gestante = idGestante;
                    objVacu.id_embarazo = idEmbarazo;
                    
                    //guardamos vacunas
                    objVacunas.registrarVacunas(objVacu);
                    //incrementamos celdas y nro vacunas
                    fechaVacuna += 1;
                    if (nroVacuna == 2) { nroVacuna = 0; }
                }

                //10: Actividades realizadas (PLAN DE PARTO - TAMIZAJE DE VBG)
                EntidadActividad objAc = new EntidadActividad();
                NegocioActividad objActividad = new NegocioActividad();
                int nroExamen = 0;
                int fechaExa = 91;
                int resultado = 95;
                string nombreExa = "";
                for (int examen = 0; examen < 6; examen++)
                {
                    nroExamen += 1;
                    if (fechaExa >= 91 && fechaExa <= 93) { nombreExa = "PLAN DE PARTO"; }
                    if (fechaExa >= 94 && fechaExa <= 99) { nombreExa = "TAMIZAJE VBG"; }
                    if (nombreExa == "PLAN DE PARTO")
                    {
                        if (dataGridView1.Rows[i].Cells[fechaExa].Value.ToString() == "")
                        {
                            fechaExa += 1;
                            if (nroExamen == 3) { nroExamen = 0; }
                            continue;
                        }
                    }
                    if (nombreExa == "TAMIZAJE VBG")
                    {
                        if (dataGridView1.Rows[i].Cells[fechaExa].Value.ToString() == "" || dataGridView1.Rows[i].Cells[resultado].Value.ToString() == "")
                        {
                            resultado += 2;
                            fechaExa += 2;
                            if (nroExamen == 3) { nroExamen = 0; }
                            continue;
                        }
                    }

                    objAc.actividad = nombreExa;
                    objAc.fecha_atencion = DateTime.Parse(dataGridView1.Rows[i].Cells[fechaExa].Value.ToString());
                    if (nombreExa == "PLAN DE PARTO")
                    {
                        objAc.resultado = "";
                    }
                    else
                    {
                        objAc.resultado = dataGridView1.Rows[i].Cells[resultado].Value.ToString();
                    }
                    objAc.nro_atencion = nroExamen.ToString();
                    objAc.id_embarazo = idEmbarazo;

                    objActividad.registrarActividad(objAc);

                    if (nombreExa == "PLAN DE PARTO") { fechaExa += 1; } else { fechaExa += 2; resultado += 2; }

                    if (nroExamen == 3) { nroExamen = 0; }


                }
                //11: SUPLEMENTACIONES
                EntidadSuplementacion objSuplem = new EntidadSuplementacion();
                NegocioSuplementacion objSuplementacion = new NegocioSuplementacion();

                int nroSuplemento = 0;
                int fechaSuplemento = 100;
                string nombreSupl = "";

                for (int suple = 0; suple < 13; suple++)
                {
                    nroSuplemento += 1;

                    if(fechaSuplemento>=100 && fechaSuplemento <= 101) { nombreSupl = "ACIDO FOLICO"; }
                    if (fechaSuplemento >= 102 && fechaSuplemento <= 107) { nombreSupl = "SULFATO FERROSO"; }
                    if (fechaSuplemento >= 108 && fechaSuplemento <= 112) { nombreSupl = "CALCIO"; }

                    if(nombreSupl=="ACIDO FOLICO")
                    {
                        if(dataGridView1.Rows[i].Cells[fechaSuplemento].Value.ToString() == "")
                        {
                            fechaSuplemento += 1;
                            if (nroSuplemento == 2) { nroSuplemento = 0; }
                            continue;
                        }
                    }
                    if (nombreSupl == "SULFATO FERROSO")
                    {
                        if (dataGridView1.Rows[i].Cells[fechaSuplemento].Value.ToString() == "")
                        {
                            fechaSuplemento += 1;
                            if (nroSuplemento == 6) { nroSuplemento = 0; }
                            continue;
                        }
                    }
                    if (nombreSupl == "CALCIO")
                    {
                        if (dataGridView1.Rows[i].Cells[fechaSuplemento].Value.ToString() == "")
                        {
                            fechaSuplemento += 1;
                            if (nroSuplemento == 5) { nroSuplemento = 0; }
                            continue;
                        }
                    }

                    objSuplem.suplementacion = nombreSupl;
                    objSuplem.num_suplementacion = nroSuplemento.ToString();
                    objSuplem.fecha_suplementacion =DateTime.Parse( dataGridView1.Rows[i].Cells[fechaSuplemento].Value.ToString()) ;
                    objSuplem.id_embarazo = idEmbarazo;

                    objSuplementacion.registrarSuplementacion(objSuplem);

                    fechaSuplemento += 1;
                    if (nombreSupl == "ACIDO FOLICO") { if (nroSuplemento == 2) { nroSuplemento = 0; } }
                    if (nombreSupl == "SULFATO FERROSO") { if (nroSuplemento == 6) { nroSuplemento = 0; } }
                    if (nombreSupl == "CALCIO") { if (nroSuplemento == 5) { nroSuplemento = 0; } }

                }

                //12: CULMINACION DEL EMBARAZO
                EntidadCulminacionEmbarazo objCulmina = new EntidadCulminacionEmbarazo();
                NegocioCulminacionEmbarazo objCumninacion = new NegocioCulminacionEmbarazo();
                string tipoCulminacion = "";
                if (dataGridView1.Rows[i].Cells[113].Value.ToString() != "")
                {
                    tipoCulminacion = "PARTO";
                    objCulmina.tipo_parto= tipoCulminacion;
                    objCulmina.via = dataGridView1.Rows[i].Cells[113].Value.ToString();
                    objCulmina.lugar = dataGridView1.Rows[i].Cells[114].Value.ToString();
                    objCulmina.fecha_cul =DateTime.Parse( dataGridView1.Rows[i].Cells[115].Value.ToString());
                }
                else if (dataGridView1.Rows[i].Cells[118].Value.ToString() != "")
                {
                    tipoCulminacion = "ABORTO";
                    objCulmina.fecha_cul= DateTime.Parse(dataGridView1.Rows[i].Cells[118].Value.ToString());
                    objCulmina.tipo_parto = tipoCulminacion;
                }
                if(dataGridView1.Rows[i].Cells[116].Value.ToString()!="" || dataGridView1.Rows[i].Cells[117].Value.ToString() != "")
                {
                    objCulmina.certificado_nac_vivo = "SI";
                    objCulmina.tipo_cer = dataGridView1.Rows[i].Cells[116].Value.ToString();
                    objCulmina.fecha_Cer =DateTime.Parse( dataGridView1.Rows[i].Cells[117].Value.ToString());
                }
                else
                {
                    objCulmina.certificado_nac_vivo = "NO";
                   
                }
                if (tipoCulminacion == "PARTO")
                {
                    objCumninacion.registrarCulminacionEmbarazo_Solo_Parto(objCulmina);
                }
                else if(tipoCulminacion == "ABORTO")
                {
                    objCumninacion.registrarCulminacionEmbarazo_Solo_Aborto(objCulmina);
                }
               


            }
            MessageBox.Show("DATOS IMPORTADO CON EXITO", "PADRON DE GESTANTE", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void frmImportarPadronGesta_Load(object sender, EventArgs e)
        {

        }
    }
}
