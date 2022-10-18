using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Web.Management;
using System.Windows.Forms;

using CapaEntidad;
using CapaNegocio;

using CapaPresentacion.Properties;

namespace CapaPresentacion
{
    public partial class frmPrincipal : Form
    {
        public frmPrincipal()
        {
            InitializeComponent();
        }


        NegocioEstablecimiento objEstablecimiento = new NegocioEstablecimiento();
        NegocioIpressUbicacion objConfigIpress = new NegocioIpressUbicacion();
        NegocioGestantes objGestante = new NegocioGestantes();
        NegocioEmbarazo objEmbarazo = new NegocioEmbarazo();

        string microred = "";

       
        void cargarUbicacionIpress()
        {
            DataTable fila = objConfigIpress.ListarUbicacionIpress();
            if (fila.Rows.Count > 0)
            {
                //obtener microred configurado
               
               microred= fila.Rows[0].ItemArray[2].ToString();
                lblMicrored.Text = "MICRO RED \n" + microred;
                cargarMicroredes();
                listarControlesNorifiacion();
                
            }
            else
            {
                //MessageBox.Show("Falta configurar Ubicacion de Microred", "Padron Gestante", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                //primera vez
                
                frmMascara objMas = new frmMascara();
               
                frmConfigIpress objIpe = new frmConfigIpress();

                objMas.Show();
                objIpe.ShowDialog();
                objMas.Hide();
                
                if (objIpe.Tag.ToString() == "A")
                {
                    cargarUbicacionIpress();
                    lblMicrored.Text = "MICRO RED \n" + microred;
                    cargarMicroredes();
                    listarControlesNorifiacion();
                }
                
            }

        }

        string focoSeleccionado;

        void cargarMicroredes()
        {
            DataTable dt = objEstablecimiento.ListarEstablecimiento(microred);
            if(dt.Rows.Count > 0)
            {
                //limpiar panel de establecimiento
                flowLayoutPanel1.Controls.Clear();

               for(int i = 0; i < dt.Rows.Count; i++)
                {
                    Panel pcl = new Panel();
                    Panel lateral = new Panel();
                    Button boton = new Button();
                    // 
                    
                    pcl.Size = new System.Drawing.Size(201, 49);
                    // 
                    lateral.Dock = System.Windows.Forms.DockStyle.Left;
                    lateral.Name = dt.Rows[i][1].ToString();
                    lateral.Size = new System.Drawing.Size(3, 49); 
                    // 
                    boton.Dock = System.Windows.Forms.DockStyle.Fill;
                    boton.FlatAppearance.BorderSize = 0;
                    boton.FlatAppearance.MouseDownBackColor = Color.FromArgb(85, 19, 16);
                    boton.FlatAppearance.MouseOverBackColor = Color.IndianRed;
                    boton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                    boton.Name = dt.Rows[i][1].ToString();
                    boton.Size = new System.Drawing.Size(196, 49);
                    boton.Text = dt.Rows[i][2].ToString();
                    boton.TextAlign = ContentAlignment.MiddleLeft;
                    boton.Font = new Font("Segoe UI", 10, FontStyle.Regular | FontStyle.Bold);
                    boton.BackColor = Color.Transparent;
                    boton.ForeColor = Color.FromArgb(255, 0, 127);
                    boton.Cursor = Cursors.Hand;
                    boton.UseVisualStyleBackColor = true;
                    // 
                  
                    if (focoSeleccionado == boton.Text)
                    {
                        lateral.BackColor = Color.Red;
                        boton.BackColor = Color.Brown;
                        boton.ForeColor = Color.White;
                    }
                    else
                    {
                        lateral.BackColor = Color.Transparent;
                        boton.BackColor = Color.Transparent;
                        boton.ForeColor = Color.White;
                    }

                    pcl.Controls.Add(lateral);
                    pcl.Controls.Add(boton);
                    flowLayoutPanel1.Controls.Add(pcl);

                    boton.BringToFront();
                    lateral.SendToBack();

                    boton.Click += boton_click;

                    
                }
            }
        }



