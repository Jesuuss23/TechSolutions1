namespace TechSolutions.Presentacion
{
    partial class frmLogin
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLogin));
            label1 = new Label();
            label2 = new Label();
            btnLogin = new Button();
            btnCancelar = new Button();
            txtUsuario = new TextBox();
            txtPassword = new TextBox();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            label1.ForeColor = Color.White;
            label1.Location = new Point(323, 69);
            label1.Name = "label1";
            label1.Size = new Size(111, 35);
            label1.TabIndex = 0;
            label1.Text = "Usuario:";
            label1.Click += label1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            label2.ForeColor = Color.White;
            label2.Location = new Point(283, 141);
            label2.Name = "label2";
            label2.Size = new Size(154, 35);
            label2.TabIndex = 1;
            label2.Text = "Contraseña:";
            // 
            // btnLogin
            // 
            btnLogin.BackColor = Color.GreenYellow;
            btnLogin.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            btnLogin.Location = new Point(648, 318);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(148, 54);
            btnLogin.TabIndex = 2;
            btnLogin.Text = "Ingresar";
            btnLogin.UseVisualStyleBackColor = false;
            btnLogin.Click += btnLogin_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.BackColor = Color.Red;
            btnCancelar.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            btnCancelar.Location = new Point(235, 318);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(153, 59);
            btnCancelar.TabIndex = 3;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = false;
            // 
            // txtUsuario
            // 
            txtUsuario.Font = new Font("Segoe UI", 12F);
            txtUsuario.Location = new Point(488, 70);
            txtUsuario.Name = "txtUsuario";
            txtUsuario.Size = new Size(175, 34);
            txtUsuario.TabIndex = 4;
            // 
            // txtPassword
            // 
            txtPassword.Font = new Font("Segoe UI", 12F);
            txtPassword.Location = new Point(488, 142);
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '*';
            txtPassword.Size = new Size(175, 34);
            txtPassword.TabIndex = 5;
            // 
            // frmLogin
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            ClientSize = new Size(951, 526);
            Controls.Add(txtPassword);
            Controls.Add(txtUsuario);
            Controls.Add(btnCancelar);
            Controls.Add(btnLogin);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "frmLogin";
            Text = "Form1";
            Load += frmLogin_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Button btnLogin;
        private Button btnCancelar;
        private TextBox txtUsuario;
        private TextBox txtPassword;
    }
}
