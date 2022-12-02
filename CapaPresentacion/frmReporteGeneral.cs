using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Xml;
using CapaEntidad;
using CapaNegocio;

namespace CapaPresentacion
{
    public partial class frmReporteGeneral : Form
    {
        public frmReporteGeneral()
        {
            InitializeComponent();
        }

        NegocioEmbarazo objEmbarao = new NegocioEmbarazo();
        NegocioGestantes objGesta = new NegocioGestantes();
        NegocioIpressUbicacion objIpre = new NegocioIpressUbicacion();
        NegocioEstablecimiento objEss = new NegocioEstablecimiento();

        void cargarResumenGeneralReporte()
        {
            try
            {
                DataTable dt = objGesta.ReporteGeneral_Resumen();
                if (dt.Rows.Count > 0)
                {
                    //lblTotalPaciente.Text = dt.Rows[0][0].ToString();
                    lblGestando.Text = dt.Rows[0][1].ToString();
                    lblCulminado.Text = dt.Rows[0][2].ToString();
                    lblParto.Text = dt.Rows[0][3].ToString();
                    lblAborto.Text = dt.Rows[0][4].ToString();
                  
                }
                else
                {
                    lblAborto.Text = "0";
                    lblGestando.Text = "0";
                    lblCulminado.Text = "0";
                    //lblTotalPaciente.Text = "0";
                    lblParto.Text = "0";
                }
            }
            catch (Exception)
            {

               
            }
        }

        void totalGestante()
        {
            try
            {
                DataTable dt = objGesta.ReporteGeneral_Resumen_TOTAL_GESTANTE();
                if (dt.Rows.Count > 0)
                {
                    lblTotalPaciente.Text= dt.Rows[0][0].ToString();
                }
                else
                {
                    lblTotalPaciente.Text = "0";
                }
            }
            catch (Exception)
            {

                lblTotalPaciente.Text = "0";
            }
        }
        private void TotalEmbarazoPorEstado()
        {
            try
            {
                DataTable dt = objGesta.ReporteGeneral_Resumen_TOTAL_EMBARAZO_POR_ESTADO();
                if(dt.Rows.Count > 0)
                {
                    lblGestando.Text = dt.Rows[0][0].ToString();
                    lblCulminado.Text = dt.Rows[0][1].ToString();
                }
                else
                {
                    lblGestando.Text = "0";
                    lblCulminado.Text = "0";
                }
            }
            catch (Exception)
            {
                lblGestando.Text = "0";
                lblCulminado.Text = "0";

            }
        }
        void graficar()
        {
            try
            {
               
                DataTable dt = objEmbarao.listar_gestante_EmbarazoEstado_Gestando_Activo();
                if (dt.Rows.Count > 0)
                {
                    chart1.Palette = ChartColorPalette.Pastel;
                    chart1.Titles.Add("Cantidad de Embarazos po Ipress");
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        Series serie = chart1.Series.Add(dt.Rows[i][0].ToString());
                        
                        serie.Label = dt.Rows[i][1].ToString();
                        serie.Points.Add(Convert.ToInt32 (dt.Rows[i][1]));
                        //serie.ChartType = SeriesChartType.Doughnut;
                    }
                }
            }
            catch (Exception)
            {

                
            }
        }

        private void listarEmbarazos(String id)
        {
            DataTable dt = objEmbarao.Listar_todos_Gestante_Activos_por_establecimiento(id);
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    DataListado.Rows.Add(
                    dt.Rows[i][0].ToString(),
                     dt.Rows[i][1].ToString(),
                     dt.Rows[i][2],
                       dt.Rows[i][3].ToString(),
                      dt.Rows[i][4],
                       dt.Rows[i][5],
                          dt.Rows[i][6].ToString(),
                           dt.Rows[i][7].ToString()


                );
                    
                }

                DataListado.Columns[2].DefaultCellStyle.Format = "dd/MM/yyyy";
                DataListado.Columns[4].DefaultCellStyle.Format = "dd/MM/yyyy";
                DataListado.Columns[5].DefaultCellStyle.Format = "dd/MM/yyyy";

