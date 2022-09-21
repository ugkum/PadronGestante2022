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
    public partial class frmAddGestante : Form
    {
        public frmAddGestante()
        {
            InitializeComponent();
        }

        //objetos de la clases NEGOCIOS
        NegocioEstablecimiento objEstablecimiento = new NegocioEstablecimiento();
        NegocioAdicional objAdicional = new NegocioAdicional();
        NegocioGestantes objGesta = new NegocioGestantes();
        NegocioAtencionPaciente objAtencion = new NegocioAtencionPaciente();
        NegocioDetalleUbicacion objDetUbicacion = new NegocioDetalleUbicacion();

        private int UltimoRegisto;

        void obtenerUltimoRegistro()
        {
            DataTable dt = objGesta.UltimoRegistro();
            if (dt.Rows.Count > 0)
            {
                UltimoRegisto =int.Parse( dt.Rows[0][0].ToString());
            }
        }
        void cargarDepartamento()
        {
            cmbDepartamento.DataSource = objEstablecimiento.ListarDepartamento();
            cmbDepartamento.DisplayMember = "Departamento";
            cmbDepartamento.ValueMember = "Departamento";
        }

       void cargarProvincia()
        {
            cmbProvincia.DataSource = objEstablecimiento.ListarProvinciaPorDep(cmbDepartamento.SelectedValue.ToString());
            cmbProvincia.DisplayMember = "Provincia";
            cmbProvincia.ValueMember = "Provincia";
        }

        void cargarDistrito()
        {
            cmbDistrito.DataSource = objEstablecimiento.ListarDistritoPorProvDep(cmbDepartamento.SelectedValue.ToString(), cmbProvincia.SelectedValue.ToString());
            cmbDistrito.DisplayMember = "Distrito";
            cmbDistrito.ValueMember = "Distrito";
        }

        void cargarDatosGestante()
        {
            if (lblCondicion.Text == "E")
            {
                //mostrar todos los datos de gestante
                int idGestante =int.Parse( lblIDGestante.Text);
                DataTable dstGe = objGesta.BuscarGestante_por_ID_Actualizar(idGestante);
                if(dstGe.Rows.Count>0)
                {
                    //gestante
                    cmbTipoDoc.Text = dstGe.Rows[0][1].ToString();
                    txtNroDocumento.Text = dstGe.Rows[0][2].ToString();
                    txtNombre.Text = dstGe.Rows[0][3].ToString();
                    txtPaterno.Text = dstGe.Rows[0][4].ToString();
                    txtMaterno.Text = dstGe.Rows[0][5].ToString();
                    txtFechaNac.Text = DateTime.Parse( dstGe.Rows[0][6].ToString()).ToShortDateString();
                    txtEdad.Text = dstGe.Rows[0][7].ToString();
                    cmbGrupoSanguineo.Text = dstGe.Rows[0][8].ToString();
                    txtTipoSangre.Text = dstGe.Rows[0][9].ToString();
                    txtTelefono.Text = dstGe.Rows[0][10].ToString();
                    //adicional
                    cmbTipoSeguro.Text = dstGe.Rows[0][11].ToString();
                    cmbIdioma.Text = dstGe.Rows[0][12].ToString();
                    cmbEtnia.Text = dstGe.Rows[0][13].ToString();
                    cmbNivelInstruccion.Text = dstGe.Rows[0][14].ToString();
                    cmbEstadoCivil.Text = dstGe.Rows[0][15].ToString();

                    //ubicacio
                    cmbDepartamento.Text = dstGe.Rows[0][22].ToString();
                    cmbProvincia.Text = dstGe.Rows[0][23].ToString();
                    cmbDistrito.Text = dstGe.Rows[0][24].ToString();
                    txtCentroPoblado.Text = dstGe.Rows[0][25].ToString();
                    txtDireccionActual.Text = dstGe.Rows[0][26].ToString(); 

                    lblRenaes.Text = dstGe.Rows[0][19].ToString();
                    lblMicroRed.Text = dstGe.Rows[0][20].ToString();
                    lblEstablecimiento.Text = dstGe.Rows[0][21].ToString();
                    //historia clinica
                    this.txtHistoriaCli.Text = dstGe.Rows[0][27].ToString();

                }
            }
        }
        public string dep, prov, distr;
        public string Renaes, micror, eess;

        private void frmAddGestante_Load(object sender, EventArgs e)
        {
            cargarDepartamento();
            cargarProvincia();
            cargarDistrito();
            if (lblCondicion.Text == "N")
            {
                cmbDepartamento.SelectedValue = dep;
                cmbProvincia.SelectedValue = prov;
                cmbDistrito.SelectedValue = distr;
            }
            if(lblCondicion.Text == "E")
            {
                cargarDatosGestante();
            }
                       
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Dispose();
            this.Tag = "A";
        }

        string SoloAgregar = "";
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (this.lblCondicion.Text == "N")
            {

                //Primero Buscar SI gestante existe en el establecimiento Actual, Si no Buscamos en otro Ipress, 
                try
                {
                    DataTable dtExiste = objGesta.buscar_gestante_en_ipress_actual(this.txtNroDocumento.Text, Convert.ToInt32(lblNombreIpress.Name));
                    if (dtExiste.Rows.Count > 0)
                    {
                        this.txtNroDocumento.Clear();
                        this.txtNroDocumento.Focus();

                        MessageBox.Show("Gestante ya existe en el extablecimiento actual", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }
                }
                catch (Exception)
                {

                  
                }
                //buscar gestante si esta registrado en otro establecimiento
                //si la gestante esta registrado en bd, solo mostrar informacion de gestante, y agregar en atencion
                DataTable dta = objGesta.BuscarGestante_por_dni(txtNroDocumento.Text);
                //ESTE GESTANTE ESTA ACTIVO ENTONCES VERIFICAMOS DONDE SE ESTA ATENDIENDO ACTUALMENTE
                if (dta.Rows.Count > 0)
                {
                    int idEss = int.Parse(dta.Rows[0][12].ToString());

                    //tiene atencion en el mismo EESS
                    if (idEss == int.Parse(lblNombreIpress.Name))
                    {

                        MessageBox.Show("Esta Gesatante ya fue registrado en el establecimiento actual,\n Por favor Intenta con la otra Gestante."
                            + "\n Dni : " + dta.Rows[0][2].ToString()
                            + "\n Nombre y Apellidos : " + dta.Rows[0][3].ToString() + " " + dta.Rows[0][4].ToString() + " " + dta.Rows[0][5].ToString()
                            + "\n Fecha de Nacimiento : " + dta.Rows[0][6].ToString()
                            + "\n Edad : " + dta.Rows[0][7].ToString(),
                            "Gestante Encontrada",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Exclamation);
                        txtNroDocumento.Clear();
                        txtNroDocumento.Focus();
                        txtNroDocumento.SelectAll();
                    }
                    //tiene atencion en otro EESS
                    else
                    {

                        SoloAgregar = "OK";

                        cargarDatosGestanteEncontradoEnOtroESS(this.txtNroDocumento.Text);

                        labelNombreGestante.Text = "Nombres y Apellidos : " + dta.Rows[0][3].ToString() + " " + dta.Rows[0][4].ToString() + " " + dta.Rows[0][5].ToString();
                        labelGestanteFechanac.Text = "Fecha de Nacimiento : " + DateTime.Parse(dta.Rows[0][7].ToString()).ToShortDateString();
                        labelGestanteEdad.Text = "Edad : " + dta.Rows[0][8].ToString();
                        labelGestanteOtro.Text = "Tipo Sangre : " + dta.Rows[0][10].ToString();
                        labelGestanteEESS.Text = "Codigo EE.SS : " + dta.Rows[0][12].ToString();
                        panelPregunta.Visible = true;

                    }
                }
            }
        }

        void cargarDatosGestanteEncontradoEnOtroESS(String DNI  )
        {
            DataTable dstSoloG = objGesta.BuscarGestante_por_dni_para_agregar_solo_atencion(DNI);
            if (dstSoloG.Rows.Count > 0)
            {
                //gestante
                lblIDGestante.Text=dstSoloG.Rows[0][0].ToString();
                cmbTipoDoc.Text = dstSoloG.Rows[0][1].ToString();
                //txtNroDocumento.Text = dstSoloG.Rows[0][2].ToString();
                txtNombre.Text = dstSoloG.Rows[0][3].ToString();
                txtPaterno.Text = dstSoloG.Rows[0][4].ToString();
                txtMaterno.Text = dstSoloG.Rows[0][5].ToString();
                txtFechaNac.Text = DateTime.Parse(dstSoloG.Rows[0][6].ToString()).ToShortDateString();
                txtEdad.Text = dstSoloG.Rows[0][7].ToString();
                txtTipoSangre.Text = dstSoloG.Rows[0][8].ToString();

                //adicional
                cmbTipoSeguro.Text = dstSoloG.Rows[0][9].ToString();
                cmbIdioma.Text = dstSoloG.Rows[0][10].ToString();
                cmbEtnia.Text = dstSoloG.Rows[0][11].ToString();
                cmbNivelInstruccion.Text = dstSoloG.Rows[0][12].ToString();
                cmbEstadoCivil.Text = dstSoloG.Rows[0][13].ToString();

                //ubicacio
                cmbDepartamento.Text = dstSoloG.Rows[0][20].ToString();
                cmbProvincia.Text = dstSoloG.Rows[0][21].ToString();
                cmbDistrito.Text = dstSoloG.Rows[0][22].ToString();
                txtCentroPoblado.Text = dstSoloG.Rows[0][23].ToString();
                lblRenaes.Text = dstSoloG.Rows[0][17].ToString();
                lblMicroRed.Text = dstSoloG.Rows[0][18].ToString();
                lblEstablecimiento.Text = dstSoloG.Rows[0][19].ToString();

                //historia clinica
                this.txtHistoriaCli.Text= dstSoloG.Rows[0][24].ToString();
            }
        }
        private void comboBox1_Enter(object sender, EventArgs e)
        {
            this.cmbTipoDoc.BackColor = Color.Yellow;
        }

        private void comboBox1_Leave(object sender, EventArgs e)
        {
            this.cmbTipoDoc.BackColor = Color.White;
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            this.txtNroDocumento.BackColor = Color.Yellow;
        }

        private void txtNroDocumento_Leave(object sender, EventArgs e)
        {
            this.txtNroDocumento.BackColor = Color.White;
        }

        private void txtNombre_Enter(object sender, EventArgs e)
        {
            this.txtNombre.BackColor = Color.Yellow;
        }

        private void txtNombre_Leave(object sender, EventArgs e)
        {
            this.txtNombre.BackColor = Color.White;
        }

        private void txtPaterno_Enter(object sender, EventArgs e)
        {
            this.txtPaterno.BackColor = Color.Yellow;
        }

        private void txtPaterno_Leave(object sender, EventArgs e)
        {
            this.txtPaterno.BackColor = Color.White;
        }

        private void txtMaterno_Enter(object sender, EventArgs e)
        {
            this.txtMaterno.BackColor = Color.Yellow;
        }

        private void txtMaterno_Leave(object sender, EventArgs e)
        {
            this.txtMaterno.BackColor = Color.White;
        }

        private void txtFechaNac_Enter(object sender, EventArgs e)
        {
            this.txtFechaNac.BackColor = Color.Yellow;
        }

        private void txtFechaNac_Leave(object sender, EventArgs e)
        {
            this.txtFechaNac.BackColor = Color.White;
           if(EsFecha(txtFechaNac.Text) == false)
            {
                errorProvider1.SetError(txtFechaNac, "Fecha no valida!");
            }
            else
            {
                errorProvider1.Clear();
            }
        }

        private void txtEdad_Enter(object sender, EventArgs e)
        {
            this.txtEdad.BackColor = Color.Yellow;
        }

        private void txtEdad_Leave(object sender, EventArgs e)
        {
            this.txtEdad.BackColor = Color.White;
        }

        private void txtTipoSangre_Enter(object sender, EventArgs e)
        {
            this.txtTipoSangre.BackColor = Color.Yellow;
        }

        private void txtTipoSangre_Leave(object sender, EventArgs e)
        {
            this.txtTipoSangre.BackColor = Color.White;
        }

        private void txtCentroPoblado_Enter(object sender, EventArgs e)
        {
            txtCentroPoblado.BackColor = Color.Yellow;
        }

        private void txtCentroPoblado_Leave(object sender, EventArgs e)
        {
            txtCentroPoblado.BackColor = Color.White;
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        void limpiar()
        {
            cmbTipoDoc.Text="";
            txtNroDocumento.Clear();
            txtNombre.Clear();
            txtPaterno.Clear();
            txtMaterno.Clear();
            txtFechaNac.Clear();
            txtEdad.Clear();
            txtTipoSangre.SelectedIndex = -1;
            cmbTipoSeguro.SelectedIndex = -1;
            cmbIdioma.SelectedIndex = -1;
            cmbEtnia.SelectedIndex = -1;
            cmbNivelInstruccion.SelectedIndex = -1;
            cmbEstadoCivil.SelectedIndex = -1;
            cmbDepartamento.SelectedText=dep;
            cmbProvincia.SelectedText = prov;
            cmbDistrito.SelectedText = distr;
            txtCentroPoblado.Clear();
            txtHistoriaCli.Clear();
            cmbTipoDoc.Focus();
        }
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (validar() != "")
            {
                MessageBox.Show("Por favor ingrese, " + validar(), "Sistema de Validacion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            //datos del gestante
            EntidadGestante objEg = new EntidadGestante();
            objEg.tipoDoc = cmbTipoDoc.Text;
            objEg.nroDoc = txtNroDocumento.Text;
            objEg.nombre = txtNombre.Text;
            objEg.paterno = txtPaterno.Text;
            objEg.materno= txtMaterno.Text;
            objEg.id_ipress =int.Parse( lblNombreIpress.Name);
            objEg.fechaNac = DateTime.Parse(txtFechaNac.Text);
            objEg.edad = int.Parse(txtEdad.Text);
            objEg.grupo_sanguineo = cmbGrupoSanguineo.Text;
            objEg.tipo_sangre = txtTipoSangre.Text;

            if (txtTelefono.Text.Trim().Length == 0){ objEg.telefono = "";} else{objEg.telefono = txtTelefono.Text;}
            if(txtNombre2.Text.Trim().Length==0){objEg.nombre2 = "";}else{objEg.nombre2=txtNombre2.Text;}
            
            //datos adicionales
            EntidadAdicional objEa = new EntidadAdicional();
            objEa.tipoSeguro = cmbTipoSeguro.Text;
            objEa.lengua = cmbIdioma.Text;
            objEa.etnia = cmbEtnia.Text;
            objEa.nivel_instruccion = cmbNivelInstruccion.Text;
            objEa.estado_civil = cmbEstadoCivil.Text;
            

            if (lblCondicion.Text == "N")
            {
                //gestante ya existe , solo agregar atencion
                if (SoloAgregar == "OK")
                {
                    //Cambiar estado de Gestate Atual
                    objAtencion.EditarAtencionGestanteEstado(int.Parse(lblIDGestante.Text), "DESACTIVO");
                    //detalle de la ubicacion
                    objDetUbicacion.EditarUbicacion(this.cmbDepartamento.Text, this.cmbProvincia.Text, this.cmbDistrito.Text, this.txtCentroPoblado.Text,this.txtDireccionActual.Text, int.Parse(lblIDGestante.Text));
                    //agregar paciente al ess actual
                    objAtencion.registrarAtencionGestante( int.Parse( lblIDGestante.Text), int.Parse(lblNombreIpress.Name), this.txtHistoriaCli.Text, "ACTIVO");
                   
                }
                else
                {
                    //registrar
                    //registrar primero gestantes
                    objGesta.registrarGestante(objEg);

                    //obtener id de ultimo gestante
                    obtenerUltimoRegistro();

                    objEa.id_gestante = UltimoRegisto;

                    //detalle de la ubicacion
                    objDetUbicacion.RegistrarUbicacion(this.cmbDepartamento.Text, this.cmbProvincia.Text, this.cmbDistrito.Text, this.txtCentroPoblado.Text,this.txtDireccionActual.Text, UltimoRegisto);

                    //registrar datos adicional de gestante
                    objAdicional.registrarAdicional(objEa);

                    //registrar donde se atendera gestante
                    objAtencion.registrarAtencionGestante(UltimoRegisto, int.Parse(lblNombreIpress.Name), this.txtHistoriaCli.Text, "ACTIVO");
                }
               


                MessageBox.Show("Gestante Registrado Safisfactoriamente", "Registro de Gestante", MessageBoxButtons.OK, MessageBoxIcon.Information);

                limpiar();
            }
            
            
            this.Tag = "A";
            this.Dispose();
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Tag = "A";
            this.Dispose();
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

        private void txtFechaNac_Validating(object sender, CancelEventArgs e)
        {
            
        }

        private void btnGuardarCambios_Click(object sender, EventArgs e)
        {
            if (validar() != "")
            {
                MessageBox.Show("Por favor ingrese, " + validar(), "Sistema de Validacion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            //datos del gestante
            EntidadGestante objEg = new EntidadGestante();
            objEg.id_gestantes = int.Parse(lblIDGestante.Text);
            objEg.tipoDoc = cmbTipoDoc.Text;
            objEg.nroDoc = txtNroDocumento.Text;
            objEg.nombre = txtNombre.Text;
            objEg.paterno = txtPaterno.Text;
            objEg.materno = txtMaterno.Text;
            objEg.id_ipress = int.Parse(lblNombreIpress.Name);
            objEg.fechaNac = DateTime.Parse(txtFechaNac.Text);
            objEg.edad = int.Parse(txtEdad.Text);
            objEg.grupo_sanguineo = cmbGrupoSanguineo.Text;
            objEg.tipo_sangre = txtTipoSangre.Text;
            if (txtTelefono.Text.Trim().Length == 0)
            {
                objEg.telefono = "";
            }
            else
            {
                objEg.telefono = txtTelefono.Text;
            }

            if (txtNombre2.Text.Trim().Length == 0) { objEg.nombre2 = ""; } else { objEg.nombre2 = txtNombre2.Text; }


            //detalle de la ubicacion

            //datos adicionales
            EntidadAdicional objEa = new EntidadAdicional();
            objEa.tipoSeguro = cmbTipoSeguro.Text;
            objEa.lengua = cmbIdioma.Text;
            objEa.etnia = cmbEtnia.Text;
            objEa.nivel_instruccion = cmbNivelInstruccion.Text;
            objEa.estado_civil = cmbEstadoCivil.Text;
            objEa.id_gestante = int.Parse(lblIDGestante.Text);

            if (lblCondicion.Text == "E")
            {
                //registrar
                //registrar primero gestantes
                objGesta.EditarGestante(objEg);

                //registrar datos adicional de gestante
                objAdicional.EditarAdicional(objEa);

                //detalle de la ubicacion
                objDetUbicacion.EditarUbicacion(this.cmbDepartamento.Text, this.cmbProvincia.Text, this.cmbDistrito.Text, this.txtCentroPoblado.Text,this.txtDireccionActual.Text, int.Parse(lblIDGestante.Text));
               
                //registrar donde se atendera gestante
                //objAtencion.EditarAtencionGestante(UltimoRegisto, int.Parse(lblNombreIpress.Name));

                MessageBox.Show("Datos de la Gestante han sido Actualizado Satisfactoriamente", "Actualizacion de Gestante", MessageBoxButtons.OK, MessageBoxIcon.Information);

                limpiar();
            }


            this.Tag = "A";
            this.Dispose();
        }

        private void lblIDGestante_Click(object sender, EventArgs e)
        {

        }

        string validar()
        {
            if (this.cmbTipoDoc.Text == "")
            {
                this.cmbTipoDoc.Focus();
                return " Tipo Docuemnto.";
            } else if (this.txtNroDocumento.Text.Trim().Length == 0)
            {
                this.txtNroDocumento.Focus();
                return " Nro Documento";
            } else if (this.txtNombre.Text.Trim().Length == 0)
            {
                this.txtNombre.Focus();
                return " Nombre de la Gestante";
            } else if (this.txtPaterno.Text.Trim().Length == 0)
            {
                this.txtPaterno.Focus();
                return " Apellido Paterno de la Gestante";
            } else if (this.txtMaterno.Text.Trim().Length == 0)
            {
                this.txtMaterno.Focus();
                return " Apellido Materno de la Gestante";
            } else if (this.txtFechaNac.Text.Trim().Length == 0 || EsFecha(this.txtFechaNac.Text) == false)
            {
                this.txtFechaNac.Focus();
                return " Fecha Nacimiento Valido";
            } else if (this.txtEdad.Text.Trim().Length == 0)
            {
                this.txtEdad.Focus();
                return " Edad de la Gestante";
            } else if (this.txtHistoriaCli.Text.Trim().Length == 0)
            {
                this.txtHistoriaCli.Focus();
                return " Historia Clinica de la Gestante";
            }
            else if (this.txtTipoSangre.Text == "")
            {
                this.txtTipoSangre.Focus();
                return " Tipo de Sangre";
            }
            else if (this.cmbTipoSeguro.Text == "")
            {
                this.cmbTipoSeguro.Focus();
                return " Tipo de Seguro";
            } else if (this.cmbIdioma.Text == "")
            {
                this.cmbIdioma.Focus();
                return " Lengua/Idioma";

            } else if (this.cmbEtnia.Text == "")
            {
                this.cmbEtnia.Focus();
                return " Etnia";
            } else if (this.cmbNivelInstruccion.Text == "")
            {
                this.cmbNivelInstruccion.Focus();
                return " Nivel Instrucción";
            } else if (this.cmbEstadoCivil.Text == "")
            {
                this.cmbEstadoCivil.Focus();
                return " Estado Civil";
            } else if (this.txtCentroPoblado.Text.Trim().Length == 0) 
            {
                this.txtCentroPoblado.Focus();
                return " Centro Poblado";
            }
            else if (this.cmbDepartamento.Text=="")
            {
                this.cmbDepartamento.Focus();
                return " Departamento";
            }else if (this.cmbProvincia.Text=="")
            {
                this.cmbProvincia.Focus();
                return " Provincia";
            }else if (this.cmbDistrito.Text=="")
            {
                this.cmbDistrito.Focus();
                return " Distrito";
            }else if (this.txtCentroPoblado.Text.Trim().Length == 0)
            {
                this.txtCentroPoblado.Focus();
                return " Centro Poblado";
            }else if (this.cmbGrupoSanguineo.Text=="")
            {
                this.cmbGrupoSanguineo.Focus();
                return " Grupo Sanguineo";
            }else if (this.txtDireccionActual.Text.Trim().Length == 0)
            {
                this.txtDireccionActual.Focus();
                return " Direccion Actual";
            }
            else
            {
                return "";
            }
            
        }
        private void button3_Click(object sender, EventArgs e)
        {
            this.panelPregunta.Visible = false;
            limpiar();

            lblRenaes.Text = Renaes;
            lblMicroRed.Text = micror;
            lblEstablecimiento.Text = eess;

            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.panelPregunta.Visible = false;
            lblRenaes.Text = Renaes;
            lblMicroRed.Text = micror;
            lblEstablecimiento.Text = eess;
        }

        private void panelPregunta_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtFechaNac_TextChanged(object sender, EventArgs e)
        {

            try
            {
                if (this.txtFechaNac.Text.Trim().Length == 2)
                {
                    this.txtFechaNac.Text = this.txtFechaNac.Text + "/";
                    this.txtFechaNac.Select(txtFechaNac.Text.Length, 0);
                }
                else if (this.txtFechaNac.Text.Trim().Length == 5)
                {
                    this.txtFechaNac.Text = this.txtFechaNac.Text + "/";
                    this.txtFechaNac.Select(txtFechaNac.Text.Length, 0);
                }

                DateTime dat = Convert.ToDateTime(this.txtFechaNac.Text);
                DateTime nacimiento = new DateTime(dat.Year, dat.Month, dat.Day);
                int edad = DateTime.Today.AddTicks(-nacimiento.Ticks).Year - 1;
                txtEdad.Text = edad.ToString();
            }
            catch (Exception)
            {

              
            }
            
        }

        private void txtNroDocumento_KeyPress(object sender, KeyPressEventArgs e)
        {
            
            if (char.IsNumber(e.KeyChar))
            {
                e.Handled = false;
            }else if (char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }else if (char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
                
        }

        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar))
            {
                e.Handled = false;
            }else if (char.IsSeparator(e.KeyChar)) 
            {
                e.Handled = false;
            }else if (char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void txtPaterno_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (char.IsSeparator(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void txtTelefono_Enter(object sender, EventArgs e)
        {
            this.txtTelefono.BackColor = Color.Yellow;
        }

        private void txtTelefono_Leave(object sender, EventArgs e)
        {
            this.txtTelefono.BackColor = Color.White;
        }

        private void txtHistoriaCli_Enter(object sender, EventArgs e)
        {
            txtHistoriaCli.BackColor = Color.Yellow;
        }

        private void txtHistoriaCli_Leave(object sender, EventArgs e)
        {
            txtHistoriaCli.BackColor = Color.White;
        }

        private void txtDireccionActual_Enter(object sender, EventArgs e)
        {
            txtDireccionActual.BackColor = Color.Yellow;
        }

        private void txtDireccionActual_Leave(object sender, EventArgs e)
        {
            txtDireccionActual.BackColor = Color.White;
        }

        private void txtNombre2_Enter(object sender, EventArgs e)
        {
            txtNombre2.BackColor = Color.Yellow;
        }

        private void txtNombre2_Leave(object sender, EventArgs e)
        {
            txtNombre2.BackColor = Color.White;
        }

        private void txtMaterno_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (char.IsSeparator(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void txtEdad_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsNumber(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void cmbDepartamento_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                cargarProvincia();
            }
            catch (Exception)
            {

                
            }
        }

        private void cmbProvincia_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                cargarDistrito();
            }
            catch (Exception)
            {

                
            }
        }
    }
}
