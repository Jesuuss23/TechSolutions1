namespace TechSolutions.Presentacion
{
    partial class frmHistorialCliente
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmHistorialCliente));
            lblNombreCliente = new Label();
            label1 = new Label();
            label2 = new Label();
            dtpFechaInicio = new DateTimePicker();
            dtpFechaFin = new DateTimePicker();
            btnBuscarHistorial = new Button();
            dgvHistorial = new DataGridView();
            btnImprimirHistorial = new Button();
            docImprimirHistorial = new System.Drawing.Printing.PrintDocument();
            vistaPreviaHistorial = new PrintPreviewDialog();
            btnEnviarCorreo = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvHistorial).BeginInit();
            SuspendLayout();
            // 
            // lblNombreCliente
            // 
            lblNombreCliente.AutoSize = true;
            lblNombreCliente.BackColor = Color.Transparent;
            lblNombreCliente.Font = new Font("Segoe UI", 45F, FontStyle.Bold);
            lblNombreCliente.ForeColor = SystemColors.ButtonHighlight;
            lblNombreCliente.Location = new Point(102, 37);
            lblNombreCliente.Name = "lblNombreCliente";
            lblNombreCliente.Size = new Size(790, 100);
            lblNombreCliente.TabIndex = 0;
            lblNombreCliente.Text = "Historial de: [Cliente]";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            label1.ForeColor = SystemColors.ButtonHighlight;
            label1.Location = new Point(102, 196);
            label1.Name = "label1";
            label1.Size = new Size(192, 41);
            label1.TabIndex = 1;
            label1.Text = "Fecha Inicio:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            label2.ForeColor = SystemColors.ButtonHighlight;
            label2.Location = new Point(809, 196);
            label2.Name = "label2";
            label2.Size = new Size(157, 41);
            label2.TabIndex = 2;
            label2.Text = "Fecha Fin:";
            // 
            // dtpFechaInicio
            // 
            dtpFechaInicio.Font = new Font("Segoe UI", 15F);
            dtpFechaInicio.Location = new Point(300, 196);
            dtpFechaInicio.Name = "dtpFechaInicio";
            dtpFechaInicio.Size = new Size(475, 41);
            dtpFechaInicio.TabIndex = 3;
            // 
            // dtpFechaFin
            // 
            dtpFechaFin.Font = new Font("Segoe UI", 15F);
            dtpFechaFin.Location = new Point(972, 196);
            dtpFechaFin.Name = "dtpFechaFin";
            dtpFechaFin.Size = new Size(455, 41);
            dtpFechaFin.TabIndex = 4;
            // 
            // btnBuscarHistorial
            // 
            btnBuscarHistorial.BackColor = Color.Orange;
            btnBuscarHistorial.Font = new Font("Segoe UI", 15F);
            btnBuscarHistorial.Location = new Point(1461, 188);
            btnBuscarHistorial.Name = "btnBuscarHistorial";
            btnBuscarHistorial.Size = new Size(219, 60);
            btnBuscarHistorial.TabIndex = 5;
            btnBuscarHistorial.Text = "Buscar Historial";
            btnBuscarHistorial.UseVisualStyleBackColor = false;
            btnBuscarHistorial.Click += btnBuscarHistorial_Click_1;
            // 
            // dgvHistorial
            // 
            dgvHistorial.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvHistorial.BackgroundColor = Color.Aquamarine;
            dgvHistorial.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvHistorial.Location = new Point(102, 274);
            dgvHistorial.Name = "dgvHistorial";
            dgvHistorial.ReadOnly = true;
            dgvHistorial.RowHeadersWidth = 51;
            dgvHistorial.Size = new Size(1325, 554);
            dgvHistorial.TabIndex = 6;
            // 
            // btnImprimirHistorial
            // 
            btnImprimirHistorial.BackColor = SystemColors.MenuHighlight;
            btnImprimirHistorial.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            btnImprimirHistorial.Location = new Point(1461, 371);
            btnImprimirHistorial.Name = "btnImprimirHistorial";
            btnImprimirHistorial.Size = new Size(266, 62);
            btnImprimirHistorial.TabIndex = 7;
            btnImprimirHistorial.Text = "Imprimir";
            btnImprimirHistorial.UseVisualStyleBackColor = false;
            btnImprimirHistorial.Click += btnImprimirHistorial_Click;
            // 
            // docImprimirHistorial
            // 
            docImprimirHistorial.PrintPage += docImprimirHistorial_PrintPage;
            // 
            // vistaPreviaHistorial
            // 
            vistaPreviaHistorial.AutoScrollMargin = new Size(0, 0);
            vistaPreviaHistorial.AutoScrollMinSize = new Size(0, 0);
            vistaPreviaHistorial.ClientSize = new Size(400, 300);
            vistaPreviaHistorial.Document = docImprimirHistorial;
            vistaPreviaHistorial.Enabled = true;
            vistaPreviaHistorial.Icon = (Icon)resources.GetObject("vistaPreviaHistorial.Icon");
            vistaPreviaHistorial.Name = "vistaPreviaHistorial";
            vistaPreviaHistorial.Visible = false;
            // 
            // btnEnviarCorreo
            // 
            btnEnviarCorreo.BackColor = Color.Coral;
            btnEnviarCorreo.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            btnEnviarCorreo.Location = new Point(1446, 609);
            btnEnviarCorreo.Name = "btnEnviarCorreo";
            btnEnviarCorreo.Size = new Size(298, 71);
            btnEnviarCorreo.TabIndex = 8;
            btnEnviarCorreo.Text = "Enviar por Correo";
            btnEnviarCorreo.UseVisualStyleBackColor = false;
            btnEnviarCorreo.Click += btnEnviarCorreo_Click;
            // 
            // frmHistorialCliente
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            ClientSize = new Size(1771, 873);
            Controls.Add(btnEnviarCorreo);
            Controls.Add(btnImprimirHistorial);
            Controls.Add(dgvHistorial);
            Controls.Add(btnBuscarHistorial);
            Controls.Add(dtpFechaFin);
            Controls.Add(dtpFechaInicio);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(lblNombreCliente);
            Name = "frmHistorialCliente";
            Text = "frmHistorialCliente";
            Load += frmHistorialCliente_Load;
            ((System.ComponentModel.ISupportInitialize)dgvHistorial).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblNombreCliente;
        private Label label1;
        private Label label2;
        private DateTimePicker dtpFechaInicio;
        private DateTimePicker dtpFechaFin;
        private Button btnBuscarHistorial;
        private DataGridView dgvHistorial;
        private Button btnImprimirHistorial;
        private System.Drawing.Printing.PrintDocument docImprimirHistorial;
        private PrintPreviewDialog vistaPreviaHistorial;
        private Button btnEnviarCorreo;
    }
}