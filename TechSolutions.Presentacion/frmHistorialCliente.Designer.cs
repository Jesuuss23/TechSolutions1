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
            lblNombreCliente.Font = new Font("Segoe UI", 14F);
            lblNombreCliente.Location = new Point(41, 32);
            lblNombreCliente.Name = "lblNombreCliente";
            lblNombreCliente.Size = new Size(236, 32);
            lblNombreCliente.TabIndex = 0;
            lblNombreCliente.Text = "Historial de: [Cliente]";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(55, 123);
            label1.Name = "label1";
            label1.Size = new Size(90, 20);
            label1.TabIndex = 1;
            label1.Text = "Fecha Inicio:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(55, 214);
            label2.Name = "label2";
            label2.Size = new Size(73, 20);
            label2.TabIndex = 2;
            label2.Text = "Fecha Fin:";
            // 
            // dtpFechaInicio
            // 
            dtpFechaInicio.Location = new Point(244, 126);
            dtpFechaInicio.Name = "dtpFechaInicio";
            dtpFechaInicio.Size = new Size(250, 27);
            dtpFechaInicio.TabIndex = 3;
            // 
            // dtpFechaFin
            // 
            dtpFechaFin.Location = new Point(244, 207);
            dtpFechaFin.Name = "dtpFechaFin";
            dtpFechaFin.Size = new Size(250, 27);
            dtpFechaFin.TabIndex = 4;
            // 
            // btnBuscarHistorial
            // 
            btnBuscarHistorial.Location = new Point(157, 305);
            btnBuscarHistorial.Name = "btnBuscarHistorial";
            btnBuscarHistorial.Size = new Size(120, 53);
            btnBuscarHistorial.TabIndex = 5;
            btnBuscarHistorial.Text = "Buscar Historial";
            btnBuscarHistorial.UseVisualStyleBackColor = true;
            btnBuscarHistorial.Click += btnBuscarHistorial_Click_1;
            // 
            // dgvHistorial
            // 
            dgvHistorial.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvHistorial.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvHistorial.Location = new Point(524, 58);
            dgvHistorial.Name = "dgvHistorial";
            dgvHistorial.ReadOnly = true;
            dgvHistorial.RowHeadersWidth = 51;
            dgvHistorial.Size = new Size(616, 325);
            dgvHistorial.TabIndex = 6;
            // 
            // btnImprimirHistorial
            // 
            btnImprimirHistorial.Location = new Point(866, 408);
            btnImprimirHistorial.Name = "btnImprimirHistorial";
            btnImprimirHistorial.Size = new Size(152, 57);
            btnImprimirHistorial.TabIndex = 7;
            btnImprimirHistorial.Text = "Imprimir";
            btnImprimirHistorial.UseVisualStyleBackColor = true;
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
            btnEnviarCorreo.Location = new Point(581, 411);
            btnEnviarCorreo.Name = "btnEnviarCorreo";
            btnEnviarCorreo.Size = new Size(151, 54);
            btnEnviarCorreo.TabIndex = 8;
            btnEnviarCorreo.Text = "Enviar por Correo";
            btnEnviarCorreo.UseVisualStyleBackColor = true;
            btnEnviarCorreo.Click += btnEnviarCorreo_Click;
            // 
            // frmHistorialCliente
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1152, 552);
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