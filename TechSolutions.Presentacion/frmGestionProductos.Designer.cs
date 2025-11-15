namespace TechSolutions.Presentacion
{
    partial class frmGestionProductos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmGestionProductos));
            groupBox1 = new GroupBox();
            btnLimpiar = new Button();
            btnEliminar = new Button();
            btnActualizar = new Button();
            btnRegistrar = new Button();
            cmbCategoria = new ComboBox();
            numStock = new NumericUpDown();
            numPrecio = new NumericUpDown();
            txtDescripcion = new TextBox();
            txtNombre = new TextBox();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            dgvProductos = new DataGridView();
            label6 = new Label();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numStock).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numPrecio).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvProductos).BeginInit();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.BackColor = Color.Transparent;
            groupBox1.Controls.Add(btnLimpiar);
            groupBox1.Controls.Add(btnEliminar);
            groupBox1.Controls.Add(btnActualizar);
            groupBox1.Controls.Add(btnRegistrar);
            groupBox1.Controls.Add(cmbCategoria);
            groupBox1.Controls.Add(numStock);
            groupBox1.Controls.Add(numPrecio);
            groupBox1.Controls.Add(txtDescripcion);
            groupBox1.Controls.Add(txtNombre);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label1);
            groupBox1.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            groupBox1.ForeColor = SystemColors.ButtonHighlight;
            groupBox1.Location = new Point(34, 36);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(768, 836);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Datos del Producto";
            // 
            // btnLimpiar
            // 
            btnLimpiar.BackColor = Color.Beige;
            btnLimpiar.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            btnLimpiar.ForeColor = SystemColors.ActiveCaptionText;
            btnLimpiar.Location = new Point(24, 723);
            btnLimpiar.Name = "btnLimpiar";
            btnLimpiar.Size = new Size(231, 74);
            btnLimpiar.TabIndex = 13;
            btnLimpiar.Text = "Limpiar Campos";
            btnLimpiar.UseVisualStyleBackColor = false;
            btnLimpiar.Click += btnLimpiar_Click;
            // 
            // btnEliminar
            // 
            btnEliminar.BackColor = Color.Red;
            btnEliminar.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            btnEliminar.ForeColor = SystemColors.ActiveCaptionText;
            btnEliminar.Location = new Point(447, 723);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(231, 74);
            btnEliminar.TabIndex = 12;
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseVisualStyleBackColor = false;
            btnEliminar.Click += btnEliminar_Click;
            // 
            // btnActualizar
            // 
            btnActualizar.BackColor = Color.Yellow;
            btnActualizar.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            btnActualizar.ForeColor = SystemColors.ActiveCaptionText;
            btnActualizar.Location = new Point(447, 623);
            btnActualizar.Name = "btnActualizar";
            btnActualizar.Size = new Size(231, 76);
            btnActualizar.TabIndex = 11;
            btnActualizar.Text = "Actualizar";
            btnActualizar.UseVisualStyleBackColor = false;
            btnActualizar.Click += btnActualizar_Click;
            // 
            // btnRegistrar
            // 
            btnRegistrar.BackColor = Color.GreenYellow;
            btnRegistrar.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            btnRegistrar.ForeColor = Color.Black;
            btnRegistrar.Location = new Point(24, 623);
            btnRegistrar.Name = "btnRegistrar";
            btnRegistrar.Size = new Size(231, 76);
            btnRegistrar.TabIndex = 10;
            btnRegistrar.Text = "Registrar";
            btnRegistrar.UseVisualStyleBackColor = false;
            btnRegistrar.Click += btnRegistrar_Click;
            // 
            // cmbCategoria
            // 
            cmbCategoria.FormattingEnabled = true;
            cmbCategoria.Location = new Point(244, 459);
            cmbCategoria.Name = "cmbCategoria";
            cmbCategoria.Size = new Size(261, 53);
            cmbCategoria.TabIndex = 9;
            // 
            // numStock
            // 
            numStock.Location = new Point(244, 366);
            numStock.Maximum = new decimal(new int[] { 100000, 0, 0, 0 });
            numStock.Name = "numStock";
            numStock.Size = new Size(261, 52);
            numStock.TabIndex = 8;
            // 
            // numPrecio
            // 
            numPrecio.Location = new Point(244, 275);
            numPrecio.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
            numPrecio.Name = "numPrecio";
            numPrecio.Size = new Size(261, 52);
            numPrecio.TabIndex = 7;
            // 
            // txtDescripcion
            // 
            txtDescripcion.Location = new Point(244, 185);
            txtDescripcion.Name = "txtDescripcion";
            txtDescripcion.Size = new Size(261, 52);
            txtDescripcion.TabIndex = 6;
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(244, 96);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(261, 52);
            txtNombre.TabIndex = 5;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            label5.ForeColor = SystemColors.ButtonHighlight;
            label5.Location = new Point(54, 459);
            label5.Name = "label5";
            label5.Size = new Size(174, 46);
            label5.TabIndex = 4;
            label5.Text = "Categoría";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            label4.ForeColor = SystemColors.ButtonHighlight;
            label4.Location = new Point(117, 366);
            label4.Name = "label4";
            label4.Size = new Size(107, 46);
            label4.TabIndex = 3;
            label4.Text = "Stock";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            label3.ForeColor = SystemColors.ButtonHighlight;
            label3.Location = new Point(106, 277);
            label3.Name = "label3";
            label3.Size = new Size(120, 46);
            label3.TabIndex = 2;
            label3.Text = "Precio";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            label2.ForeColor = SystemColors.ButtonHighlight;
            label2.Location = new Point(24, 185);
            label2.Name = "label2";
            label2.Size = new Size(207, 46);
            label2.TabIndex = 1;
            label2.Text = "Descripción";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            label1.ForeColor = SystemColors.ButtonHighlight;
            label1.Location = new Point(75, 96);
            label1.Name = "label1";
            label1.Size = new Size(152, 46);
            label1.TabIndex = 0;
            label1.Text = "Nombre";
            // 
            // dgvProductos
            // 
            dgvProductos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvProductos.BackgroundColor = Color.Aquamarine;
            dgvProductos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvProductos.Location = new Point(837, 179);
            dgvProductos.Name = "dgvProductos";
            dgvProductos.ReadOnly = true;
            dgvProductos.RowHeadersWidth = 51;
            dgvProductos.Size = new Size(881, 584);
            dgvProductos.TabIndex = 1;
            dgvProductos.CellClick += dgvProductos_CellClick;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.BackColor = Color.Transparent;
            label6.Font = new Font("Segoe UI", 45F, FontStyle.Bold);
            label6.ForeColor = SystemColors.ButtonHighlight;
            label6.Location = new Point(1092, 53);
            label6.Name = "label6";
            label6.Size = new Size(399, 100);
            label6.TabIndex = 2;
            label6.Text = "Productos";
            // 
            // frmGestionProductos
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            ClientSize = new Size(1775, 895);
            Controls.Add(label6);
            Controls.Add(dgvProductos);
            Controls.Add(groupBox1);
            Name = "frmGestionProductos";
            Text = "frmGestionProductos";
            Load += frmGestionProductos_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numStock).EndInit();
            ((System.ComponentModel.ISupportInitialize)numPrecio).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvProductos).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private GroupBox groupBox1;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
        private Button btnLimpiar;
        private Button btnEliminar;
        private Button btnActualizar;
        private Button btnRegistrar;
        private ComboBox cmbCategoria;
        private NumericUpDown numStock;
        private NumericUpDown numPrecio;
        private TextBox txtDescripcion;
        private TextBox txtNombre;
        private DataGridView dgvProductos;
        private Label label6;
    }
}