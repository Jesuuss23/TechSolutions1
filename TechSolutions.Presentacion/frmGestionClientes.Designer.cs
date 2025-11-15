namespace TechSolutions.Presentacion
{
    partial class frmGestionClientes
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmGestionClientes));
            label1 = new Label();
            groupBox1 = new GroupBox();
            btnVerHistorial = new Button();
            txtDireccion = new TextBox();
            txtTelefono = new TextBox();
            txtCorreo = new TextBox();
            txtDocumento = new TextBox();
            txtApellido = new TextBox();
            txtNombre = new TextBox();
            Direccion = new Label();
            Nombre = new Label();
            Telefono = new Label();
            Apellido = new Label();
            Correo = new Label();
            Documento = new Label();
            btnRegistrar = new Button();
            btnActualizar = new Button();
            btnLimpiar = new Button();
            dgvClientes = new DataGridView();
            btnEliminar = new Button();
            label2 = new Label();
            txtBuscar = new TextBox();
            epClientes = new ErrorProvider(components);
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvClientes).BeginInit();
            ((System.ComponentModel.ISupportInitialize)epClientes).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Segoe UI Black", 35F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label1.ForeColor = SystemColors.ButtonHighlight;
            label1.Location = new Point(544, 9);
            label1.Name = "label1";
            label1.Size = new Size(578, 78);
            label1.TabIndex = 0;
            label1.Text = "Gestión de Clientes";
            // 
            // groupBox1
            // 
            groupBox1.BackColor = Color.Transparent;
            groupBox1.Controls.Add(btnVerHistorial);
            groupBox1.Controls.Add(txtDireccion);
            groupBox1.Controls.Add(txtTelefono);
            groupBox1.Controls.Add(txtCorreo);
            groupBox1.Controls.Add(txtDocumento);
            groupBox1.Controls.Add(txtApellido);
            groupBox1.Controls.Add(txtNombre);
            groupBox1.Controls.Add(Direccion);
            groupBox1.Controls.Add(Nombre);
            groupBox1.Controls.Add(Telefono);
            groupBox1.Controls.Add(Apellido);
            groupBox1.Controls.Add(Correo);
            groupBox1.Controls.Add(Documento);
            groupBox1.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            groupBox1.ForeColor = SystemColors.ButtonHighlight;
            groupBox1.Location = new Point(12, 90);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(784, 555);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            groupBox1.Text = "Datos del Cliente";
            // 
            // btnVerHistorial
            // 
            btnVerHistorial.BackColor = Color.Cyan;
            btnVerHistorial.Enabled = false;
            btnVerHistorial.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            btnVerHistorial.ForeColor = SystemColors.ActiveCaptionText;
            btnVerHistorial.Location = new Point(500, 216);
            btnVerHistorial.Name = "btnVerHistorial";
            btnVerHistorial.Size = new Size(197, 73);
            btnVerHistorial.TabIndex = 9;
            btnVerHistorial.Text = "Ver Historial";
            btnVerHistorial.UseVisualStyleBackColor = false;
            btnVerHistorial.Click += btnVerHistorial_Click;
            // 
            // txtDireccion
            // 
            txtDireccion.Location = new Point(183, 462);
            txtDireccion.Name = "txtDireccion";
            txtDireccion.Size = new Size(249, 47);
            txtDireccion.TabIndex = 13;
            // 
            // txtTelefono
            // 
            txtTelefono.Location = new Point(183, 386);
            txtTelefono.Name = "txtTelefono";
            txtTelefono.Size = new Size(249, 47);
            txtTelefono.TabIndex = 12;
            // 
            // txtCorreo
            // 
            txtCorreo.Location = new Point(183, 307);
            txtCorreo.Name = "txtCorreo";
            txtCorreo.Size = new Size(249, 47);
            txtCorreo.TabIndex = 11;
            // 
            // txtDocumento
            // 
            txtDocumento.Location = new Point(183, 227);
            txtDocumento.Name = "txtDocumento";
            txtDocumento.Size = new Size(249, 47);
            txtDocumento.TabIndex = 10;
            txtDocumento.TextChanged += txtNombre_TextChanged;
            txtDocumento.Validating += txtNombre_Validating;
            // 
            // txtApellido
            // 
            txtApellido.Location = new Point(183, 148);
            txtApellido.Name = "txtApellido";
            txtApellido.Size = new Size(249, 47);
            txtApellido.TabIndex = 9;
            txtApellido.TextChanged += txtNombre_TextChanged;
            txtApellido.Validating += txtNombre_Validating;
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(183, 72);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(249, 47);
            txtNombre.TabIndex = 8;
            txtNombre.TextChanged += txtNombre_TextChanged;
            txtNombre.Validating += txtNombre_Validating;
            // 
            // Direccion
            // 
            Direccion.AutoSize = true;
            Direccion.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            Direccion.Location = new Point(29, 462);
            Direccion.Name = "Direccion";
            Direccion.Size = new Size(132, 35);
            Direccion.TabIndex = 7;
            Direccion.Text = "Dirección:";
            // 
            // Nombre
            // 
            Nombre.AutoSize = true;
            Nombre.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            Nombre.Location = new Point(41, 80);
            Nombre.Name = "Nombre";
            Nombre.Size = new Size(120, 35);
            Nombre.TabIndex = 2;
            Nombre.Text = "Nombre:";
            // 
            // Telefono
            // 
            Telefono.AutoSize = true;
            Telefono.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            Telefono.Location = new Point(39, 394);
            Telefono.Name = "Telefono";
            Telefono.Size = new Size(125, 35);
            Telefono.TabIndex = 6;
            Telefono.Text = "Teléfono:";
            // 
            // Apellido
            // 
            Apellido.AutoSize = true;
            Apellido.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            Apellido.Location = new Point(42, 151);
            Apellido.Name = "Apellido";
            Apellido.Size = new Size(121, 35);
            Apellido.TabIndex = 3;
            Apellido.Text = "Apellido:";
            // 
            // Correo
            // 
            Correo.AutoSize = true;
            Correo.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            Correo.Location = new Point(58, 307);
            Correo.Name = "Correo";
            Correo.Size = new Size(102, 35);
            Correo.TabIndex = 5;
            Correo.Text = "Correo:";
            // 
            // Documento
            // 
            Documento.AutoSize = true;
            Documento.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            Documento.Location = new Point(0, 232);
            Documento.Name = "Documento";
            Documento.Size = new Size(159, 35);
            Documento.TabIndex = 4;
            Documento.Text = "Documento:";
            // 
            // btnRegistrar
            // 
            btnRegistrar.BackColor = Color.LawnGreen;
            btnRegistrar.Enabled = false;
            btnRegistrar.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            btnRegistrar.Location = new Point(128, 741);
            btnRegistrar.Name = "btnRegistrar";
            btnRegistrar.Size = new Size(207, 95);
            btnRegistrar.TabIndex = 2;
            btnRegistrar.Text = "Registrar";
            btnRegistrar.UseVisualStyleBackColor = false;
            btnRegistrar.Click += btnRegistrar_Click;
            // 
            // btnActualizar
            // 
            btnActualizar.BackColor = Color.Yellow;
            btnActualizar.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            btnActualizar.Location = new Point(990, 741);
            btnActualizar.Name = "btnActualizar";
            btnActualizar.Size = new Size(200, 95);
            btnActualizar.TabIndex = 3;
            btnActualizar.Text = "Actualizar";
            btnActualizar.UseVisualStyleBackColor = false;
            btnActualizar.Click += btnActualizar_Click;
            // 
            // btnLimpiar
            // 
            btnLimpiar.BackColor = Color.Beige;
            btnLimpiar.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            btnLimpiar.Location = new Point(563, 741);
            btnLimpiar.Name = "btnLimpiar";
            btnLimpiar.Size = new Size(214, 95);
            btnLimpiar.TabIndex = 4;
            btnLimpiar.Text = "Limpiar Campos";
            btnLimpiar.UseVisualStyleBackColor = false;
            btnLimpiar.Click += btnLimpiar_Click;
            // 
            // dgvClientes
            // 
            dgvClientes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvClientes.BackgroundColor = Color.Aquamarine;
            dgvClientes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvClientes.Location = new Point(839, 185);
            dgvClientes.Name = "dgvClientes";
            dgvClientes.ReadOnly = true;
            dgvClientes.RowHeadersWidth = 51;
            dgvClientes.Size = new Size(885, 482);
            dgvClientes.TabIndex = 5;
            dgvClientes.CellClick += dgvClientes_CellClick;
            // 
            // btnEliminar
            // 
            btnEliminar.BackColor = Color.Red;
            btnEliminar.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            btnEliminar.Location = new Point(1357, 741);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(196, 95);
            btnEliminar.TabIndex = 6;
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseVisualStyleBackColor = false;
            btnEliminar.Click += btnEliminar_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            label2.Location = new Point(839, 116);
            label2.Name = "label2";
            label2.Size = new Size(136, 46);
            label2.TabIndex = 7;
            label2.Text = "Buscar:";
            label2.Click += label2_Click;
            // 
            // txtBuscar
            // 
            txtBuscar.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            txtBuscar.Location = new Point(987, 121);
            txtBuscar.Name = "txtBuscar";
            txtBuscar.Size = new Size(737, 41);
            txtBuscar.TabIndex = 8;
            txtBuscar.TextChanged += txtBuscar_TextChanged;
            // 
            // epClientes
            // 
            epClientes.ContainerControl = this;
            // 
            // frmGestionClientes
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            ClientSize = new Size(1755, 898);
            Controls.Add(txtBuscar);
            Controls.Add(label2);
            Controls.Add(btnEliminar);
            Controls.Add(dgvClientes);
            Controls.Add(btnLimpiar);
            Controls.Add(btnActualizar);
            Controls.Add(btnRegistrar);
            Controls.Add(groupBox1);
            Controls.Add(label1);
            Name = "frmGestionClientes";
            Text = "frmGestionClientes";
            Load += frmGestionClientes_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvClientes).EndInit();
            ((System.ComponentModel.ISupportInitialize)epClientes).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private GroupBox groupBox1;
        private Label Nombre;
        private Label Apellido;
        private Label Documento;
        private Label Correo;
        private Label Telefono;
        private Label Direccion;
        private Button btnRegistrar;
        private Button btnActualizar;
        private Button btnLimpiar;
        private DataGridView dgvClientes;
        private TextBox txtDireccion;
        private TextBox txtTelefono;
        private TextBox txtCorreo;
        private TextBox txtDocumento;
        private TextBox txtApellido;
        private TextBox txtNombre;
        private Button btnEliminar;
        private Label label2;
        private TextBox txtBuscar;
        private Button btnVerHistorial;
        private ErrorProvider epClientes;
    }
}