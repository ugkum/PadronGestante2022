using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.IO;
using System.Collections.Specialized;
using CapaEntidad;
using CapaNegocio;
using CapaPresentacion;
using CapaPresentacion.Dataset_Reportes;
using CapaPresentacion.Reportes;

namespace CapaPresentacion
{
    public partial class frmEmbarazo : Form
    {
        public frmEmbarazo()
        {
            InitializeComponent();
        }

        NegocioEmbarazo objEmbarazo = new NegocioEmbarazo();

        private void frmEmbarazo_Load(object sender, EventArgs e)
        {
            listarEmbarazoPorGestante();
            
            ListarVacuna();
            HayEmbarazo();
            paneles_22();

        }

        void HayEmbarazo()
        {
            if (this.DataListado.Rows.Count > 0){
                panelSinGesta.Dock = DockStyle.None;
                panelSinGesta.Visible = false;
              
            }else{
                panelSinGesta.Dock = DockStyle.Fill;
                panelSinGesta.Visible = true;
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            int hay = 0;

            if (DataListado.Rows.Count > 0)
            {
                for (int i = 0; i < DataListado.Rows.Count; i++)
                {
                    if (DataListado.Rows[i].Cells[8].Value.ToString()=="GESTANDO")
                    {
                        hay++;
                        MessageBox.Show("La Gestante actual, Tiene Fecha probable del parto en : " + DataListado.Rows[0].Cells[4].Value.ToString() + "\n Es Imposible que tenga Mas Embarazos una Gestante ", "Sistema de Validacion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }
                }

                if (hay == 0)
                {
                    panelSinGesta.Dock = DockStyle.None;
                    panelSinGesta.Visible = false;
                    panelAddEmb.Dock = DockStyle.Fill;
                    panelAddEmb.Visible = true;
                    button1.Enabled = false;
                    label1.Text = "CREAR NUEVO EMBARAZO";
                }
            }
            else
            {
                panelSinGesta.Dock = DockStyle.None;
                panelSinGesta.Visible = false;
                panelAddEmb.Dock = DockStyle.Fill;
                panelAddEmb.Visible = true;
                button1.Enabled = false;
                label1.Text = "CREAR NUEVO EMBARAZO";
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            
            bunifuTransition1.ShowSync(panelAddEmb , true, BunifuAnimatorNS.Animation.Particles);
            
            panelAddEmb.Visible = false;
            panelAddEmb.Dock = DockStyle.None;
            esEditarEmbarazo = "";
            button1.Enabled = true;
            errorProvider1.Clear();
            HayEmbarazo();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Tag = "A";
            this.Close();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void tabPage4_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        public static Boolean EsFecha(String fecha)
        {
            try
            {
                DateTime.Parse(fecha);
                return true;
            }
            catch
            {
                return false;
            }
        }

        private void listarEmbarazoPorGestante()
        {
            DataTable datos = objEmbarazo.listarEmbarazoPorGestante(int.Parse(this.lblgestante.Name));
            if (datos.Rows.Count > 0)
            {
                DataListado.DataSource = datos;
                DataListado.Columns[0].Width = 20;
                DataListado.Columns[1].Width = 20;
                DataListado.Columns[2].Visible = false;
                DataListado.Columns[3].Width = 70;
                DataListado.Columns[4].Width = 70;
                DataListado.Columns[5].Width = 20;
                DataListado.Columns[6].Width = 50;
                DataListado.Columns[7].Visible = false;
                DataListado.Columns[8].Width = 75;
            }

            this.DataListado.EnableHeadersVisualStyles = false;
            DataGridViewCellStyle stiloCabesa = new DataGridViewCellStyle();


            stiloCabesa.BackColor = Color.White;
            stiloCabesa.ForeColor = Color.Black;
            stiloCabesa.Font = new Font("Segoe UI", 8, FontStyle.Regular | FontStyle.Bold);
            this.DataListado.ColumnHeadersDefaultCellStyle = stiloCabesa;

            foreach (DataGridViewRow row in DataListado.Rows)
            {
                if (row.Cells["tipo_parto"].Value.ToString() == "PARTO" || row.Cells["tipo_parto"].Value.ToString() == "ABORTO")
                {
                    row.DefaultCellStyle.Font = new Font("Segoe UI", 8, FontStyle.Strikeout | FontStyle.Bold);
                    row.DefaultCellStyle.ForeColor = Color.Red;
                }
            }
            paneles_22();
        }

        void limpiarNuevoEmbarazo()
        {
            this.txtUltimaRegla.Clear();
            this.txtFechaPlanParto.Clear();

        }
        private string ValidaEmbarazo() {

            if (this.txtUltimaRegla.Text.Trim().Length == 0)
            {
                this.txtUltimaRegla.Focus();
                return "Igrese Fecha Ultimo regla";
            }
            
            else if (EsFecha(this.txtUltimaRegla.Text) == false)
            {
                this.txtUltimaRegla.Focus();
                return "Fecha Ultimo Regla, No valido";
            }
            else if (this.txtFechaPlanParto.Text.Trim().Length == 0)
            {
                this.txtFechaPlanParto.Focus();
                return "Igrese Fecha Probable del Parto";
            }
            else if (EsFecha(txtFechaPlanParto.Text) == false)
            {
                this.txtFechaPlanParto.Focus();
                return "Fecha Probable del Parto, No valido";
            }else if (this.txtGesta.Text.Trim().Length == 0)
            {
                this.txtGesta.Focus();
                return "Ingrese Gestacional";
            }else if (this.txtPariedad.Text.Trim().Length == 0)
            {
                this.txtPariedad.Focus();
                return "Ingrese Pariedad";
            }
            else
            {
                return "";
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {


            if (ValidaEmbarazo() != "")
            {
                MessageBox.Show(ValidaEmbarazo(), "Sistema de Validación", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (DateTime.Parse(this.txtUltimaRegla.Text) >= DateTime.Parse(this.txtFechaPlanParto.Text))
            {
                MessageBox.Show("Fecha Ultima Regla No debe ser mayor a Fecha Probable del Parto", "Sistema Validacion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            DataTable dstultimoEm = objEmbarazo.ultimoEmbarazo();
            int idEmbarazo = 0;
            if (dstultimoEm.Rows.Count > 0)
            {
                idEmbarazo =Convert.ToInt32( dstultimoEm.Rows[0][0].ToString())+1;
            }
            else
            {
                idEmbarazo = 1;
            }

            //objeto de la entidadEmbarazo
            EntidadEmbarazo objEE = new EntidadEmbarazo();
            //envio de datos a entidad embarazo
            objEE.id_embaazo = idEmbarazo;
            objEE.fecha_ultima_regla = DateTime.Parse(txtUltimaRegla.Text);
            objEE.fecha_plan_parto = DateTime.Parse(txtFechaPlanParto.Text);
            objEE.gesta = txtGesta.Text;
            objEE.pariedad = txtPariedad.Text;
            objEE.id_gestante = int.Parse(lblgestante.Name);

            if (esEditarEmbarazo == "SI")
            {
                objEE.id_embaazo = int.Parse(lblIdEmbarazo.Text);

                objEmbarazo.EditarEmbarazo(objEE);
                MessageBox.Show("Embarazo Actualizado con exito", "Datos Actualizado", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                if (DataListado.Rows.Count > 0)
                {
                    for (int i = 0; i < DataListado.Rows.Count; i++)
                    {
                        if (DateTime.Parse(DataListado.Rows[i].Cells[4].Value.ToString()) >= DateTime.Now && DataListado.Rows[i].Cells[8].Value.ToString()=="")
                        {
                            MessageBox.Show("La Gestante actual, Tiene Fecha probable del parto en : " + DataListado.Rows[0].Cells[4].Value.ToString() + "/n Es Imposible que tenga Mas Embarazos una Gestante ", "Sistema de Validacion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            return;
                        }

                    }
                }
                //registro de embarazo 
                objEmbarazo.RegistrarEmbarazo(objEE);
              
                MessageBox.Show("Embarazo Registrado con exito", "Datos Registrado", MessageBoxButtons.OK, MessageBoxIcon.Information);
               
            }
           

            
            limpiarNuevoEmbarazo();//limpiar datos
            //deshabilita panel
            panelAddEmb.Visible = false;
            button1.Enabled = true;
            errorProvider1.Clear();
            //mostrar datos registrado del embarazo
            listarEmbarazoPorGestante();
            esEditarEmbarazo = "";
            HayEmbarazo();
        }

        private void lblgestante_Click(object sender, EventArgs e)
        {

        }

        private void panelAddEmb_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtUltimaRegla_Enter(object sender, EventArgs e)
        {
            this.txtUltimaRegla.BackColor = Color.Yellow;
        }

        private void txtUltimaRegla_Leave(object sender, EventArgs e)
        {
            try
            {
                this.txtUltimaRegla.BackColor = Color.White;

                if (EsFecha(txtUltimaRegla.Text) == false)
                {
                    errorProvider1.SetError(txtUltimaRegla, "Fecha no valida!");
                    txtUltimaRegla.SelectAll();
                    txtUltimaRegla.Focus();
                }
                else if (DateTime.Parse(txtUltimaRegla.Text) > DateTime.Now)
                {
                    errorProvider1.Clear();


                }

                DateTime nuevaFecha = Convert.ToDateTime(this.txtUltimaRegla.Text);

                nuevaFecha = nuevaFecha.AddMonths(9);
                nuevaFecha = nuevaFecha.AddDays(7);

                txtFechaPlanParto.Text = nuevaFecha.ToShortDateString();
                //MessageBox.Show(nuevaFecha.ToString("dd-MM-yyyy"));
            }
            catch (Exception)
            {

               
            }

        }

        private void txtFechaPlanParto_Enter(object sender, EventArgs e)
        {
            this.txtFechaPlanParto.BackColor = Color.Yellow;
        }

        private void txtFechaPlanParto_Leave(object sender, EventArgs e)
        {
            this.txtFechaPlanParto.BackColor = Color.White;
            if (EsFecha(txtFechaPlanParto.Text) == false)
            {
                errorProvider1.SetError(txtFechaPlanParto, "Fecha no valida!");
            }
            else
            {
                errorProvider1.Clear();
            }

            try
            {
                if (DateTime.Parse(this.txtUltimaRegla.Text) >= DateTime.Parse(this.txtFechaPlanParto.Text))
                {
                    this.txtFechaPlanParto.SelectAll();
                    this.txtFechaPlanParto.Focus();
                    MessageBox.Show("Fecha de Ultima de Regla no debe ser mayor o igual a Fecha Probable del Parto", "Sistema de Validacion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
            }
            catch (Exception)
            {


            }
        }


        private void txtUltimaRegla_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.txtUltimaRegla.Text.Trim().Length == 2)
                {
                    this.txtUltimaRegla.Text = this.txtUltimaRegla.Text + "/";
                    this.txtUltimaRegla.Select(txtUltimaRegla.Text.Length, 0);
                }
                else if (this.txtUltimaRegla.Text.Trim().Length == 5)
                {
                    this.txtUltimaRegla.Text = this.txtUltimaRegla.Text + "/";
                    this.txtUltimaRegla.Select(txtUltimaRegla.Text.Length, 0);
                }

                

            }
            catch (Exception)
            {

               
            }
        }

        private void txtFechaPlanParto_TextChanged(object sender, EventArgs e)
        {
            if (this.txtFechaPlanParto.Text.Trim().Length == 2)
            {
                this.txtFechaPlanParto.Text = this.txtFechaPlanParto.Text + "/";
                this.txtFechaPlanParto.Select(txtFechaPlanParto.Text.Length, 0);
            }
            else if (this.txtFechaPlanParto.Text.Trim().Length == 5)
            {
                this.txtFechaPlanParto.Text = this.txtFechaPlanParto.Text + "/";
                this.txtFechaPlanParto.Select(txtFechaPlanParto.Text.Length, 0);
            }

        }



        //AQUI EL CODIGO ES TODO VACUNAS
        //objeto de negociovacuna

        NegocioVacunas objVacuna = new NegocioVacunas();

        void cargarVacuna()
        {
            comboBox2.Items.Clear();
            comboBox2.Items.Add("DT");
            comboBox2.Items.Add("DPTA");
            comboBox2.Items.Add("INFLUENZA");
            comboBox2.Items.Add("COVID19");
        }
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

            }
            catch (Exception)
            {

                throw;
            }
        }

        void limpiarVacuna()
        {
            cargarVacuna();
            comboBox2.Text = "";
            comboBox1.Text = "";
            dateTimePicker1.Value = DateTime.Now;
            comboBox2.Focus();
        }

        void ListarVacuna()
        {
            try
            {
                if (DataListado.Rows.Count == 0)
                {
                    return;
                }
                
                DataTable ListaVacuna = objVacuna.mostrarVacunas(int.Parse(DataListado.CurrentRow.Cells[2].Value.ToString()));
                DataListadoInmunizacion.DataSource = DBNull.Value;
                if (ListaVacuna.Rows.Count > 0)
                {
                  
                    DataListadoInmunizacion.DataSource = ListaVacuna;
                    DataListadoInmunizacion.Columns[0].Visible = false;
                    DataListadoInmunizacion.Columns[1].Width = 430;
                    DataListadoInmunizacion.Columns[2].Width = 230;
                    DataListadoInmunizacion.Columns[3].Width = 230;
                    DataListadoInmunizacion.Columns[4].Visible = false;
                }

                this.DataListadoInmunizacion.EnableHeadersVisualStyles = false;
                DataGridViewCellStyle stiloCabesa = new DataGridViewCellStyle();


                stiloCabesa.BackColor = Color.White;
                stiloCabesa.ForeColor = Color.Black;
                stiloCabesa.Font = new Font("Segoe UI", 10, FontStyle.Regular | FontStyle.Bold);
                this.DataListadoInmunizacion.ColumnHeadersDefaultCellStyle = stiloCabesa;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
              
            }
        }

        void nuevoVacuna()
        {
            comboBox2.Enabled = true;
            comboBox1.Enabled = true;
            dateTimePicker1.Enabled = true;

            btnGuardarInmuni.Enabled = true;
            btnCancelarInmu.Enabled = true;
            btnEditarInmu.Enabled = false;
            btnEliminarInmu.Enabled = false;
            btnNuevoInmunizaciones.Enabled = false;

        }
        void cancelarVacuna()
        {
            comboBox2.Enabled = false;
            comboBox1.Enabled = false;
            dateTimePicker1.Enabled = false;

            btnGuardarInmuni.Enabled = false;
            btnCancelarInmu.Enabled = false;
            btnEditarInmu.Enabled = false;
            btnEliminarInmu.Enabled = false;
            btnNuevoInmunizaciones.Enabled = true;
        }
        private void btnNuevoInmunizaciones_Click(object sender, EventArgs e)
        {
            btnGuardarInmuni.Text = "Guardar";
            nuevoVacuna();
            limpiarVacuna();
        }

        private void btnCancelarInmu_Click(object sender, EventArgs e)
        {
            btnGuardarInmuni.Text = "Guardar";
            cancelarVacuna();
            limpiarVacuna();
            esEditar = "NO";
        }

        string validaVacuna()
        {
            if (comboBox2.Text == "")
            {
                comboBox2.Focus();
                return " Seleccione Nombre de Vacuna";
            } else if ((comboBox2.Text == "DT" || comboBox2.Text == "COVID19") && comboBox1.Text == "")
            {
                comboBox1.Focus();
                return " Seleccione Dosis de la Vacuna";
            } else if (this.dateTimePicker1.Value > DateTime.Now)
            {
                this.dateTimePicker1.Focus();
                return " Fecha de Atencion no debe ser mayor a Fecha Actual";
            }
            else
            {
                return "";
            }

        }
        private void btnGuardarInmuni_Click(object sender, EventArgs e)
        {
            if (DataListadoInmunizacion.Rows.Count > 0)
            {
                for (int i = 0; i < DataListado.Rows.Count - 1; i++)
                {
                    if (DataListadoInmunizacion.Rows[i].Cells[1].Value.ToString() == comboBox2.Text && DataListadoInmunizacion.Rows[i].Cells[2].ToString() == this.comboBox1.Text)
                    {
                        MessageBox.Show("Vacuna ya fue Ingresado, por favor intenta con vacuna o dosis diferente", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }
                }
            }

            if (validaVacuna() != "")
            {
                MessageBox.Show(validaVacuna(), "Sistema de Validacion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }


            try
            {

                EntidadVacunas objV = new EntidadVacunas();

                objV.vacuna = comboBox2.Text;
                objV.num_vacunas = comboBox1.Text;
                objV.fecha = dateTimePicker1.Value;
                objV.id_gestante = int.Parse(lblgestante.Name);
                objV.id_embarazo = int.Parse(DataListado.CurrentRow.Cells[2].Value.ToString());

                string mensaje = "";

                if (this.btnGuardarInmuni.Text == "Guardar")
                {
                    if (comboBox2.Text == "COVID19")
                    {
                        comboBox1.Items.Clear();


                        for (int i = 0; i < DataListadoInmunizacion.Rows.Count; i++)
                        {
                            if (DataListadoInmunizacion.Rows[i].Cells[1].Value.ToString() == this.comboBox2.Text && DataListadoInmunizacion.Rows[i].Cells[2].Value.ToString() == this.comboBox1.Text)
                            {
                                MessageBox.Show(this.comboBox2.Text + " - " + this.comboBox1.Text + " , Ya Existe ", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                return;
                            }

                        }
                    }

                    objVacuna.registrarVacunas(objV);
                    mensaje = "Vacuna Registrado con Exito";
                }
                else
                {

                    //enviar id vacuna seleccionado
                    objV.id_vacuanas = int.Parse(DataListadoInmunizacion.CurrentRow.Cells[0].Value.ToString());

                    objVacuna.editarVacunas(objV);
                    mensaje = "Los Cambios se ha registrado con Exito";
                }


                MessageBox.Show(mensaje, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                limpiarVacuna();
                ListarVacuna();
                cancelarVacuna();
                btnGuardarInmuni.Text = "Guardar";
                esEditar = "NO";
            }
            catch (Exception ex)
            {

                MessageBox.Show("Ocurrio erro al registrar vacuna " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DataListadoInmunizacion_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                cancelarVacuna();
                limpiarVacuna();
                btnGuardarInmuni.Text = "Guardar";
                esEditar = "NO";
            }
            catch (Exception)
            {


            }
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void DataListadoInmunizacion_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnEditarInmu_Click(object sender, EventArgs e)
        {
            nuevoVacuna();
            comboBox1.Enabled = false;
            comboBox2.Enabled = false;
            btnGuardarInmuni.Text = "Guardar Cambios";
            esEditar = "SI";
        }

        private void DataListadoInmunizacion_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }


        private void DataListadoInmunizacion_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                this.comboBox2.Text = DataListadoInmunizacion.CurrentRow.Cells[1].Value.ToString();
                this.comboBox1.Text = DataListadoInmunizacion.CurrentRow.Cells[2].Value.ToString();
                this.dateTimePicker1.Value = DateTime.Parse(DataListadoInmunizacion.CurrentRow.Cells[3].Value.ToString());

                btnEditarInmu.Enabled = true;
                btnCancelarInmu.Enabled = true;
                btnEliminarInmu.Enabled = true;
                btnGuardarInmuni.Enabled = false;
                btnNuevoInmunizaciones.Enabled = false;

                this.comboBox1.Enabled = false;
                this.comboBox2.Enabled = false;
                this.dateTimePicker1.Enabled = false;

                esEditar = "SI";
            }
            catch (Exception)
            {


            }
        }

        string esEditar = "";
        List<string> misDosisVacuna;
        private void comboBox2_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                misDosisVacuna = new List<string>();

                if (comboBox2.Text == "DT")
                {
                    comboBox1.Items.Clear();
                    comboBox1.Enabled = true;
                    comboBox1.Items.Add("1");
                    comboBox1.Items.Add("2");
                    comboBox1.Items.Add("3");
                }
                else if (comboBox2.Text == "DPTA")
                {
                    comboBox1.Items.Clear();
                    comboBox1.Items.Add("Dosis Unica");
                    comboBox1.SelectedIndex = 1;
                    comboBox1.Enabled = false;
                }
                else if (comboBox2.Text == "INFLUENZA")
                {
                    comboBox1.Items.Clear();
                    comboBox1.Items.Add("Dosis Unica");
                    comboBox1.SelectedIndex = 1;
                    comboBox1.Enabled = false;
                }

                if (esEditar == "SI")
                {
                    return;
                }
                else if (comboBox2.Text == "COVID19")
                {
                    comboBox1.Items.Clear();
                    //verificar que dosis tiene
                    string cov1 = "";
                    string cov2 = "";
                    string cov3 = "";
                    string cov4 = "";

                    for (int i = 0; i < DataListadoInmunizacion.Rows.Count; i++)
                    {
                        if (DataListadoInmunizacion.Rows[i].Cells[1].Value.ToString() == "COVID19" && DataListadoInmunizacion.Rows[i].Cells[2].Value.ToString() == "1 Dosis"){ cov1 = "Existe";}
                        else if (DataListadoInmunizacion.Rows[i].Cells[1].Value.ToString() == "COVID19" && DataListadoInmunizacion.Rows[i].Cells[2].Value.ToString() == "2 Dosis"){cov2 = "Existe";}
                        else if (DataListadoInmunizacion.Rows[i].Cells[1].Value.ToString() == "COVID19" && DataListadoInmunizacion.Rows[i].Cells[2].Value.ToString() == "3 Dosis"){cov3 = "Existe";}
                        else if (DataListadoInmunizacion.Rows[i].Cells[1].Value.ToString() == "COVID19" && DataListadoInmunizacion.Rows[i].Cells[2].Value.ToString() == "4 Dosis"){cov4 = "Existe";}
                    }

                    
                    misDosisVacuna.Clear();

                    if (cov1 == "") { misDosisVacuna.Add("1"); }
                    if (cov2 == "") { misDosisVacuna.Add("2"); }
                    if (cov3 == "") { misDosisVacuna.Add("3"); }
                    if (cov4 == "") { misDosisVacuna.Add("4"); }

                    foreach (string item in misDosisVacuna)
                    {
                        comboBox1.Items.Add(item);
                    }
                    comboBox1.Enabled = true;


                }
            }
            catch (Exception)
            {


            }
        }

        private void comboBox1_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {

            }
            catch (Exception)
            {


            }
        }

        private void btnEliminarInmu_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Estas seguro que quiere eliminar Vacuan?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                EntidadVacunas objVac = new EntidadVacunas();
                objVac.id_vacuanas = Convert.ToInt32(DataListadoInmunizacion.CurrentRow.Cells[0].Value.ToString());
                objVac.id_gestante = Convert.ToInt32(lblgestante.Name);

                objVacuna.eliminarVacunas(objVac);

                MessageBox.Show("Vacuna se ha Eliminaco con exito", "Elimino", MessageBoxButtons.OK, MessageBoxIcon.Error);
                limpiarVacuna();
                cancelarVacuna();
                ListarVacuna();
                btnGuardarInmuni.Text = "Guardar";
                esEditar = "NO";
            }


        }

        //TODO CONTROLES

        NegocioControles objControles = new NegocioControles();


        void mostrarControlesAData()
        {
            try
            {
                if (DataListado.Rows.Count > 0 && DataListado.SelectedRows.Count>0)
                {

                    DataTable dataControl = objControles.mostrarSuplementacion(int.Parse(DataListado.CurrentRow.Cells[2].Value.ToString()));
                    DataListadoControles.DataSource = dataControl;

                    //ocultar columna
                    DataListadoControles.Columns[0].Visible = false;
                    DataListadoControles.Columns[4].Visible = false;

                    //aplicar ancho de columnas
                    DataListadoControles.Columns[1].Width = 450;
                    DataListadoControles.Columns[2].Width = 250;
                    DataListadoControles.Columns[3].Width = 200;

                    this.DataListadoControles.EnableHeadersVisualStyles = false;

                    //estilo de cabecera
                    DataGridViewCellStyle stiloCabesa = new DataGridViewCellStyle();
                    stiloCabesa.BackColor = Color.White;
                    stiloCabesa.ForeColor = Color.Black;
                    stiloCabesa.Font = new Font("Segoe UI", 10, FontStyle.Regular | FontStyle.Bold);
                    this.DataListadoControles.ColumnHeadersDefaultCellStyle = stiloCabesa;
                }
                
            }
            catch (Exception)
            {

              
            }
        }

        List<string> misControles;
        void llenarControles()
        {

            string control1 = "";
            string control2 = "";
            string control3 = "";
            string control4 = "";
            string control5 = "";
            string control6 = "";
            string control7 = "";
            string control8 = "";
            string control9 = "";
            string control10 = "";
            string control11 = "";
            string control12 = "";
            string control13 = "";

            misControles = new List<string>();

            if (esEditarControl == "")
            {

                for (int i = 0; i < DataListadoControles.Rows.Count; i++)
                {
                    if (DataListadoControles.Rows[i].Cells[1].Value.ToString() == "1RA"){control1 = "SI";}
                    if (DataListadoControles.Rows[i].Cells[1].Value.ToString() == "2DA"){control2 = "SI";}
                    if (DataListadoControles.Rows[i].Cells[1].Value.ToString() == "3RA"){control3 = "SI";}
                    if (DataListadoControles.Rows[i].Cells[1].Value.ToString() == "4TA"){control4 = "SI";}
                    if (DataListadoControles.Rows[i].Cells[1].Value.ToString() == "5TA"){control5= "SI";}
                    if (DataListadoControles.Rows[i].Cells[1].Value.ToString() == "6TA"){control6 = "SI";}
                    if (DataListadoControles.Rows[i].Cells[1].Value.ToString() == "7MA"){control7 = "SI";}
                    if (DataListadoControles.Rows[i].Cells[1].Value.ToString() == "8VA"){control8 = "SI";}
                    if (DataListadoControles.Rows[i].Cells[1].Value.ToString() == "9NA"){control9 = "SI";}
                    if (DataListadoControles.Rows[i].Cells[1].Value.ToString() == "10MA"){control10 = "SI";}
                    if (DataListadoControles.Rows[i].Cells[1].Value.ToString() == "11RA"){control11 = "SI";}
                    if (DataListadoControles.Rows[i].Cells[1].Value.ToString() == "12DA"){control12 = "SI";}
                    if (DataListadoControles.Rows[i].Cells[1].Value.ToString() == "13RA"){control13 = "SI";}
                }

                misControles.Clear();
                cmbNumeroControl.Items.Clear();

                if (control1 == "") { misControles.Add("1RA"); }
                if (control2 == "") { misControles.Add("2DA"); }
                if (control3 == "") { misControles.Add("3RA"); }
                if (control4 == "") { misControles.Add("4TA"); }
                if (control5 == "") { misControles.Add("5TA"); }
                if (control6 == "") { misControles.Add("6TA"); }
                if (control7 == "") { misControles.Add("7MA"); }
                if (control8 == "") { misControles.Add("8VA"); }
                if (control9 == "") { misControles.Add("9NA"); }
                if (control10 == "") { misControles.Add("10MA"); }
                if (control11 == "") { misControles.Add("11RA"); }
                if (control12 == "") { misControles.Add("12DA"); }
                if (control13 == "") { misControles.Add("13RA"); }

                foreach (string contrl in misControles)
                {
                    cmbNumeroControl.Items.Add(contrl);
                }

            }
            else
            {
                misControles.Clear();
                cmbNumeroControl.Items.Clear();

                misControles.Add("1RA");
                misControles.Add("2DA"); 
                misControles.Add("3RA"); 
                misControles.Add("4TA"); 
                misControles.Add("5TA"); 
                misControles.Add("6TA"); 
                misControles.Add("7MA"); 
                misControles.Add("8VA"); 
                misControles.Add("9NA"); 
                misControles.Add("10MA"); 
                misControles.Add("11RA"); 
                misControles.Add("12DA"); 
                misControles.Add("13RA");

                foreach (string contrl in misControles)
                {
                    cmbNumeroControl.Items.Add(contrl);
                }
            }

        }
        void habilitarControles()
        {
            this.cmbNumeroControl.Enabled = true;
            this.dtpFechaControl.Enabled = true;
            this.tctEdadGesControl.Enabled = true;
            cmbNumeroControl.Focus();
        }
        void DeshabilitarControles()
        {
            this.cmbNumeroControl.Enabled = false;
            this.dtpFechaControl.Enabled = false;
            this.tctEdadGesControl.Enabled = false;

        }
        void limpiarControles()
        {
            this.cmbNumeroControl.Text = "";
            this.dtpFechaControl.Value = DateTime.Now;
            this.tctEdadGesControl.Clear();
            cmbNumeroControl.Focus();
        }

        void cancelarControl()
        {
            btnGuardarControl.Enabled = false;
            btnEditarControl.Enabled = false;
            btnEliminarControl.Enabled = false;
            btnCancelarControl.Enabled = false;
            btnNuevoControl.Enabled = true;
            limpiarControles();
            llenarControles();
            DeshabilitarControles();
        }
        void nuevoControl()
        {
            btnGuardarControl.Enabled = true;
            btnEditarControl.Enabled = false;
            btnEliminarControl.Enabled = false;
            btnCancelarControl.Enabled = true;
            btnNuevoControl.Enabled = false;
            limpiarControles();

            habilitarControles();
        }
        private void btnNuevoControl_Click(object sender, EventArgs e)
        {
            nuevoControl();
            esEditarControl = "";
            llenarControles();
        }

        private void tabControl1_Selected(object sender, TabControlEventArgs e)
        {
            if (tabControl1.SelectedTab.Text == "Controles")
            {
                tabControl1.SelectedTab.UseVisualStyleBackColor = true;
                //llenarControles();
                mostrarControlesAData();
            }
            if (tabControl1.SelectedTab.Text == "Suplementacion")
            {
                mostraraAcidoFolico();
                mostrarSulfatoFerroso();
                MostrarCalcio();
            }
            if (tabControl1.SelectedTab.Text == "Inmunizaciones")
            {

            }
            if (tabControl1.SelectedTab.Text == "Examenes")
            {
                mostrarExamenes();
            }
            if (tabControl1.SelectedTab.Text == "Suplementacion")
            {
                mostrarSulfatoFerroso();
                mostraraAcidoFolico();
            }
            if (tabControl1.SelectedTab.Text == "Ecografia")
            {
                mostrarEcografia();
            }
            if (tabControl1.SelectedTab.Text == "Actividad")
            {
                Mostrar_actividad();
            }
            if(tabControl1.SelectedTab.Text == "CULMINACIÓN DEL EMBARAZO")
            {
                mostrar_culminacion_Gestante();
                MostrarPlanificacionFamiliar();
            }if(tabControl1.SelectedTab.Text == "DATOS ADICIONAL")
            {
                MostrarDatosAdcional();
            }
        }

        private void btnCancelarControl_Click(object sender, EventArgs e)
        {
            cancelarControl();
            esEditarControl = "";
            limpiarControles();
        }

        string validaControles()
        {
            if (cmbNumeroControl.Text == "")
            {
                this.cmbNumeroControl.Focus();
                return "Seleccione Numero Control ";
            } else if (this.dtpFechaControl.Value > DateTime.Now)
            {
                this.dtpFechaControl.Focus();
                return "Fecha No debe Ser Mayor a Fecha Actual ";
            }
            else if (this.tctEdadGesControl.Text.Trim().Length == 0)
            {
                this.tctEdadGesControl.Focus();
                return "Ingrese Edad Gestacional ";
            }
            else
            {
                return "";
            }
        }

        string esEditarControl = "";
        private void btnGuardarControl_Click(object sender, EventArgs e)
        {
            if (validaControles() != "")
            {
                MessageBox.Show(validaControles(), "Sistema de validacion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }



            EntidadControles objCon = new EntidadControles();

            objCon.num_control = cmbNumeroControl.Text;
            objCon.id_embarazo = int.Parse(DataListado.CurrentRow.Cells[2].Value.ToString());
            objCon.fecha_control = dtpFechaControl.Value;
            objCon.edad_ges = tctEdadGesControl.Text;

            if (esEditarControl == "")
            {
                for (int i = 0; i < DataListadoControles.Rows.Count; i++)
                {
                    if (this.DataListadoControles.Rows[i].Cells[1].Value.ToString() == this.cmbNumeroControl.Text)
                    {
                        MessageBox.Show("Control ya existe", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }
                }
                objControles.registrarControles(objCon);
                MessageBox.Show("Control Registrado con Exito", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                objCon.id_control = int.Parse(DataListadoControles.CurrentRow.Cells[0].Value.ToString());

                objControles.EditarControles(objCon);
                MessageBox.Show("Control Actualizado con Exito", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }


            mostrarControlesAData();
            esEditarControl = "";
            cancelarControl();
            limpiarControles();
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            mostrarControlesAData();
        }

        private void btnEditarControl_Click(object sender, EventArgs e)
        {
            esEditarControl = "Si";
            btnGuardarControl.Enabled = true;
            btnEditarControl.Enabled = false;
            btnEliminarControl.Enabled = false;
            btnCancelarControl.Enabled = true;
            btnNuevoControl.Enabled = false;
            cmbNumeroControl.Enabled = false;
            dtpFechaControl.Enabled = true;
            tctEdadGesControl.Enabled = true;

        }

        private void DataListadoControles_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                esEditarControl = "SI";

                cmbNumeroControl.Items.Clear();
                cmbNumeroControl.Items.Add("1RA");
                cmbNumeroControl.Items.Add("2DA");
                cmbNumeroControl.Items.Add("3RA");
                cmbNumeroControl.Items.Add("4TA");
                cmbNumeroControl.Items.Add("5TA");
                cmbNumeroControl.Items.Add("6TA");
                cmbNumeroControl.Items.Add("7MA");
                cmbNumeroControl.Items.Add("8VA");
                cmbNumeroControl.Items.Add("9NA");
                cmbNumeroControl.Items.Add("10MA");
                cmbNumeroControl.Items.Add("11RA");
                cmbNumeroControl.Items.Add("12DA");
                cmbNumeroControl.Items.Add("13RA");


                this.cmbNumeroControl.Text = DataListadoControles.CurrentRow.Cells[1].Value.ToString();
                this.dtpFechaControl.Value = DateTime.Parse(DataListadoControles.CurrentRow.Cells[2].Value.ToString());
                this.tctEdadGesControl.Text = DataListadoControles.CurrentRow.Cells[3].Value.ToString();
                esEditarControl = "";
                btnNuevoControl.Enabled = false;
                btnGuardarControl.Enabled = false;
                btnEliminarControl.Enabled = true;
                btnEditarControl.Enabled = true;
                btnCancelarControl.Enabled = true;

            }
            catch (Exception)
            {


            }
        }

        private void DataListadoControles_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            esEditarControl = "";
            btnGuardarControl.Text = "Guardar";
            cancelarControl();
            DeshabilitarControles();
        }

        private void cmbNumeroControl_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnEliminarControl_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult res = MessageBox.Show("¿Estas seguro que quiere eliminar el Control?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (res == DialogResult.Yes)
                {
                    EntidadControles objCo = new EntidadControles();
                    objCo.id_control = Convert.ToInt32(DataListadoControles.CurrentRow.Cells[0].Value.ToString());
                    objCo.id_embarazo = Convert.ToInt32(DataListado.CurrentRow.Cells[2].Value.ToString());

                    objControles.EliminarControles(objCo);
                    MessageBox.Show("Control ha sido eliminado con exito", "Eliminado", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    limpiarControles();
                    mostrarControlesAData();
                    cancelarControl();
                    DeshabilitarControles();
                    btnGuardarControl.Text = "Guardar";
                    esEditar = "";
                }
            }
            catch (Exception)
            {

                MessageBox.Show("Ocurrio un error al aliminar Control", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //Todo Suplementacin
        //Mantenimiento de Acido Folico

        NegocioSuplementacion objSuplemento = new NegocioSuplementacion();

        void mostraraAcidoFolico()
        {
            try
            {
                if (DataListado.Rows.Count > 0 && DataListado.SelectedRows.Count > 0)
                {
                    int idEm = int.Parse(DataListado.CurrentRow.Cells[2].Value.ToString());
                    string tipoSup = "ACIDO FOLICO";
                    DataTable dataAcidoFolico = objSuplemento.mostrarSuplementacion(idEm, tipoSup);

                    DataListadoAcidoFolico.DataSource = dataAcidoFolico;

                    DataListadoAcidoFolico.Columns[0].Visible = false;
                    DataListadoAcidoFolico.Columns[1].Width = 400;
                    DataListadoAcidoFolico.Columns[2].Width = 300;
                    DataListadoAcidoFolico.Columns[3].Width = 200;
                    DataListadoAcidoFolico.Columns[4].Visible = false;

                    this.DataListadoAcidoFolico.EnableHeadersVisualStyles = false;

                    //estilo de cabecera
                    DataGridViewCellStyle stiloCabesa = new DataGridViewCellStyle();
                    stiloCabesa.BackColor = Color.White;
                    stiloCabesa.ForeColor = Color.Black;
                    stiloCabesa.Font = new Font("Segoe UI", 10, FontStyle.Regular | FontStyle.Bold);
                    this.DataListadoAcidoFolico.ColumnHeadersDefaultCellStyle = stiloCabesa;
                }
            }
            catch (Exception)
            {

                
            }
        }
        void llenarAcidoFolico()
        {
            string acidoFo1 = "";
            string acidoFo2 = "";

            for (int i = 0; i < DataListadoAcidoFolico.Rows.Count; i++)
            {
                if (DataListadoAcidoFolico.Rows[i].Cells[2].Value.ToString() == "1")
                {
                    acidoFo1 = "SI";
                } else if (DataListadoAcidoFolico.Rows[i].Cells[2].Value.ToString() == "2")
                {
                    acidoFo2 = "SI";
                }
            }
            if (acidoFo1 == "SI" && acidoFo2 == "SI")
            {
                this.cmbAcidoFolico.Items.Clear();
               
            }
            else if (acidoFo1=="SI")
            {
                this.cmbAcidoFolico.Items.Clear();
                this.cmbAcidoFolico.Items.Add("2");
            }
            else if (acidoFo2 == "SI")
            {
                this.cmbAcidoFolico.Items.Clear();
                this.cmbAcidoFolico.Items.Add("1");
            }
            else
            {
                this.cmbAcidoFolico.Items.Clear();
                this.cmbAcidoFolico.Items.Add("1");
                this.cmbAcidoFolico.Items.Add("2");
            }
        }
        void nuevoAcidoFolico()
        {
            cmbAcidoFolico.Items.Clear();
            dtpFechaAtencionAcidoFolico.Value = DateTime.Now;

            btnNuevoAcidoFolico.Enabled = false;
            btnCancelarAcidoFolico.Enabled = true;
            btnGuardarAcidoFolico.Enabled = true;
            btnEditarAcidoFolico.Enabled = false;
            btnEliminarAcidoFolico.Enabled = false;
        }
        void CancelarAcidoFolico()
        {
            cmbAcidoFolico.Items.Clear();
            dtpFechaAtencionAcidoFolico.Value = DateTime.Now;

            btnNuevoAcidoFolico.Enabled = true;
            btnCancelarAcidoFolico.Enabled = false;
            btnGuardarAcidoFolico.Enabled = false;
            btnEditarAcidoFolico.Enabled = false;
            btnEliminarAcidoFolico.Enabled = false;
        }


        void habilitarAcidoFolico()
        {
            cmbAcidoFolico.Enabled = true;
            dtpFechaAtencionAcidoFolico.Enabled = true;
        }

        void deshabilitarAcidoFolico()
        {
            cmbAcidoFolico.Enabled = false;
            dtpFechaAtencionAcidoFolico.Enabled = false;
        }

        void limpiarSuplementacion()
        {
            cmbAcidoFolico.Items.Clear();
            dtpFechaAtencionAcidoFolico.Value = DateTime.Now;
            cmbAcidoFolico.Focus();
        }
        string validaAcidoFolico()
        {
            if (cmbAcidoFolico.Text == "")
            {
                this.cmbAcidoFolico.Focus();
                return "Seleccione ACIDO FOLICO";
            } else if (dtpFechaAtencionAcidoFolico.Value > DateTime.Now)
            {
                this.dtpFechaAtencionAcidoFolico.Focus();
                return "Fecha no valida, Fecha Atencion no debe ser mayor a la Fecha Actual";
            }
            else
            {
                return "";
            }
        }
        private void btnNuevoAcidoFolico_Click(object sender, EventArgs e)
        {

            limpiarSuplementacion();
            habilitarAcidoFolico();
            nuevoAcidoFolico();
            llenarAcidoFolico();
        }

        string esEditarAcidoFolico = "";
        private void btnGuardarAcidoFolico_Click(object sender, EventArgs e)
        {
            if (validaAcidoFolico() != "")
            {
                MessageBox.Show(validaAcidoFolico(), " Sistema de Validacion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            EntidadSuplementacion objSuple = new EntidadSuplementacion();

            objSuple.suplementacion = "ACIDO FOLICO";
            objSuple.num_suplementacion = cmbAcidoFolico.Text;
            objSuple.fecha_suplementacion = dtpFechaAtencionAcidoFolico.Value;
            objSuple.id_embarazo = int.Parse(DataListado.CurrentRow.Cells[2].Value.ToString());

            if (esEditarAcidoFolico == "")
            {
                objSuplemento.registrarSuplementacion(objSuple);
                MessageBox.Show("Suplementacion de Acido Folico se ha Registrado con Exito", "Registro de Suplementacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                objSuple.id_suplementacion = int.Parse(DataListadoAcidoFolico.CurrentRow.Cells[0].Value.ToString());
                objSuplemento.EditarSuplementacion(objSuple);
                MessageBox.Show("Suplementacion de Acido Folico se ha Actualizado con Exito", "Suplementacion", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }

            CancelarAcidoFolico();
            btnGuardarAcidoFolico.Text = "Guardar";
            esEditarAcidoFolico = "";
            deshabilitarAcidoFolico();
            mostraraAcidoFolico();
        }

        private void tabControl2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl2.SelectedTab.Text == "Acido Folico")
            {
                mostraraAcidoFolico();
            }
            if (tabControl2.SelectedTab.Text == "Sulfato Ferroso")
            {
                //mostrar solo sulfato ferroso
            }
        }

        private void DataListadoAcidoFolico_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {

        }

        private void btnEditarAcidoFolico_Click(object sender, EventArgs e)
        {
            cmbAcidoFolico.Enabled = false;
            dtpFechaAtencionAcidoFolico.Enabled = true;
            esEditarAcidoFolico = "SI";
            btnEditarAcidoFolico.Enabled = false;
            btnEliminarAcidoFolico.Enabled = false;
            btnCancelarAcidoFolico.Enabled = true;
            btnNuevoAcidoFolico.Enabled = false;
            btnGuardarAcidoFolico.Enabled = true;
        }

        private void DataListadoAcidoFolico_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void DataListadoAcidoFolico_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                CancelarAcidoFolico();
                limpiarSuplementacion();
                deshabilitarAcidoFolico();
            }
            catch (Exception)
            {


            }
        }

        private void btnCancelarAcidoFolico_Click(object sender, EventArgs e)
        {
            CancelarAcidoFolico();
            limpiarSuplementacion();
            deshabilitarAcidoFolico();
           
        }

        private void btnEliminarAcidoFolico_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult opcion = MessageBox.Show("¿Estas seguro que quiere eliminar?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (opcion == DialogResult.Yes)
                {
                    //eliminar
                    EntidadSuplementacion objSup = new EntidadSuplementacion();
                    objSup.id_suplementacion = Convert.ToInt32(DataListadoAcidoFolico.CurrentRow.Cells[0].Value.ToString());
                    objSup.id_embarazo = Convert.ToInt32(DataListado.CurrentRow.Cells[2].Value.ToString());

                    objSuplemento.EliminarSuplementacion(objSup);
                    MessageBox.Show("Suplementacion de Acido Folico se ha eliminado con exito", "Eliminado", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    CancelarAcidoFolico();
                    mostraraAcidoFolico();
                    limpiarSuplementacion();
                    deshabilitarAcidoFolico();
                    btnGuardarAcidoFolico.Text = "Guardar";
                    esEditarAcidoFolico = "";
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Ocurrio un error al eliminar", "Error de eliminacion", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void DataListadoAcidoFolico_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void DataListadoAcidoFolico_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                cmbAcidoFolico.Items.Add(this.DataListadoAcidoFolico.CurrentRow.Cells[2].Value.ToString());
                cmbAcidoFolico.Text = this.DataListadoAcidoFolico.CurrentRow.Cells[2].Value.ToString();
                dtpFechaAtencionAcidoFolico.Value = DateTime.Parse(this.DataListadoAcidoFolico.CurrentRow.Cells[3].Value.ToString());
                btnNuevoAcidoFolico.Enabled = false;

                btnEditarAcidoFolico.Enabled = true;
                btnEliminarAcidoFolico.Enabled = true;
                btnCancelarAcidoFolico.Enabled = true;
                btnGuardarAcidoFolico.Enabled = false;

            }
            catch (Exception)
            {


            }
        }

        string esEditarEmbarazo = "";
        
        void paneles_22()
        {
            string estadoEmbarazo = "";
           if (this.DataListado.Rows.Count > 0)
            {
                estadoEmbarazo= this.DataListado.CurrentRow.Cells[8].Value.ToString();

            }

            //jugando con mascara, 
            if (estadoEmbarazo == "ABORTO" || estadoEmbarazo == "PARTO")
            {
                //cerrando paneles
                TapaActividades.Visible = false;
                TapaAdicional.Visible = false;
                TapaControl.Visible = false;
                TapaEcografia.Visible = false;
                TapaEmbarazo.Visible = false;
                TapaExamenes.Visible = false;
                TapaSuplemento.Visible = false;

                //1    atenciones
                pbAtencion.Visible = true;
                pbAtencion.Image = Properties.Resources.counting;
                lblMensajeAtencion.Visible = true;
                lblMensajeAtencion.Text = "Seleccione una Embarazo Para Iniciar...!";
                btnVerAtencion.Visible = false;
                //2    suplementacion
                pbSuplementacion.Visible = true;
                pbSuplementacion.Image = Properties.Resources.counting;
                lblMensajeSuplementacion.Visible = true;
                lblMensajeSuplementacion.Text = "Seleccione una Embarazo Para Iniciar...!";
                btnVerSuplementacion.Visible = false;
                //3    examen
                pbExamen.Visible = true;
                pbExamen.Image = Properties.Resources.counting;
                lblMensajeExamen.Visible = true;
                lblMensajeExamen.Text = "Seleccione una Embarazo Para Iniciar...!";
                btnVerExamen.Visible = false;
                //4    ecografia
                pbEcografia.Visible = true;
                pbEcografia.Image = Properties.Resources.counting;
                lblMensajeEcografia.Visible = true;
                lblMensajeEcografia.Text = "Seleccione una Embarazo Para Iniciar...!";
                btnVerEcografia.Visible = false;
                //5    actividades
                pbActividad.Visible = true;
                pbActividad.Image = Properties.Resources.counting;
                lblMensajeActividad.Visible = true;
                lblMensajeActividad.Text = "Seleccione una Embarazo Para Iniciar...!";
                btnVerActividad.Visible = false;
                //6    Culminacion embarazo
                pbCulminacion.Visible = true;
                pbCulminacion.Image = Properties.Resources.counting;
                lblmensajeCulminacion.Visible = true;
                lblmensajeCulminacion.Text = "Seleccione una Embarazo Para Iniciar...!";
                btnVerCulminacion.Visible = false;
                //se activaran cuando finalize la gestantacio
                // 7   Atencion del puerperio
                TapaPuerpera.Visible = false;
                pbAtencionPuerpera.Visible = true;
                pbAtencionPuerpera.Image = Properties.Resources.out_of_stock;
                lblmensajeAtencionPuerpera.Visible = true;
                lblmensajeAtencionPuerpera.Text = "No Disponible, Falta Culminar Embarazo";
                btnVerPuerpera.Visible = false;
                // 8   Atencion del puerperio
                TapaPlani.Visible = false;
                pbPlanificacion.Visible = true;
                pbPlanificacion.Image = Properties.Resources.out_of_stock;
                lblMensajePlanificacion.Visible = true;
                lblMensajePlanificacion.Text = "No Disponible, Falta Culminar Embarazo";
                btnVerPlanificacion.Visible = false;
                // 9   Atencion del puerperio
                pbAdional.Visible = true;
                pbAdional.Image = Properties.Resources.counting;
                lblMensajeAdicional.Visible = true;
                lblMensajeAdicional.Text = "Seleccione una Embarazo Para Iniciar...!";
                btnVerAdicional.Visible = false;

            }
            else if (estadoEmbarazo == "CULMINADO")
            {
                //activando paneles
                TapaActividades.Visible = false;
                TapaAdicional.Visible = false;
                TapaControl.Visible = false;
                TapaEcografia.Visible = false;
                TapaEmbarazo.Visible = false;
                TapaExamenes.Visible = false;
                TapaSuplemento.Visible = false;

                //habilitando botones y agregar fotos + cambiar mensaje
                //1    atenciones
                pbAtencion.Visible = true;
                pbAtencion.Image = Properties.Resources.like;
                lblMensajeAtencion.Visible = true;
                lblMensajeAtencion.Text = "ACTIVIDAD FINALIZADA";
                btnVerAtencion.Visible = true;
                //2    suplementacion
                pbSuplementacion.Visible = true;
                pbSuplementacion.Image = Properties.Resources.like;
                lblMensajeSuplementacion.Visible = true;
                lblMensajeSuplementacion.Text = "ACTIVIDAD FINALIZADA";
                btnVerSuplementacion.Visible = true;
                //3    examen
                pbExamen.Visible = true;
                pbExamen.Image = Properties.Resources.like;
                lblMensajeExamen.Visible = true;
                lblMensajeExamen.Text = "ACTIVIDAD FINALIZADA";
                btnVerExamen.Visible = true;
                //4    ecografia
                pbEcografia.Visible = true;
                pbEcografia.Image = Properties.Resources.like;
                lblMensajeEcografia.Visible = true;
                lblMensajeEcografia.Text = "ACTIVIDAD FINALIZADA";
                btnVerEcografia.Visible = true;
                //5    actividades
                pbActividad.Visible = true;
                pbActividad.Image = Properties.Resources.like;
                lblMensajeActividad.Visible = true;
                lblMensajeActividad.Text = "ACTIVIDAD FINALIZADA";
                btnVerActividad.Visible = true;
                //6    Culminacion embarazo
                pbCulminacion.Visible = true;
                pbCulminacion.Image = Properties.Resources.like;
                lblmensajeCulminacion.Visible = true;
                lblmensajeCulminacion.Text = "ACTIVIDAD FINALIZADA";
                btnVerCulminacion.Visible = true;
                //se activaran cuando finalize la gestantacio
                // 7   Atencion del puerperio
                TapaPuerpera.Visible = false;
                pbAtencionPuerpera.Visible = true;
                pbAtencionPuerpera.Image = Properties.Resources.out_of_stock;
                lblmensajeAtencionPuerpera.Visible = true;
                lblmensajeAtencionPuerpera.Text = "Seleccione una Embarazo Para Iniciar...!";
                btnVerPuerpera.Visible = true;
                // 8   Atencion del puerperio
                TapaPlani.Visible = false;
                pbPlanificacion.Visible = true;
                pbPlanificacion.Image = Properties.Resources.out_of_stock;
                lblMensajePlanificacion.Visible = true;
                lblMensajePlanificacion.Text = "Seleccione una Embarazo Para Iniciar...!";
                btnVerPlanificacion.Visible = false;
                // 9   Atencion del puerperio
                pbAdional.Visible = true;
                pbAdional.Image = Properties.Resources.like;
                lblMensajeAdicional.Visible = true;
                lblMensajeAdicional.Text = "ACTIVIDAD FINALIZADA";
                btnVerAdicional.Visible = true;

            }
            else if(DataListado.SelectedRows.Count==0)
            {
                //cerrando paneles
                TapaActividades.Visible = false;
                TapaAdicional.Visible = false;
                TapaControl.Visible = false;
                TapaEcografia.Visible = false;
                TapaEmbarazo.Visible = false;
                TapaExamenes.Visible = false;
                TapaSuplemento.Visible = false;

                //1    atenciones
                pbAtencion.Visible = true;
                pbAtencion.Image = Properties.Resources.counting;
                lblMensajeAtencion.Visible = true;
                lblMensajeAtencion.Text = "Seleccione una Embarazo Para Iniciar...!";
                btnVerAtencion.Visible = false;
                //2    suplementacion
                pbSuplementacion.Visible = true;
                pbSuplementacion.Image = Properties.Resources.counting;
                lblMensajeSuplementacion.Visible = true;
                lblMensajeSuplementacion.Text = "Seleccione una Embarazo Para Iniciar...!";
                btnVerSuplementacion.Visible = false;
                //3    examen
                pbExamen.Visible = true;
                pbExamen.Image = Properties.Resources.counting;
                lblMensajeExamen.Visible = true;
                lblMensajeExamen.Text = "Seleccione una Embarazo Para Iniciar...!";
                btnVerExamen.Visible = false;
                //4    ecografia
                pbEcografia.Visible = true;
                pbEcografia.Image = Properties.Resources.counting;
                lblMensajeEcografia.Visible = true;
                lblMensajeEcografia.Text = "Seleccione una Embarazo Para Iniciar...!";
                btnVerEcografia.Visible = false;
                //5    actividades
                pbActividad.Visible = true;
                pbActividad.Image = Properties.Resources.counting;
                lblMensajeActividad.Visible = true;
                lblMensajeActividad.Text = "Seleccione una Embarazo Para Iniciar...!";
                btnVerActividad.Visible = false;
                //6    Culminacion embarazo
                pbCulminacion.Visible = true;
                pbCulminacion.Image = Properties.Resources.counting;
                lblmensajeCulminacion.Visible = true;
                lblmensajeCulminacion.Text = "Seleccione una Embarazo Para Iniciar...!";
                btnVerCulminacion.Visible = false;

                //se activaran cuando finalize la gestantacion
                // 7   Atencion del puerperio

                TapaPuerpera.Visible = true;
                pbAtencionPuerpera.Visible = true;
                pbAtencionPuerpera.Image = Properties.Resources.out_of_stock;
                lblmensajeAtencionPuerpera.Visible = true;
                lblmensajeAtencionPuerpera.Text = "No Disponible, Falta Culminar Embarazo";
                btnVerPuerpera.Visible = false;
                // 8   Atencion del puerperio
                TapaPlani.Visible = true;
                pbPlanificacion.Visible = true;
                pbPlanificacion.Image = Properties.Resources.out_of_stock;
                lblMensajePlanificacion.Visible = true;
                lblMensajePlanificacion.Text = "No Disponible, Falta Culminar Embarazo";
                btnVerPlanificacion.Visible = false;
                // 9   Planificacion Familiar
              
                pbAdional.Visible = true;
                pbAdional.Image = Properties.Resources.out_of_stock;
                lblMensajeAdicional.Visible = true;
                lblMensajeAdicional.Text = "Seleccione una Embarazo Para Iniciar...!";
                btnVerAdicional.Visible = false;

            }

        }

        private void DataListado_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                mostraraAcidoFolico();
                mostrarControlesAData();
                ListarVacuna();
                mostrarExamenes();
                mostrarSulfatoFerroso();
                mostrarEcografia();
                Mostrar_actividad();
                mostrar_culminacion_Gestante();
                MostrarAtencionPuerperio();
                MostrarPlanificacionFamiliar();
                MostrarDatosAdcional();
                MostrarCalcio();



                paneles_22();
                

                if (e.ColumnIndex == this.DataListado.Columns["Edi"].Index)
                {
                    if (DataListado.SelectedRows.Count > 0)
                    {
                        esEditarEmbarazo = "SI";
                        button1.Enabled = false;
                        lblIdEmbarazo.Text = DataListado.CurrentRow.Cells[2].Value.ToString();
                        this.txtUltimaRegla.Text = DateTime.Parse( DataListado.CurrentRow.Cells[3].Value.ToString()).ToShortDateString();
                        this.txtGesta.Text = DataListado.CurrentRow.Cells[5].Value.ToString();
                        this.txtPariedad.Text = DataListado.CurrentRow.Cells[6].Value.ToString();
                        this.txtFechaPlanParto.Text =DateTime.Parse( DataListado.CurrentRow.Cells[4].Value.ToString()).ToShortDateString();
                        panelAddEmb.Dock = DockStyle.Fill;
                        panelAddEmb.Visible = true;
                        label1.Text = "ACTUALIZAR DATOS DEL EMBARAZO";
                    }
                }
            }
            catch (Exception)
            {


            }
        }

        //aqui es todo CODIGO DE MANTENIEMIENTO DE EXAMENES

        NegocioExamenes objExamenes = new NegocioExamenes();

        string esEditarExamen = "";
        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (esEditarExamen == "")
            {
                nroExamenes = new List<int>();
                nroExamenes.Clear();
                for (int i = 1; i < 3; i++) { nroExamenes.Add(i); }

                for (int i = 0; i < this.dataListadoExamen.Rows.Count; i++)
                {
                    if (this.dataListadoExamen.Rows[i].Cells[1].Value.ToString() == this.cmbTipoExamen.Text)
                    {
                        
                        if (this.dataListadoExamen.Rows[i].Cells[2].Value.ToString() == "1") { nroExamenes.Remove(1); }
                        if (this.dataListadoExamen.Rows[i].Cells[2].Value.ToString() == "2") { nroExamenes.Remove(2); }
                    }

                }
                cmbtNroExamen.Items.Clear();
                foreach (int item in nroExamenes)
                {
                    cmbtNroExamen.Items.Add(item);
                }
                if (cmbTipoExamen.Text == "SIFILIS" || cmbTipoExamen.Text == "VIH")
                {
                    txtResultadoExamen.Visible = false;
                    cmbtNroExamen.Enabled = true;
                    cmbResultado.Visible = true;
                    cmbResultado.Items.Clear();
                    cmbResultado.Items.Add("REACTIVO");
                    cmbResultado.Items.Add("NO REACTIVO");
                }
                else if (cmbTipoExamen.Text == "ORINA" || cmbTipoExamen.Text == "HEPATITIS")
                {
                    txtResultadoExamen.Visible = false;
                    cmbtNroExamen.Enabled = false;
                    cmbResultado.Visible = true;
                    cmbResultado.Items.Clear();
                    cmbResultado.Items.Add("POSITIVO");
                    cmbResultado.Items.Add("NEGATIVO");
                }
                else if (cmbTipoExamen.Text == "HEMOGLOBINA" || cmbTipoExamen.Text == "GLUCOSA(mg/dl)")
                {
                    cmbResultado.Visible = false;
                    cmbtNroExamen.Enabled = true;
                    txtResultadoExamen.Visible = true;
                }
                else if (cmbTipoExamen.Text == "PROTEINA")
                {
                    cmbResultado.Visible = true;
                    cmbtNroExamen.Enabled = true;
                    cmbResultado.Items.Clear();
                    txtResultadoExamen.Visible = false;

                    cmbResultado.Items.Add("(-)");
                    cmbResultado.Items.Add("(+)");
                }
            }
        }

        string validarExamenes()
        {
            if (this.cmbTipoExamen.Text == "")
            {
                this.cmbTipoExamen.Focus();
                return "Seleccione Tipo de Examen";
            }
            else if ((cmbTipoExamen.Text == "HEMOGLOBINA" || cmbTipoExamen.Text == "GLUCOSA(mg/dl)" || cmbTipoExamen.Text == "SIFILIS" || cmbTipoExamen.Text == "VIH" || cmbTipoExamen.Text == "PROTEINA") && this.cmbtNroExamen.Text == "")
            {
                this.cmbtNroExamen.Focus();
                return "Seleccione Nro Examen";
            } else if (this.dtpFechaExamen.Value > DateTime.Now)
            {
                this.dtpFechaExamen.Focus();
                return "Ingrese Fecha Examen Valido";
            } else if ((cmbTipoExamen.Text=="HEMOGLOBINA" || cmbTipoExamen.Text == "GLUCOSA(mg/dl)") && this.txtResultadoExamen.Text.Trim().Length == 0)
            {
                this.txtResultadoExamen.Focus();
                return "Ingrese Resultado de Examen";
            }
            else if ((cmbTipoExamen.Text == "SIFILIS" || cmbTipoExamen.Text == "VIH" || cmbTipoExamen.Text == "ORINA" || cmbTipoExamen.Text == "HEPATITIS" || cmbTipoExamen.Text == "PROTEINA") && this.cmbResultado.Text == "")
            {
                this.cmbResultado.Focus();
                return "Seleccione Resultado de la Examen";
            }
            else
            {
                return "";
            }
        }
        void mostrarExamenes()
        {
            try
            {
                if (DataListado.Rows.Count > 0 && DataListado.SelectedRows.Count > 0)
                {
                    DataTable dt = objExamenes.MostrarExamenes(int.Parse(this.DataListado.CurrentRow.Cells[2].Value.ToString()));
                    dataListadoExamen.DataSource = dt;


                    dataListadoExamen.Columns[0].Visible = false;
                    dataListadoExamen.Columns[1].Width = 300;
                    dataListadoExamen.Columns[2].Width = 200;
                    dataListadoExamen.Columns[3].Width = 200;
                    dataListadoExamen.Columns[4].Width = 200;

                    //estilo de cabecera
                    DataGridViewCellStyle stiloCabesa = new DataGridViewCellStyle();
                    stiloCabesa.BackColor = Color.White;
                    stiloCabesa.ForeColor = Color.Black;
                    stiloCabesa.Font = new Font("Segoe UI", 10, FontStyle.Regular | FontStyle.Bold);
                    this.dataListadoExamen.ColumnHeadersDefaultCellStyle = stiloCabesa;
                }
            }
            catch (Exception)
            {

               
            }

        }
        void listarExamenesEnCombo()
        {
            
            cmbTipoExamen.Items.Clear();
            cmbTipoExamen.Items.Add("SIFILIS");
            cmbTipoExamen.Items.Add("VIH");
            cmbTipoExamen.Items.Add("ORINA");
            cmbTipoExamen.Items.Add("HEPATITIS");
            cmbTipoExamen.Items.Add("HEMOGLOBINA");
            cmbTipoExamen.Items.Add("GLUCOSA(mg/dl)");
            cmbTipoExamen.Items.Add("PROTEINA");

            cmbtNroExamen.Items.Add("1");
            cmbtNroExamen.Items.Add("2");
        }

        void HabilitarExamenes()
        {
            this.cmbTipoExamen.Enabled = true;
            this.cmbtNroExamen.Enabled = true;
            this.dtpFechaExamen.Enabled = true;
            this.txtResultadoExamen.Enabled = true;
            cmbResultado.Enabled = true;
        }
        void DeshabilitarExamenes()
        {
            this.cmbTipoExamen.Enabled = false;
            this.cmbtNroExamen.Enabled = false;
            this.dtpFechaExamen.Enabled = false;
            this.txtResultadoExamen.Enabled = false;
            cmbResultado.Enabled = false;
        }
        void nuevoExamen()
        {
            this.btnNuevoExamen.Enabled = false;
            this.btnGuardarExamen.Enabled = true;
            this.btnEditarExamen.Enabled = false;
            this.btnEliminarExamen.Enabled = false;
            this.btnCancelarExamen.Enabled = true;

        }

        void CancelarExamen()
        {
            this.btnNuevoExamen.Enabled = true;
            this.btnGuardarExamen.Enabled = false;
            this.btnEditarExamen.Enabled = false;
            this.btnEliminarExamen.Enabled = false;
            this.btnCancelarExamen.Enabled = false;
        }

        void limpiarExamen()
        {
            this.cmbTipoExamen.Items.Clear();
            this.cmbtNroExamen.Items.Clear();
            this.dtpFechaExamen.Value = DateTime.Now;
            this.txtResultadoExamen.Clear();
            this.cmbResultado.Items.Clear();
            this.cmbTipoExamen.Focus();
        }
        private void btnNuevoExamen_Click(object sender, EventArgs e)
        {
            nuevoExamen();
            HabilitarExamenes();
            limpiarExamen();
            listarExamenesEnCombo();
            esEditarExamen = "";
        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void btnCancelarExamen_Click(object sender, EventArgs e)
        {
            limpiarExamen();
            DeshabilitarExamenes();
            CancelarExamen();
            esEditarExamen = "";
        }

        private void btnGuardarExamen_Click(object sender, EventArgs e)
        {
            if (validarExamenes() == "")
            {
                EntidadExamenes objExa = new EntidadExamenes();
                objExa.id_embarazo = int.Parse(this.DataListado.CurrentRow.Cells[2].Value.ToString());
                objExa.prueba = this.cmbTipoExamen.Text;
                
                objExa.fecha_prueba = this.dtpFechaExamen.Value;
                if (cmbTipoExamen.Text == "SIFILIS" || cmbTipoExamen.Text == "VIH" || cmbTipoExamen.Text == "ORINA" || cmbTipoExamen.Text == "HEPATITIS" || cmbTipoExamen.Text == "PROTEINA")
                {
                    objExa.resultado = this.cmbResultado.Text;
                    objExa.num_prueba = this.cmbtNroExamen.Text;
                }
                else
                {
                    objExa.resultado = this.txtResultadoExamen.Text;
                    objExa.num_prueba = "-";
                }
                    


                if (esEditarExamen == "")
                {
                    objExamenes.insertarExamen(objExa);
                    MessageBox.Show("Examen Registrado con exito", "Examen registrado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    objExa.id_examanes = int.Parse(this.dataListadoExamen.CurrentRow.Cells[0].Value.ToString());
                    objExamenes.EditarExamen(objExa);
                    MessageBox.Show("Examen Actualizado con exito", "Examen Actualizado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                limpiarExamen();
                DeshabilitarExamenes();
                CancelarExamen();
                mostrarExamenes();
                esEditarExamen = "";
            }
            else
            {
                MessageBox.Show(validarExamenes(), "Ocurrio un error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btnEditarExamen_Click(object sender, EventArgs e)
        {

            esEditarExamen = "SI";
            this.cmbTipoExamen.Enabled = false;
            this.cmbtNroExamen.Enabled = false;
            this.dtpFechaExamen.Enabled = true;
            this.txtResultadoExamen.Enabled = true;
            this.cmbResultado.Enabled = true;
            this.btnEditarExamen.Enabled = false;
            this.btnEliminarExamen.Enabled = false;
            this.btnCancelarExamen.Enabled = true;
            this.btnNuevoExamen.Enabled = false;
            this.btnGuardarExamen.Enabled = true;
        }

        private void dataListadoExamen_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                esEditarExamen = "SI";
                listarExamenesEnCombo();
                
                

                this.cmbTipoExamen.Text = this.dataListadoExamen.CurrentRow.Cells[1].Value.ToString();
                if (this.dataListadoExamen.CurrentRow.Cells[1].Value.ToString() == "SIFILIS" || this.dataListadoExamen.CurrentRow.Cells[1].Value.ToString() == "VIH" )
                {
                    cmbResultado.Visible = true;
                   txtResultadoExamen.Visible = false;
                   
                    cmbResultado.Items.Clear();
                    cmbResultado.Items.Add("REACTIVO");
                    cmbResultado.Items.Add("NO REACTIVO");
                    this.cmbResultado.Text = this.dataListadoExamen.CurrentRow.Cells[4].Value.ToString();
                }
                if (this.dataListadoExamen.CurrentRow.Cells[1].Value.ToString() == "ORINA" || this.dataListadoExamen.CurrentRow.Cells[1].Value.ToString() == "HEPATITIS")
                {
                    cmbResultado.Visible = true;
                    txtResultadoExamen.Visible = false;
                 
                    cmbResultado.Items.Clear();
                    cmbResultado.Items.Add("POSITIVO");
                    cmbResultado.Items.Add("NEGATIVO");
                    this.cmbResultado.Text = this.dataListadoExamen.CurrentRow.Cells[4].Value.ToString();
                }
                if (this.dataListadoExamen.CurrentRow.Cells[1].Value.ToString() == "PROTEINA" )
                {
                    cmbResultado.Visible = true;
                    txtResultadoExamen.Visible = false;
                   
                    cmbResultado.Items.Clear();
                    cmbResultado.Items.Add("(-)");
                    cmbResultado.Items.Add("(+");
                    this.cmbResultado.Text = this.dataListadoExamen.CurrentRow.Cells[4].Value.ToString();
                }
                if(this.dataListadoExamen.CurrentRow.Cells[1].Value.ToString() == "HEMOGLOBINA" || this.dataListadoExamen.CurrentRow.Cells[1].Value.ToString() == "GLUCOSA(mg/dl)")
                {
                    txtResultadoExamen.Visible = true;
                    cmbResultado.Visible = false;
                   
                    this.txtResultadoExamen.Text = this.dataListadoExamen.CurrentRow.Cells[4].Value.ToString();
                }
                this.cmbtNroExamen.Text = this.dataListadoExamen.CurrentRow.Cells[2].Value.ToString();
                this.dtpFechaExamen.Value = DateTime.Parse(this.dataListadoExamen.CurrentRow.Cells[3].Value.ToString());
              
                this.btnEditarExamen.Enabled = true;
                this.btnEliminarExamen.Enabled = true;
                this.btnCancelarExamen.Enabled = true;
                this.btnNuevoExamen.Enabled = false;
                this.btnGuardarExamen.Enabled = false;
                
            }
            catch (Exception)
            {

                
            }
        }

       
        List<int> nroExamenes;

        private void cmbTipoExamen_SelectionChangeCommitted(object sender, EventArgs e)
        {
            
        }

        private void btnEliminarExamen_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult res = MessageBox.Show("¿Estas seguro que quieres elininar?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (res == DialogResult.Yes)
                {
                    int id = Convert.ToInt32(dataListadoExamen.CurrentRow.Cells[0].Value.ToString());
                    EntidadExamenes objExa = new EntidadExamenes();
                    objExa.id_examanes = id;

                    objExamenes.EliminarExamen(objExa);
                    MessageBox.Show("Examanen eliminado con exito", "Examen Eliminado", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    limpiarExamen();
                    DeshabilitarExamenes();
                    CancelarExamen();
                    esEditarExamen = "";
                    mostrarExamenes();
                    
                }
                
            }
            catch (Exception)
            {

                MessageBox.Show("Ocurrio un error al eliminar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void dataListadoExamen_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                limpiarExamen();
                DeshabilitarExamenes();
                CancelarExamen();
                esEditarExamen = "";

            }catch(Exception)
            {

            }
        }

        //Todo codigo sobre suplementacion de sulfato ferroso

        void mostrarSulfatoFerroso()
        {
            try
            {
                if (DataListado.Rows.Count > 0 && DataListado.SelectedRows.Count > 0)
                {
                    DataTable dt = objSuplemento.mostrarSuplementacion(Convert.ToInt32(this.DataListado.CurrentRow.Cells[2].Value.ToString()), "SULFATO FERROSO");

                    DataListadoSulfatoFerroso.DataSource = dt;

                    DataListadoSulfatoFerroso.Columns[0].Visible = false;
                    DataListadoSulfatoFerroso.Columns[1].Width = 400;
                    DataListadoSulfatoFerroso.Columns[2].Width = 200;
                    DataListadoSulfatoFerroso.Columns[3].Width = 200;
                    DataListadoSulfatoFerroso.Columns[4].Visible = false;

                    //estilo de cabecera
                    DataGridViewCellStyle stiloCabesa = new DataGridViewCellStyle();
                    stiloCabesa.BackColor = Color.White;
                    stiloCabesa.ForeColor = Color.Black;
                    stiloCabesa.Font = new Font("Segoe UI", 10, FontStyle.Regular | FontStyle.Bold);
                    this.DataListadoSulfatoFerroso.ColumnHeadersDefaultCellStyle = stiloCabesa;
                }
            }
            catch (Exception)
            {

              
            }
        }
        void habilitControelsSulfatoFerroso()
        {
            this.cmbSuplementacion.Enabled = true;
            this.dtpFechaSuplementacion.Enabled = true;
        }
        void DeshabilitControelsSulfatoFerroso()
        {
            this.cmbSuplementacion.Enabled = false;
            this.dtpFechaSuplementacion.Enabled = false;
        }
        void limpiarControlesSulfatoFerrso()
        {
            this.cmbSuplementacion.Text = "";
            this.dtpFechaSuplementacion.Value = DateTime.Now;
        }

        List<string> nroSF;

        void llenarSulfatoFerroso()
        {
            if (esEditarSF == "SI")
            {
                return;
            }
            //nuevo objeto de la lista
            nroSF = new List<string>();
            //limpair lista
            nroSF.Clear();
            //llenar lista
            for (int i = 1; i < 7; i++)
            {
                nroSF.Add(i.ToString());
            }
            //recorriendo registro para quitar sf q existe
            for (int i = 0; i < DataListadoSulfatoFerroso.Rows.Count; i++)
            {
                //quitando sf encontrado dentro de registro
                nroSF.Remove(DataListadoSulfatoFerroso.Rows[i].Cells[2].Value.ToString());
            }

            //limpiar combo
            cmbSuplementacion.Items.Clear();
            //recorriendo la lista de nrosf para llenar en combo
            foreach (string nro in nroSF)
            {//llenando en combo
                cmbSuplementacion.Items.Add(nro);
            }

        }
        void nuevoSulfatoFerroso()
        {
            this.btnNuevoSF.Enabled = false;
            this.btnGuardarSF.Enabled = true;
            this.btnEditarSf.Enabled = false;
            this.btnEliminarSF.Enabled = false;
            this.btnCancelarSF.Enabled = true;

        }

        void CancelarSf()
        {
            this.btnNuevoSF.Enabled = true;
            this.btnGuardarSF.Enabled = false;
            this.btnEditarSf.Enabled = false;
            this.btnEliminarSF.Enabled = false;
            this.btnCancelarSF.Enabled = false;
        }


        private void button14_Click(object sender, EventArgs e)
        {
            try
            {
                esEditarSF = "";
                limpiarControlesSulfatoFerrso();
                habilitControelsSulfatoFerroso();
                nuevoSulfatoFerroso();
                llenarSulfatoFerroso();
                
            }
            catch (Exception)
            {

                
            }
        }

        private void btnCancelarSF_Click(object sender, EventArgs e)
        {
            limpiarControlesSulfatoFerrso();
            DeshabilitControelsSulfatoFerroso();
            CancelarSf();
        }

        string esEditarSF = "";

        string validarSulfatoFerroso()
        {
            if (this.cmbSuplementacion.Text == "")
            {
                this.cmbSuplementacion.Focus();
                return "Seleccion Nro Sulfato Ferroso";
            }else if (this.dtpFechaSuplementacion.Value > DateTime.Now)
            {
                this.dtpFechaSuplementacion.Focus();
                return "Fecha Ingresada No debe ser Mayor a la Fecha de Atencion";
            }
            else
            {
                return "";
            }
        }
        private void btnGuardarSF_Click(object sender, EventArgs e)
        {
            if (validarSulfatoFerroso() != "")
            {
                MessageBox.Show(validarSulfatoFerroso(), "Sistema de Validacion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            EntidadSuplementacion objSupl = new EntidadSuplementacion();

            objSupl.id_embarazo = int.Parse(DataListado.CurrentRow.Cells[2].Value.ToString());
            objSupl.suplementacion = "SULFATO FERROSO";
            objSupl.num_suplementacion = this.cmbSuplementacion.Text;
            objSupl.fecha_suplementacion = dtpFechaSuplementacion.Value;

            if (esEditarSF == "")
            {
                objSuplemento.registrarSuplementacion(objSupl);
                
                MessageBox.Show("Sulfato Ferroso Registrado con exito", "Registro de Sf", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                objSupl.id_suplementacion = Convert.ToInt32(DataListadoSulfatoFerroso.CurrentRow.Cells[0].Value.ToString());
                objSuplemento.EditarSuplementacion(objSupl);
               
                MessageBox.Show("Sulfato Ferroso Actualizado con exito", "Actualizar de Sf", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            limpiarControlesSulfatoFerrso();
            DeshabilitControelsSulfatoFerroso();
            CancelarSf();
            llenarSulfatoFerroso();
            mostrarSulfatoFerroso();
            esEditarSF = "";

        }

        private void DataListadoSulfatoFerroso_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {

                this.cmbSuplementacion.Text = this.DataListadoSulfatoFerroso.CurrentRow.Cells[2].Value.ToString();
                this.dtpFechaSuplementacion.Text = this.DataListadoSulfatoFerroso.CurrentRow.Cells[3].Value.ToString();
                esEditar = "";
                this.btnEditarSf.Enabled = true;
                this.btnEliminarSF.Enabled = true;
                btnCancelarSF.Enabled = true;
                btnNuevoSF.Enabled = false;
                btnGuardarSF.Enabled = false;
            }
            catch (Exception)
            {

                
            }
        }

        private void btnEditarSf_Click(object sender, EventArgs e)
        {
            esEditarSF = "SI";
            this.cmbSuplementacion.Enabled = false;
            this.dtpFechaSuplementacion.Enabled = true;
            this.btnEditarSf.Enabled = false;
            this.btnEliminarSF.Enabled = false;
            btnCancelarSF.Enabled = true;
            btnNuevoSF.Enabled = false;
            btnGuardarSF.Enabled = true;

        }

        private void DataListadoSulfatoFerroso_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            limpiarControlesSulfatoFerrso();
            DeshabilitControelsSulfatoFerroso();
            CancelarSf();
            esEditar = "";
        }

        private void btnEliminarSF_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult res = MessageBox.Show("¿Estas Seguro que quieres eliminar?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (res == DialogResult.Yes)
                {
                    int id = int.Parse(this.DataListadoSulfatoFerroso.CurrentRow.Cells[0].Value.ToString());
                    int id_emb = Convert.ToInt32(this.DataListado.CurrentRow.Cells[2].Value.ToString());

                    EntidadSuplementacion objE = new EntidadSuplementacion();

                    objE.id_suplementacion = id;
                    objE.id_embarazo = id_emb;

                    objSuplemento.EliminarSuplementacion(objE);

                    MessageBox.Show("Sulfato Ferroso elimado con exito", "Eliminado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    limpiarControlesSulfatoFerrso();
                    DeshabilitControelsSulfatoFerroso();
                    CancelarSf();
                    mostrarSulfatoFerroso();
                }


            }
            catch (Exception)
            {

                MessageBox.Show("Ocurrio un error al eliminar SF", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /*CODIGO ECOGRAFIA*/

        NegocioEcografia objEcografia = new NegocioEcografia();

        void mostrarEcografia()
        {
            try
            {
                if (DataListado.Rows.Count > 0 && DataListado.SelectedRows.Count > 0)
                {
                    EntidadEcografia objECo = new EntidadEcografia();
                    objECo.id_embarazo = int.Parse(this.DataListado.CurrentRow.Cells[2].Value.ToString());
                    DataTable dt = objEcografia.ListarEcografia(objECo);

                    dataListadoEcografia.DataSource = dt;

                    dataListadoEcografia.Columns[0].Visible = false;
                    dataListadoEcografia.Columns[1].Width = 400;
                    dataListadoEcografia.Columns[2].Width = 200;
                    dataListadoEcografia.Columns[3].Width = 200;
                    dataListadoEcografia.Columns[4].Visible = false;

                    //estilo de cabecera
                    DataGridViewCellStyle stiloCabesa = new DataGridViewCellStyle();
                    stiloCabesa.BackColor = Color.White;
                    stiloCabesa.ForeColor = Color.Black;
                    stiloCabesa.Font = new Font("Segoe UI", 10, FontStyle.Regular | FontStyle.Bold);
                    this.dataListadoEcografia.ColumnHeadersDefaultCellStyle = stiloCabesa;
                }
            }
            catch (Exception)
            {

               
            }
            
        }

        void limpiarControlesEcografia()
        {
            this.cmbEcografiaNro.Items.Clear();
            this.dtpFechaEcografia.Value = DateTime.Now;
            this.txtEdadGestEcografia.Clear();
        }
        void habilitarControlEcografia()
        {
            this.cmbEcografiaNro.Enabled = true;
            this.dtpFechaEcografia.Enabled = true;
            this.txtEdadGestEcografia.Enabled = true;
        }
        void desHabilitarControlEcografia()
        {
            this.cmbEcografiaNro.Enabled = false;
            this.dtpFechaEcografia.Enabled = false;
            this.txtEdadGestEcografia.Enabled = false;
        }
        void nuevoEcografia()
        {
            this.btnNuevoEcografia.Enabled = false;
            this.btnGuardarEcografia.Enabled = true;
            this.btnEditarEcografia.Enabled = false;
            this.btnEliminarEacografia.Enabled = false;
            this.btnCancelarEcografia.Enabled = true;
        }
        void cancelarEcogradfia()
        {
            this.btnNuevoEcografia.Enabled = true;
            this.btnGuardarEcografia.Enabled = false;
            this.btnEditarEcografia.Enabled = false;
            this.btnEliminarEacografia.Enabled = false;
            this.btnCancelarEcografia.Enabled = false;
        }

        string esEditarEcografia = "";

        void llenarEcografia()
        {
            cmbEcografiaNro.Items.Clear();

            string econ1 = "";
            string econ2 = "";

            if (esEditarEcografia == "")
            {

                if (this.dataListadoEcografia.Rows.Count > 0)
                {
                    for (int i = 0; i < dataListadoEcografia.Rows.Count; i++)
                    {
                        if (dataListadoEcografia.Rows[i].Cells[0].Value.ToString() == "1")
                        {
                            econ1 = "SI";

                        }
                        else if (dataListadoEcografia.Rows[i].Cells[0].Value.ToString() == "2")
                        {
                            econ1 = "SI";
                        }
                    }
                    if (econ1 == "SI" && econ2 == "SI")
                    {
                        cmbEcografiaNro.Items.Clear();
                    }
                    else if (econ1 == "SI" && econ2 == "")
                    {
                        cmbEcografiaNro.Items.Clear();
                        cmbEcografiaNro.Items.Add("2");
                    }
                    else if (econ1 == "" && econ2 == "2")
                    {
                        cmbEcografiaNro.Items.Clear();
                        cmbEcografiaNro.Items.Add("1");
                    }
                    else
                    {
                        cmbEcografiaNro.Items.Clear();
                        cmbEcografiaNro.Items.Add("1");
                        cmbEcografiaNro.Items.Add("2");
                    }
                }
                else
                {
                    cmbEcografiaNro.Items.Clear();
                    cmbEcografiaNro.Items.Add("1");
                    cmbEcografiaNro.Items.Add("2");
                }
            }
        }
        string validaEcografia()
        {
            if (this.cmbEcografiaNro.Text == "")
            {
                this.cmbEcografiaNro.Focus();
                return "Seleccione Nro Ecografia";
            }
            else if (this.dtpFechaEcografia.Value> DateTime.Now)
            {
                this.dtpFechaEcografia.Focus();
                return "Fecha de atencion no debe ser mayor a fecha actual";
                }
            else if (this.txtEdadGestEcografia.Text.Trim().Length==0)
            {
                this.txtEdadGestEcografia.Focus();
                return "Ingresa Edad gestacional";
            }
            else
            {
                return "";
            }
        }

        private void btnNuevoEcografia_Click(object sender, EventArgs e)
        {
            limpiarControlesEcografia();
            habilitarControlEcografia();
            nuevoEcografia();
            llenarEcografia();
            esEditarEcografia = "";
        }

        private void btnCancelarEcografia_Click(object sender, EventArgs e)
        {
            limpiarControlesEcografia();
            desHabilitarControlEcografia ();
            cancelarEcogradfia();
            esEditarEcografia = "";
        }

        private void btnGuardarEcografia_Click(object sender, EventArgs e)
        {
            if (validaEcografia() == "")
            {

                //obtener datos de formulario
                EntidadEcografia objEco = new EntidadEcografia();

                objEco.nro_eco = this.cmbEcografiaNro.Text;
                objEco.fecha_ecografia = dtpFechaEcografia.Value;
                objEco.edad_gestacional = this.txtEdadGestEcografia.Text;
                objEco.id_embarazo = Convert.ToInt32(this.DataListado.CurrentRow.Cells[2].Value.ToString());


                if (esEditarEcografia == "")
                {
                    //registrar ecografia
                    objEcografia.RegistrarEcografia(objEco);
                    MessageBox.Show("Ecografia registrado con exito", "Registrado", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                else
                {
                    //sacar id ecografia seleccionado para editar
                    objEco.id_ecografia= Convert.ToInt32(this.dataListadoEcografia.CurrentRow.Cells[0].Value.ToString());

                    //editar ecografia
                    objEcografia.EditarEcografia(objEco);
                    MessageBox.Show("Ecografia Actualizado con exito", "Actualizado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                //terminaos
                limpiarControlesEcografia();
                desHabilitarControlEcografia();
                cancelarEcogradfia();
                esEditarEcografia = "";
                mostrarEcografia();
            }
            else
            {
                MessageBox.Show(validaEcografia(), "Sistema de Validacion de Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btnEditarEcografia_Click(object sender, EventArgs e)
        {
            esEditarEcografia = "SI";
            this.btnNuevoEcografia.Enabled = false;
            this.btnGuardarEcografia.Enabled = true;
            this.btnEditarEcografia.Enabled = false;
            this.btnEliminarEacografia.Enabled = false;
            this.btnCancelarEcografia.Enabled = true;
            this.cmbEcografiaNro.Enabled = false;
            this.dtpFechaEcografia.Enabled = true;
            this.txtEdadGestEcografia.Enabled = true;


        }

        private void dataListadoEcografia_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                this.cmbEcografiaNro.Text = this.dataListadoEcografia.CurrentRow.Cells[1].Value.ToString();
                this.dtpFechaEcografia.Text = this.dataListadoEcografia.CurrentRow.Cells[2].Value.ToString();
                this.txtEdadGestEcografia.Text = this.dataListadoEcografia.CurrentRow.Cells[3].Value.ToString();
                esEditarEcografia = "";
                this.btnNuevoEcografia.Enabled = false;
                this.btnGuardarEcografia.Enabled = false;
                this.btnEditarEcografia.Enabled = true;
                this.btnEliminarEacografia.Enabled = true;
                this.btnCancelarEcografia.Enabled = true;
               
            }
            catch (Exception)
            {

              
            }
        }

        private void dataListadoEcografia_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            limpiarControlesEcografia();
            desHabilitarControlEcografia();
            this.btnNuevoEcografia.Enabled = true;
            this.btnGuardarEcografia.Enabled = false;
            this.btnEditarEcografia.Enabled = false;
            this.btnEliminarEacografia.Enabled = false;
            this.btnCancelarEcografia.Enabled = false;
        }

        private void btnEliminarEacografia_Click(object sender, EventArgs e)
        {
            try
            {
                

                DialogResult res = MessageBox.Show("¿Estas seguro que quieres elimnar?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (res == DialogResult.Yes)
                {
                    int id = int.Parse(this.DataListado.CurrentRow.Cells[2].Value.ToString());
                    int id_eco = int.Parse(this.dataListadoEcografia.CurrentRow.Cells[0].Value.ToString());

                    EntidadEcografia objEco = new EntidadEcografia();

                    objEco.id_ecografia = id_eco;
                    objEco.id_embarazo = id;

                    objEcografia.EliminarEcografia(objEco);
                    MessageBox.Show("Ecografia Eliminado con exito", "Eliminado", MessageBoxButtons.OK, MessageBoxIcon.Question);
                    limpiarControlesEcografia();
                    desHabilitarControlEcografia();
                    cancelarEcogradfia();
                    mostrarEcografia();
                    esEditarEcografia = "";
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Ocurrio un Erro al Eliminar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Question);

            }
        }

        private void DataListadoSulfatoFerroso_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void tabPage12_Click(object sender, EventArgs e)
        {

        }

        private void tabControl1_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (tabControl1.SelectedIndex == e.Index)
            {
                e.DrawBackground();
                Color tabTextColor = Color.SteelBlue;
                var color = Color.White;

                TextRenderer.DrawText(e.Graphics, tabControl1.TabPages[e.Index].Text, e.Font, e.Bounds, color);
            }
            else
            {
                e.DrawBackground();
                Color tabTextColor = Color.White;
                var color = Color.Black;

                TextRenderer.DrawText(e.Graphics, tabControl1.TabPages[e.Index].Text, e.Font, e.Bounds, color);
            }
                 
        }

        //todo  ACTIVIDAD

        NegocioActividad objActividad = new NegocioActividad();

        void Mostrar_actividad()
        {
            try
            {
                if(DataListado.Rows.Count>0 && DataListado.SelectedRows.Count > 0)
                {
                    int id = int.Parse(this.DataListado.CurrentRow.Cells[2].Value.ToString());

                    DataTable listaActividad = objActividad.ListarActividad(id);

                    dataListadoActividadRealizada.DataSource = listaActividad;

                    dataListadoActividadRealizada.Columns[0].Visible = false;
                    dataListadoActividadRealizada.Columns[1].Width = 300;
                    dataListadoActividadRealizada.Columns[2].Width = 150;
                    dataListadoActividadRealizada.Columns[3].Width = 150;
                    dataListadoActividadRealizada.Columns[4].Width = 200;

                    //estilo de cabecera
                    DataGridViewCellStyle stiloCabesa = new DataGridViewCellStyle();
                    stiloCabesa.BackColor = Color.White;
                    stiloCabesa.ForeColor = Color.Black;
                    stiloCabesa.Font = new Font("Segoe UI", 10, FontStyle.Regular | FontStyle.Bold);
                    this.dataListadoActividadRealizada.ColumnHeadersDefaultCellStyle = stiloCabesa;
                }
            }
            catch (Exception)
            {

               
            }
          
        }
        void limpiarControlesActividad()
        {
            cmbActividadRealizada.Items.Clear();
            cmbNroAtencion.Items.Clear();
            dtpFechaAtencionActividad.Value = DateTime.Now;
            txtResultado.Clear();
            cmbActividadRealizada.Focus();
        }

        void HabilitarControlActividad()
        {
            cmbActividadRealizada.Enabled = true;
            cmbNroAtencion.Enabled = true;
            dtpFechaAtencionActividad.Enabled = true;
            //txtResultado.Enabled = false;
        }

        void DesHabilitarControlActividad()
        {
            cmbActividadRealizada.Enabled = false;
            cmbNroAtencion.Enabled = false;
            dtpFechaAtencionActividad.Enabled = false;
        }

        void nuevoActividad()
        {
            btnGuardarActividad.Enabled = true;
            btnNuevoActividad.Enabled = false;
            btnEditarActividad.Enabled = false;
            btnEliminarActividad.Enabled = false;
            btnCancelarActividad.Enabled = true;
        }

        void CancelarActividad()
        {
            btnGuardarActividad.Enabled = false;
            btnNuevoActividad.Enabled = true;
            btnEditarActividad.Enabled = false;
            btnEliminarActividad.Enabled = false;
            btnCancelarActividad.Enabled = false;
        }
        void llenarActidad_A_Combo()
        {
            cmbActividadRealizada.Items.Clear();
            cmbActividadRealizada.Items.Add("PLAN DE PARTO");
            cmbActividadRealizada.Items.Add("TAMIZAJE VBG"); 
        }
        string validaActividad()
        {
            if (cmbActividadRealizada.Text == "")
            {
                this.cmbActividadRealizada.Focus();
                return "Seleccinar Actividad Realizada";
            }else if (this.cmbNroAtencion.Text == "")
            {
                this.cmbNroAtencion.Focus();
                return "Seleccionar Nro Atencion";
            }else if(this.dtpFechaAtencionActividad.Value> DateTime.Now)
            {
                this.dtpFechaAtencionActividad.Focus();
                return "Ingrese fecha Valido, no debe ser mayor a fecha actual";
            }
            else
            {
                return "";
            }
        }

        void llenarNroAtencionActividad()
        {
            this.cmbNroAtencion.Items.Clear();
            this.cmbNroAtencion.Items.Add("1");
            this.cmbNroAtencion.Items.Add("2");
            this.cmbNroAtencion.Items.Add("3");
        }
        private void btnNuevoActividad_Click(object sender, EventArgs e)
        {
            limpiarControlesActividad();
            HabilitarControlActividad();
            nuevoActividad();
            llenarActidad_A_Combo();
            llenarNroAtencionActividad();
        }

        private void btnCancelarActividad_Click(object sender, EventArgs e)
        {
            limpiarControlesActividad();
            DesHabilitarControlActividad();
            CancelarActividad();
            esEditar = "";
        }

        string esEditarActividad = "";

        private void btnGuardarActividad_Click(object sender, EventArgs e)
        {
            if (validaActividad() != "")
            {
                MessageBox.Show(validaActividad(), "Validacion de Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if(cmbActividadRealizada.Text== "TAMIZAJE VBG")
            {
                if (txtResultado.Text.Trim().Length == 0)
                {
                    MessageBox.Show("Ingrese Resultado de Tamizaje VBG", "Validacion de Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
            }
            EntidadActividad objEnAc = new EntidadActividad();
            objEnAc.actividad = this.cmbActividadRealizada.Text;
            objEnAc.nro_atencion=this.cmbNroAtencion.Text;
            objEnAc.fecha_atencion = this.dtpFechaAtencionActividad.Value;
            objEnAc.id_embarazo = int.Parse(this.DataListado.CurrentRow.Cells[2].Value.ToString());
            if(cmbActividadRealizada.Text== "TAMIZAJE VBG")
            {
                objEnAc.resultado = txtResultado.Text;
            }
            else
            {
                objEnAc.resultado = "";
            }

            if (esEditarActividad == "")
            {
                //guardar
                //VERIFICAR SI EXISTE EL REGISTRO
                for (int i = 0; i < dataListadoActividadRealizada.Rows.Count; i++)
                {
                    if (dataListadoActividadRealizada.Rows[i].Cells[1].Value.ToString()==this.cmbActividadRealizada.Text && dataListadoActividadRealizada.Rows[i].Cells[2].Value.ToString() == this.cmbNroAtencion.Text)
                    {
                        MessageBox.Show("Registro ya existe, Por favor Intenta de Nuevo", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }
                }

                objActividad.registrarActividad(objEnAc);
                MessageBox.Show("Actidad registrada con exito", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                objEnAc.id_actividad = int.Parse(this.dataListadoActividadRealizada.CurrentRow.Cells[0].Value.ToString());
                //editar
                objActividad.EditarActividad(objEnAc);
                MessageBox.Show("Actidad Actualizada con exito", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }

            limpiarControlesActividad();
            DesHabilitarControlActividad();
            CancelarActividad();
            Mostrar_actividad();
            esEditarActividad = "";
        }

        private void btnEditarActividad_Click(object sender, EventArgs e)
        {
            esEditarActividad = "SI";
            this.cmbActividadRealizada.Enabled = false;
            this.cmbNroAtencion.Enabled = false;
           if(cmbActividadRealizada.Text == "TAMIZAJE VBG")
            {
                this.txtResultado.Enabled = true;
            }
            else
            {
                this.txtResultado.Enabled = false;
            }
            dtpFechaAtencionActividad.Enabled = true;
            btnNuevoActividad.Enabled = false;
            btnGuardarActividad.Enabled = true;
            btnEditarActividad.Enabled = false;
            btnEliminarActividad.Enabled = false;
            btnCancelarActividad.Enabled = true;
        }

        private void btnEliminarActividad_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("¿Estas seguro que quieres eliminar?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    EntidadActividad objEAc = new EntidadActividad();

                    objEAc.id_actividad = int.Parse(this.dataListadoActividadRealizada.CurrentRow.Cells[0].Value.ToString());

                    objActividad.EliminarActividad(objEAc);
                    MessageBox.Show("Actividad eliminado con exito", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    limpiarControlesActividad();
                    DesHabilitarControlActividad();
                    CancelarActividad();
                    Mostrar_actividad();
                    esEditarActividad = "";

                }
        }
            catch (Exception)
            {

                MessageBox.Show("Ocurrio un error al elimnar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
}

        private void dataListadoActividadRealizada_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                esEditar = "SI";

                this.cmbActividadRealizada.Items.Clear();
                this.cmbActividadRealizada.Items.Add("PLAN DE PARTO");
                this.cmbActividadRealizada.Items.Add("TAMIZAJE VBG");

                this.cmbNroAtencion.Items.Clear();
                this.cmbNroAtencion.Items.Add("1");
                this.cmbNroAtencion.Items.Add("2");
                this.cmbNroAtencion.Items.Add("3");

                this.cmbActividadRealizada.Text = this.dataListadoActividadRealizada.CurrentRow.Cells[1].Value.ToString();
                this.cmbNroAtencion.Text = this.dataListadoActividadRealizada.CurrentRow.Cells[2].Value.ToString();
                this.dtpFechaAtencionActividad.Text = this.dataListadoActividadRealizada.CurrentRow.Cells[3].Value.ToString();
                this.txtResultado.Text = this.dataListadoActividadRealizada.CurrentRow.Cells[4].Value.ToString();

                btnNuevoActividad.Enabled = false;
                btnGuardarActividad.Enabled = false;
                btnEditarActividad.Enabled = true;
                btnEliminarActividad.Enabled = true;
                btnCancelarActividad.Enabled = true;

            }
            catch (Exception)
            {

               
            }
        }

        private void dataListadoActividadRealizada_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                limpiarControlesActividad();
                DesHabilitarControlActividad();
                CancelarActividad();
                esEditar = "";
            }
            catch (Exception)
            {

              
            }
        }

        private void cmbActividadRealizada_SelectionChangeCommitted(object sender, EventArgs e)
        {
            //aun falta agregar mas codigo 
            string existePlan1 = "";
            string existePlan2 = "";
            string existePlan3 = "";

            if (esEditarActividad == "")
            {
               if(cmbActividadRealizada.Text== "TAMIZAJE VBG")
                {
                    txtResultado.Enabled = true;
                }
                else
                {
                    txtResultado.Enabled = false;
                }
                for (int i = 0; i < dataListadoActividadRealizada.Rows.Count; i++)
                {
                    if (this.dataListadoActividadRealizada.Rows[i].Cells[1].Value.ToString() == this.cmbActividadRealizada.Text && this.dataListadoActividadRealizada.Rows[i].Cells[2].Value.ToString() == "1")
                    {
                        existePlan1 = "SI";
                    }
                    if (this.dataListadoActividadRealizada.Rows[i].Cells[1].Value.ToString() == this.cmbActividadRealizada.Text && this.dataListadoActividadRealizada.Rows[i].Cells[2].Value.ToString() == "2")
                    {
                        existePlan2 = "SI";
                    }

                    if (this.dataListadoActividadRealizada.Rows[i].Cells[1].Value.ToString() == this.cmbActividadRealizada.Text && this.dataListadoActividadRealizada.Rows[i].Cells[2].Value.ToString() == "3")
                    {
                        existePlan3 = "SI";
                    }

                }

                //llenar lab 
                if (existePlan1 == "SI" && existePlan2 == "SI" && existePlan3 == "SI")
                {
                    cmbNroAtencion.Items.Clear();
                }
                else if (existePlan1 == "SI" && existePlan2 == "SI" && existePlan3 == "")
                {
                    cmbNroAtencion.Items.Clear();
                    cmbNroAtencion.Items.Add("3");
                }
                else if (existePlan1 == "SI" && existePlan2 == "" && existePlan3 == "")
                {
                    cmbNroAtencion.Items.Clear();
                    cmbNroAtencion.Items.Add("2");
                    cmbNroAtencion.Items.Add("3");
                }
                else if (existePlan1 == "" && existePlan2 == "" && existePlan3 == "")
                {
                    cmbNroAtencion.Items.Clear();
                    cmbNroAtencion.Items.Add("1");
                    cmbNroAtencion.Items.Add("2");
                    cmbNroAtencion.Items.Add("3");
                }
                else if (existePlan1 == "" && existePlan2 == "SI" && existePlan3 == "SI")
                {
                    cmbNroAtencion.Items.Clear();
                    cmbNroAtencion.Items.Add("1");

                }
                else if (existePlan1 == "" && existePlan2 == "" && existePlan3 == "SI")
                {
                    cmbNroAtencion.Items.Clear();
                    cmbNroAtencion.Items.Add("1");
                    cmbNroAtencion.Items.Add("2");

                }
                else if (existePlan1 == "" && existePlan2 == "SI" && existePlan3 == "SI")
                {
                    cmbNroAtencion.Items.Clear();
                    cmbNroAtencion.Items.Add("1");
                    cmbNroAtencion.Items.Add("3");

                }
            }
        }



        //todo puerperio

        NegocioCulminacionEmbarazo objCulminaEmbarazo = new NegocioCulminacionEmbarazo();

        void llenarTipoParto()
        {
            cmbCulminacionEmbarazo.Items.Clear();
            cmbCulminacionEmbarazo.Items.Add("ABORTO");
            cmbCulminacionEmbarazo.Items.Add("PARTO");
        }
        void llenarVia()
        {
            cmbVia.Items.Clear();
            cmbVia.Items.Add("CESARIA");
            cmbVia.Items.Add("EUTOCICO");
            cmbVia.Items.Add("VAGINAL");
        }

        void llenarTipoCertificado()
        {
            cmbTipoCertificado.Items.Clear();
            cmbTipoCertificado.Items.Add("ELECTRONICO");
            cmbTipoCertificado.Items.Add("INSTITUCIONAL");
            cmbTipoCertificado.Items.Add("MANUAL");
        }
        void mostrar_culminacion_Gestante()
        {
            if(DataListado.Rows.Count>0 && DataListado.SelectedRows.Count > 0)
            {
                DataTable dt = objCulminaEmbarazo.ListarACulminacionEmbarazo(Convert.ToInt32(this.DataListado.CurrentRow.Cells[2].Value.ToString()));

                dataListadoCulminaGestante.DataSource = dt;
                dataListadoCulminaGestante.Columns[0].Visible = false;
                dataListadoCulminaGestante.Columns[1].Width = 250;
                dataListadoCulminaGestante.Columns[2].Width = 100;
                dataListadoCulminaGestante.Columns[3].Width = 200;
                dataListadoCulminaGestante.Columns[4].Width = 80;
                dataListadoCulminaGestante.Columns[5].Width = 50;
                dataListadoCulminaGestante.Columns[6].Width = 150;
                dataListadoCulminaGestante.Columns[7].Width = 90;

                //estilo de cabecera
                DataGridViewCellStyle stiloCabesa = new DataGridViewCellStyle();
                stiloCabesa.BackColor = Color.White;
                stiloCabesa.ForeColor = Color.Black;
                stiloCabesa.Font = new Font("Segoe UI", 10, FontStyle.Regular | FontStyle.Bold);
                this.dataListadoCulminaGestante.ColumnHeadersDefaultCellStyle = stiloCabesa;

            }
        }
        void limpiarCulminacion()
        {
            cmbCulminacionEmbarazo.Items.Clear();
            cmbVia.Items.Clear();
            txtLugar.Clear();
            dtpFechaAbortoParto.Value = DateTime.Now;
            cbCertificadp.Checked = false;
            cmbTipoCertificado.Items.Clear();
            dtpFechaCertificado.Value = DateTime.Now;

        }

        void habilitarCulminacion()
        {
            cmbCulminacionEmbarazo.Enabled = true;
            cmbVia.Enabled = true;
            txtLugar.Enabled = true;
            dtpFechaAbortoParto.Enabled = true;
            cbCertificadp.Enabled = true;
            //cmbTipoCertificado.Enabled = true;
            //dtpFechaCertificado.Enabled = true;
            //groupBox1.Enabled = true;
        }
        void deshabilitarCulminacion()
        {
            cmbCulminacionEmbarazo.Enabled = false;
            cmbVia.Enabled = false;
            txtLugar.Enabled = false;
            dtpFechaAbortoParto.Enabled = false;
            cbCertificadp.Enabled = false;
            cmbTipoCertificado.Enabled = false;
            dtpFechaCertificado.Enabled = false;
            groupBox1.Enabled = false;
        }

        void nuevoCulminacion()
        {
            btnNuevoCulEmb.Enabled = false;
            btnGuardarCulEmb.Enabled = true;
            btnEditarCulEmb.Enabled = false;
            btnEliminarCulEmb.Enabled = false;
            btnCancelarCulEmba.Enabled = true;
        }
        void CancelarCulminacion()
        {
            btnNuevoCulEmb.Enabled = true;
            btnGuardarCulEmb.Enabled = false;
            btnEditarCulEmb.Enabled = false;
            btnEliminarCulEmb.Enabled = false;
            btnCancelarCulEmba.Enabled = false;
        }
        string eseditarCulminacion = "";
        private void btnNuevoCulEmb_Click(object sender, EventArgs e)
        {
            limpiarCulminacion();
            habilitarCulminacion();
            nuevoCulminacion();
            llenarTipoParto();
            llenarVia();
            llenarTipoCertificado();
            eseditarCulminacion = "";
        }

        private void cbCertificadp_CheckedChanged(object sender, EventArgs e)
        {
            if (cbCertificadp.Checked == true)
            {
                groupBox1.Enabled = true;
                this.cmbTipoCertificado.Enabled = true;
                this.dtpFechaCertificado.Enabled = true;
            }else if(cbCertificadp.Checked==false)
            {
                groupBox1.Enabled = false;
                this.cmbTipoCertificado.Enabled = false;
                this.dtpFechaCertificado.Enabled = false;
            }
        }

        private void btnCancelarCulEmba_Click(object sender, EventArgs e)
        {
            limpiarCulminacion();
            deshabilitarCulminacion();
            CancelarCulminacion();
            eseditarCulminacion = "";
        }

        private void btnGuardarCulEmb_Click(object sender, EventArgs e)
        {
           

            if (DateTime.Parse(this.DataListado.CurrentRow.Cells[4].Value.ToString()) > DateTime.Now)
            {
               if( MessageBox.Show("¿Estas seguro, que quieres Culminar Embarazo Actual?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    return;
                }
            }
            EntidadCulminacionEmbarazo objCul = new EntidadCulminacionEmbarazo();

            string cnv = "";

            if (cbCertificadp.Checked == true)
            {
                cnv = "SI";//DATOS DE CNV
                
                objCul.tipo_cer = cmbTipoCertificado.Text;
                objCul.fecha_Cer = dtpFechaCertificado.Value;
            }
            else
            {
                cnv = "NO";
            }
            
            //DATOS DE CUlMINACION - ENTIDAD CULMINACION DE GESTANTE
            objCul.id_embarazo = Convert.ToInt32(this.DataListado.CurrentRow.Cells[2].Value.ToString());
            objCul.tipo_parto = this.cmbCulminacionEmbarazo.Text;
            objCul.via = cmbVia.Text;
            objCul.fecha_cul = dtpFechaAbortoParto.Value;
            objCul.lugar = this.txtLugar.Text;
            objCul.certificado_nac_vivo = cnv;

            //ENTIDAD EMBARAZO
            EntidadEmbarazo objEE = new EntidadEmbarazo();
            objEE.id_embaazo = int.Parse(this.DataListado.CurrentRow.Cells[2].Value.ToString());
            objEE.estado = "CULMINADO";

            if (eseditarCulminacion == "")
            {
                if (dataListadoCulminaGestante.Rows.Count > 0)
                {
                    MessageBox.Show("Embarazo ya fue Culminado, No pudes Ingresar mas Regisro", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); ;
                    return;
                }

                if (cmbCulminacionEmbarazo.Text == "")
                {
                    this.cmbCulminacionEmbarazo.Focus();
                    MessageBox.Show("Seleccione Tipo de Culminación del Embarazo ", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                if (cmbCulminacionEmbarazo.Text == "PARTO" && cbCertificadp.Checked==true)
                {
                    //validar datos
                    if (cmbVia.Text == "")
                    {
                        this.cmbVia.Focus();
                        MessageBox.Show("Seleccione Via del Parto", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }else if (this.txtLugar.Text.Trim().Length == 0)
                    {
                        this.txtLugar.Focus();
                        MessageBox.Show("Ingrese Lugar del Parto", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }else if (this.dtpFechaAbortoParto.Value > DateTime.Now)
                    {
                        this.dtpFechaAbortoParto.Focus();
                        MessageBox.Show("Seleccione fecha correcta, La fecha del parto no debe ser mayor a la fecha actual", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }else if (cmbTipoCertificado.Text == "")
                    {
                        this.cmbTipoCertificado.Focus();
                        MessageBox.Show("Seleccione, Tipo de certificado", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }
                    else if (dtpFechaCertificado.Value == DateTime.Now)
                    {
                        this.dtpFechaCertificado.Focus();
                        MessageBox.Show("Fecha de Registro de CNV no debe ser mayor a la Fecha Actual", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }
                    //guardar PARTO con CNV
                    objCulminaEmbarazo.registrarCulminacionEmbarazo(objCul);
                    //actualizar ESTADO DE EMBARAZO
                   
                    objEmbarazo.Actualizar_Estado_Embarazo(objEE);
                   
                }else if(cmbCulminacionEmbarazo.Text == "PARTO" && cbCertificadp.Checked == false)
                {
                    if (cmbVia.Text == "")
                    {
                        this.cmbVia.Focus();

                        MessageBox.Show("Seleccione Via del Parto", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }
                    else if (this.txtLugar.Text.Trim().Length == 0)
                    {
                        this.txtLugar.Focus();
                        MessageBox.Show("Ingrese Lugar del Parto", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }
                    else if (this.dtpFechaAbortoParto.Value > DateTime.Now)
                    {
                        this.dtpFechaAbortoParto.Focus();
                        MessageBox.Show("Seleccione fecha correcta, La fecha del parto no debe ser mayor a la fecha actual", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }
                    //guardar PARTO sin CNV
                    objCulminaEmbarazo.registrarCulminacionEmbarazo_Solo_Parto(objCul);
                    //actualizar ESTADO DE EMBARAZO

                    objEmbarazo.Actualizar_Estado_Embarazo(objEE);
                }
                else
                {
                    //registrar solo aborto
                    if (this.dtpFechaAbortoParto.Value > DateTime.Now)
                    {
                        this.dtpFechaAbortoParto.Focus();
                        MessageBox.Show("Seleccione fecha correcta, La fecha del Aborto no debe ser mayor a la fecha actual", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }

                    objCulminaEmbarazo.registrarCulminacionEmbarazo_Solo_Aborto(objCul);
                    //actualizar ESTADO DE EMBARAZO

                    objEmbarazo.Actualizar_Estado_Embarazo(objEE);
                }


                MessageBox.Show("EMBARAZO CULMINADO CON EXITO!","MENSAJE",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
            //Aqui comienza todo codifo de actualizacion de CULMINACION DE EMBARAZO

            else
            {



                objCul.id_culmicacion =int.Parse( dataListadoCulminaGestante.CurrentRow.Cells[0].Value.ToString());

                //Actualizacion Total parto con CNV

                if(cmbCulminacionEmbarazo.Text=="PARTO" && cbCertificadp.Checked == true)
                {
                    //validacion
                    //validar datos
                    if (cmbVia.Text == "")
                    {
                        this.cmbVia.Focus();
                        MessageBox.Show("Seleccione Via del Parto", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }
                    else if (this.txtLugar.Text.Trim().Length == 0)
                    {
                        this.txtLugar.Focus();
                        MessageBox.Show("Ingrese Lugar del Parto", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }
                    else if (this.dtpFechaAbortoParto.Value > DateTime.Now)
                    {
                        this.dtpFechaAbortoParto.Focus();
                        MessageBox.Show("Seleccione fecha correcta, La fecha del parto no debe ser mayor a la fecha actual", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }
                    else if (cmbTipoCertificado.Text == "")
                    {
                        this.cmbTipoCertificado.Focus();
                        MessageBox.Show("Seleccione, Tipo de certificado", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }
                    else if (dtpFechaCertificado.Value == DateTime.Now)
                    {
                        this.dtpFechaCertificado.Focus();
                        MessageBox.Show("Fecha de Registro de CNV no debe ser mayor a la Fecha Actual", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }
                    //ACTUAIZA DATOS DE CULMINACION DE EMBARAZO
                    objCulminaEmbarazo.editarCulminacionEmbarazo(objCul);
                    //actualizar ESTADO DE EMBARAZO

                    objEmbarazo.Actualizar_Estado_Embarazo(objEE);

                }
                else if (cmbCulminacionEmbarazo.Text == "PARTO" && cbCertificadp.Checked == false)
                {
                    //validacion
                    if (cmbVia.Text == "")
                    {
                        this.cmbVia.Focus();

                        MessageBox.Show("Seleccione Via del Parto", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }
                    else if (this.txtLugar.Text.Trim().Length == 0)
                    {
                        this.txtLugar.Focus();
                        MessageBox.Show("Ingrese Lugar del Parto", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }
                    else if (this.dtpFechaAbortoParto.Value > DateTime.Now)
                    {
                        this.dtpFechaAbortoParto.Focus();
                        MessageBox.Show("Seleccione fecha correcta, La fecha del parto no debe ser mayor a la fecha actual", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }
                    //actualizando parto sin CNV
                    objCulminaEmbarazo.editarCulminacionEmbarazo_solo_Parto(objCul);
                    //actualizar ESTADO DE EMBARAZO

                    objEmbarazo.Actualizar_Estado_Embarazo(objEE);
                }
                else
                {
                    //validaciom
                    if (this.dtpFechaAbortoParto.Value > DateTime.Now)
                    {
                        this.dtpFechaAbortoParto.Focus();
                        MessageBox.Show("Seleccione fecha correcta, La fecha del Aborto no debe ser mayor a la fecha actual", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }
                    //Actualizando solo aborto
                    objCulminaEmbarazo.editarCulminacionEmbarazo_solo_Aborto(objCul);
                    //actualizar ESTADO DE EMBARAZO

                    objEmbarazo.Actualizar_Estado_Embarazo(objEE);
                }

               
                MessageBox.Show("EMBARAZO ACUALIZADO CON EXITO!", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            limpiarCulminacion();
            deshabilitarCulminacion();
            CancelarCulminacion();
            mostrar_culminacion_Gestante();
            listarEmbarazoPorGestante();
            eseditarCulminacion = "";
            paneles_22();
        }

        private void cmbCulminacionEmbarazo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbCulminacionEmbarazo.Text == "PARTO")
            {
                cbCertificadp.Enabled = true;
                cmbVia.Enabled = true;
                txtLugar.Enabled = true;
                dtpFechaAbortoParto.Enabled = true;
            }
            else
            {
                cbCertificadp.Enabled = false;
                groupBox1.Enabled = false;
                txtLugar.Enabled = false;
                cmbVia.Enabled = false;
                dtpFechaAbortoParto.Enabled = true;
            }
        }

        private void dataListadoCulminaGestante_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                llenarTipoParto();
                llenarVia();
                llenarTipoCertificado();

                this.cmbCulminacionEmbarazo.Text = dataListadoCulminaGestante.CurrentRow.Cells[1].Value.ToString();
                this.cmbVia.Text = dataListadoCulminaGestante.CurrentRow.Cells[2].Value.ToString();
                this.txtLugar.Text= dataListadoCulminaGestante.CurrentRow.Cells[3].Value.ToString();
                this.dtpFechaAbortoParto.Value = DateTime.Parse(dataListadoCulminaGestante.CurrentRow.Cells[4].Value.ToString());
                string miCnv = dataListadoCulminaGestante.CurrentRow.Cells[5].Value.ToString();

                if(miCnv == "SI")
                {
                    cbCertificadp.Checked = true;
                    groupBox1.Enabled = false;
                    llenarTipoCertificado();
                    cmbTipoCertificado.Text = dataListadoCulminaGestante.CurrentRow.Cells[6].Value.ToString();
                    dtpFechaCertificado.Value = DateTime.Parse(dataListadoCulminaGestante.CurrentRow.Cells[7].Value.ToString());
                }
                else
                {

                    cbCertificadp.Checked = false;
                    groupBox1.Enabled = false;
                    cmbTipoCertificado.Items.Clear();
                    dtpFechaCertificado.Value = DateTime.Now;
                }

                

                btnEditarCulEmb.Enabled = true;
                btnEliminarCulEmb.Enabled = true;
                btnCancelarCulEmba.Enabled = true;
                btnNuevoCulEmb.Enabled = false;
                btnGuardarCulEmb.Enabled = false;
                deshabilitarCulminacion();
                eseditarCulminacion = "";
            }
            catch (Exception)
            {

               
            }
        }

        private void txtLugar_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnEditarCulEmb_Click(object sender, EventArgs e)
        {
            eseditarCulminacion = "SI";
            btnEditarCulEmb.Enabled = false;
            btnEliminarCulEmb.Enabled = false;
            btnCancelarCulEmba.Enabled = true;
            btnNuevoCulEmb.Enabled = false;
            btnGuardarCulEmb.Enabled = true;

           

            
            if (cmbCulminacionEmbarazo.Text == "PARTO")
            {
                cmbCulminacionEmbarazo.Enabled = true;
                cmbVia.Enabled = true;
                txtLugar.Enabled = true;
                dtpFechaAbortoParto.Enabled = true;
                cbCertificadp.Enabled = true;
            }
            else
            {
                cmbCulminacionEmbarazo.Enabled = true;
                cmbVia.Enabled = false;
                txtLugar.Enabled = false;
                dtpFechaAbortoParto.Enabled = true;
            }

            if (cbCertificadp.Checked == true)
            {
                groupBox1.Enabled = true;
                cmbTipoCertificado.Enabled = true;
                dtpFechaCertificado.Enabled = true;
            }
            else
            {
                groupBox1.Enabled = false;
                cmbTipoCertificado.Enabled = true;
                dtpFechaCertificado.Enabled = true;
            }

        }

        private void btnEliminarCulEmb_Click(object sender, EventArgs e)
        {
            try
            {
                if(MessageBox.Show("¿Estas seguro que quieres eliminar ?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    return;
                }
                //ENTIDAD EMBARAZO
                EntidadEmbarazo objEE = new EntidadEmbarazo();
                objEE.id_embaazo = int.Parse(this.DataListado.CurrentRow.Cells[2].Value.ToString());
                objEE.estado = "GESTANDO";

                EntidadCulminacionEmbarazo objCul = new EntidadCulminacionEmbarazo();

                objCul.id_culmicacion = int.Parse(this.dataListadoCulminaGestante.CurrentRow.Cells[0].Value.ToString());
                //eliminamos su culminacion de embarazo
                objCulminaEmbarazo.elimnarCulminacionEmbarazo(objCul);
                //como ya se eliminado culminacion de gestante, quiere decir que la gestante aun no ha culminado
                //actualizamos su estado de embarazo a GESTANDO
                objEmbarazo.Actualizar_Estado_Embarazo(objEE);

                MessageBox.Show("Registro Eliminado con exito", "Eliminado", MessageBoxButtons.OK, MessageBoxIcon.Information);

                eseditarCulminacion = "";
                limpiarCulminacion();
                deshabilitarCulminacion();
                CancelarCulminacion();
                mostrar_culminacion_Gestante();
                listarEmbarazoPorGestante();
                paneles_22();
            }
            catch (Exception)
            {

                MessageBox.Show("Ocurrio un error al elimiar Culminacion de Embarazo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataListadoCulminaGestante_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                limpiarCulminacion();
                deshabilitarCulminacion();
                CancelarCulminacion();
                eseditarCulminacion = "";
            }
            catch (Exception)
            {

              
            }
        }

        //TODO CODIGO DE ATENCION INTEGRAL

        NegocioPuerperio objPuerperio = new NegocioPuerperio(); 

        void MostrarAtencionPuerperio()
        {
            if(DataListado.Rows.Count>0 && DataListado.SelectedRows.Count > 0)
            {
               
                DataTable dt = objPuerperio.ListarPuerpera(Convert.ToInt32(this.DataListado.CurrentRow.Cells[2].Value.ToString()));

                DataListadoPuerpera.DataSource = dt;

               
                DataListadoPuerpera.Columns[0].Visible = false;
                DataListadoPuerpera.Columns[1].Width = 150;
                DataListadoPuerpera.Columns[2].Width = 200;
                DataListadoPuerpera.Columns[3].Width = 200;
                DataListadoPuerpera.Columns[4].Width = 200;

                //estilo de cabecera
                DataGridViewCellStyle stiloCabesa = new DataGridViewCellStyle();
                stiloCabesa.BackColor = Color.White;
                stiloCabesa.ForeColor = Color.Black;
                stiloCabesa.Font = new Font("Segoe UI", 10, FontStyle.Regular | FontStyle.Bold);
                this.DataListadoPuerpera.ColumnHeadersDefaultCellStyle = stiloCabesa;

            }
        }

        void habilitarPuerpera()
        {
            cmbNroAtencionPuerperio.Enabled = true;
            dtpFechaSupPuerpera.Enabled = true;
            dtpFechaAtencionPuerpera.Enabled = true;
            txtValorHBVPuerpera.Enabled = true;
        }
        void DesHabilitarPuerpera()
        {
            cmbNroAtencionPuerperio.Enabled = false;
            dtpFechaSupPuerpera.Enabled = false;
            dtpFechaAtencionPuerpera.Enabled = false;
            txtValorHBVPuerpera.Enabled = false;
        }

        void limpiarPuerpera()
        {
            cmbNroAtencionPuerperio.Items.Clear();
            dtpFechaAtencionPuerpera.Value = DateTime.Now;
            dtpFechaSupPuerpera.Value = DateTime.Now;
            txtValorHBVPuerpera.Clear();
            cmbNroAtencionPuerperio.Focus();
        }

        void llenarNroAtencionPuerpera()
        {
            string atencion1 = "";
            string atencion2 = "";
            

            if (DataListadoPuerpera.Rows.Count > 0)
            {
                for (int i = 0; i < DataListadoPuerpera.Rows.Count; i++)
                {
                    if (DataListadoPuerpera.Rows[i].Cells[1].Value.ToString() == "1")
                    {
                        atencion1 = "SI";
                    }
                    if (DataListadoPuerpera.Rows[i].Cells[1].Value.ToString() == "2")
                    {
                        atencion2 = "SI";
                    }
                   
                }
            }
            else
            {
                cmbNroAtencionPuerperio.Items.Clear();
                cmbNroAtencionPuerperio.Items.Add("1");
                cmbNroAtencionPuerperio.Items.Add("2");
               
            }

            if(atencion1=="SI" && atencion2=="" )
            {
                cmbNroAtencionPuerperio.Items.Clear();
                cmbNroAtencionPuerperio.Items.Add("2");
            }
            else if (atencion1 == "" && atencion2 == "")
            {
                cmbNroAtencionPuerperio.Items.Clear();
                cmbNroAtencionPuerperio.Items.Add("1");
                cmbNroAtencionPuerperio.Items.Add("2");
               
            }
            else if (atencion1 == "" && atencion2 == "SI" )
            {
                cmbNroAtencionPuerperio.Items.Clear();
                cmbNroAtencionPuerperio.Items.Add("1");
             
               
            }
           
        }

        void NuevoPuerpera()
        {
            btnnNuevoPuerpera.Enabled = false;
            btnGuardarPuerpera.Enabled = true;
            btnEliminarPuerpera.Enabled = false;
            btnEditarPuerpera.Enabled = false;
            btnCancelarPuerpera.Enabled = true;
        }
        void CancelarPuerpera()
        {
            btnnNuevoPuerpera.Enabled = true;
            btnGuardarPuerpera.Enabled = false;
            btnEliminarPuerpera.Enabled = false;
            btnEditarPuerpera.Enabled = false;
            btnCancelarPuerpera.Enabled = false;
        }
        string esEditarPuerpera = "";
        private void button10_Click(object sender, EventArgs e)
        {
            limpiarPuerpera();
            habilitarPuerpera();
            NuevoPuerpera();
            llenarNroAtencionPuerpera();
            esEditarPuerpera = "";
        }

        private void btnCancelarPuerpera_Click(object sender, EventArgs e)
        {
            limpiarPuerpera();
            DesHabilitarPuerpera();
            CancelarPuerpera();
            esEditarPuerpera = "";
        }

       
        private void btnGuardarPuerpera_Click(object sender, EventArgs e)
        {
            if (cmbNroAtencionPuerperio.Text == "")
            {
                MessageBox.Show("Selecione Nro de Atención de Puerpera", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            EntidadPuerpera objPuer = new EntidadPuerpera();

            objPuer.nro_atencion=cmbNroAtencionPuerperio.Text;
            objPuer.fecha_atencion = dtpFechaAtencionPuerpera.Value;
            objPuer.id_embarazo = int.Parse(this.DataListado.CurrentRow.Cells[2].Value.ToString());

            if (esEditarPuerpera == "")
            {
                if (cmbNroAtencionPuerperio.Text == "1")
                {
                    if (dtpFechaAtencionPuerpera.Value > DateTime.Now)
                    {
                        this.dtpFechaAtencionPuerpera.Focus();
                        MessageBox.Show("Seleccione fecha correcta, Fecha de Atencion no Debe ser mayor a la fecha Actual", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }
                    if (dtpFechaSupPuerpera.Value > DateTime.Now)
                    {
                        this.dtpFechaSupPuerpera.Focus();

                        MessageBox.Show("Seleccione fecha correcta, Fecha de Suplementacion no Debe ser mayor a la fecha Actual", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }

                    objPuer.fecha_suplementacion = dtpFechaSupPuerpera.Value;
                    objPuerperio.registrarAtencion_Puerpera_Solo_1(objPuer);


                }
                else if (cmbNroAtencionPuerperio.Text == "2")
                {
                    if (dtpFechaAtencionPuerpera.Value > DateTime.Now)
                    {
                        this.dtpFechaAtencionPuerpera.Focus();
                        MessageBox.Show("Seleccione fecha correcta, Fecha de Atencion no Debe ser mayor a la fecha Actual", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }

                    if (txtValorHBVPuerpera.Text.Trim().Length == 0)
                    {
                        this.txtValorHBVPuerpera.Focus();
                        MessageBox.Show("Ingrese Resultado de HBV", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }

                    objPuer.valor_HBV = txtValorHBVPuerpera.Text;
                    objPuerperio.registrarAtencionPuerpera(objPuer);



                }

                MessageBox.Show("REGISTRADO CON EXITO", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {

                //Actualizar Atencion de puerpera

                objPuer.id_puerpera = int.Parse(this.DataListadoPuerpera.CurrentRow.Cells[0].Value.ToString());

                if (cmbNroAtencionPuerperio.Text == "1")
                {
                    if (dtpFechaAtencionPuerpera.Value > DateTime.Now)
                    {
                        this.dtpFechaAtencionPuerpera.Focus();
                        MessageBox.Show("Seleccione fecha correcta, Fecha de Atencion no Debe ser mayor a la fecha Actual", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }
                    if (dtpFechaSupPuerpera.Value > DateTime.Now)
                    {
                        this.dtpFechaSupPuerpera.Focus();

                        MessageBox.Show("Seleccione fecha correcta, Fecha de Suplementacion no Debe ser mayor a la fecha Actual", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }

                    objPuer.fecha_suplementacion = dtpFechaSupPuerpera.Value;

                    objPuerperio.EditarAtencionPuerperaSolo_1(objPuer);

                   
                }
                else
                {
                    if (dtpFechaAtencionPuerpera.Value > DateTime.Now)
                    {
                        this.dtpFechaAtencionPuerpera.Focus();
                        MessageBox.Show("Seleccione fecha correcta, Fecha de Atencion no Debe ser mayor a la fecha Actual", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }

                    if (txtValorHBVPuerpera.Text.Trim().Length == 0)
                    {
                        this.txtValorHBVPuerpera.Focus();
                        MessageBox.Show("Ingrese Resultado de HBV", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }

                    objPuer.valor_HBV = txtValorHBVPuerpera.Text;
                    objPuerperio.EditarAtencionPuerpera(objPuer);

                }
                MessageBox.Show("ACTUALIZADO CON EXITO", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            
            limpiarPuerpera();
            DesHabilitarPuerpera();
            CancelarPuerpera();
            MostrarAtencionPuerperio();
            esEditarPuerpera = "";
        }

        private void cmbNroAtencionPuerperio_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if(cmbNroAtencionPuerperio.Text == "1")
                {
                    dtpFechaAtencionPuerpera.Enabled = true;
                    dtpFechaSupPuerpera.Enabled = true;
                    txtValorHBVPuerpera.Enabled = false;
                }
                else if (cmbNroAtencionPuerperio.Text == "2")
                {
                    dtpFechaAtencionPuerpera.Enabled = true;
                    dtpFechaSupPuerpera.Enabled = false;
                    txtValorHBVPuerpera.Enabled = true;
                }
            }
            catch (Exception)
            {

                
            }
        }

        private void tabControl3_Selected(object sender, TabControlEventArgs e)
        {
            if(tabControl3.SelectedTab.Text=="ATENCION DEL PUERPERIO")
            {
                MostrarAtencionPuerperio();
                paneles_22();
            }
            paneles_22();
        }

        private void DataListadoPuerpera_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {

                cmbNroAtencionPuerperio.Items.Clear();
                cmbNroAtencionPuerperio.Items.Add("1");
                cmbNroAtencionPuerperio.Items.Add("2");

                this.cmbNroAtencionPuerperio.Text = this.DataListadoPuerpera.CurrentRow.Cells[1].Value.ToString();
                this.dtpFechaAtencionPuerpera.Text = this.DataListadoPuerpera.CurrentRow.Cells[2].Value.ToString();
                this.dtpFechaSupPuerpera.Text = this.DataListadoPuerpera.CurrentRow.Cells[3].Value.ToString();
                this.txtValorHBVPuerpera.Text = this.DataListadoPuerpera.CurrentRow.Cells[4].Value.ToString();

                this.cmbNroAtencionPuerperio.Enabled = false;
                this.dtpFechaAtencionPuerpera.Enabled = false;
                this.dtpFechaSupPuerpera.Enabled = false;
                this.txtValorHBVPuerpera.Enabled = false;

                btnEditarPuerpera.Enabled = true;
                btnEliminarPuerpera.Enabled = true;
                btnnNuevoPuerpera.Enabled = false;
                btnGuardarPuerpera.Enabled = false;
                btnCancelarPuerpera.Enabled = true;

            }
            catch (Exception)
            {

              
            }
        }

        private void btnEditarPuerpera_Click(object sender, EventArgs e)
        {
            esEditarPuerpera = "SI";

            if (cmbNroAtencionPuerperio.Text == "1")
            {
                this.cmbNroAtencionPuerperio.Enabled = false;
                this.dtpFechaAtencionPuerpera.Enabled = true;
                this.dtpFechaSupPuerpera.Enabled = true;
                this.txtValorHBVPuerpera.Enabled = false;
            }
            else
            {
                this.cmbNroAtencionPuerperio.Enabled = false;
                this.dtpFechaAtencionPuerpera.Enabled = true;
                this.dtpFechaSupPuerpera.Enabled = false;
                this.txtValorHBVPuerpera.Enabled = true;
            }

            btnEditarPuerpera.Enabled = false;
            btnEliminarPuerpera.Enabled = false;
            btnnNuevoPuerpera.Enabled = false   ;
            btnGuardarPuerpera.Enabled = true;
            btnCancelarPuerpera.Enabled = true;

        }

        private void btnEliminarPuerpera_Click(object sender, EventArgs e)
        {
            try
            {
                if (DataListadoPuerpera.SelectedRows.Count > 0)
                {
                    DialogResult res = MessageBox.Show("¿Estas seguro que quiere eliminar?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                   
                    if (res == DialogResult.Yes)
                    {
                        EntidadPuerpera objPue = new EntidadPuerpera();

                        objPue.id_puerpera = Convert.ToInt32(this.DataListadoPuerpera.CurrentRow.Cells[0].Value.ToString());

                        objPuerperio.EliminarActencionPuerpera(objPue);

                        limpiarPuerpera();
                        DesHabilitarPuerpera();
                        MostrarAtencionPuerperio();
                        esEditarPuerpera = "";
                        CancelarPuerpera();

                    }
                }
            }
            catch (Exception)
            {

            }
        }

        private void DataListadoPuerpera_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            CancelarPuerpera();
            limpiarPuerpera();
            DesHabilitarPuerpera();
            }

        //Aqui todo codifo de PLANIFICACION FAMILIAR

        NegocioPlanificacionFamiliar objPlaniFam = new NegocioPlanificacionFamiliar();


        void MostrarPlanificacionFamiliar()
        {
            if(DataListado.Rows.Count>0 && DataListado.SelectedRows.Count > 0)
            {
                EntidadPlanificacionFamiliar objPla = new EntidadPlanificacionFamiliar();

                objPla.id_embarazo = Convert.ToInt32(this.DataListado.CurrentRow.Cells[2].Value.ToString());
                DataTable dt = objPlaniFam.ListarPlanificacionFamiliar(objPla);

                DataListadoPlani.DataSource = dt;

                DataListadoPlani.Columns[0].Visible = false;
                DataListadoPlani.Columns[1].Width = 150;
                DataListadoPlani.Columns[2].Width = 300;
                DataListadoPlani.Columns[3].Width = 300;

                //estilo de cabecera
                DataGridViewCellStyle stiloCabesa = new DataGridViewCellStyle();
                stiloCabesa.BackColor = Color.White;
                stiloCabesa.ForeColor = Color.Black;
                stiloCabesa.Font = new Font("Segoe UI", 10, FontStyle.Regular | FontStyle.Bold);
                this.DataListadoPlani.ColumnHeadersDefaultCellStyle = stiloCabesa;

            }
        
        }

        void limpiarPlanificacionFamiliar()
        {
            dtpFechaAtencionPlani.Value = DateTime.Now;
            cmbOrientacionConsejeria.Items.Clear();
            cmbMetodo.Items.Clear();
            dtpFechaAtencionPlani.Focus();
        }

        void llenarOrietacionConsejeria()
        {
            cmbOrientacionConsejeria.Items.Clear();
            cmbOrientacionConsejeria.Items.Add("SI");
            cmbOrientacionConsejeria.Items.Add("NO");
        }
        void llenarMetodoAplica()
        {
            cmbMetodo.Items.Clear();
            cmbMetodo.Items.Add("NO");
            cmbMetodo.Items.Add("INYECTABLE TRIMESTRAL");
            cmbMetodo.Items.Add("INYECTABLE MENSUAL");
            cmbMetodo.Items.Add("IMPLANTE");
            cmbMetodo.Items.Add("MELA");
            cmbMetodo.Items.Add("ORAL COMBINADO");
            cmbMetodo.Items.Add("LIGADURA DE TROMPAS");
            cmbMetodo.Items.Add("ABSTINENCIA PERIÓDICA");
            cmbMetodo.Items.Add("BTB");
        }

        void habilitarPlanificacion()
        {
            dtpFechaAtencionPlani.Enabled = true;
            cmbOrientacionConsejeria.Enabled = true;
            cmbMetodo.Enabled = true;
        }

        void DeshabilitarPlanificacion()
        {
            dtpFechaAtencionPlani.Enabled = false;
            cmbOrientacionConsejeria.Enabled = false;
            cmbMetodo.Enabled = false;
        }

        void nuevoPlanificacion()
        {
            btnNuevoPlani.Enabled = false;
            btnGuardarPlani.Enabled = true;
            btnCancelarPlani.Enabled = true;
            btnEditarPlani.Enabled = false;
            btnEliminarPlani.Enabled = false;
        }

        void cancelarPlanificacion()
        {
            btnNuevoPlani.Enabled = true;
            btnGuardarPlani.Enabled = false;
            btnCancelarPlani.Enabled = false;
            btnEditarPlani.Enabled = false;
            btnEliminarPlani.Enabled = false;
        }

        string esEditarPlani ="";
        private void btnNuevoPlani_Click(object sender, EventArgs e)
        {
            limpiarPlanificacionFamiliar();
            habilitarPlanificacion();
            nuevoPlanificacion();
            llenarOrietacionConsejeria();
            llenarMetodoAplica();
            esEditarPlani = "";
        }

        private void btnCancelarPlani_Click(object sender, EventArgs e)
        {
            limpiarPlanificacionFamiliar();
            DeshabilitarPlanificacion();
            cancelarPlanificacion();
            esEditarPlani = "";
        }

        string validaPlanificacion()
        {
            if(dtpFechaAtencionPlani.Value > DateTime.Now)
            {
                this.dtpFechaAtencionPlani.Focus();
                return "Ingrese fecha correcta, La fecha de atencion no debe ser mayor a la fecha Actual";
            }
            else if(cmbOrientacionConsejeria.Text == "")
            {
                this.cmbOrientacionConsejeria.Focus();
                return "Seleccione Orientacion y Consejeria";
            }else if (cmbMetodo.Text == "")
            {
                this.cmbMetodo.Focus();
                return "Seleccione Metodo Aplicado";
            }
            else
            {
                return "";
            }
        }
        private void btnGuardarPlani_Click(object sender, EventArgs e)
        {
            if (validaPlanificacion() != "")
            {
                MessageBox.Show(validaPlanificacion(), "Ocurrio un error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            EntidadPlanificacionFamiliar objPlani = new EntidadPlanificacionFamiliar();

            objPlani.fecha_plan = dtpFechaAtencionPlani.Value;
            objPlani.orientacion_consejeria = cmbOrientacionConsejeria.Text;
            objPlani.metodo_aplicado = cmbMetodo.Text;
            objPlani.id_embarazo = Convert.ToInt32(this.DataListado.CurrentRow.Cells[2].Value.ToString());
           
            if (esEditarPlani == "")
            {
                //guardar planificacion

                objPlaniFam.registrarPlanificacionFamiliar(objPlani);
                MessageBox.Show("Planificacion Registrado con exito", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                //obtener ID de plani seleccionado
                objPlani.id_plani_fam = Convert.ToInt32(this.DataListadoPlani.CurrentRow.Cells[0].Value.ToString());

                //editar planificacion

                objPlaniFam.EditarPlanificacionFamiliar(objPlani);
                MessageBox.Show("Planificacion Actualizado con exito", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }

            limpiarPlanificacionFamiliar();
            DeshabilitarPlanificacion();
            cancelarPlanificacion();
            MostrarPlanificacionFamiliar();
            esEditarPlani = "";
        }

        private void DataListadoPlani_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                llenarOrietacionConsejeria();
                llenarMetodoAplica();

                esEditarPlani = "SI";

                this.dtpFechaAtencionPlani.Value = DateTime.Parse(this.DataListadoPlani.CurrentRow.Cells[1].Value.ToString());
                this.cmbOrientacionConsejeria.Text = this.DataListadoPlani.CurrentRow.Cells[2].Value.ToString();
                this.cmbMetodo.Text = this.DataListadoPlani.CurrentRow.Cells[3].Value.ToString();

                DeshabilitarPlanificacion();

                btnNuevoPlani.Enabled = false;
                btnGuardarPlani.Enabled = false;
                btnEliminarPlani.Enabled = true;
                btnEditarPlani.Enabled = true;
                btnCancelarPlani.Enabled = true;

            }
            catch (Exception)
            {

                
            }
        }

        private void DataListadoPlani_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                limpiarPlanificacionFamiliar();
                DeshabilitarPlanificacion();
                cancelarPlanificacion();
                esEditarPlani = "";
            }
            catch (Exception)
            {

               
            }
        }

        private void btnEditarPlani_Click(object sender, EventArgs e)
        {
            habilitarPlanificacion();
            esEditarPlani = "SI";

            btnNuevoPlani.Enabled = false;
            btnGuardarPlani.Enabled = true;
            btnEliminarPlani.Enabled = false;
            btnEditarPlani.Enabled = false;
            btnCancelarPlani.Enabled = true;

        }

        private void btnEliminarPlani_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult res = MessageBox.Show("¿Estas seguro que quiere eliminar Registro?","Confirmar",MessageBoxButtons.YesNo,MessageBoxIcon.Question);

                if(res== DialogResult.Yes)
                {

                    EntidadPlanificacionFamiliar objPla = new EntidadPlanificacionFamiliar();

                    objPla.id_plani_fam = Convert.ToInt32(this.DataListadoPlani.CurrentRow.Cells[0].Value.ToString());


                    objPlaniFam.EliminarPlanificacionFamiliar(objPla);

                    MessageBox.Show("Registro Eliminado con exito", "Eliminado", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                    limpiarPlanificacionFamiliar();
                    DeshabilitarPlanificacion();
                    cancelarPlanificacion();
                    MostrarPlanificacionFamiliar();
                    esEditarPlani = "";
                }

            }
            catch (Exception)
            {

                MessageBox.Show("Ocurrio un error al eliminar", "Error", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            }
        }

        //TODO CODIGO DE DATOS ADICIONAL

        NegocioDatosAdicional objAdicional = new NegocioDatosAdicional();

        void MostrarDatosAdcional()
        {
            if(DataListado.Rows.Count>0 && DataListado.SelectedRows.Count > 0)
            {
                EntidadDatosAdicional objAdi = new EntidadDatosAdicional();

              int id = Convert.ToInt32(this.DataListado.CurrentRow.Cells[2].Value.ToString());

                DataTable dt = objAdicional.ListarDatosAdicional(id);

                dataListadoAdicional.DataSource = dt;

                dataListadoAdicional.Columns[0].Visible = false;
                dataListadoAdicional.Columns[1].Width = 300;
                dataListadoAdicional.Columns[2].Width = 300;
                dataListadoAdicional.Columns[3].Width = 300;
                dataListadoAdicional.Columns[4].Visible = false;

                //estilo de cabecera
                DataGridViewCellStyle stiloCabesa = new DataGridViewCellStyle();
                stiloCabesa.BackColor = Color.White;
                stiloCabesa.ForeColor = Color.Black;
                stiloCabesa.Font = new Font("Segoe UI", 10, FontStyle.Regular | FontStyle.Bold);
                this.dataListadoAdicional.ColumnHeadersDefaultCellStyle = stiloCabesa;


            }
        }

       void limpiarDatosAdicional()
        {
            this.txtNombreContacto.Clear();
            this.txtTelefono.Clear();
            this.txtObservacion.Clear();
            this.txtNombreContacto.Focus();
        }

        void habilitarDatosAdicional()
        {
            this.txtNombreContacto.Enabled=true;
            this.txtTelefono.Enabled=true;
            this.txtObservacion.Enabled=true;
        
        }

        void desHabilitarDatosAdicional()
        {
            this.txtNombreContacto.Enabled = false;
            this.txtTelefono.Enabled = false;
            this.txtObservacion.Enabled = false;
        }

        void nuevoDatosAdicional()
        {
            this.btnNuevoAdicional.Enabled = false;
            this.btnGuardarAdicional.Enabled = true;
            this.btnEliminarAdicional.Enabled = false;
            this.btnEditarAdicional.Enabled = false;
            this.btnCancelarAdicional.Enabled = true;
        }

        void cancelarDatosAdicional()
        {
            this.btnNuevoAdicional.Enabled = true;
            this.btnGuardarAdicional.Enabled = false;
            this.btnEliminarAdicional.Enabled = false;
            this.btnEditarAdicional.Enabled = false;
            this.btnCancelarAdicional.Enabled = false;
        }

        string esEditarDatosAdicional = "";

        private void btnNuevoAdicional_Click(object sender, EventArgs e)
        {
            limpiarDatosAdicional();
            habilitarDatosAdicional();
            nuevoDatosAdicional();
            esEditarDatosAdicional = "";
        }

        private void btnCancelarAdicional_Click(object sender, EventArgs e)
        {
            limpiarDatosAdicional();
            desHabilitarDatosAdicional();
            cancelarDatosAdicional();
            esEditarDatosAdicional = "";
        }

        string validaDatosAdicional()
        {
            if (this.txtNombreContacto.Text.Trim().Length == 0)
            {
                this.txtNombreContacto.Focus();
                return "Ingrese Nombre del Contacto";
            }else if (this.txtTelefono.Text.Trim().Length == 0)
            {
                this.txtTelefono.Focus();
                return "Ingrese Telefono";
            }else if (this.txtObservacion.Text.Trim().Length == 0)
            {
                this.txtObservacion.Focus();
                return "Ingrese Observacion";
            }
            else
            {
                return "";
            }
        }
        private void btnGuardarAdicional_Click(object sender, EventArgs e)
        {
            if (validaDatosAdicional() == "")
            {
                EntidadDatosAdicional objEnDatA = new EntidadDatosAdicional();

                objEnDatA.nombre = this.txtNombreContacto.Text;
                objEnDatA.telefono = this.txtTelefono.Text;
                objEnDatA.observacion = this.txtObservacion.Text;
                objEnDatA.id_embarazo = Convert.ToInt32(this.DataListado.CurrentRow.Cells[2].Value.ToString());

                if (esEditarDatosAdicional == "")
                {
                    //guardar registro
                    
                    objAdicional.registrarDatosAdicional(objEnDatA);
                    MessageBox.Show("Datos Adicional Registrado con exito", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                else
                {
                    //editar datos
                    objEnDatA.id_datos_adicional = Convert.ToInt32(this.dataListadoAdicional.CurrentRow.Cells[0].Value.ToString());
                    objAdicional.EditarDatosAdicional(objEnDatA);
                    MessageBox.Show("Datos Adicional Actualizado con exito", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                limpiarDatosAdicional();
                desHabilitarDatosAdicional();
                cancelarDatosAdicional();
                esEditarDatosAdicional = "";
                MostrarDatosAdcional();
            }
            else
            {
                MessageBox.Show(validaDatosAdicional(), "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void dataListadoAdicional_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                esEditarDatosAdicional = "";

                this.txtNombreContacto.Text = this.dataListadoAdicional.CurrentRow.Cells[1].Value.ToString();
                this.txtTelefono.Text = this.dataListadoAdicional.CurrentRow.Cells[2].Value.ToString().Trim();
                this.txtObservacion.Text = this.dataListadoAdicional.CurrentRow.Cells[3].Value.ToString();
                desHabilitarDatosAdicional();

                btnNuevoAdicional.Enabled = false;
                btnEliminarAdicional.Enabled = true;
                btnEditarAdicional.Enabled = true;
                btnCancelarAdicional.Enabled = true;
                btnGuardarAdicional.Enabled = false;

            }
            catch (Exception)
            {

              
            }
        }

        private void btnEditarAdicional_Click(object sender, EventArgs e)
        {
            esEditarDatosAdicional = "SI";
            habilitarDatosAdicional();
            btnNuevoAdicional.Enabled = false;
            btnGuardarAdicional.Enabled = true;
            btnEditarAdicional.Enabled = false;
            btnEliminarAdicional.Enabled = false;
            btnCancelarAdicional.Enabled = true;
        }

        private void dataListadoAdicional_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                limpiarDatosAdicional();
                desHabilitarDatosAdicional();
                cancelarDatosAdicional();
                esEditarDatosAdicional = "";
            }
            catch (Exception)
            {

                
            }
        }

        private void btnEliminarAdicional_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult res = MessageBox.Show("¿Estas seguro que quieres elimianar Registro Seleccionado?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (res == DialogResult.Yes)
                {
                    EntidadDatosAdicional objE = new EntidadDatosAdicional();
                    objE.id_datos_adicional = int.Parse(dataListadoAdicional.CurrentRow.Cells[0].Value.ToString());
                    objAdicional.EliminarDatosAdicional(objE);
                    MessageBox.Show("Registro Eliminado con exito", "Eliminado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    limpiarDatosAdicional();
                    desHabilitarDatosAdicional();
                    cancelarDatosAdicional();
                    esEditarDatosAdicional = "";
                    MostrarDatosAdcional();
                }
            }
            catch (Exception)
            {

                MessageBox.Show("Ocurrio un error al eliminar Datos Adicional", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //Todo codigo de calcio

        
        void MostrarCalcio()
        {
            if(DataListado.Rows.Count>0 && DataListado.SelectedRows.Count > 0)
            {
                DataTable dt = objSuplemento.mostrarSuplementacion(Convert.ToInt32(this.DataListado.CurrentRow.Cells[2].Value.ToString()), "CALCIO");

                dataListadoCALCIO.DataSource = dt;

                dataListadoCALCIO.Columns[0].Visible = false;
                dataListadoCALCIO.Columns[1].Width = 400;
                dataListadoCALCIO.Columns[2].Width = 200;
                dataListadoCALCIO.Columns[3].Width = 300;
                dataListadoCALCIO.Columns[4].Visible = false;

                //estilo de cabecera
                DataGridViewCellStyle stiloCabesa = new DataGridViewCellStyle();
                stiloCabesa.BackColor = Color.White;
                stiloCabesa.ForeColor = Color.Black;
                stiloCabesa.Font = new Font("Segoe UI", 10, FontStyle.Regular | FontStyle.Bold);
                this.dataListadoCALCIO.ColumnHeadersDefaultCellStyle = stiloCabesa;
            }
        }

        void limpiarCalcio()
        {
            cmbCalcio.Items.Clear();
            dtpfechaCalcio.Value = DateTime.Now;
            cmbCalcio.Focus();
        }
        void habilitarCalcio()
        {
            cmbCalcio.Enabled = true;
            dtpfechaCalcio.Enabled = true;
        }
        void DeshabilitarCalcio()
        {
            cmbCalcio.Enabled = false;
            dtpfechaCalcio.Enabled = false;
        }
        void nuevoCalcio()
        {
            btnNuevoCalcio.Enabled = false;
            btnGuardarCalcio.Enabled = true;
            btnEditarCalcio.Enabled = false;
            btnEliminarCalcio.Enabled = false;
            btnCancelarCalcio.Enabled = true;
        }
        void cancelarCalcio()
        {
            btnNuevoCalcio.Enabled = true;
            btnGuardarCalcio.Enabled = false;
            btnEditarCalcio.Enabled = false;
            btnEliminarCalcio.Enabled = false;
            btnCancelarCalcio.Enabled = false;
        }


        List<string> miCalcio;
        void listarCalcio()
        {
            //crear objeto lista
            miCalcio = new List<string>();
            //limpiar lista
            miCalcio.Clear();
            for (int i = 1; i < 6; i++)
            {
                miCalcio.Add(i.ToString());
            }

            if (dataListadoCALCIO.Rows.Count > 0)//si no hay registro , verificamos 
            {
                for (int i = 0; i < this.dataListadoCALCIO.Rows.Count; i++)
                {
                    miCalcio.Remove(dataListadoCALCIO.Rows[i].Cells[2].Value.ToString());
                }
            }
                //limpiar combobox
                cmbCalcio.Items.Clear();

                //llenar en combo - lista calcio
                foreach (string c in miCalcio)
                {
                    cmbCalcio.Items.Add(c);
                }
        }
        string validaCalcio()
        {
            if (this.cmbCalcio.Text == "")
            {
                this.cmbCalcio.Focus();
                return "Seleccione Calcio";
            }else if(this.dtpfechaCalcio.Value> DateTime.Now)
            {
                this.dtpfechaCalcio.Focus();
                return "Ingrese fecha correcta, Fecha atencion no debe ser mayor a la Fecha Actual";
            }
            else
            {
                return "";
            }
        }
        private void btnNuevoCalcio_Click(object sender, EventArgs e)
        {
            limpiarCalcio();
            habilitarCalcio();
            nuevoCalcio();
            listarCalcio();
            esEditarCalcio = "";
        }

        private void txtGesta_Enter(object sender, EventArgs e)
        {
            txtGesta.BackColor = Color.Yellow;
        }

        private void txtGesta_Leave(object sender, EventArgs e)
        {
            txtGesta.BackColor = Color.White;
        }

        private void txtPariedad_Enter(object sender, EventArgs e)
        {
            txtPariedad.BackColor = Color.Yellow;
        }

        private void txtPariedad_Layout(object sender, LayoutEventArgs e)
        {

        }

        private void txtPariedad_Leave(object sender, EventArgs e)
        {
            txtPariedad.BackColor = Color.White;
        }
        string esEditarCalcio = "";
        private void btnCancelarCalcio_Click(object sender, EventArgs e)
        {
            limpiarCalcio();
            DeshabilitarCalcio();
            cancelarCalcio();
            esEditarCalcio = "";
        }

        private void btnGuardarCalcio_Click(object sender, EventArgs e)
        {
            if (validaCalcio()=="")
            {
                EntidadSuplementacion objSub = new EntidadSuplementacion();
                objSub.suplementacion = "CALCIO";
                objSub.num_suplementacion = cmbCalcio.Text;
                objSub.fecha_suplementacion = dtpfechaCalcio.Value;
                objSub.id_embarazo = int.Parse(this.DataListado.CurrentRow.Cells[2].Value.ToString());

                if (esEditarCalcio == "")
                {
                    //guardar calcio
                    for (int i = 0; i < dataListadoCALCIO.Rows.Count; i++)
                    {
                        if (this.dataListadoCALCIO.Rows[i].Cells[2].Value.ToString() == this.cmbCalcio.Text)
                        {
                            MessageBox.Show(this.cmbCalcio.Text + " Suplemetacion de Calcio ya Existe", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            return;
                        }
                    }
                    objSuplemento.registrarSuplementacion(objSub);
                    MessageBox.Show("Suplementacion de calcio, Registrado con exito", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                else
                {
                    //editar calcio
                    objSub.id_suplementacion = int.Parse(this.dataListadoCALCIO.CurrentRow.Cells[0].Value.ToString());
                    objSuplemento.EditarSuplementacion(objSub);
                    MessageBox.Show("Suplementacion de calcio, Actualizado con exito", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                //Termino 
                limpiarCalcio();
                DeshabilitarCalcio();
                MostrarCalcio();
                cancelarCalcio();
                esEditarCalcio = "";
            }
            else
            {
                MessageBox.Show(validaCalcio(), "Ocurrio un error", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }

        private void btnEliminarCalcio_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult res = MessageBox.Show("¿Estas seguro que quieres eliminar registro?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (res == DialogResult.Yes)
                {
                    EntidadSuplementacion objSup = new EntidadSuplementacion();
                    objSup.id_embarazo = int.Parse(this.DataListado.CurrentRow.Cells[2].Value.ToString());
                    objSup.id_suplementacion = Convert.ToInt32(this.dataListadoCALCIO.CurrentRow.Cells[0].Value.ToString());

                    objSuplemento.EliminarSuplementacion(objSup);

                    MessageBox.Show("Registro Eliminado con exito", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    limpiarCalcio();
                    DeshabilitarCalcio();
                    cancelarCalcio();
                    esEditarCalcio = "";
                    MostrarCalcio();
                }
            }
            catch (Exception)
            {

                MessageBox.Show("Ocurrio un erro al eliminar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnEditarCalcio_Click(object sender, EventArgs e)
        {
            try
            {
                habilitarCalcio();
                esEditarCalcio = "SI";

               

                cmbCalcio.Enabled = false;

                this.btnEditarCalcio.Enabled = false;
                this.btnEliminarCalcio.Enabled = false;
                this.btnCancelarCalcio.Enabled = true;
                this.btnNuevoCalcio.Enabled = false;
                this.btnGuardarCalcio.Enabled = true;
            }
            catch (Exception)
            {

                
            }
        }

        private void dataListadoCALCIO_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            limpiarCalcio();
            DeshabilitarCalcio();
            cancelarCalcio();
            esEditarCalcio = "";
        }

        private void dataListadoCALCIO_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try

            {
                //creamos y llenamos calcio
                miCalcio = new List<string>();
                miCalcio.Add("1");
                miCalcio.Add("2");
                miCalcio.Add("3");
                miCalcio.Add("4");
                miCalcio.Add("5");

                foreach (string c in miCalcio)
                {
                    cmbCalcio.Items.Add(c);
                }

                esEditarCalcio = "";

                this.cmbCalcio.Text = this.dataListadoCALCIO.CurrentRow.Cells[2].Value.ToString();
                this.dtpfechaCalcio.Text = this.dataListadoCALCIO.CurrentRow.Cells[3].Value.ToString();

                this.btnEditarCalcio.Enabled = true;
                this.btnEliminarCalcio.Enabled = true;
                this.btnCancelarCalcio.Enabled = true;
                this.btnNuevoCalcio.Enabled = false;
                this.btnGuardarCalcio.Enabled = false;
            }
            catch (Exception)
            {

              
            }
        }

        private void btnVerCulminacion_Click(object sender, EventArgs e)
        {
            TapaEmbarazo.Dock = DockStyle.None;
            TapaEmbarazo.Visible = false;
        }

        private void btnVerPlanificacion_Click(object sender, EventArgs e)
        {
           bunifuTransition1.HideSync(TapaEmbarazo,true,BunifuAnimatorNS.Animation.Particles);
        }

        private void btnVerAdicional_Click(object sender, EventArgs e)
        {

        }

        private void cmbActividadRealizada_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        DataSet dst;
        private void btnImprimir_Click(object sender, EventArgs e)
        {
            if (DataListado.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione un embarazo para Imprimir", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            frmMascara fil = new frmMascara();
            frmImpresion imprimir = new frmImpresion();
            NegocioGestantes objGesta = new NegocioGestantes();

            int codigo = int.Parse(DataListado.CurrentRow.Cells[2].Value.ToString());
           dst = objGesta.Imprimir_Atenciones_Gestante_del_Embarazo(codigo);
            if(dst != null)
            {
                crReporteDatosPaciente reporte = new crReporteDatosPaciente();
                fil.Show();
                reporte.SetDataSource(dst.Tables[0]);
                //imprimir.crystalReportViewer1.Refresh();
                imprimir.crystalReportViewer1.ReportSource = reporte;
               
                imprimir.ShowDialog();
                fil.Hide();
            }
            
        }

        private void dataListadoExamen_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void tabControl1_MouseDown(object sender, MouseEventArgs e)
        {
        }

        private void tabControl1_KeyDown(object sender, KeyEventArgs e)
        {
            
        }

        private void frmEmbarazo_KeyDown(object sender, KeyEventArgs e)
        {
          
            if (e.KeyData == Keys.Escape)
            {
              DialogResult opcion=  MessageBox.Show("¿Desea salir de la ventana actual?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (opcion == DialogResult.Yes)
                {
                    this.Tag = "";
                    this.Close();
                }
                
            }
        }

        private void DataListado_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
