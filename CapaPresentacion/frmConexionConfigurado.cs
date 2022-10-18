using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using CapaNegocio;

namespace CapaPresentacion
{
    public partial class frmConexionConfigurado : Form
    {
        public frmConexionConfigurado()
        {
            InitializeComponent();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnConectar_Click(object sender, EventArgs e)
        {

            CapaNegocio.PropiedadConexion.servidor = this.txtServidor.Text;
            CapaNegocio.PropiedadConexion.basedatos = this.txtBaseDeDatos.Text;
            CapaNegocio.PropiedadConexion.usua = this.txtUsuario.Text;
            CapaNegocio.PropiedadConexion.pass = this.txtContrasena.Text;

            CapaNegocio.PropiedadConexion objC = new CapaNegocio.PropiedadConexion();
            objC.Conectar();
            frmPrincipal frmPrincipal = new frmPrincipal();
            frmPrincipal.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                PropiedadConexion objCon = new PropiedadConexion();
                objCon.servidor = this.txtServidor.Text;
                objCon.baseDatos = this.txtBaseDeDatos.Text;
                objCon.usuario = this.txtUsuario.Text;
                objCon.clave = this.txtContrasena.Text;

                SaveFileDialog sv = new SaveFileDialog();
                sv.Filter = "Archivo Binario|*.bin";
                sv.Title = "Guardar Archivo de Conexion";
                sv.InitialDirectory= @"C:\RSC_PADRON_GESTANTE_2022\ConexionBaseDatos\";
                if(sv.ShowDialog() == DialogResult.OK)
                {
                   
                    FileStream fs = new FileStream(sv.FileName,FileMode.Create);
                    BinaryFormatter bf = new BinaryFormatter();
                    
                    bf.Serialize(fs, objCon);
                    fs.Close();
                    fs.Dispose();

                   
                    MessageBox.Show("Archivo de conexion se guardo correctamente","Guardar Cadena",MessageBoxButtons.OK,MessageBoxIcon.Information);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Ocurrio al guardar Archivo de Conexion", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);


            }
        }

        private void frmConexionConfigurado_Load(object sender, EventArgs e)
        {
            try
            {
                string[] archivos = Directory.GetFiles(@"C:\RSC_PADRON_GESTANTE_2022\ConexionBaseDatos");
                foreach (string archivo in archivos)
                {
                   FileStream fs = new FileStream(archivo,FileMode.Open);
                    BinaryFormatter b = new BinaryFormatter();
                  PropiedadConexion objPC=(PropiedadConexion)  (b.Deserialize(fs));
                    this.txtServidor.Text = objPC.servidor;
                    this.txtBaseDeDatos.Text = objPC.baseDatos;
                    this.txtUsuario.Text=objPC.usuario;
                    this.txtContrasena.Text=objPC.clave;
                    fs.Close();
                    fs.Dispose();
                }
            }
            catch (Exception)
            {

                
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog ofd = new OpenFileDialog();
            }
            catch (Exception)
            {

              
            }
        }
    }
}
