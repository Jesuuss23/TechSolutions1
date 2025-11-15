using TechSolutions.BLL;
using TechSolutions.Entidades;
using System;
using System.Windows.Forms;
namespace TechSolutions.Presentacion
{
    public partial class frmLogin : Form
    {
        private readonly UsuarioBLL _usuarioBLL = new UsuarioBLL();
        public Usuario UsuarioLogueado { get; private set; }
        public frmLogin()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string nombreUsuario = txtUsuario.Text;
            string password = txtPassword.Text;

            try
            {
                Usuario usuarioValidado = _usuarioBLL.Login(nombreUsuario, password);

                if (usuarioValidado != null)
                {
                    this.UsuarioLogueado = usuarioValidado;

                    this.DialogResult = DialogResult.OK;

                    this.Close();
                }
                else
                {
                    MessageBox.Show("Usuario o contraseña incorrectos.", "Error de Login", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al intentar conectar: " + ex.Message, "Error Crítico", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close(); 
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
          //  StyleHelper.AplicarEstiloFormulario(this);
        }
    }
}
