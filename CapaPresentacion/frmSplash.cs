using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class frmSplash : Form
    {
        public frmSplash()
        {
            InitializeComponent();
        }

        private void frmSplash_Load(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            timer1.Interval = 1500;
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            while(this.Opacity > 0)
            {
                this.Opacity-=0.00001;
            }
            this.Hide();
            timer1.Stop();
            frmConexionConfigurado objP = new frmConexionConfigurado();
            objP.Show();
           
        }
    }
}
