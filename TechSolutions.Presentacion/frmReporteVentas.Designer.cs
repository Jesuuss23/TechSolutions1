namespace TechSolutions.Presentacion
{
    partial class frmReporteVentas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmReporteVentas));
            label1 = new Label();
            label2 = new Label();
            dtpFechaInicio = new DateTimePicker();
            dtpFechaFin = new DateTimePicker();
            btnGenerarReporte = new Button();
            dgvReporteVentas = new DataGridView();
            btnImprimir = new Button();
            docImprimir = new System.Drawing.Printing.PrintDocument();
            vistaPreviaImpresion = new PrintPreviewDialog();
            btnEnviarCorreo = new Button();
            label3 = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvReporteVentas).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            label1.ForeColor = SystemColors.ButtonHighlight;
            label1.Location = new Point(42, 160);
            label1.Name = "label1";
            label1.Size = new Size(192, 41);
            label1.TabIndex = 0;
            label1.Text = "Fecha Inicio:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            label2.ForeColor = SystemColors.ButtonHighlight;
            label2.Location = new Point(730, 160);
            label2.Name = "label2";
            label2.Size = new Size(157, 41);
            label2.TabIndex = 1;
            label2.Text = "Fecha Fin:";
            // 
            // dtpFechaInicio
            // 
            dtpFechaInicio.Font = new Font("Segoe UI", 15F);
            dtpFechaInicio.Location = new Point(240, 160);
            dtpFechaInicio.Name = "dtpFechaInicio";
            dtpFechaInicio.Size = new Size(445, 41);
            dtpFechaInicio.TabIndex = 2;
            // 
            // dtpFechaFin
            // 
            dtpFechaFin.Font = new Font("Segoe UI", 15F);
            dtpFechaFin.Location = new Point(893, 160);
            dtpFechaFin.Name = "dtpFechaFin";
            dtpFechaFin.Size = new Size(457, 41);
            dtpFechaFin.TabIndex = 3;
            // 
            // btnGenerarReporte
            // 
            btnGenerarReporte.BackColor = SystemColors.MenuHighlight;
            btnGenerarReporte.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            btnGenerarReporte.Location = new Point(1368, 160);
            btnGenerarReporte.Name = "btnGenerarReporte";
            btnGenerarReporte.Size = new Size(229, 57);
            btnGenerarReporte.TabIndex = 4;
            btnGenerarReporte.Text = "Generar Reporte";
            btnGenerarReporte.UseVisualStyleBackColor = false;
            btnGenerarReporte.Click += btnGenerarReporte_Click;
            // 
            // dgvReporteVentas
            // 
            dgvReporteVentas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvReporteVentas.BackgroundColor = Color.Aquamarine;
            dgvReporteVentas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvReporteVentas.Location = new Point(53, 238);
            dgvReporteVentas.Name = "dgvReporteVentas";
            dgvReporteVentas.ReadOnly = true;
            dgvReporteVentas.RowHeadersWidth = 51;
            dgvReporteVentas.Size = new Size(1297, 552);
            dgvReporteVentas.TabIndex = 5;
            // 
            // btnImprimir
            // 
            btnImprimir.BackColor = Color.Yellow;
            btnImprimir.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            btnImprimir.Location = new Point(1425, 318);
            btnImprimir.Name = "btnImprimir";
            btnImprimir.Size = new Size(234, 72);
            btnImprimir.TabIndex = 6;
            btnImprimir.Text = "Imprimir";
            btnImprimir.UseVisualStyleBackColor = false;
            btnImprimir.Click += btnImprimir_Click;
            // 
            // docImprimir
            // 
            docImprimir.PrintPage += docImprimir_PrintPage;
            // 
            // vistaPreviaImpresion
            // 
            vistaPreviaImpresion.AutoScrollMargin = new Size(0, 0);
            vistaPreviaImpresion.AutoScrollMinSize = new Size(0, 0);
            vistaPreviaImpresion.ClientSize = new Size(400, 300);
            vistaPreviaImpresion.Document = docImprimir;
            vistaPreviaImpresion.Enabled = true;
            vistaPreviaImpresion.Icon = (Icon)resources.GetObject("vistaPreviaImpresion.Icon");
            vistaPreviaImpresion.Name = "vistaPreviaImpresion";
            vistaPreviaImpresion.Visible = false;
            // 
            // btnEnviarCorreo
            // 
            btnEnviarCorreo.BackColor = Color.Orange;
            btnEnviarCorreo.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            btnEnviarCorreo.Location = new Point(1425, 541);
            btnEnviarCorreo.Name = "btnEnviarCorreo";
            btnEnviarCorreo.Size = new Size(234, 74);
            btnEnviarCorreo.TabIndex = 7;
            btnEnviarCorreo.Text = "Enviar por Correo";
            btnEnviarCorreo.UseVisualStyleBackColor = false;
            btnEnviarCorreo.Click += btnEnviarCorreo_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Transparent;
            label3.Font = new Font("Segoe UI", 45F, FontStyle.Bold);
            label3.ForeColor = SystemColors.ButtonHighlight;
            label3.Location = new Point(387, 39);
            label3.Name = "label3";
            label3.Size = new Size(682, 100);
            label3.TabIndex = 8;
            label3.Text = "Reporte de ventas";
            // 
            // frmReporteVentas
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            ClientSize = new Size(1683, 832);
            Controls.Add(label3);
            Controls.Add(btnEnviarCorreo);
            Controls.Add(btnImprimir);
            Controls.Add(dgvReporteVentas);
            Controls.Add(btnGenerarReporte);
            Controls.Add(dtpFechaFin);
            Controls.Add(dtpFechaInicio);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "frmReporteVentas";
            Text = "frmReporteVentas";
            Load += frmReporteVentas_Load;
            ((System.ComponentModel.ISupportInitialize)dgvReporteVentas).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private DateTimePicker dtpFechaInicio;
        private DateTimePicker dtpFechaFin;
        private Button btnGenerarReporte;
        private DataGridView dgvReporteVentas;
        private Button btnImprimir;
        private System.Drawing.Printing.PrintDocument docImprimir;
        private PrintPreviewDialog vistaPreviaImpresion;
        private Button btnEnviarCorreo;
        private Label label3;
    }
}