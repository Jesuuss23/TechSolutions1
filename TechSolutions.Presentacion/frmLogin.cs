using TechSolutions.BLL;
using TechSolutions.Entidades;
using System;
using System.Windows.Forms;
namespace TechSolutions.Presentacion
{
    public partial class frmLogin : Form
    {
        private readonly UsuarioBLL _usuarioBLL = new UsuarioBLL();
        // Esta propiedad pública guardará al usuario para que Program.cs
        // lo pueda "recoger" después de que el formulario se cierre.
        public Usuario UsuarioLogueado { get; private set; }
        // ------------------------------
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
                    // ¡ÉXITO!
                    // 1. Guardamos el usuario en nuestra nueva propiedad
                    this.UsuarioLogueado = usuarioValidado;

                    // 2. Le decimos al 'ShowDialog()' que el resultado fue "OK"
                    this.DialogResult = DialogResult.OK;

                    // 3. Cerramos este formulario de login
                    this.Close();
                }
                else
                {
                    // FRACASO
                    MessageBox.Show("Usuario o contraseña incorrectos.", "Error de Login", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    // No cerramos el formulario
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al intentar conectar: " + ex.Message, "Error Crítico", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        // (Opcional) Programa el botón Cancelar
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close(); // Cierra el formulario de login
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {

        }
    }
}
