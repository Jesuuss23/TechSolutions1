using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using TechSolutions.BLL;
using TechSolutions.Entidades;

namespace TechSolutions.Presentacion
{
    public partial class frmGestionUsuarios : Form
    {
        private readonly UsuarioBLL _usuarioBLL = new UsuarioBLL();
        private readonly RolBLL _rolBLL = new RolBLL();

        private int _idUsuarioSeleccionado = 0;
        public frmGestionUsuarios()
        {
            InitializeComponent();
        }

        private void frmGestionUsuarios_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            StyleHelper.AplicarEstiloDataGridView(dgvUsuarios);
            CargarRoles(); 
            CargarUsuarios();
        }

        private void CargarRoles()
        {
            try
            {
                List<Rol> listaRoles = _rolBLL.ObtenerRoles();

                cmbRol.DataSource = listaRoles;
                cmbRol.DisplayMember = "NombreRol";
                cmbRol.ValueMember = "IdRol";    
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar roles: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void CargarUsuarios()
        {
            try
            {
                List<Usuario> listaUsuarios = _usuarioBLL.ObtenerUsuarios();

                dgvUsuarios.DataSource = null;
                dgvUsuarios.DataSource = listaUsuarios;

                // (Opcional) Ocultar columnas
                dgvUsuarios.Columns["IdUsuario"].Visible = false;
                dgvUsuarios.Columns["IdRol"].Visible = false;
                dgvUsuarios.Columns["UltimoAcceso"].HeaderText = "Último Acceso";
                dgvUsuarios.Columns["NombreRol"].HeaderText = "Rol";
                dgvUsuarios.Columns["NombreUsuario"].HeaderText = "Usuario";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar usuarios: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            try
            {
                Usuario nuevoUsuario = new Usuario
                {
                    NombreUsuario = txtUsuario.Text,
                    Email = txtEmail.Text,
                    IdRol = (int)cmbRol.SelectedValue
                };

                string password = txtPassword.Text;

                bool exito = _usuarioBLL.RegistrarUsuario(nuevoUsuario, password);

                if (exito)
                {
                    MessageBox.Show(
                        "¡Usuario registrado exitosamente!",
                        "Registro Exitoso",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    CargarUsuarios();

                    LimpiarCampos();
                }
                else
                {
                    MessageBox.Show(
                        "No se pudo registrar el usuario. Verifique que el nombre de usuario o email no esté duplicado.",
                        "Error de Registro",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error inesperado al registrar: " + ex.Message,
                    "Error Crítico",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
        private void LimpiarCampos()
        {
            txtUsuario.Text = "";
            txtPassword.Text = "";
            txtEmail.Text = "";
            cmbRol.SelectedIndex = 0; 
            chkActivo.Checked = true;
            _idUsuarioSeleccionado = 0; 

            txtPassword.Enabled = true;
            btnResetPassword.Enabled = false;
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }

        private void dgvUsuarios_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                try
                {
                    DataGridViewRow fila = dgvUsuarios.Rows[e.RowIndex];

                    txtUsuario.Text = fila.Cells["NombreUsuario"].Value.ToString();
                    txtEmail.Text = fila.Cells["Email"].Value.ToString();

                    cmbRol.SelectedValue = Convert.ToInt32(fila.Cells["IdRol"].Value);

                    chkActivo.Checked = Convert.ToBoolean(fila.Cells["Estado"].Value);

                    _idUsuarioSeleccionado = Convert.ToInt32(fila.Cells["IdUsuario"].Value);

                    txtPassword.Enabled = false;
                    txtPassword.Text = "**********"; 
                    btnResetPassword.Enabled = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al seleccionar el usuario: " + ex.Message);
                }
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (_idUsuarioSeleccionado <= 0)
            {
                MessageBox.Show(
                    "Por favor, seleccione un usuario de la lista antes de actualizar.",
                    "Selección Requerida",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return; 
            }


            try
            {
                Usuario usuarioActualizado = new Usuario
                {
                    IdUsuario = _idUsuarioSeleccionado,

                    NombreUsuario = txtUsuario.Text,
                    Email = txtEmail.Text,
                    IdRol = (int)cmbRol.SelectedValue,
                    Estado = chkActivo.Checked 
                };

                bool exito = _usuarioBLL.ActualizarUsuario(usuarioActualizado);

                if (exito)
                {
                    MessageBox.Show(
                        "¡Usuario actualizado exitosamente!",
                        "Actualización Exitosa",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    CargarUsuarios();

                    LimpiarCampos();
                }
                else
                {
                    MessageBox.Show(
                        "No se pudo actualizar el usuario. Verifique que el nombre de usuario o email no esté duplicado.",
                        "Error de Actualización",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error inesperado al actualizar: " + ex.Message,
                    "Error Crítico",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (_idUsuarioSeleccionado <= 0)
            {
                MessageBox.Show(
                    "Por favor, seleccione un usuario de la lista antes de eliminar.",
                    "Selección Requerida",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return; 
            }

            DialogResult confirmacion = MessageBox.Show(
                "¿Está seguro de que desea eliminar (desactivar) a este usuario?",
                "Confirmar Eliminación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirmacion == DialogResult.Yes)
            {
                try
                {
                    bool exito = _usuarioBLL.EliminarUsuario(_idUsuarioSeleccionado);

                    if (exito)
                    {
                        MessageBox.Show(
                            "¡Usuario eliminado (desactivado) exitosamente!",
                            "Eliminación Exitosa",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);

                        CargarUsuarios();

                        LimpiarCampos();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(
                        "Error inesperado al eliminar: " + ex.Message,
                        "Error Crítico",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
        }

        private void btnResetPassword_Click(object sender, EventArgs e)
        {
            if (_idUsuarioSeleccionado <= 0)
            {
                MessageBox.Show("Por favor, seleccione un usuario de la lista.", "Selección Requerida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string nuevaPassword = Interaction.InputBox(
                $"Ingrese la nueva contraseña para el usuario: {txtUsuario.Text}",
                "Restablecer Contraseña",
                ""); 

            if (string.IsNullOrEmpty(nuevaPassword))
            {
                MessageBox.Show("Operación cancelada o contraseña vacía.", "Cancelado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                bool exito = _usuarioBLL.ResetPassword(_idUsuarioSeleccionado, nuevaPassword);

                if (exito)
                {
                    MessageBox.Show(
                        "¡Contraseña restablecida exitosamente!",
                        "Éxito",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    LimpiarCampos(); 
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error inesperado al restablecer la contraseña: " + ex.Message, "Error Crítico", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
