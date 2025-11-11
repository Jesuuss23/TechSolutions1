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
            ((System.ComponentModel.ISupportInitialize)dgvReporteVentas).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(85, 53);
            label1.Name = "label1";
            label1.Size = new Size(90, 20);
            label1.TabIndex = 0;
            label1.Text = "Fecha Inicio:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(102, 118);
            label2.Name = "label2";
            label2.Size = new Size(73, 20);
            label2.TabIndex = 1;
            label2.Text = "Fecha Fin:";
            // 
            // dtpFechaInicio
            // 
            dtpFechaInicio.Location = new Point(246, 48);
            dtpFechaInicio.Name = "dtpFechaInicio";
            dtpFechaInicio.Size = new Size(250, 27);
            dtpFechaInicio.TabIndex = 2;
            // 
            // dtpFechaFin
            // 
            dtpFechaFin.Location = new Point(246, 118);
            dtpFechaFin.Name = "dtpFechaFin";
            dtpFechaFin.Size = new Size(250, 27);
            dtpFechaFin.TabIndex = 3;
            // 
            // btnGenerarReporte
            // 
            btnGenerarReporte.Location = new Point(581, 66);
            btnGenerarReporte.Name = "btnGenerarReporte";
            btnGenerarReporte.Size = new Size(141, 56);
            btnGenerarReporte.TabIndex = 4;
            btnGenerarReporte.Text = "Generar Reporte";
            btnGenerarReporte.UseVisualStyleBackColor = true;
            btnGenerarReporte.Click += btnGenerarReporte_Click;
            // 
            // dgvReporteVentas
            // 
            dgvReporteVentas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvReporteVentas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvReporteVentas.Location = new Point(125, 168);
            dgvReporteVentas.Name = "dgvReporteVentas";
            dgvReporteVentas.ReadOnly = true;
            dgvReporteVentas.RowHeadersWidth = 51;
            dgvReporteVentas.Size = new Size(597, 298);
            dgvReporteVentas.TabIndex = 5;
            // 
            // btnImprimir
            // 
            btnImprimir.Location = new Point(843, 66);
            btnImprimir.Name = "btnImprimir";
            btnImprimir.Size = new Size(127, 56);
            btnImprimir.TabIndex = 6;
            btnImprimir.Text = "Imprimir";
            btnImprimir.UseVisualStyleBackColor = true;
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
            // frmReporteVentas
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1124, 496);
            Controls.Add(btnImprimir);
            Controls.Add(dgvReporteVentas);
            Controls.Add(btnGenerarReporte);
            Controls.Add(dtpFechaFin);
            Controls.Add(dtpFechaInicio);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "frmReporteVentas";
            Text = "frmReporteVentas";
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
    }
}