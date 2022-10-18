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
            this.Tag = "";
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (txtClave.Text.Trim().Length == 0)
            {
                MessageBox.Show("Ingrese clave","Clave de activacion",MessageBoxButtons.OK,MessageBoxIcon.Information);
                return;
            }
            if (Properties.Settings.Default.ProductoRegistrado == true)
            {
                MessageBox.Show("Producto Activo", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (txtClave.Text == Properties.Settings.Default.Serial)
            {
                
                MessageBox.Show("Producto registrado con exito","Activado",MessageBoxButtons.OK,MessageBoxIcon.Information);
                Properties.Settings.Default.ProductoRegistrado = true;
                Properties.Settings.Default.FechaCaducidad = DateTime.Now.AddMonths(3);
                Properties.Settings.Default.Save();
                this.Tag = "A";
                    
                this.Close();
            }
            else
            {
                MessageBox.Show("Clave invalida","Informacion",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            
        }
    }
}
