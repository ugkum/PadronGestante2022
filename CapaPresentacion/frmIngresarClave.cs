using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class frmIngresarClave : Form
    {
        public frmIngresarClave()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (txtClave.Text.Trim().Length == 0)
            {
                MessageBox.Show("Ingrese clave");
                return;
            }

            if (txtClave.Text == Properties.Settings.Default.Serial)
            {
                MessageBox.Show("Producto registrado con exito");
                Properties.Settings.Default.ProductoRegistrado = true;
                Properties.Settings.Default.FechaCaducidad = DateTime.Now.AddSeconds(10);
                Properties.Settings.Default.Save();
                this.Tag = "A";
                    
                this.Close();
            }
            else
            {
                MessageBox.Show("Clave invalida");
            }
            
        }
    }
}
