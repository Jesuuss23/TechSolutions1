namespace TechSolutions.Presentacion
{
    partial class frmMenuPrincipal
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
            btnGestionClientes = new Button();
            btnGestionProductos = new Button();
            btnGestionVentas = new Button();
            btnReportes = new Button();
            timerReloj = new System.Windows.Forms.Timer(components);
            lblReloj = new Label();
            btnGestionUsuarios = new Button();
            btnCerrarSesion = new Button();
            groupBox1 = new GroupBox();
            groupBox2 = new GroupBox();
            lblVentasHoy = new Label();
            dgvUltimasVentas = new DataGridView();
            groupBox3 = new GroupBox();
            dgvBajoStock = new DataGridView();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvUltimasVentas).BeginInit();
            groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvBajoStock).BeginInit();
            SuspendLayout();
            // 
            // btnGestionClientes
            // 
            btnGestionClientes.Location = new Point(45, 283);
            btnGestionClientes.Name = "btnGestionClientes";
            btnGestionClientes.Size = new Size(179, 48);
            btnGestionClientes.TabIndex = 0;
            btnGestionClientes.Text = "Gestión de Clientes";
            btnGestionClientes.UseVisualStyleBackColor = true;
            btnGestionClientes.Click += btnGestionClientes_Click;
            // 
            // btnGestionProductos
            // 
            btnGestionProductos.Location = new Point(45, 111);
            btnGestionProductos.Name = "btnGestionProductos";
            btnGestionProductos.Size = new Size(179, 46);
            btnGestionProductos.TabIndex = 1;
            btnGestionProductos.Text = "Gestión de Productos";
            btnGestionProductos.UseVisualStyleBackColor = true;
            btnGestionProductos.Click += btnGestionProductos_Click;
            // 
            // btnGestionVentas
            // 
            btnGestionVentas.Location = new Point(45, 429);
            btnGestionVentas.Name = "btnGestionVentas";
            btnGestionVentas.Size = new Size(179, 57);
            btnGestionVentas.TabIndex = 2;
            btnGestionVentas.Text = "Registrar Venta";
            btnGestionVentas.UseVisualStyleBackColor = true;
            btnGestionVentas.Click += btnGestionVentas_Click;
            // 
            // btnReportes
            // 
            btnReportes.Location = new Point(45, 360);
            btnReportes.Name = "btnReportes";
            btnReportes.Size = new Size(179, 48);
            btnReportes.TabIndex = 3;
            btnReportes.Text = "Reporte de Ventas";
            btnReportes.UseVisualStyleBackColor = true;
            btnReportes.Click += btnReportes_Click;
            // 
            // timerReloj
            // 
            timerReloj.Enabled = true;
            timerReloj.Interval = 1000;
            timerReloj.Tick += timerReloj_Tick;
            // 
            // lblReloj
            // 
            lblReloj.AutoSize = true;
            lblReloj.Font = new Font("Segoe UI", 12F);
            lblReloj.Location = new Point(80, 21);
            lblReloj.Name = "lblReloj";
            lblReloj.Size = new Size(154, 28);
            lblReloj.TabIndex = 4;
            lblReloj.Text = "Cargando reloj...";
            // 
            // btnGestionUsuarios
            // 
            btnGestionUsuarios.Location = new Point(45, 197);
            btnGestionUsuarios.Name = "btnGestionUsuarios";
            btnGestionUsuarios.Size = new Size(179, 54);
            btnGestionUsuarios.TabIndex = 5;
            btnGestionUsuarios.Text = "Gestión de Usuarios";
            btnGestionUsuarios.UseVisualStyleBackColor = true;
            btnGestionUsuarios.Click += btnGestionUsuarios_Click;
            // 
            // btnCerrarSesion
            // 
            btnCerrarSesion.Location = new Point(954, 21);
            btnCerrarSesion.Name = "btnCerrarSesion";
            btnCerrarSesion.Size = new Size(114, 29);
            btnCerrarSesion.TabIndex = 6;
            btnCerrarSesion.Text = "Cerrar Sesión";
            btnCerrarSesion.UseVisualStyleBackColor = true;
            btnCerrarSesion.Click += btnCerrarSesion_Click;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(lblVentasHoy);
            groupBox1.Location = new Point(274, 122);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(413, 129);
            groupBox1.TabIndex = 7;
            groupBox1.TabStop = false;
            groupBox1.Text = "Ventas de Hoy";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(dgvUltimasVentas);
            groupBox2.Location = new Point(706, 122);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(450, 340);
            groupBox2.TabIndex = 8;
            groupBox2.TabStop = false;
            groupBox2.Text = "Últimas Ventas";
            // 
            // lblVentasHoy
            // 
            lblVentasHoy.AutoSize = true;
            lblVentasHoy.Font = new Font("Segoe UI", 24F, FontStyle.Bold);
            lblVentasHoy.Location = new Point(18, 45);
            lblVentasHoy.Name = "lblVentasHoy";
            lblVentasHoy.Size = new Size(154, 54);
            lblVentasHoy.TabIndex = 0;
            lblVentasHoy.Text = "S/ 0.00";
            // 
            // dgvUltimasVentas
            // 
            dgvUltimasVentas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvUltimasVentas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvUltimasVentas.Location = new Point(16, 26);
            dgvUltimasVentas.Name = "dgvUltimasVentas";
            dgvUltimasVentas.ReadOnly = true;
            dgvUltimasVentas.RowHeadersWidth = 51;
            dgvUltimasVentas.Size = new Size(428, 296);
            dgvUltimasVentas.TabIndex = 0;
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(dgvBajoStock);
            groupBox3.Location = new Point(274, 283);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(413, 317);
            groupBox3.TabIndex = 9;
            groupBox3.TabStop = false;
            groupBox3.Text = "Productos con Bajo Stock";
            // 
            // dgvBajoStock
            // 
            dgvBajoStock.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvBajoStock.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvBajoStock.Location = new Point(18, 37);
            dgvBajoStock.Name = "dgvBajoStock";
            dgvBajoStock.ReadOnly = true;
            dgvBajoStock.RowHeadersWidth = 51;
            dgvBajoStock.Size = new Size(373, 262);
            dgvBajoStock.TabIndex = 0;
            // 
            // frmMenuPrincipal
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1168, 625);
            Controls.Add(groupBox3);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Controls.Add(btnCerrarSesion);
            Controls.Add(btnGestionUsuarios);
            Controls.Add(lblReloj);
            Controls.Add(btnReportes);
            Controls.Add(btnGestionVentas);
            Controls.Add(btnGestionProductos);
            Controls.Add(btnGestionClientes);
            Name = "frmMenuPrincipal";
            Text = "frmMenuPrincipal";
            Load += frmMenuPrincipal_Load_1;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvUltimasVentas).EndInit();
            groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvBajoStock).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnGestionClientes;
        private Button btnGestionProductos;
        private Button btnGestionVentas;
        private Button btnReportes;
        private System.Windows.Forms.Timer timerReloj;
        private Label lblReloj;
        private Button btnGestionUsuarios;
        private Button btnCerrarSesion;
        private GroupBox groupBox1;
        private Label lblVentasHoy;
        private GroupBox groupBox2;
        private DataGridView dgvUltimasVentas;
        private GroupBox groupBox3;
        private DataGridView dgvBajoStock;
    }
}