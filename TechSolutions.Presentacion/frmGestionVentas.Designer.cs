namespace TechSolutions.Presentacion
{
    partial class frmGestionVentas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmGestionVentas));
            groupBox1 = new GroupBox();
            btnAgregar = new Button();
            numCantidad = new NumericUpDown();
            label3 = new Label();
            cmbProducto = new ComboBox();
            label2 = new Label();
            label1 = new Label();
            cmbCliente = new ComboBox();
            dgvCarrito = new DataGridView();
            lblTotal = new Label();
            btnRegistrarVenta = new Button();
            label4 = new Label();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numCantidad).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvCarrito).BeginInit();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.BackColor = Color.Transparent;
            groupBox1.Controls.Add(btnAgregar);
            groupBox1.Controls.Add(numCantidad);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(cmbProducto);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(cmbCliente);
            groupBox1.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            groupBox1.ForeColor = SystemColors.ButtonHighlight;
            groupBox1.Location = new Point(137, 184);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(650, 734);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Información de Venta";
            // 
            // btnAgregar
            // 
            btnAgregar.BackColor = Color.Blue;
            btnAgregar.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            btnAgregar.ForeColor = SystemColors.ButtonHighlight;
            btnAgregar.Location = new Point(212, 507);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(242, 85);
            btnAgregar.TabIndex = 6;
            btnAgregar.Text = "Agregar al Carrito";
            btnAgregar.UseVisualStyleBackColor = false;
            btnAgregar.Click += btnAgregar_Click;
            // 
            // numCantidad
            // 
            numCantidad.Font = new Font("Segoe UI", 15F);
            numCantidad.Location = new Point(233, 345);
            numCantidad.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numCantidad.Name = "numCantidad";
            numCantidad.Size = new Size(221, 41);
            numCantidad.TabIndex = 5;
            numCantidad.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(18, 340);
            label3.Name = "label3";
            label3.Size = new Size(172, 46);
            label3.TabIndex = 4;
            label3.Text = "Cantidad:";
            // 
            // cmbProducto
            // 
            cmbProducto.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cmbProducto.AutoCompleteSource = AutoCompleteSource.ListItems;
            cmbProducto.Font = new Font("Segoe UI", 15F);
            cmbProducto.FormattingEnabled = true;
            cmbProducto.Location = new Point(233, 234);
            cmbProducto.Name = "cmbProducto";
            cmbProducto.Size = new Size(350, 43);
            cmbProducto.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(14, 229);
            label2.Name = "label2";
            label2.Size = new Size(177, 46);
            label2.TabIndex = 2;
            label2.Text = "Producto:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(48, 118);
            label1.Name = "label1";
            label1.Size = new Size(140, 46);
            label1.TabIndex = 1;
            label1.Text = "Cliente:";
            // 
            // cmbCliente
            // 
            cmbCliente.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cmbCliente.AutoCompleteSource = AutoCompleteSource.ListItems;
            cmbCliente.Font = new Font("Segoe UI", 15F);
            cmbCliente.FormattingEnabled = true;
            cmbCliente.Location = new Point(233, 121);
            cmbCliente.Name = "cmbCliente";
            cmbCliente.Size = new Size(350, 43);
            cmbCliente.TabIndex = 0;
            // 
            // dgvCarrito
            // 
            dgvCarrito.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvCarrito.BackgroundColor = Color.Aquamarine;
            dgvCarrito.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvCarrito.Location = new Point(809, 211);
            dgvCarrito.Name = "dgvCarrito";
            dgvCarrito.ReadOnly = true;
            dgvCarrito.RowHeadersWidth = 51;
            dgvCarrito.Size = new Size(792, 403);
            dgvCarrito.TabIndex = 1;
            // 
            // lblTotal
            // 
            lblTotal.AutoSize = true;
            lblTotal.BackColor = SystemColors.Info;
            lblTotal.Font = new Font("Segoe UI", 25F, FontStyle.Bold);
            lblTotal.Location = new Point(809, 669);
            lblTotal.Name = "lblTotal";
            lblTotal.Size = new Size(284, 57);
            lblTotal.TabIndex = 2;
            lblTotal.Text = "Total: S/ 0.00";
            // 
            // btnRegistrarVenta
            // 
            btnRegistrarVenta.BackColor = Color.LightGreen;
            btnRegistrarVenta.Font = new Font("Segoe UI", 20F);
            btnRegistrarVenta.Location = new Point(1309, 664);
            btnRegistrarVenta.Name = "btnRegistrarVenta";
            btnRegistrarVenta.Size = new Size(292, 75);
            btnRegistrarVenta.TabIndex = 3;
            btnRegistrarVenta.Text = "Registrar Venta";
            btnRegistrarVenta.UseVisualStyleBackColor = false;
            btnRegistrarVenta.Click += btnRegistrarVenta_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.Transparent;
            label4.Font = new Font("Segoe UI", 45F, FontStyle.Bold);
            label4.ForeColor = SystemColors.ButtonHighlight;
            label4.Location = new Point(490, 52);
            label4.Name = "label4";
            label4.Size = new Size(647, 100);
            label4.TabIndex = 4;
            label4.Text = "Carrito de Ventas";
            // 
            // frmGestionVentas
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            ClientSize = new Size(1772, 967);
            Controls.Add(label4);
            Controls.Add(btnRegistrarVenta);
            Controls.Add(lblTotal);
            Controls.Add(dgvCarrito);
            Controls.Add(groupBox1);
            Name = "frmGestionVentas";
            Text = "frmGestionVentas";
            Load += frmGestionVentas_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numCantidad).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvCarrito).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private GroupBox groupBox1;
        private ComboBox cmbCliente;
        private Label label1;
        private Button btnAgregar;
        private NumericUpDown numCantidad;
        private Label label3;
        private ComboBox cmbProducto;
        private Label label2;
        private DataGridView dgvCarrito;
        private Label lblTotal;
        private Button btnRegistrarVenta;
        private Label label4;
    }
}