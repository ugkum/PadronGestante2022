using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CapaEntidad;
using CapaNegocio;

namespace CapaPresentacion
{
    public partial class frmVistaExportador : Form
    {
        public frmVistaExportador()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        NegocioPadronGestante objPadron = new NegocioPadronGestante();

        void reportarPadronGestante()
        {
            try
            {
                DataTable dt = objPadron.ReportarPadronNominal();
                DataListado.DataSource = dt;

                this.DataListado.EnableHeadersVisualStyles = false;
                DataGridViewCellStyle stiloCabesa = new DataGridViewCellStyle();


                stiloCabesa.BackColor = Color.White;
                stiloCabesa.ForeColor = Color.Black;
                stiloCabesa.Font = new Font("Segoe UI", 9, FontStyle.Regular | FontStyle.Bold);

                this.DataListado.ColumnHeadersDefaultCellStyle = stiloCabesa;


            }
            catch (Exception)
            {

              
            }
        }

        private void frmVistaExportador_Load(object sender, EventArgs e)
        {
            //backgroundWorker1.WorkerReportsProgress = true;
            //backgroundWorker1.WorkerSupportsCancellation = true;

            //backgroundWorker1.DoWork += new DoWorkEventHandler(backgroundWorker1_DoWork);
            //backgroundWorker1.ProgressChanged += new ProgressChangedEventHandler(backgroundWorker1_ProgressChanged);
            //backgroundWorker1.RunWorkerCompleted += new RunWorkerCompletedEventHandler(backgroundWorker1_RunWorkerCompleted);
            //reportarPadronGestante();
        }

        //ExportarExcel
        void ExportarExcel()
        {
            Microsoft.Office.Interop.Excel.Application oXL;
            Microsoft.Office.Interop.Excel._Workbook oWB;
            Microsoft.Office.Interop.Excel._Worksheet oSheet;
            object misvalue = System.Reflection.Missing.Value;
            //try
            //{
                //copiar el contenido de un datatable en un archivo existente de Microsoft Excel
                oXL = new Microsoft.Office.Interop.Excel.Application();
                oXL.Visible = false;
                oXL.ScreenUpdating = false;
                oXL.UserControl = false;

                string directorio = (@"C:\\RSC_PADRON_GESTANTE_2022\\");
                oWB = (Microsoft.Office.Interop.Excel._Workbook)(oXL.Workbooks.Open(directorio + "mi_plantilla.xlsx"));
                oSheet = (Microsoft.Office.Interop.Excel._Worksheet)oWB.ActiveSheet;

                //obtener datos de sql server(base de datos)
                DataTable dt = objPadron.ReportarPadronNominal();

            //Copiar datos de la tabla recorriendola como matriz y asigando fila a fila y campo a campo en Excel , la tabla es zero-index y excel el indice empieza en 1
                panel1.Visible = true;
                
                label3.Visible = false;
            lblContadorExpor.Visible = true;
            progressBar1.Visible = true;
            progressBar1.Minimum = 0;
            progressBar1.Maximum = dt.Rows.Count;
            progressBar1.Value = 0;


            for (int i = 0; i < dt.Rows.Count; i++)
                {

                progressBar1.Value = (i + 1);
                lblContadorExpor.Text = "Cargando ..." + progressBar1.Value.ToString();

                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    oSheet.Cells[(i + 6), (1)] = i+1;

                    //if (j == 5 || j == 25 || j == 26 || j == 27 || j == 29 || j == 31 || j == 33 || j == 35 || j == 39 || j == 41 || j == 43 || j == 45 || j == 47 || j == 49 || j == 51 || j == 53 || j == 55 || j == 57 || j == 59 || j == 61 || j == 63 || j == 65 || j == 67 || j == 69 || j == 71 || j == 73 || j == 77 || j == 79 || j == 81 || j == 83 || j == 85 || j == 86 || j == 87 || j == 88 || j == 89 || j == 90 || j == 91 || j == 92 || j == 93 || j == 94 || j == 95 || j == 96 || j == 98 || j == 100 || j == 102 || j == 103 || j == 104 || j == 105 || j == 106 || j == 107 || j == 108 || j == 109 || j == 110 || j == 111 || j == 112 || j == 113 || j == 114 || j == 117 || j == 119 || j == 120 || j == 121 || j == 122 || j == 123 || j == 125)
                    //{
                    //    if (dt.Rows[i][j].ToString() == "")
                    //    {
                    //        oSheet.Cells[(i + 6), (j + 2)] = dt.Rows[i][j].ToString();
                    //    }
                    //    else
                    //    {
                    //        oSheet.Cells[(i + 6), (j + 2)] = DateTime.Parse(dt.Rows[i][j].ToString()).ToString("yyyy-MM-dd");
                    //    }

                    //}
                    //else
                    //{
                    oSheet.Cells[(i + 6), (j + 2)] = dt.Rows[i][j].ToString();
                    //}


                }
                

                }

                Random miAleatorio = new Random();

               int num= miAleatorio.Next(1, 10);
                


                int dia = DateTime.Now.Day;
                int mes = DateTime.Now.Month;
                int anio = DateTime.Now.Year;
                string unio_fecha = dia + "-" + mes + "-" + anio;
                
                string nomarchivo ="C:\\RSC_PADRON_GESTANTE_2022\\EXPOTACION\\" + "Padron_Gestante_" + unio_fecha +"Cod_"+num+ ".xlsx" ;


                oWB.SaveAs(nomarchivo, Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookDefault, Type.Missing, Type.Missing,
                    false, false, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlNoChange,
                    Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);

                oWB.Close();
                oXL.Quit();
                
                panel1.Visible = true;
            timer1.Enabled = true;
            timer1.Start();
        //}
        //    catch (Exception)
        //    {
        //        MessageBox.Show("OCURRIO UN ERROR AL EXPORTAR","INTENTE DE NUEVO",MessageBoxButtons.OK,MessageBoxIcon.Error);
        //    }
}
        //exportar padron de gestante a excel 2022
        private void button1_Click(object sender, EventArgs e)
        {
            //if (backgroundWorker1.IsBusy)
            //{
            //    backgroundWorker1.CancelAsync();
            //}
            //else
            //{
                pictureBox1.Image = Properties.Resources._7211791;
                ExportarExcel();

            //    if (progressBar1.Value == progressBar1.Maximum)
            //    {
            //        progressBar1.Value = progressBar1.Minimum;
            //    }
            //    backgroundWorker1.RunWorkerAsync(progressBar1.Value);

            //}
            
        }

        int tiempo = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            tiempo += 10;
            if (tiempo == 10)
            {
                pictureBox1.Image = Properties.Resources._6172512;
                lblContadorExpor.Visible = false;
                progressBar1.Value = 0;
                progressBar1.Visible = false;

            }
            else if(tiempo == 80)
            {
                pictureBox1.Image = Properties.Resources.aprobar;
                label3.Visible = true;
            }
            if(tiempo >= 100)
            {
                timer1.Stop();
                //timer1.Interval = 0;
                panel1.Visible = false;
                tiempo = 0;
              
                this.Dispose();
                this.Close();
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            int final = (int)e.Argument;
            while (!backgroundWorker1.CancellationPending && final < 100)
            {
                final++;
                backgroundWorker1.ReportProgress(final);
                System.Threading.Thread.Sleep(50);
            }
            e.Result = final;
            
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value=e.ProgressPercentage;
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            MessageBox.Show("Exportacion exitoso");

        }
    }
}