        string idMicro="5151";
        string idMicro2;
        private void boton_click(object sender, EventArgs e){
            try
            {

                focoSeleccionado = (sender as Button).Text;
                
                idMicro = (sender as Button).Name;

                foreach (Control panel in flowLayoutPanel1.Controls)
            {
                if (panel is Panel)
                {
                    foreach (Control panelLateral in panel.Controls)
                    {
                        if (panelLateral is Panel)
                        {
                           
                                panelLateral.BackColor = Color.Transparent;
                                panel.BackColor = Color.Transparent;
                            

                            }
                    }
                }
            }

            idMicro2 = (sender as Button).Name;
            foreach (Control panel in flowLayoutPanel1.Controls)
                {
                if(panel is Panel)
                {
                    foreach(Control panelLateral in panel.Controls)
                    {
                        if(panelLateral is Panel)
                        {
                            if(panelLateral.Name == idMicro2)
                            {
                                panelLateral.BackColor = Color.Red;
                                panel.BackColor = Color.Brown;
                                    panel.ForeColor = Color.White;
                                }
                        }
                    }
                }
            }

                listarPacientesPorEstablecimiento(int.Parse(idMicro));
                listarControlesNorifiacion();
            }
            catch (Exception)
            {


            }
        }
        void listarPacientesPorEstablecimiento(int id)
        {
            DataListado.Rows.Clear();
            string estado;
            if (rbActivo.Checked == true)
            {
                estado = "ACTIVO";
            }else if (rbIactivo.Checked == true)
            {
                estado = "DESACTIVO";
            }
            else
            {
                estado = "";
            }
            string texto;

            if (txtBuscar.Text.Trim().Length == 0)
            {
                texto = "";
            }
            else
            {
                texto = this.txtBuscar.Text;
            }

            DataTable dt = objGestante.listarGestantes(id,estado, texto);

            if (dt.Rows.Count > 0)
            {
                
                //lblMensajeBien.Text = "Si ahy registro";
                panel5.Dock = DockStyle.None;
                panel5.Visible = false;

                //DataListado.DataSource = dt;//llenar datos tips1

                for (int i = 0; i < dt.Rows.Count; i++)//llenar datos tips2
                {
                    DataListado.Rows.Add(
                        Resources.boton_x,Resources.lapiz,Resources.mas_informacion,
                        dt.Rows[i][0].ToString()//id gestante
                         ,dt.Rows[i][1].ToString()//tipo documento
                          , dt.Rows[i][2].ToString()//nro doc
                           , dt.Rows[i][3].ToString()//nombre y apellidos de gestante
                            ,  dt.Rows[i][4] //fecha nacimiento
                             , dt.Rows[i][5].ToString()//edad
                              , dt.Rows[i][6].ToString()//estado
                               , dt.Rows[i][7].ToString()//id_gestante

                        );
                }

                //configuamos tamaño de columnas
                DataListado.Columns[0].Visible = false;
                DataListado.Columns[0].DefaultCellStyle.Padding = new Padding(7, 5,7, 5);
                
                DataListado.Columns[1].Width = 40;
                DataListado.Columns[1].DefaultCellStyle.Padding = new Padding(7, 5, 7, 5);
                DataListado.Columns[2].Width = 40;
                DataListado.Columns[2].DefaultCellStyle.Padding = new Padding(7, 5, 7, 5);
                DataListado.Columns[3].Visible = false;
                DataListado.Columns[4].Width = 90;
                DataListado.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                DataListado.Columns[5].Width = 100;
                DataListado.Columns[6].Width = 280;
                DataListado.Columns[7].Width = 100;
                DataListado.Columns[7].DefaultCellStyle.Format = "dd/MM/yyyy";
                DataListado.Columns[8].Width = 80;
                //DataListado.Columns[9].Visible = false;


                this.DataListado.EnableHeadersVisualStyles = false;
                DataGridViewCellStyle stiloCabesa = new DataGridViewCellStyle();

                
                stiloCabesa.BackColor = Color.White;
                stiloCabesa.ForeColor = Color.Black;
                stiloCabesa.Font = new Font("Segoe UI", 10,FontStyle.Regular | FontStyle.Bold);
                
                this.DataListado.ColumnHeadersDefaultCellStyle = stiloCabesa;

                foreach (DataGridViewRow row in DataListado.Rows)
                {
                    if (row.Cells["estado"].Value.ToString() == "DESACTIVO" || row.Cells["estado"].Value.ToString() == "ELIMINADO")
                    {
                        row.DefaultCellStyle.Font = new Font("Segoi UI",10, FontStyle.Strikeout | FontStyle.Bold);
                        row.DefaultCellStyle.ForeColor = Color.Red;
                    }
                }

                AsignaCondicionGestante();

            }
            else
            {
                lblMensajeBien.Text = "No hay ninguna gestante, Registrada en el Establecimiento Seleccionado";
                pictureBox3.Image = Properties.Resources.no_hay_resultados;
                panel5.Dock = DockStyle.Fill;
                panel5.Visible = true;
            }



        }

