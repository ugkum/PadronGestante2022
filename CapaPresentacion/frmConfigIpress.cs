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
    public partial class frmConfigIpress : Form
    {
        public frmConfigIpress()
        {
            InitializeComponent();
        }

        NegocioEstablecimiento objEstable = new NegocioEstablecimiento();
        NegocioIpressUbicacion objIpressUbicacion = new NegocioIpressUbicacion();   

        void cargarRed()
        {
            this.cmbRed.DataSource = objEstable.ListarRed();
            this.cmbRed.DisplayMember = "Red";
            this.cmbRed.ValueMember = "Red";
        }

        void cargarMicroRed(string red)
        {
            this.cmbMicroRed.DataSource=objEstable.ListarMicrored(red);
            this.cmbMicroRed.DisplayMember = "Microred";
            this.cmbMicroRed.ValueMember = "Microred";
        }

        void cargarUbicacionIpress()
        {
            DataTable fila = objIpressUbicacion.ListarUbicacionIpress();
            if (fila.Rows.Count > 0)
            {
                //mostrar
                cmbRed.Text = fila.Rows[0].ItemArray[1].ToString();
                cmbMicroRed.Text = fila.Rows[0].ItemArray[2].ToString();  
            }
            else
            {
                //primera vez
                cmbMicroRed.Text = null;
                cmbRed.Text = null;
            }

        }

        private void frmConfigIpress_Load(object sender, EventArgs e)
        {
            cargarRed();
            cargarUbicacionIpress();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void cmbRed_SelectionChangeCommitted(object sender, EventArgs e)
        {
           
        }

        private void cmbRed_SelectedIndexChanged(object sender, EventArgs e)
        {

            cargarMicroRed(this.cmbRed.Text);
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            DataTable fila = objIpressUbicacion.ListarUbicacionIpress();
            if(fila.Rows.Count > 0)
            {
                //modificar
                objIpressUbicacion.modificarUbicacion(this.cmbRed.Text, this.cmbMicroRed.Text);
                MessageBox.Show("Ubicacion de Establecimiento, Actualizado Satisfactoriamente", "Padron Gestante", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Tag = "A";
                this.Close();
            }
            else
            {
                //insertar
                objIpressUbicacion.insertarUbicacion(this.cmbRed.Text, this.cmbMicroRed.Text);
                MessageBox.Show("Ubicacion de Establecimiento, Registrado Satisfactoriamente", "Padron Gestante", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Tag = "A";
                this.Close();
            }
        }
    }
}
