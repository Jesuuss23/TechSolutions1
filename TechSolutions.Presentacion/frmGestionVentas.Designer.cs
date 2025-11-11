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
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numCantidad).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvCarrito).BeginInit();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(btnAgregar);
            groupBox1.Controls.Add(numCantidad);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(cmbProducto);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(cmbCliente);
            groupBox1.Location = new Point(20, 25);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(386, 426);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Información de Venta";
            // 
            // btnAgregar
            // 
            btnAgregar.Location = new Point(100, 303);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(115, 58);
            btnAgregar.TabIndex = 6;
            btnAgregar.Text = "Agregar al Carrito";
            btnAgregar.UseVisualStyleBackColor = true;
            btnAgregar.Click += btnAgregar_Click;
            // 
            // numCantidad
            // 
            numCantidad.Location = new Point(148, 205);
            numCantidad.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numCantidad.Name = "numCantidad";
            numCantidad.Size = new Size(150, 27);
            numCantidad.TabIndex = 5;
            numCantidad.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(22, 203);
            label3.Name = "label3";
            label3.Size = new Size(72, 20);
            label3.TabIndex = 4;
            label3.Text = "Cantidad:";
            // 
            // cmbProducto
            // 
            cmbProducto.FormattingEnabled = true;
            cmbProducto.Location = new Point(150, 122);
            cmbProducto.Name = "cmbProducto";
            cmbProducto.Size = new Size(151, 28);
            cmbProducto.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(14, 119);
            label2.Name = "label2";
            label2.Size = new Size(72, 20);
            label2.TabIndex = 2;
            label2.Text = "Producto:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(11, 49);
            label1.Name = "label1";
            label1.Size = new Size(58, 20);
            label1.TabIndex = 1;
            label1.Text = "Cliente:";
            // 
            // cmbCliente
            // 
            cmbCliente.FormattingEnabled = true;
            cmbCliente.Location = new Point(150, 44);
            cmbCliente.Name = "cmbCliente";
            cmbCliente.Size = new Size(151, 28);
            cmbCliente.TabIndex = 0;
            // 
            // dgvCarrito
            // 
            dgvCarrito.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvCarrito.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvCarrito.Location = new Point(419, 40);
            dgvCarrito.Name = "dgvCarrito";
            dgvCarrito.ReadOnly = true;
            dgvCarrito.RowHeadersWidth = 51;
            dgvCarrito.Size = new Size(423, 411);
            dgvCarrito.TabIndex = 1;
            // 
            // lblTotal
            // 
            lblTotal.AutoSize = true;
            lblTotal.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblTotal.Location = new Point(918, 62);
            lblTotal.Name = "lblTotal";
            lblTotal.Size = new Size(164, 32);
            lblTotal.TabIndex = 2;
            lblTotal.Text = "Total: S/ 0.00";
            // 
            // btnRegistrarVenta
            // 
            btnRegistrarVenta.BackColor = Color.LightGreen;
            btnRegistrarVenta.Location = new Point(959, 162);
            btnRegistrarVenta.Name = "btnRegistrarVenta";
            btnRegistrarVenta.Size = new Size(94, 29);
            btnRegistrarVenta.TabIndex = 3;
            btnRegistrarVenta.Text = "Registrar Venta";
            btnRegistrarVenta.UseVisualStyleBackColor = false;
            btnRegistrarVenta.Click += btnRegistrarVenta_Click;
            // 
            // frmGestionVentas
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1151, 463);
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
    }
}