        //despues de haber llenado todos las gestantes, vamos hacer que este metodo
        /*recorra toda la fila y obtener id_gestante , luego buscamos si tiene embarazo y en que estado
         se enuentra, */

        void AsignaCondicionGestante()
        {
            //iniciar en cero
            int x = 0;

            //mientras el registro es mayor a x vamos a seguir recorriendo las filas
            while (DataListado.Rows.Count > x)
            {
                //obtener id_gestante
                int id_gestante =Convert.ToInt32( DataListado.Rows[x].Cells[3].Value.ToString());

                //llamamos al objeto embarazo y metodo buscar embarazo de gestante
                DataTable dt= objEmbarazo.listar_Condicion_Embarazo_Por_Gestante(id_gestante);
                string condicion = "";
                //verificamos si tiene ultimo embarazo embarazo
                if (dt.Rows.Count > 0)
                {
                    //si tiene embarazo obtenemos en que estado esta el ultimo embarazo
                    condicion= dt.Rows[0][6].ToString();
                }
                else
                {
                    condicion = "";
                }
                DataListado.Rows[x].Cells[11].Value = condicion;
                x++;
            }
        }


        string departamento;
        string provincia;
        string distrito;
        string centroPoblado;
        string renaes;
        string microredAc;
        string ipress;

        public void enviarDatosEstablecimiento()
        {
            DataTable dt = objEstablecimiento.ListarEstablecimientoTotalPorId(Convert.ToInt32( idMicro));
            if (dt.Rows.Count > 0)
            {
                departamento = dt.Rows[0][12].ToString();
                provincia = dt.Rows[0][13].ToString();
                distrito = dt.Rows[0][14].ToString();
                centroPoblado = dt.Rows[0][1].ToString();
                renaes = dt.Rows[0][2].ToString();
                microredAc=dt.Rows[0][8].ToString();
                ipress=dt.Rows[0][1].ToString();
            }

        }