                //formato columnas
                DataListado.Columns[0].Width = 150;
                DataListado.Columns[1].Width = 300;
                DataListado.Columns[2].Width = 150;
                DataListado.Columns[3].Width = 90;
                DataListado.Columns[4].Width = 100;
                DataListado.Columns[5].Width = 100;
                DataListado.Columns[6].Visible = false;
                DataListado.Columns[6].Width = 90;
                DataListado.Columns[7].Width = 90;
                DataListado.Columns[8].Width = 25;
                
               
                //agregando iconos
                for (int i = 0; i < DataListado.Rows.Count; i++)
                {
                    if (Convert.ToInt32(DataListado.Rows[i].Cells[7].Value.ToString()) <= 10)//esta muy cerca
                    {
                        DataListado.Rows[i].Cells[8].Value = Properties.Resources.advertencia_uk;
                    }else if (Convert.ToInt32(DataListado.Rows[i].Cells[7].Value.ToString()) <= 90)//alerta
                    {
                        DataListado.Rows[i].Cells[8].Value = Properties.Resources.campana_de_notificacion;
                    }
                    else//falta 
                    {
                        DataListado.Rows[i].Cells[8].Value = Properties.Resources.bandera;
                    }
                }

                this.DataListado.EnableHeadersVisualStyles = false;
                DataGridViewCellStyle stiloCabesa = new DataGridViewCellStyle();


                stiloCabesa.BackColor = Color.White;
                stiloCabesa.ForeColor = Color.Black;
                stiloCabesa.Font = new Font("Segoe UI", 10, FontStyle.Regular | FontStyle.Bold);

                this.DataListado.ColumnHeadersDefaultCellStyle = stiloCabesa;

            }
        }
        private void frmReporteGeneral_Load(object sender, EventArgs e)
        {
           graficar();
           
            cargarResumenGeneralReporte();
            totalGestante();
            TotalEmbarazoPorEstado();
            cargarUbicacionIpress();

        }

        void cargarUbicacionIpress()
        {
            DataTable fila = objIpre.ListarUbicacionIpress();
            if (fila.Rows.Count > 0)
            {
                string idEs = fila.Rows[0].ItemArray[2].ToString();
                cargarMicroredes(idEs);

            }
        }
        void cargarMicroredes(string id)
        {
            DataTable dt = objEss.ListarEstablecimiento(id);
            if (dt.Rows.Count > 0)
            {
                cmbEss.Items.Clear();
                cmbEss.DataSource= dt;
                cmbEss.DisplayMember = "Nombre_Establecimiento";
                cmbEss.ValueMember = "Id_Establecimiento";
                cmbEss.SelectedIndex = 1;

                cmbEESSGesta.Items.Clear();
                cmbEESSGesta.DataSource = dt;
                cmbEESSGesta.DisplayMember = "Nombre_Establecimiento";
                cmbEESSGesta.ValueMember = "Id_Establecimiento";
                cmbEESSGesta.SelectedIndex = 1;

            }
        }
        private void bunifuCustomLabel10_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (this.dataGridView1.Columns[e.ColumnIndex].Name == "AVISO" )
            {
                if (e.Value != null)
                {
                    if (e.Value.GetType() != typeof(System.DBNull))
                    {
                        //Stock menor a 20
                        if (e.Value.ToString() == "No Controlada")
                        {
                            e.CellStyle.ForeColor = Color.White;
                            e.CellStyle.SelectionForeColor = Color.White;
                            e.CellStyle.BackColor = Color.FromArgb(237, 86, 60);
                            e.CellStyle.SelectionBackColor = Color.FromArgb(237, 86, 60);
                            
                        }
                        else if(e.Value.ToString() == "Hoy")
                        {
                            e.CellStyle.ForeColor = Color.White;
                            e.CellStyle.SelectionForeColor = Color.White;
                            e.CellStyle.BackColor = Color.Yellow;
                            e.CellStyle.SelectionBackColor = Color.Yellow;
                        }
                        else
                        {
                            e.CellStyle.ForeColor = Color.White;
                            e.CellStyle.SelectionForeColor = Color.White;
                            e.CellStyle.BackColor = Color.Green;
                            e.CellStyle.SelectionBackColor = Color.Green;
                        }
                        
                    }
                }
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void cmbEss_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                dataGridView1.DataSource = objGesta.ListarNotificacionControlesGestante(int.Parse(cmbEss.SelectedValue.ToString()));
                dataGridView1.Columns[0].Width = 200;
                dataGridView1.Columns[1].Width = 200;
                dataGridView1.Columns[2].Visible = false;
                dataGridView1.Columns[3].Width = 150;
                dataGridView1.Columns[4].Width = 150;
                dataGridView1.Columns[5].Visible = false;
                dataGridView1.Columns[6].Visible = false;
                dataGridView1.Columns[7].Width = 100;
            }
            catch (Exception)
            {
                Console.WriteLine("Ocurrio un error al mostrar");
                
            }
        }

        private void cmbEESSGesta_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                DataListado.Rows.Clear();
                listarEmbarazos(cmbEESSGesta.SelectedValue.ToString());
            }
            catch (Exception)
            {

                Console.WriteLine("Ocurrio un error al mostrar Getantes");
            }
        }
    }
}
