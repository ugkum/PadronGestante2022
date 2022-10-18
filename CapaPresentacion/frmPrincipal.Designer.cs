namespace CapaPresentacion
{
    partial class frmPrincipal
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPrincipal));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.lblMicrored = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel7 = new System.Windows.Forms.Panel();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.lblMensajeBien = new System.Windows.Forms.Label();
            this.DataListado = new System.Windows.Forms.DataGridView();
            this.Eli = new System.Windows.Forms.DataGridViewImageColumn();
            this.Edi = new System.Windows.Forms.DataGridViewImageColumn();
            this.Ver = new System.Windows.Forms.DataGridViewImageColumn();
            this.id_gestante = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tipo_doc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.num_doc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nombre_apellido = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fecha_nac = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.edad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.estado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.id_ges = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.condicion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel4 = new System.Windows.Forms.Panel();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lblFalta = new System.Windows.Forms.Label();
            this.lblFechaCaducidad = new System.Windows.Forms.Label();
            this.lblTiempo = new System.Windows.Forms.Label();
            this.lblNotificacion = new System.Windows.Forms.Label();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.rbTodo = new System.Windows.Forms.RadioButton();
            this.rbIactivo = new System.Windows.Forms.RadioButton();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.usuarioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.verRadarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reporteGeneralToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importarPadronGestanteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.eportarPadronNomimalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.recuperarClaveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.ayudaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.verMasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.configurarConexionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.activarProductoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.limpiarBDToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cerrarSistemaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rbActivo = new System.Windows.Forms.RadioButton();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.txtBuscar = new System.Windows.Forms.TextBox();
            this.panel6 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.bunifuElipse1 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.bunifuElipse2 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.bunifuElipse3 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataListado)).BeginInit();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.panel1.Controls.Add(this.flowLayoutPanel1);
            this.panel1.Controls.Add(this.lblMicrored);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(204, 504);
            this.panel1.TabIndex = 0;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.BackColor = System.Drawing.Color.Transparent;
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 75);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(204, 429);
            this.flowLayoutPanel1.TabIndex = 3;
            this.flowLayoutPanel1.Paint += new System.Windows.Forms.PaintEventHandler(this.flowLayoutPanel1_Paint);
            // 
            // lblMicrored
            // 
            this.lblMicrored.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblMicrored.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblMicrored.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMicrored.ForeColor = System.Drawing.Color.White;
            this.lblMicrored.Location = new System.Drawing.Point(0, 0);
            this.lblMicrored.Name = "lblMicrored";
            this.lblMicrored.Size = new System.Drawing.Size(204, 75);
            this.lblMicrored.TabIndex = 1;
            this.lblMicrored.Text = "MICRO RED GALILEA";
            this.lblMicrored.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblMicrored.Click += new System.EventHandler(this.lblMicrored_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.panel5);
            this.panel2.Controls.Add(this.DataListado);
            this.panel2.Controls.Add(this.panel4);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(204, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1021, 504);
            this.panel2.TabIndex = 1;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.panel7);
            this.panel5.Controls.Add(this.pictureBox3);
            this.panel5.Controls.Add(this.lblMensajeBien);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(0, 58);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(824, 446);
            this.panel5.TabIndex = 3;
            // 
            // panel7
            // 
            this.panel7.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel7.BackColor = System.Drawing.Color.LightCoral;
            this.panel7.Location = new System.Drawing.Point(14, 373);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(806, 1);
            this.panel7.TabIndex = 2;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::CapaPresentacion.Properties.Resources.grifo;
            this.pictureBox3.Location = new System.Drawing.Point(420, 201);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(67, 94);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox3.TabIndex = 1;
            this.pictureBox3.TabStop = false;
            // 
            // lblMensajeBien
            // 
            this.lblMensajeBien.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblMensajeBien.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblMensajeBien.Font = new System.Drawing.Font("Segoe UI Semibold", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMensajeBien.ForeColor = System.Drawing.Color.LightCoral;
            this.lblMensajeBien.Location = new System.Drawing.Point(11, 298);
            this.lblMensajeBien.Name = "lblMensajeBien";
            this.lblMensajeBien.Size = new System.Drawing.Size(812, 72);
            this.lblMensajeBien.TabIndex = 0;
            this.lblMensajeBien.Text = "Seleccione un Establecimiento";
            this.lblMensajeBien.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // DataListado
            // 
            this.DataListado.AllowUserToAddRows = false;
            this.DataListado.AllowUserToDeleteRows = false;
            this.DataListado.AllowUserToResizeRows = false;
            this.DataListado.BackgroundColor = System.Drawing.Color.White;
            this.DataListado.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.DataListado.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.DataListado.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.DataListado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataListado.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Eli,
            this.Edi,
            this.Ver,
            this.id_gestante,
            this.tipo_doc,
            this.num_doc,
            this.nombre_apellido,
            this.fecha_nac,
            this.edad,
            this.estado,
            this.id_ges,
            this.condicion});
            this.DataListado.Cursor = System.Windows.Forms.Cursors.Default;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DataListado.DefaultCellStyle = dataGridViewCellStyle2;
            this.DataListado.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DataListado.GridColor = System.Drawing.Color.White;
            this.DataListado.Location = new System.Drawing.Point(0, 58);
            this.DataListado.MultiSelect = false;
            this.DataListado.Name = "DataListado";
            this.DataListado.ReadOnly = true;
            this.DataListado.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.DataListado.RowHeadersVisible = false;
            this.DataListado.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DataListado.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.DataListado.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black;
            this.DataListado.RowTemplate.Height = 48;
            this.DataListado.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DataListado.Size = new System.Drawing.Size(824, 446);
            this.DataListado.TabIndex = 4;
            this.DataListado.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataListado_CellClick);
            this.DataListado.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataListado_CellContentClick);
            this.DataListado.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataListado_CellDoubleClick);
            this.DataListado.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.DataListado_CellFormatting);
            // 
            // Eli
            // 
            this.Eli.HeaderText = "";
            this.Eli.Image = ((System.Drawing.Image)(resources.GetObject("Eli.Image")));
            this.Eli.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.Eli.Name = "Eli";
            this.Eli.ReadOnly = true;
            // 
            // Edi
            // 
            this.Edi.HeaderText = "";
            this.Edi.Image = ((System.Drawing.Image)(resources.GetObject("Edi.Image")));
            this.Edi.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.Edi.Name = "Edi";
            this.Edi.ReadOnly = true;
            // 
            // Ver
            // 
            this.Ver.HeaderText = "";
            this.Ver.Image = ((System.Drawing.Image)(resources.GetObject("Ver.Image")));
            this.Ver.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.Ver.Name = "Ver";
            this.Ver.ReadOnly = true;
            // 
            // id_gestante
            // 
            this.id_gestante.HeaderText = "ID";
            this.id_gestante.Name = "id_gestante";
            this.id_gestante.ReadOnly = true;
            // 
            // tipo_doc
            // 
            this.tipo_doc.HeaderText = "TIPO DOC.";
            this.tipo_doc.Name = "tipo_doc";
            this.tipo_doc.ReadOnly = true;
            // 
            // num_doc
            // 
            this.num_doc.HeaderText = "NRO DCMTO";
            this.num_doc.Name = "num_doc";
            this.num_doc.ReadOnly = true;
            // 
            // nombre_apellido
            // 
            this.nombre_apellido.HeaderText = "NOMBRE Y APELLIDOS";
            this.nombre_apellido.Name = "nombre_apellido";
            this.nombre_apellido.ReadOnly = true;
            // 
            // fecha_nac
            // 
            this.fecha_nac.HeaderText = "FECHA NAC.";
            this.fecha_nac.Name = "fecha_nac";
            this.fecha_nac.ReadOnly = true;
            // 
            // edad
            // 
            this.edad.HeaderText = "EDAD";
            this.edad.Name = "edad";
            this.edad.ReadOnly = true;
            // 
            // estado
            // 
            this.estado.HeaderText = "ESTADO";
            this.estado.Name = "estado";
            this.estado.ReadOnly = true;
            // 
            // id_ges
            // 
            this.id_ges.HeaderText = "ID_GESTANTE";
            this.id_ges.Name = "id_ges";
            this.id_ges.ReadOnly = true;
            this.id_ges.Visible = false;
            // 
            // condicion
            // 
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.condicion.DefaultCellStyle = dataGridViewCellStyle1;
            this.condicion.HeaderText = "CONDICIÓN";
            this.condicion.Name = "condicion";
            this.condicion.ReadOnly = true;
            this.condicion.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.flowLayoutPanel2);
            this.panel4.Controls.Add(this.pictureBox1);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel4.Location = new System.Drawing.Point(824, 58);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(197, 446);
            this.panel4.TabIndex = 2;
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.AutoScroll = true;
            this.flowLayoutPanel2.BackColor = System.Drawing.Color.White;
            this.flowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(197, 373);
            this.flowLayoutPanel2.TabIndex = 1;
            this.flowLayoutPanel2.Visible = false;
            this.flowLayoutPanel2.Paint += new System.Windows.Forms.PaintEventHandler(this.flowLayoutPanel2_Paint);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(0, 373);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(197, 73);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.White;
            this.panel3.Controls.Add(this.lblFalta);
            this.panel3.Controls.Add(this.lblFechaCaducidad);
            this.panel3.Controls.Add(this.lblTiempo);
            this.panel3.Controls.Add(this.lblNotificacion);
            this.panel3.Controls.Add(this.pictureBox4);
            this.panel3.Controls.Add(this.rbTodo);
            this.panel3.Controls.Add(this.rbIactivo);
            this.panel3.Controls.Add(this.menuStrip1);
            this.panel3.Controls.Add(this.rbActivo);
            this.panel3.Controls.Add(this.pictureBox2);
            this.panel3.Controls.Add(this.txtBuscar);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1021, 58);
            this.panel3.TabIndex = 1;
            // 
            // lblFalta
            // 
            this.lblFalta.AutoSize = true;
            this.lblFalta.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFalta.Location = new System.Drawing.Point(16, 29);
            this.lblFalta.Name = "lblFalta";
            this.lblFalta.Size = new System.Drawing.Size(0, 21);
            this.lblFalta.TabIndex = 8;
            // 
            // lblFechaCaducidad
            // 
            this.lblFechaCaducidad.AutoSize = true;
            this.lblFechaCaducidad.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFechaCaducidad.Location = new System.Drawing.Point(16, 9);
            this.lblFechaCaducidad.Name = "lblFechaCaducidad";
            this.lblFechaCaducidad.Size = new System.Drawing.Size(0, 13);
            this.lblFechaCaducidad.TabIndex = 7;
            // 
            // lblTiempo
            // 
            this.lblTiempo.AutoSize = true;
            this.lblTiempo.Location = new System.Drawing.Point(143, 5);
            this.lblTiempo.Name = "lblTiempo";
            this.lblTiempo.Size = new System.Drawing.Size(43, 17);
            this.lblTiempo.TabIndex = 7;
            this.lblTiempo.Text = "label1";
            this.lblTiempo.Visible = false;
            // 
            // lblNotificacion
            // 
            this.lblNotificacion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblNotificacion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblNotificacion.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNotificacion.ForeColor = System.Drawing.Color.White;
            this.lblNotificacion.Location = new System.Drawing.Point(906, -1);
            this.lblNotificacion.Name = "lblNotificacion";
            this.lblNotificacion.Size = new System.Drawing.Size(30, 29);
            this.lblNotificacion.TabIndex = 6;
            this.lblNotificacion.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblNotificacion.Click += new System.EventHandler(this.lblNotificacion_Click);
            // 
            // pictureBox4
            // 
            this.pictureBox4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox4.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox4.Image")));
            this.pictureBox4.Location = new System.Drawing.Point(882, 5);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(45, 49);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox4.TabIndex = 5;
            this.pictureBox4.TabStop = false;
            this.pictureBox4.Click += new System.EventHandler(this.pictureBox4_Click);
            // 
            // rbTodo
            // 
            this.rbTodo.AutoSize = true;
            this.rbTodo.Location = new System.Drawing.Point(622, 13);
            this.rbTodo.Name = "rbTodo";
            this.rbTodo.Size = new System.Drawing.Size(56, 21);
            this.rbTodo.TabIndex = 4;
            this.rbTodo.Text = "Todo";
            this.rbTodo.UseVisualStyleBackColor = true;
            this.rbTodo.CheckedChanged += new System.EventHandler(this.rbTodo_CheckedChanged);
            // 
            // rbIactivo
            // 
            this.rbIactivo.AutoSize = true;
            this.rbIactivo.Location = new System.Drawing.Point(751, 13);
            this.rbIactivo.Name = "rbIactivo";
            this.rbIactivo.Size = new System.Drawing.Size(70, 21);
            this.rbIactivo.TabIndex = 4;
            this.rbIactivo.Text = "Inactivo";
            this.rbIactivo.UseVisualStyleBackColor = true;
            this.rbIactivo.CheckedChanged += new System.EventHandler(this.rbIactivo_CheckedChanged);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.menuStrip1.AutoSize = false;
            this.menuStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(929, 3);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(91, 31);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // menuToolStripMenuItem
            // 
            this.menuToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.usuarioToolStripMenuItem,
            this.verRadarToolStripMenuItem,
            this.reporteGeneralToolStripMenuItem,
            this.importarPadronGestanteToolStripMenuItem,
            this.eportarPadronNomimalToolStripMenuItem,
            this.toolStripMenuItem1,
            this.recuperarClaveToolStripMenuItem,
            this.toolStripMenuItem2,
            this.ayudaToolStripMenuItem,
            this.verMasToolStripMenuItem,
            this.configurarConexionToolStripMenuItem,
            this.activarProductoToolStripMenuItem,
            this.limpiarBDToolStripMenuItem,
            this.cerrarSistemaToolStripMenuItem});
            this.menuToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("menuToolStripMenuItem.Image")));
            this.menuToolStripMenuItem.Name = "menuToolStripMenuItem";
            this.menuToolStripMenuItem.Size = new System.Drawing.Size(77, 27);
            this.menuToolStripMenuItem.Text = "Menu";
            // 
            // usuarioToolStripMenuItem
            // 
            this.usuarioToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("usuarioToolStripMenuItem.Image")));
            this.usuarioToolStripMenuItem.Name = "usuarioToolStripMenuItem";
            this.usuarioToolStripMenuItem.Size = new System.Drawing.Size(255, 24);
            this.usuarioToolStripMenuItem.Text = "Usuario";
            // 
            // verRadarToolStripMenuItem
            // 
            this.verRadarToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("verRadarToolStripMenuItem.Image")));
            this.verRadarToolStripMenuItem.Name = "verRadarToolStripMenuItem";
            this.verRadarToolStripMenuItem.Size = new System.Drawing.Size(255, 24);
            this.verRadarToolStripMenuItem.Text = "Ver Radar";
            this.verRadarToolStripMenuItem.Click += new System.EventHandler(this.verRadarToolStripMenuItem_Click);
            // 
            // reporteGeneralToolStripMenuItem
            // 
            this.reporteGeneralToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("reporteGeneralToolStripMenuItem.Image")));
            this.reporteGeneralToolStripMenuItem.Name = "reporteGeneralToolStripMenuItem";
            this.reporteGeneralToolStripMenuItem.Size = new System.Drawing.Size(255, 24);
            this.reporteGeneralToolStripMenuItem.Text = "Reporte General";
            this.reporteGeneralToolStripMenuItem.Click += new System.EventHandler(this.reporteGeneralToolStripMenuItem_Click);
            // 
            // importarPadronGestanteToolStripMenuItem
            // 
            this.importarPadronGestanteToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("importarPadronGestanteToolStripMenuItem.Image")));
            this.importarPadronGestanteToolStripMenuItem.Name = "importarPadronGestanteToolStripMenuItem";
            this.importarPadronGestanteToolStripMenuItem.Size = new System.Drawing.Size(255, 24);
            this.importarPadronGestanteToolStripMenuItem.Text = "Importar Padron Gestante";
            this.importarPadronGestanteToolStripMenuItem.Click += new System.EventHandler(this.importarPadronGestanteToolStripMenuItem_Click);
            // 
            // eportarPadronNomimalToolStripMenuItem
            // 
            this.eportarPadronNomimalToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("eportarPadronNomimalToolStripMenuItem.Image")));
            this.eportarPadronNomimalToolStripMenuItem.Name = "eportarPadronNomimalToolStripMenuItem";
            this.eportarPadronNomimalToolStripMenuItem.Size = new System.Drawing.Size(255, 24);
            this.eportarPadronNomimalToolStripMenuItem.Text = "Eportar Padron Nomimal";
            this.eportarPadronNomimalToolStripMenuItem.Click += new System.EventHandler(this.eportarPadronNomimalToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(252, 6);
            // 
            // recuperarClaveToolStripMenuItem
            // 
            this.recuperarClaveToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("recuperarClaveToolStripMenuItem.Image")));
            this.recuperarClaveToolStripMenuItem.Name = "recuperarClaveToolStripMenuItem";
            this.recuperarClaveToolStripMenuItem.Size = new System.Drawing.Size(255, 24);
            this.recuperarClaveToolStripMenuItem.Text = "Cambiar MicroRed";
            this.recuperarClaveToolStripMenuItem.Click += new System.EventHandler(this.recuperarClaveToolStripMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(252, 6);
            // 
            // ayudaToolStripMenuItem
            // 
            this.ayudaToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("ayudaToolStripMenuItem.Image")));
            this.ayudaToolStripMenuItem.Name = "ayudaToolStripMenuItem";
            this.ayudaToolStripMenuItem.Size = new System.Drawing.Size(255, 24);
            this.ayudaToolStripMenuItem.Text = "Ayuda";
            this.ayudaToolStripMenuItem.Click += new System.EventHandler(this.ayudaToolStripMenuItem_Click);
            // 
            // verMasToolStripMenuItem
            // 
            this.verMasToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("verMasToolStripMenuItem.Image")));
            this.verMasToolStripMenuItem.Name = "verMasToolStripMenuItem";
            this.verMasToolStripMenuItem.Size = new System.Drawing.Size(255, 24);
            this.verMasToolStripMenuItem.Text = "Ver mas";
            // 
            // configurarConexionToolStripMenuItem
            // 
            this.configurarConexionToolStripMenuItem.Image = global::CapaPresentacion.Properties.Resources.exportar;
            this.configurarConexionToolStripMenuItem.Name = "configurarConexionToolStripMenuItem";
            this.configurarConexionToolStripMenuItem.Size = new System.Drawing.Size(255, 24);
            this.configurarConexionToolStripMenuItem.Text = "Configurar Conexion";
            this.configurarConexionToolStripMenuItem.Click += new System.EventHandler(this.configurarConexionToolStripMenuItem_Click);
            // 
            // activarProductoToolStripMenuItem
            // 
            this.activarProductoToolStripMenuItem.Image = global::CapaPresentacion.Properties.Resources.no_hay_resultados;
            this.activarProductoToolStripMenuItem.Name = "activarProductoToolStripMenuItem";
            this.activarProductoToolStripMenuItem.Size = new System.Drawing.Size(255, 24);
            this.activarProductoToolStripMenuItem.Text = "Activar Producto";
            this.activarProductoToolStripMenuItem.Visible = false;
            this.activarProductoToolStripMenuItem.Click += new System.EventHandler(this.activarProductoToolStripMenuItem_Click);
            // 
            // limpiarBDToolStripMenuItem
            // 
            this.limpiarBDToolStripMenuItem.Enabled = false;
            this.limpiarBDToolStripMenuItem.Image = global::CapaPresentacion.Properties.Resources.importar;
            this.limpiarBDToolStripMenuItem.Name = "limpiarBDToolStripMenuItem";
            this.limpiarBDToolStripMenuItem.Size = new System.Drawing.Size(255, 24);
            this.limpiarBDToolStripMenuItem.Text = "Limpiar BD";
            this.limpiarBDToolStripMenuItem.Click += new System.EventHandler(this.limpiarBDToolStripMenuItem_Click);
            // 
            // cerrarSistemaToolStripMenuItem
            // 
            this.cerrarSistemaToolStripMenuItem.Image = global::CapaPresentacion.Properties.Resources.boton_x;
            this.cerrarSistemaToolStripMenuItem.Name = "cerrarSistemaToolStripMenuItem";
            this.cerrarSistemaToolStripMenuItem.Size = new System.Drawing.Size(255, 24);
            this.cerrarSistemaToolStripMenuItem.Text = "Cerrar Sistema";
            this.cerrarSistemaToolStripMenuItem.Click += new System.EventHandler(this.cerrarSistemaToolStripMenuItem_Click_1);
            // 
            // rbActivo
            // 
            this.rbActivo.AutoSize = true;
            this.rbActivo.Checked = true;
            this.rbActivo.Location = new System.Drawing.Point(684, 13);
            this.rbActivo.Name = "rbActivo";
            this.rbActivo.Size = new System.Drawing.Size(61, 21);
            this.rbActivo.TabIndex = 3;
            this.rbActivo.TabStop = true;
            this.rbActivo.Text = "Activo";
            this.rbActivo.UseVisualStyleBackColor = true;
            this.rbActivo.CheckedChanged += new System.EventHandler(this.rbActivo_CheckedChanged);
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.White;
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(230, 16);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(30, 25);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 2;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // txtBuscar
            // 
            this.txtBuscar.BackColor = System.Drawing.Color.White;
            this.txtBuscar.Location = new System.Drawing.Point(266, 16);
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.Size = new System.Drawing.Size(336, 25);
            this.txtBuscar.TabIndex = 1;
            this.txtBuscar.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // panel6
            // 
            this.panel6.Location = new System.Drawing.Point(0, 0);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(200, 100);
            this.panel6.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(0, 0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            // 
            // bunifuElipse1
            // 
            this.bunifuElipse1.ElipseRadius = 0;
            this.bunifuElipse1.TargetControl = this;
            // 
            // bunifuElipse2
            // 
            this.bunifuElipse2.ElipseRadius = 20;
            this.bunifuElipse2.TargetControl = this.lblNotificacion;
            // 
            // bunifuElipse3
            // 
            this.bunifuElipse3.ElipseRadius = 0;
            this.bunifuElipse3.TargetControl = this;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // frmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1225, 504);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sistema de Padron Nominal 1.0";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmPrincipal_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataListado)).EndInit();
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox txtBuscar;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label lblMicrored;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label lblMensajeBien;
        internal System.Windows.Forms.DataGridView DataListado;
        private System.Windows.Forms.RadioButton rbIactivo;
        private System.Windows.Forms.RadioButton rbActivo;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem usuarioToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem verRadarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reporteGeneralToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem eportarPadronNomimalToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem recuperarClaveToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem ayudaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem verMasToolStripMenuItem;
        private System.Windows.Forms.RadioButton rbTodo;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.DataGridViewImageColumn Eli;
        private System.Windows.Forms.DataGridViewImageColumn Edi;
        private System.Windows.Forms.DataGridViewImageColumn Ver;
        private System.Windows.Forms.DataGridViewTextBoxColumn id_gestante;
        private System.Windows.Forms.DataGridViewTextBoxColumn tipo_doc;
        private System.Windows.Forms.DataGridViewTextBoxColumn num_doc;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombre_apellido;
        private System.Windows.Forms.DataGridViewTextBoxColumn fecha_nac;
        private System.Windows.Forms.DataGridViewTextBoxColumn edad;
        private System.Windows.Forms.DataGridViewTextBoxColumn estado;
        private System.Windows.Forms.DataGridViewTextBoxColumn id_ges;
        private System.Windows.Forms.DataGridViewTextBoxColumn condicion;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.Label lblNotificacion;
        private Bunifu.Framework.UI.BunifuElipse bunifuElipse1;
        private System.Windows.Forms.ToolStripMenuItem cerrarSistemaToolStripMenuItem;
        private Bunifu.Framework.UI.BunifuElipse bunifuElipse2;
        private Bunifu.Framework.UI.BunifuElipse bunifuElipse3;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label lblTiempo;
        private System.Windows.Forms.Label lblFechaCaducidad;
        private System.Windows.Forms.ToolStripMenuItem importarPadronGestanteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem limpiarBDToolStripMenuItem;
        private System.Windows.Forms.Label lblFalta;
        private System.Windows.Forms.ToolStripMenuItem activarProductoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem configurarConexionToolStripMenuItem;
    }
}