        private void iniciar_proceso_activacion()
        {
            //Properties.Settings.Default.ProductoRegistrado = false;
            //Properties.Settings.Default.HaIngresado = false;

            if (Properties.Settings.Default.ProductoRegistrado == false)
            {
                panel3.BackColor = Color.IndianRed;
                panel3.BackColor = Color.White;

                if (Properties.Settings.Default.HaIngresado == false)
                {
                    if(Properties.Settings.Default.HaIngresado == true)
                    {
                        MessageBox.Show("Es la primera vez que ingresa","Sistema de Padron de Gestante",MessageBoxButtons.OK,MessageBoxIcon.Information);
                        timer1.Start();
                        lblTiempo.Text = DateTime.Now.ToString();
                        Properties.Settings.Default.FechaCaducidad = DateTime.Now.AddMinutes(1);
                        Properties.Settings.Default.HaIngresado = true;
                        lblFechaCaducidad.Text ="Fecha Caducidad : "+ Properties.Settings.Default.FechaCaducidad.ToString();
                        Properties.Settings.Default.Save();
                    }
                    else
                    {
                        MessageBox.Show("No es la primera vez que ingresa", "Sistema de Padron de Gestante", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        timer1.Start();
                        lblTiempo.Text = DateTime.Now.ToString();
                        lblFechaCaducidad.Text = "Fecha Caducidad : " + Properties.Settings.Default.FechaCaducidad.ToString();
                    }
                    
                }
                else
                {
                    //MessageBox.Show("No es la primera vez que entra");

                    timer1.Start();
                    lblTiempo.Text = DateTime.Now.ToString();
                    lblFechaCaducidad.Text = Properties.Settings.Default.FechaCaducidad.ToString();
                }
            }
            else
            {
                MessageBox.Show("BIENVENIDOS A SISTEMA DE PADRON DE GESTANTE","PRODUCTO ACTIVADO",MessageBoxButtons.OK,MessageBoxIcon.Information);
                
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            

                cargarUbicacionIpress();

            //cargarMicroredes();
            listarControlesNorifiacion();
            iniciar_proceso_activacion();
        }
        public void actualizarTiempo()
        {
            lblTiempo.Text = DateTime.Now.ToString();
            DateTime fechaIni = DateTime.Parse(lblTiempo.Text);
            DateTime fechFin = DateTime.Parse(Properties.Settings.Default.FechaCaducidad.ToString());
            lblFalta.Text = "Falta : " + ( fechFin- fechaIni).ToString();
            
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (focoSeleccionado == null)
            {
                MessageBox.Show("Seleccione un Establecimiento , para Agregar Nuevo Paciente", "Padron Gestante", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            frmMascara objMas = new frmMascara();

            frmAddGestante objIpe = new frmAddGestante();

            objMas.Show();
            objIpe.lblNombreIpress.Text = focoSeleccionado;
            objIpe.lblNombreIpress.Name = idMicro;
            enviarDatosEstablecimiento();
            objIpe.dep = departamento;
            objIpe.prov = provincia;
            objIpe.distr = distrito;
            //ubicacion 
            objIpe.Renaes = renaes;
            objIpe.micror = microred;
            objIpe.eess = ipress;

            objIpe.txtCentroPoblado.Text = ipress;
            objIpe.lblRenaes.Text = renaes;
            objIpe.lblMicroRed.Text = microred;
            objIpe.lblEstablecimiento.Text = ipress;
            objIpe.lblCondicion.Text = "N";
            objIpe.btnGuardar.Enabled = true;
            objIpe.btnGuardarCambios.Enabled = false;
            objIpe.btnVolver.Enabled = true;
            objIpe.ShowDialog();
            objMas.Hide();

            if (objIpe.Tag.ToString() == "A")
            {

                objMas.Dispose();
                objIpe.Dispose();
                listarPacientesPorEstablecimiento(int.Parse(idMicro));
                //MessageBox.Show("se cerro con exito jajaja");

            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            listarPacientesPorEstablecimiento(int.Parse(idMicro));
        }

        private void lblMicrored_Click(object sender, EventArgs e)
        {

        }

        private void DataListado_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void DataListado_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void DataListado_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == this.DataListado.Columns["Edi"].Index)
            {
                int id_gestante =int.Parse( DataListado.CurrentRow.Cells[10].Value.ToString());
                
                frmMascara objMas = new frmMascara();

                frmAddGestante objGsta = new frmAddGestante();

                objMas.Show();
                objGsta.lblNombreIpress.Text = focoSeleccionado;
                objGsta.lblNombreIpress.Name = idMicro;

                objGsta.lblIDGestante.Text = id_gestante.ToString();
                objGsta.lblCondicion.Text = "E";
                objGsta.btnGuardar.Enabled = false;
                objGsta.btnGuardarCambios.Enabled = true;
                objGsta.btnVolver.Enabled = true;
                objGsta.ShowDialog();
                objMas.Hide();
               

                if (objGsta.Tag.ToString() == "A")
                {
                    objMas.Dispose();
                    objGsta.Dispose();
                    listarPacientesPorEstablecimiento(int.Parse(idMicro));
                }
            }
            if (e.ColumnIndex == this.DataListado.Columns["Ver"].Index)
            {
                frmMascara objMas = new frmMascara();
               

                frmEmbarazo objEmb = new frmEmbarazo();
                objEmb.lblgestante.Name = DataListado.CurrentRow.Cells[3].Value.ToString();
                objEmb.lblgestante.Text = DataListado.CurrentRow.Cells[6].Value.ToString();
             
                objMas.Show();
                objEmb.ShowDialog();
                objMas.Hide();

                if (objEmb.Tag.ToString() == "A")
                {
                    objMas.Dispose();
                    objEmb.Dispose();
                    listarPacientesPorEstablecimiento(int.Parse(idMicro));
                }
            }
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void verRadarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmRadarGestante objRadar = new frmRadarGestante();
            objRadar.ShowDialog();
        }

        private void DataListado_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (this.DataListado.Columns[e.ColumnIndex].Name == "condicion")
            {
                if (e.Value != null)
                {
                    if (e.Value.GetType() != typeof(System.DBNull))
                    {
                        //Stock menor a 20
                        if (e.Value.ToString() =="GESTANDO")
                        {
                            e.CellStyle.BackColor = Color.FromArgb(245, 176, 65);
                            e.CellStyle.ForeColor = Color.White;
                            e.CellStyle.SelectionBackColor = Color.FromArgb(245, 176, 65);
                            e.CellStyle.SelectionForeColor = Color.White;
                        }
                        //Stock menor a 10
                        if (e.Value.ToString() == "CULMINADO")
                        {
                            e.CellStyle.BackColor = Color.FromArgb(39, 174, 96);
                            e.CellStyle.ForeColor = Color.White;
                            e.CellStyle.SelectionBackColor = Color.FromArgb(39, 174, 96);
                            e.CellStyle.SelectionForeColor = Color.White;
                        }
                    }
                }
            }
        }

        private void ayudaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAyuda objAyuda = new frmAyuda();
            frmMascara objMascara = new frmMascara();
            objMascara.Show();
            objAyuda.ShowDialog();
            objMascara.Dispose();

            if (objAyuda.Tag.ToString() == "A")
            {

                objAyuda.Dispose();
                objMascara.Dispose();
              
            }
        }

        private void reporteGeneralToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmReporteGeneral objR = new frmReporteGeneral();
            frmMascara objMascara = new frmMascara();
            objMascara.Show();
            objR.ShowDialog();
            objMascara.Dispose();
        }

