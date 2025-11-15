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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMenuPrincipal));
            btnGestionClientes = new Button();
            btnGestionProductos = new Button();
            btnGestionVentas = new Button();
            btnReportes = new Button();
            timerReloj = new System.Windows.Forms.Timer(components);
            lblReloj = new Label();
            btnGestionUsuarios = new Button();
            btnCerrarSesion = new Button();
            groupBox1 = new GroupBox();
            lblVentasHoy = new Label();
            groupBox2 = new GroupBox();
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
            btnGestionClientes.BackColor = Color.LemonChiffon;
            btnGestionClientes.Cursor = Cursors.Hand;
            btnGestionClientes.FlatAppearance.BorderColor = Color.Cyan;
            btnGestionClientes.FlatAppearance.BorderSize = 3;
            btnGestionClientes.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnGestionClientes.Location = new Point(1073, 687);
            btnGestionClientes.Name = "btnGestionClientes";
            btnGestionClientes.Size = new Size(222, 95);
            btnGestionClientes.TabIndex = 0;
            btnGestionClientes.Text = "Gestión de Clientes";
            btnGestionClientes.UseVisualStyleBackColor = false;
            btnGestionClientes.Click += btnGestionClientes_Click;
            // 
            // btnGestionProductos
            // 
            btnGestionProductos.BackColor = Color.LemonChiffon;
            btnGestionProductos.Cursor = Cursors.Hand;
            btnGestionProductos.FlatAppearance.BorderColor = Color.Cyan;
            btnGestionProductos.FlatAppearance.BorderSize = 3;
            btnGestionProductos.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnGestionProductos.Location = new Point(390, 687);
            btnGestionProductos.Name = "btnGestionProductos";
            btnGestionProductos.Size = new Size(220, 95);
            btnGestionProductos.TabIndex = 1;
            btnGestionProductos.Text = "Gestión de Productos";
            btnGestionProductos.UseVisualStyleBackColor = false;
            btnGestionProductos.Click += btnGestionProductos_Click;
            // 
            // btnGestionVentas
            // 
            btnGestionVentas.BackColor = Color.LemonChiffon;
            btnGestionVentas.Cursor = Cursors.Hand;
            btnGestionVentas.FlatAppearance.BorderColor = Color.Cyan;
            btnGestionVentas.FlatAppearance.BorderSize = 3;
            btnGestionVentas.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnGestionVentas.Location = new Point(80, 687);
            btnGestionVentas.Name = "btnGestionVentas";
            btnGestionVentas.Size = new Size(222, 95);
            btnGestionVentas.TabIndex = 2;
            btnGestionVentas.Text = "Registrar Venta";
            btnGestionVentas.UseVisualStyleBackColor = false;
            btnGestionVentas.Click += btnGestionVentas_Click;
            // 
            // btnReportes
            // 
            btnReportes.BackColor = Color.LemonChiffon;
            btnReportes.Cursor = Cursors.Hand;
            btnReportes.FlatAppearance.BorderColor = Color.Cyan;
            btnReportes.FlatAppearance.BorderSize = 3;
            btnReportes.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnReportes.Location = new Point(725, 687);
            btnReportes.Name = "btnReportes";
            btnReportes.Size = new Size(220, 95);
            btnReportes.TabIndex = 3;
            btnReportes.Text = "Reporte de Ventas";
            btnReportes.UseVisualStyleBackColor = false;
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
            lblReloj.BackColor = Color.Transparent;
            lblReloj.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblReloj.ForeColor = Color.Red;
            lblReloj.Location = new Point(80, 48);
            lblReloj.Name = "lblReloj";
            lblReloj.Size = new Size(251, 41);
            lblReloj.TabIndex = 4;
            lblReloj.Text = "Cargando reloj...";
            // 
            // btnGestionUsuarios
            // 
            btnGestionUsuarios.BackColor = Color.LemonChiffon;
            btnGestionUsuarios.Cursor = Cursors.Hand;
            btnGestionUsuarios.FlatAppearance.BorderColor = Color.Cyan;
            btnGestionUsuarios.FlatAppearance.BorderSize = 3;
            btnGestionUsuarios.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnGestionUsuarios.Location = new Point(1417, 687);
            btnGestionUsuarios.Name = "btnGestionUsuarios";
            btnGestionUsuarios.Size = new Size(222, 95);
            btnGestionUsuarios.TabIndex = 5;
            btnGestionUsuarios.Text = "Gestión de Usuarios";
            btnGestionUsuarios.UseVisualStyleBackColor = false;
            btnGestionUsuarios.Click += btnGestionUsuarios_Click;
            // 
            // btnCerrarSesion
            // 
            btnCerrarSesion.BackColor = Color.Red;
            btnCerrarSesion.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            btnCerrarSesion.Location = new Point(1468, 12);
            btnCerrarSesion.Name = "btnCerrarSesion";
            btnCerrarSesion.Size = new Size(235, 66);
            btnCerrarSesion.TabIndex = 6;
            btnCerrarSesion.Text = "Cerrar Sesión";
            btnCerrarSesion.UseVisualStyleBackColor = false;
            btnCerrarSesion.Click += btnCerrarSesion_Click;
            // 
            // groupBox1
            // 
            groupBox1.BackColor = Color.FromArgb(128, 255, 255);
            groupBox1.Controls.Add(lblVentasHoy);
            groupBox1.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            groupBox1.Location = new Point(612, 33);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(463, 126);
            groupBox1.TabIndex = 7;
            groupBox1.TabStop = false;
            groupBox1.Text = "Ventas de Hoy";
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
            // groupBox2
            // 
            groupBox2.BackColor = Color.Transparent;
            groupBox2.Controls.Add(dgvUltimasVentas);
            groupBox2.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            groupBox2.ForeColor = SystemColors.ButtonHighlight;
            groupBox2.Location = new Point(908, 209);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(769, 400);
            groupBox2.TabIndex = 8;
            groupBox2.TabStop = false;
            groupBox2.Text = "Últimas Ventas";
            // 
            // dgvUltimasVentas
            // 
            dgvUltimasVentas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvUltimasVentas.BackgroundColor = Color.Aquamarine;
            dgvUltimasVentas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvUltimasVentas.GridColor = SystemColors.InactiveCaptionText;
            dgvUltimasVentas.Location = new Point(19, 37);
            dgvUltimasVentas.Name = "dgvUltimasVentas";
            dgvUltimasVentas.ReadOnly = true;
            dgvUltimasVentas.RowHeadersWidth = 51;
            dgvUltimasVentas.Size = new Size(739, 354);
            dgvUltimasVentas.TabIndex = 0;
            // 
            // groupBox3
            // 
            groupBox3.BackColor = Color.Transparent;
            groupBox3.Controls.Add(dgvBajoStock);
            groupBox3.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            groupBox3.ForeColor = SystemColors.ButtonFace;
            groupBox3.Location = new Point(80, 209);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(769, 400);
            groupBox3.TabIndex = 9;
            groupBox3.TabStop = false;
            groupBox3.Text = "Productos con Bajo Stock";
            // 
            // dgvBajoStock
            // 
            dgvBajoStock.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvBajoStock.BackgroundColor = Color.Aquamarine;
            dgvBajoStock.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvBajoStock.Location = new Point(18, 37);
            dgvBajoStock.Name = "dgvBajoStock";
            dgvBajoStock.ReadOnly = true;
            dgvBajoStock.RowHeadersWidth = 51;
            dgvBajoStock.Size = new Size(734, 354);
            dgvBajoStock.TabIndex = 0;
            // 
            // frmMenuPrincipal
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            ClientSize = new Size(1742, 847);
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