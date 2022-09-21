using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using CapaNegocio;
using CapaEntidad;

namespace CapaPresentacion
{
    public partial class frmEstablecimiento : Form
    {
        public frmEstablecimiento()
        {
            InitializeComponent();
        }


        //objeto de la clase NegocioIpress
        NegocioIpress objIpress = new NegocioIpress();


        private void frmEstablecimiento_Load(object sender, EventArgs e)
        {

        }

        void mostrar()
        {
            dataListado.DataSource = objIpress.ListarIpress();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
          mostrar();
        }

        void limpiar()
        {
            this.txtRenaes.Clear();
            this.txtNombre.Clear();
            this.txtMicrored.Clear();
            this.txtRed.Clear();
            this.txtRenaes.Focus();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            EntidadIpress objI = new EntidadIpress();
           
            objI.renaes = this.txtRenaes.Text;
            objI.nombre = this.txtNombre.Text;
            objI.microred = this.txtMicrored.Text;  
            objI .red=this.txtRed.Text;
            objI.estado = "ACTIVO";

            try
            {
                objIpress.InsertarIpress(objI);
                mostrar();
                limpiar();
            }
            catch (Exception)
            {

                MessageBox.Show("Ocurrio un error al registrar Ipress", "Error de registro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