        private void cerrarSistemaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void cerrarSistemaToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
         if(MessageBox.Show("¿Estas seguro que quiere cerrar sistema?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Dispose();
                Application.Exit();
                this.Close();
            }
        }

        private void eportarPadronNomimalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmVistaExportador objExport = new frmVistaExportador();
            frmMascara objMascara = new frmMascara();
            objMascara.Show();
            objExport.ShowDialog();
            objMascara.Dispose();
        }

        private void rbTodo_CheckedChanged(object sender, EventArgs e)
        {
            if (rbTodo.Checked == true)
            {
                listarPacientesPorEstablecimiento(int.Parse(idMicro));
            }
        }

        private void rbActivo_CheckedChanged(object sender, EventArgs e)
        {
            if(rbActivo.Checked == true)
            {
                listarPacientesPorEstablecimiento(int.Parse(idMicro));
            }
        }

        private void rbIactivo_CheckedChanged(object sender, EventArgs e)
        {
            if (rbIactivo.Checked == true)
            {
                listarPacientesPorEstablecimiento(int.Parse(idMicro));
            }
        }

        void listarControlesNorifiacion()
        {
            if (idMicro.Trim().Length == 0)
            {
                idMicro = "5151";
            }
            DataTable dt = objGestante.ListarNotificacionControlesGestante(Convert.ToInt32( idMicro));
            if (dt.Rows.Count > 0)
            {
                int cantn = 0;
                flowLayoutPanel2.Controls.Clear();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (dt.Rows[i][7].ToString() != "En Espera")
                    {
                        cantn++;
                       
                        Label label1 = new Label();
                    Label label2 = new Label();
                    Label label3 = new Label();
                    Label label4 = new Label();
                    Label label5 = new Label();
                    Label label6 = new Label();
                    Label label7 = new Label();
                    PictureBox picture5 = new PictureBox();
                    Panel panel8 = new Panel();
                    // label1
                    // 
                    label1.AutoSize = true;
                    label1.Font = new System.Drawing.Font("Segoe UI", 5.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    label1.Location = new System.Drawing.Point(3, 3);
                    label1.Name = dt.Rows[i][0].ToString();
                    label1.Size = new System.Drawing.Size(118, 12);
                    label1.TabIndex = 0;
                    label1.Text = dt.Rows[i][0].ToString();
                    // 
                    // label2
                    // 
                    label2.AutoSize = true;
                    label2.Font = new System.Drawing.Font("Segoe UI", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    label2.Location = new System.Drawing.Point(3, 17);
                    label2.Name = "label2";
                    label2.Size = new System.Drawing.Size(74, 12);
                    label2.TabIndex = 1;
                    label2.Text = "Ultimo Control:";
                    // 
                    // label3
                    // 
                    label3.AutoSize = true;
                    label3.Font = new System.Drawing.Font("Segoe UI", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    label3.Location = new System.Drawing.Point(3, 31);
                    label3.Name = "label3";
                    label3.Size = new System.Drawing.Size(84, 12);
                    label3.TabIndex = 1;
                    label3.Text = "Siguiente Control:";
                    // 
                    // label4
                    // 
                    label4.AutoSize = true;
                    label4.Font = new System.Drawing.Font("Segoe UI", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    label4.Location = new System.Drawing.Point(75, 17);
                    label4.Name = DateTime.Parse( dt.Rows[i][3].ToString()).ToShortDateString();
                    label4.Size = new System.Drawing.Size(53, 12);
                    label4.TabIndex = 1;
                    label4.Text = DateTime.Parse(dt.Rows[i][3].ToString()).ToShortDateString();
                    // 
                    // label5
                    // 
                    label5.AutoSize = true;
                    label5.Font = new System.Drawing.Font("Segoe UI", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    label5.Location = new System.Drawing.Point(85, 31);
                    label5.Name = DateTime.Parse(dt.Rows[i][7].ToString()).ToShortDateString();
                    label5.Size = new System.Drawing.Size(53, 12);
                    label5.TabIndex = 1;
                    label5.Text = DateTime.Parse(dt.Rows[i][7].ToString()).ToShortDateString();
                    // 
                    // pictureBox5
                    // 
                    if (dt.Rows[i][8].ToString() == "No Controlada")
                    {
                        picture5.Image = global::CapaPresentacion.Properties.Resources.boton_x;
                    } else if (dt.Rows[i][8].ToString() == "En Espera")
                    {
                        picture5.Image = global::CapaPresentacion.Properties.Resources.campana_de_notificacion;
                    }
                    else
                    {
                        picture5.Image = global::CapaPresentacion.Properties.Resources.grifo;
                    }

                    picture5.Location = new System.Drawing.Point(140, 3);
                    picture5.Name = "pictureBox5";
                    picture5.Size = new System.Drawing.Size(20, 15);
                    picture5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
                    picture5.TabIndex = 2;
                    picture5.TabStop = false;
                    // 
                    // label6
                    // 
                    label6.AutoSize = true;
                    label6.Font = new System.Drawing.Font("Segoe UI", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    label6.Location = new System.Drawing.Point(3, 46);
                    label6.Name = "label" + i.ToString();
                    label6.Size = new System.Drawing.Size(60, 12);
                    label6.TabIndex = 1;
                    label6.Text = "Fecha Actual:";
                    // 
                    // label7
                    // 
                    label7.AutoSize = true;
                    label7.Font = new System.Drawing.Font("Segoe UI", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    label7.Location = new System.Drawing.Point(62, 46);
                    label7.Name = "label" + i.ToString();
                    label7.Size = new System.Drawing.Size(53, 12);
                    label7.TabIndex = 1;
                    label7.Text = DateTime.Now.ToShortDateString();

                    //panel
                    panel8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
                    panel8.Controls.Add(picture5);
                    panel8.Controls.Add(label7);
                    panel8.Controls.Add(label6); 
                    panel8.Controls.Add(label5);
                    panel8.Controls.Add(label3);
                    panel8.Controls.Add(label4);
                    panel8.Controls.Add(label2);
                    panel8.Controls.Add(label1);
                    panel8.ForeColor = System.Drawing.Color.SkyBlue;
                    panel8.Location = new System.Drawing.Point(3, 3);
                    panel8.Name = "panel" + i.ToString();
                    panel8.Size = new System.Drawing.Size(158, 62);
                    panel8.TabIndex = 0;

                    flowLayoutPanel2.Controls.Add(panel8);
                }
                }
                lblNotificacion.Text = cantn.ToString();
            }
            else
            {
                lblNotificacion.Text = "0";
            }
        }
        private void pictureBox4_Click(object sender, EventArgs e)
        {
            listarControlesNorifiacion();
            if (flowLayoutPanel2.Visible == true)
            {
                flowLayoutPanel2.Visible = false;
            }
            else
            {
                flowLayoutPanel2.Visible = true;
            }

        }

        private void lblNotificacion_Click(object sender, EventArgs e)
        {
            listarControlesNorifiacion();
            if (flowLayoutPanel2.Visible == true)
            {
                flowLayoutPanel2.Visible = false;
            }
            else
            {
                flowLayoutPanel2.Visible = true;
            }
        }

        //producto no activado confirmar salida auto
        string salida;
        private void timer1_Tick(object sender, EventArgs e)
        {
            actualizarTiempo();
            if (DateTime.Now > Properties.Settings.Default.FechaCaducidad)
            {
                frmMascara fil = new frmMascara();
                frmIngresarClave obj = new frmIngresarClave();
                fil.Show();
                timer1.Stop();
                obj.ShowDialog();

                fil.Hide();
                if (obj.Tag.ToString() == "A")
                {
                    iniciar_proceso_activacion();
                }else 
                {
                    salida = "SI";
                    this.Close();
                }
            }
        }

        private void recuperarClaveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmConfigIpress obj = new frmConfigIpress();
            frmMascara mas = new frmMascara();
            mas.Show();
            obj.ShowDialog();
            mas.Hide();
            if(obj.Tag.ToString() == "A")
            {
                cargarUbicacionIpress();
            }
        }

        private void frmPrincipal_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(MessageBox.Show("Estas seguro que quieres salir del sistema", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Dispose();
                Application.Exit();
                e.Cancel = false;
                
            }
            else
            {
                e.Cancel = true;
            }
            if (salida == "SI")
            {
                this.Dispose();
                Application.Exit();
                e.Cancel = false;
            }
        }

        private void importarPadronGestanteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmImportarPadronGesta obj = new frmImportarPadronGesta();
            frmMascara fil = new frmMascara();
            fil.Show();

            obj.ShowDialog();
            fil.Hide();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void limpiarBDToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NegocioAdicional objAdicional = new NegocioAdicional();
           if(objAdicional.LimpiarGestante() == true)
            {
                MessageBox.Show("La base datos ha sido Limpiado Correctamente","Mensaje",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Ocurrio errore al Limpiar Base de datos","Advertencia",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private void activarProductoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmIngresarClave objActivar = new frmIngresarClave();
            frmMascara objMas = new frmMascara();
            objMas.Show();
            objActivar.ShowDialog();
            
            objMas.Hide();
            if (objActivar.Tag .ToString()== "")
            {
                iniciar_proceso_activacion();
            }
        }

        private void flowLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void configurarConexionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmConexionConfigurado objConexionConfigurado = new frmConexionConfigurado();
            frmMascara objm = new frmMascara();
            objm.Show();
            objConexionConfigurado.ShowDialog();
            objm.Hide();
        }
    }
}
