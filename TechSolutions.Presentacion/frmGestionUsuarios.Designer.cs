namespace TechSolutions.Presentacion
{
    partial class frmGestionUsuarios
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmGestionUsuarios));
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            txtUsuario = new TextBox();
            txtPassword = new TextBox();
            txtEmail = new TextBox();
            cmbRol = new ComboBox();
            chkActivo = new CheckBox();
            btnRegistrar = new Button();
            btnActualizar = new Button();
            btnEliminar = new Button();
            btnLimpiar = new Button();
            dgvUsuarios = new DataGridView();
            btnResetPassword = new Button();
            label5 = new Label();
            groupBox2 = new GroupBox();
            ((System.ComponentModel.ISupportInitialize)dgvUsuarios).BeginInit();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            label1.Location = new Point(50, 92);
            label1.Name = "label1";
            label1.Size = new Size(153, 46);
            label1.TabIndex = 0;
            label1.Text = "Usuario:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            label2.Location = new Point(6, 199);
            label2.Name = "label2";
            label2.Size = new Size(209, 46);
            label2.TabIndex = 1;
            label2.Text = "Contraseña:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            label3.Location = new Point(84, 310);
            label3.Name = "label3";
            label3.Size = new Size(116, 46);
            label3.TabIndex = 2;
            label3.Text = "Email:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            label4.Location = new Point(116, 413);
            label4.Name = "label4";
            label4.Size = new Size(81, 46);
            label4.TabIndex = 3;
            label4.Text = "Rol:";
            // 
            // txtUsuario
            // 
            txtUsuario.Location = new Point(221, 89);
            txtUsuario.Name = "txtUsuario";
            txtUsuario.Size = new Size(269, 52);
            txtUsuario.TabIndex = 4;
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(221, 201);
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '*';
            txtPassword.Size = new Size(269, 52);
            txtPassword.TabIndex = 5;
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(221, 304);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(269, 52);
            txtEmail.TabIndex = 6;
            // 
            // cmbRol
            // 
            cmbRol.FormattingEnabled = true;
            cmbRol.Location = new Point(221, 406);
            cmbRol.Name = "cmbRol";
            cmbRol.Size = new Size(269, 53);
            cmbRol.TabIndex = 7;
            // 
            // chkActivo
            // 
            chkActivo.AutoSize = true;
            chkActivo.BackColor = Color.Aqua;
            chkActivo.Checked = true;
            chkActivo.CheckState = CheckState.Checked;
            chkActivo.ForeColor = SystemColors.ActiveCaptionText;
            chkActivo.Location = new Point(321, 505);
            chkActivo.Name = "chkActivo";
            chkActivo.Size = new Size(144, 50);
            chkActivo.TabIndex = 8;
            chkActivo.Text = "Activo";
            chkActivo.UseVisualStyleBackColor = false;
            // 
            // btnRegistrar
            // 
            btnRegistrar.BackColor = Color.Chartreuse;
            btnRegistrar.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            btnRegistrar.ForeColor = SystemColors.ActiveCaptionText;
            btnRegistrar.Location = new Point(84, 589);
            btnRegistrar.Name = "btnRegistrar";
            btnRegistrar.Size = new Size(223, 63);
            btnRegistrar.TabIndex = 9;
            btnRegistrar.Text = "Registrar";
            btnRegistrar.UseVisualStyleBackColor = false;
            btnRegistrar.Click += btnRegistrar_Click;
            // 
            // btnActualizar
            // 
            btnActualizar.BackColor = Color.Yellow;
            btnActualizar.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            btnActualizar.ForeColor = SystemColors.ActiveCaptionText;
            btnActualizar.Location = new Point(84, 724);
            btnActualizar.Name = "btnActualizar";
            btnActualizar.Size = new Size(223, 63);
            btnActualizar.TabIndex = 10;
            btnActualizar.Text = "Actualizar";
            btnActualizar.UseVisualStyleBackColor = false;
            btnActualizar.Click += btnActualizar_Click;
            // 
            // btnEliminar
            // 
            btnEliminar.BackColor = Color.Red;
            btnEliminar.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            btnEliminar.ForeColor = Color.Black;
            btnEliminar.Location = new Point(504, 724);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(223, 63);
            btnEliminar.TabIndex = 11;
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseVisualStyleBackColor = false;
            btnEliminar.Click += btnEliminar_Click;
            // 
            // btnLimpiar
            // 
            btnLimpiar.BackColor = Color.Beige;
            btnLimpiar.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            btnLimpiar.ForeColor = SystemColors.ActiveCaptionText;
            btnLimpiar.Location = new Point(504, 589);
            btnLimpiar.Name = "btnLimpiar";
            btnLimpiar.Size = new Size(223, 63);
            btnLimpiar.TabIndex = 12;
            btnLimpiar.Text = "Limpiar Campos";
            btnLimpiar.UseVisualStyleBackColor = false;
            btnLimpiar.Click += btnLimpiar_Click;
            // 
            // dgvUsuarios
            // 
            dgvUsuarios.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvUsuarios.BackgroundColor = Color.Aquamarine;
            dgvUsuarios.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvUsuarios.Location = new Point(797, 156);
            dgvUsuarios.Name = "dgvUsuarios";
            dgvUsuarios.ReadOnly = true;
            dgvUsuarios.RowHeadersWidth = 51;
            dgvUsuarios.Size = new Size(917, 706);
            dgvUsuarios.TabIndex = 13;
            dgvUsuarios.CellClick += dgvUsuarios_CellClick;
            // 
            // btnResetPassword
            // 
            btnResetPassword.BackColor = Color.DarkOrange;
            btnResetPassword.Enabled = false;
            btnResetPassword.Font = new Font("Segoe UI", 15F);
            btnResetPassword.ForeColor = SystemColors.ActiveCaptionText;
            btnResetPassword.Location = new Point(522, 184);
            btnResetPassword.Name = "btnResetPassword";
            btnResetPassword.Size = new Size(228, 90);
            btnResetPassword.TabIndex = 14;
            btnResetPassword.Text = "Restablecer Contraseña";
            btnResetPassword.UseVisualStyleBackColor = false;
            btnResetPassword.Click += btnResetPassword_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = Color.Transparent;
            label5.Font = new Font("Segoe UI", 45F, FontStyle.Bold);
            label5.ForeColor = SystemColors.ButtonHighlight;
            label5.Location = new Point(904, 26);
            label5.Name = "label5";
            label5.Size = new Size(708, 100);
            label5.TabIndex = 15;
            label5.Text = "Gestion de Usuario";
            // 
            // groupBox2
            // 
            groupBox2.BackColor = Color.Transparent;
            groupBox2.Controls.Add(label1);
            groupBox2.Controls.Add(txtUsuario);
            groupBox2.Controls.Add(btnResetPassword);
            groupBox2.Controls.Add(btnLimpiar);
            groupBox2.Controls.Add(label2);
            groupBox2.Controls.Add(btnEliminar);
            groupBox2.Controls.Add(txtPassword);
            groupBox2.Controls.Add(btnActualizar);
            groupBox2.Controls.Add(label3);
            groupBox2.Controls.Add(btnRegistrar);
            groupBox2.Controls.Add(txtEmail);
            groupBox2.Controls.Add(chkActivo);
            groupBox2.Controls.Add(label4);
            groupBox2.Controls.Add(cmbRol);
            groupBox2.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            groupBox2.ForeColor = SystemColors.ButtonHighlight;
            groupBox2.Location = new Point(12, 26);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(768, 836);
            groupBox2.TabIndex = 14;
            groupBox2.TabStop = false;
            groupBox2.Text = "Registrar/ Eliminar Usuario";
            // 
            // frmGestionUsuarios
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            ClientSize = new Size(1767, 892);
            Controls.Add(groupBox2);
            Controls.Add(label5);
            Controls.Add(dgvUsuarios);
            Name = "frmGestionUsuarios";
            Text = "frmGestionUsuarios";
            Load += frmGestionUsuarios_Load;
            ((System.ComponentModel.ISupportInitialize)dgvUsuarios).EndInit();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private TextBox txtUsuario;
        private TextBox txtPassword;
        private TextBox txtEmail;
        private ComboBox cmbRol;
        private CheckBox chkActivo;
        private Button btnRegistrar;
        private Button btnActualizar;
        private Button btnEliminar;
        private Button btnLimpiar;
        private DataGridView dgvUsuarios;
        private Button btnResetPassword;
        private Label label5;
        private GroupBox groupBox2;
    }
}