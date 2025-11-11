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
            label1.Font = new Font("Segoe UI Black", 18F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label1.Location = new Point(253, 22);
            label1.Name = "label1";
            label1.Size = new Size(293, 41);
            label1.TabIndex = 0;
            label1.Text = "Gestión de Clientes";
            // 
            // groupBox1
            // 
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
            groupBox1.Location = new Point(23, 108);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(506, 262);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            groupBox1.Text = "Datos del Cliente";
            // 
            // btnVerHistorial
            // 
            btnVerHistorial.Enabled = false;
            btnVerHistorial.Location = new Point(305, 137);
            btnVerHistorial.Name = "btnVerHistorial";
            btnVerHistorial.Size = new Size(141, 53);
            btnVerHistorial.TabIndex = 9;
            btnVerHistorial.Text = "Ver Historial";
            btnVerHistorial.UseVisualStyleBackColor = true;
            btnVerHistorial.Click += btnVerHistorial_Click;
            // 
            // txtDireccion
            // 
            txtDireccion.Location = new Point(348, 49);
            txtDireccion.Name = "txtDireccion";
            txtDireccion.Size = new Size(125, 27);
            txtDireccion.TabIndex = 13;
            // 
            // txtTelefono
            // 
            txtTelefono.Location = new Point(114, 229);
            txtTelefono.Name = "txtTelefono";
            txtTelefono.Size = new Size(125, 27);
            txtTelefono.TabIndex = 12;
            // 
            // txtCorreo
            // 
            txtCorreo.Location = new Point(118, 185);
            txtCorreo.Name = "txtCorreo";
            txtCorreo.Size = new Size(125, 27);
            txtCorreo.TabIndex = 11;
            // 
            // txtDocumento
            // 
            txtDocumento.Location = new Point(120, 151);
            txtDocumento.Name = "txtDocumento";
            txtDocumento.Size = new Size(125, 27);
            txtDocumento.TabIndex = 10;
            txtDocumento.TextChanged += txtNombre_TextChanged;
            txtDocumento.Validating += txtNombre_Validating;
            // 
            // txtApellido
            // 
            txtApellido.Location = new Point(112, 102);
            txtApellido.Name = "txtApellido";
            txtApellido.Size = new Size(125, 27);
            txtApellido.TabIndex = 9;
            txtApellido.TextChanged += txtNombre_TextChanged;
            txtApellido.Validating += txtNombre_Validating;
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(109, 44);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(125, 27);
            txtNombre.TabIndex = 8;
            txtNombre.TextChanged += txtNombre_TextChanged;
            txtNombre.Validating += txtNombre_Validating;
            // 
            // Direccion
            // 
            Direccion.AutoSize = true;
            Direccion.Location = new Point(269, 47);
            Direccion.Name = "Direccion";
            Direccion.Size = new Size(72, 20);
            Direccion.TabIndex = 7;
            Direccion.Text = "Dirección";
            // 
            // Nombre
            // 
            Nombre.AutoSize = true;
            Nombre.Location = new Point(28, 47);
            Nombre.Name = "Nombre";
            Nombre.Size = new Size(64, 20);
            Nombre.TabIndex = 2;
            Nombre.Text = "Nombre";
            // 
            // Telefono
            // 
            Telefono.AutoSize = true;
            Telefono.Location = new Point(28, 220);
            Telefono.Name = "Telefono";
            Telefono.Size = new Size(67, 20);
            Telefono.TabIndex = 6;
            Telefono.Text = "Teléfono";
            // 
            // Apellido
            // 
            Apellido.AutoSize = true;
            Apellido.Location = new Point(26, 101);
            Apellido.Name = "Apellido";
            Apellido.Size = new Size(66, 20);
            Apellido.TabIndex = 3;
            Apellido.Text = "Apellido";
            // 
            // Correo
            // 
            Correo.AutoSize = true;
            Correo.Location = new Point(28, 183);
            Correo.Name = "Correo";
            Correo.Size = new Size(54, 20);
            Correo.TabIndex = 5;
            Correo.Text = "Correo";
            // 
            // Documento
            // 
            Documento.AutoSize = true;
            Documento.Location = new Point(26, 146);
            Documento.Name = "Documento";
            Documento.Size = new Size(87, 20);
            Documento.TabIndex = 4;
            Documento.Text = "Documento";
            // 
            // btnRegistrar
            // 
            btnRegistrar.Enabled = false;
            btnRegistrar.Location = new Point(72, 396);
            btnRegistrar.Name = "btnRegistrar";
            btnRegistrar.Size = new Size(94, 29);
            btnRegistrar.TabIndex = 2;
            btnRegistrar.Text = "Registrar";
            btnRegistrar.UseVisualStyleBackColor = true;
            btnRegistrar.Click += btnRegistrar_Click;
            // 
            // btnActualizar
            // 
            btnActualizar.Location = new Point(253, 396);
            btnActualizar.Name = "btnActualizar";
            btnActualizar.Size = new Size(94, 29);
            btnActualizar.TabIndex = 3;
            btnActualizar.Text = "Actualizar";
            btnActualizar.UseVisualStyleBackColor = true;
            btnActualizar.Click += btnActualizar_Click;
            // 
            // btnLimpiar
            // 
            btnLimpiar.Location = new Point(400, 396);
            btnLimpiar.Name = "btnLimpiar";
            btnLimpiar.Size = new Size(146, 29);
            btnLimpiar.TabIndex = 4;
            btnLimpiar.Text = "Limpiar Campos";
            btnLimpiar.UseVisualStyleBackColor = true;
            btnLimpiar.Click += btnLimpiar_Click;
            // 
            // dgvClientes
            // 
            dgvClientes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvClientes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvClientes.Location = new Point(633, 167);
            dgvClientes.Name = "dgvClientes";
            dgvClientes.ReadOnly = true;
            dgvClientes.RowHeadersWidth = 51;
            dgvClientes.Size = new Size(516, 339);
            dgvClientes.TabIndex = 5;
            dgvClientes.CellClick += dgvClientes_CellClick;
            // 
            // btnEliminar
            // 
            btnEliminar.BackColor = Color.Red;
            btnEliminar.Location = new Point(256, 462);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(94, 29);
            btnEliminar.TabIndex = 6;
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseVisualStyleBackColor = false;
            btnEliminar.Click += btnEliminar_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(621, 105);
            label2.Name = "label2";
            label2.Size = new Size(55, 20);
            label2.TabIndex = 7;
            label2.Text = "Buscar:";
            // 
            // txtBuscar
            // 
            txtBuscar.Location = new Point(821, 107);
            txtBuscar.Name = "txtBuscar";
            txtBuscar.Size = new Size(125, 27);
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
            ClientSize = new Size(1161, 542);
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