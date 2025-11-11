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
        // --- AÑADE LAS INSTANCIAS DE LAS BLLs ---
        private readonly UsuarioBLL _usuarioBLL = new UsuarioBLL();
        private readonly RolBLL _rolBLL = new RolBLL();

        // Variable para guardar el ID seleccionado
        private int _idUsuarioSeleccionado = 0;
        // ------------------------------------
        public frmGestionUsuarios()
        {
            InitializeComponent();
        }

        private void frmGestionUsuarios_Load(object sender, EventArgs e)
        {
            CargarRoles(); // ¡Primero cargamos el ComboBox!
            CargarUsuarios();
        }

        /// <summary>
        /// Carga el ComboBox (cmbRol) con los roles de la BD.
        /// </summary>
        private void CargarRoles()
        {
            try
            {
                List<Rol> listaRoles = _rolBLL.ObtenerRoles();

                // Configuramos el ComboBox
                cmbRol.DataSource = listaRoles;
                cmbRol.DisplayMember = "NombreRol"; // Lo que ve el usuario
                cmbRol.ValueMember = "IdRol";     // El valor oculto (ID)
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar roles: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Carga la cuadrícula (dgvUsuarios) con los usuarios de la BD.
        /// </summary>
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
                // 1. Recolectar los datos del formulario
                Usuario nuevoUsuario = new Usuario
                {
                    NombreUsuario = txtUsuario.Text,
                    Email = txtEmail.Text,
                    IdRol = (int)cmbRol.SelectedValue
                    // El 'Estado' se maneja por defecto en el SP
                };

                // Obtenemos la contraseña en texto plano
                string password = txtPassword.Text;

                // 2. Llamar a la BLL para que intente registrarlo
                //    (La BLL se encargará de hashear la contraseña)
                bool exito = _usuarioBLL.RegistrarUsuario(nuevoUsuario, password);

                // 3. Evaluar la respuesta de la BLL
                if (exito)
                {
                    MessageBox.Show(
                        "¡Usuario registrado exitosamente!",
                        "Registro Exitoso",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    // 4. Refrescar la cuadrícula
                    CargarUsuarios();

                    // 5. Limpiar los campos
                    LimpiarCampos();
                }
                else
                {
                    // Esto sucede si la BLL o la DAL devuelven 'false'
                    // (ej. el nombre de usuario o email ya existe)
                    MessageBox.Show(
                        "No se pudo registrar el usuario. Verifique que el nombre de usuario o email no esté duplicado.",
                        "Error de Registro",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                // Esto captura errores más graves (ej. se cayó la BD)
                MessageBox.Show(
                    "Error inesperado al registrar: " + ex.Message,
                    "Error Crítico",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
        /// <summary>
        /// Método auxiliar para limpiar los controles del formulario.
        /// </summary>
        private void LimpiarCampos()
        {
            txtUsuario.Text = "";
            txtPassword.Text = "";
            txtEmail.Text = "";
            cmbRol.SelectedIndex = 0; // Selecciona el primer ítem
            chkActivo.Checked = true;
            _idUsuarioSeleccionado = 0; // Reseteamos el ID

            // Habilitamos el campo de contraseña por si estaba deshabilitado
            txtPassword.Enabled = true;
            btnResetPassword.Enabled = false;
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }

        private void dgvUsuarios_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Verificamos que se haya hecho clic en una fila válida
            if (e.RowIndex >= 0)
            {
                try
                {
                    // 1. Obtenemos la fila seleccionada
                    DataGridViewRow fila = dgvUsuarios.Rows[e.RowIndex];

                    // 2. Pasamos los valores de las celdas a los controles
                    txtUsuario.Text = fila.Cells["NombreUsuario"].Value.ToString();
                    txtEmail.Text = fila.Cells["Email"].Value.ToString();

                    // 3. Seleccionamos el Rol en el ComboBox
                    cmbRol.SelectedValue = Convert.ToInt32(fila.Cells["IdRol"].Value);

                    // 4. Marcamos el CheckBox de Estado
                    chkActivo.Checked = Convert.ToBoolean(fila.Cells["Estado"].Value);

                    // 5. Guardamos el ID del usuario para "Actualizar" o "Eliminar"
                    _idUsuarioSeleccionado = Convert.ToInt32(fila.Cells["IdUsuario"].Value);

                    // --- Lógica de seguridad ---
                    // 6. Deshabilitamos el campo de contraseña.
                    //    No se debe poder ver ni editar la contraseña existente.
                    //    Para cambiarla, se debería usar un formulario separado.
                    txtPassword.Enabled = false;
                    txtPassword.Text = "**********"; // Relleno visual
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
            // 1. Verificamos que haya un usuario seleccionado
            if (_idUsuarioSeleccionado <= 0)
            {
                MessageBox.Show(
                    "Por favor, seleccione un usuario de la lista antes de actualizar.",
                    "Selección Requerida",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return; // Salimos del método
            }

            // Nota: No actualizamos la contraseña aquí.
            // Eso requeriría un SP y un formulario separados por seguridad.

            try
            {
                // 2. Recolectar los datos del formulario
                Usuario usuarioActualizado = new Usuario
                {
                    // ¡IMPORTANTE! Asignamos el ID que guardamos al seleccionar
                    IdUsuario = _idUsuarioSeleccionado,

                    NombreUsuario = txtUsuario.Text,
                    Email = txtEmail.Text,
                    IdRol = (int)cmbRol.SelectedValue,
                    Estado = chkActivo.Checked // Asignamos el estado del CheckBox
                };

                // 3. Llamar a la BLL para que intente actualizarlo
                bool exito = _usuarioBLL.ActualizarUsuario(usuarioActualizado);

                // 4. Evaluar la respuesta de la BLL
                if (exito)
                {
                    MessageBox.Show(
                        "¡Usuario actualizado exitosamente!",
                        "Actualización Exitosa",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    // 5. Refrescar la cuadrícula para ver los cambios
                    CargarUsuarios();

                    // 6. Limpiar los campos y el ID
                    LimpiarCampos();
                }
                else
                {
                    // Esto sucede si la BLL o la DAL devuelven 'false'
                    // (ej. el nombre de usuario o email está duplicado por OTRO usuario)
                    MessageBox.Show(
                        "No se pudo actualizar el usuario. Verifique que el nombre de usuario o email no esté duplicado.",
                        "Error de Actualización",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                // Esto captura errores más graves (ej. se cayó la BD)
                MessageBox.Show(
                    "Error inesperado al actualizar: " + ex.Message,
                    "Error Crítico",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            // 1. Verificamos que haya un usuario seleccionado
            if (_idUsuarioSeleccionado <= 0)
            {
                MessageBox.Show(
                    "Por favor, seleccione un usuario de la lista antes de eliminar.",
                    "Selección Requerida",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return; // Salimos del método
            }

            // 2. ¡Confirmación!
            DialogResult confirmacion = MessageBox.Show(
                "¿Está seguro de que desea eliminar (desactivar) a este usuario?",
                "Confirmar Eliminación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            // 3. Verificamos la respuesta
            if (confirmacion == DialogResult.Yes)
            {
                try
                {
                    // 4. Llamar a la BLL para que intente eliminarlo
                    bool exito = _usuarioBLL.EliminarUsuario(_idUsuarioSeleccionado);

                    if (exito)
                    {
                        MessageBox.Show(
                            "¡Usuario eliminado (desactivado) exitosamente!",
                            "Eliminación Exitosa",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);

                        // 5. Refrescar la cuadrícula (el estado cambiará a 'False')
                        // Nota: Nuestro SP_ObtenerUsuarios los sigue mostrando.
                        // Podríamos cambiar ese SP para que solo muestre los 'Estado = 1'
                        // si quisiéramos que desaparezcan de la lista.
                        CargarUsuarios();

                        // 6. Limpiar los campos y el ID
                        LimpiarCampos();
                    }
                }
                catch (Exception ex)
                {
                    // Esto captura errores (ej. si el SP falla al intentar borrar 'admin')
                    MessageBox.Show(
                        "Error inesperado al eliminar: " + ex.Message,
                        "Error Crítico",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
            // Si el usuario presiona "No", no hacemos nada.
        }

        private void btnResetPassword_Click(object sender, EventArgs e)
        {
            // 1. Verificamos que haya un usuario seleccionado
            if (_idUsuarioSeleccionado <= 0)
            {
                MessageBox.Show("Por favor, seleccione un usuario de la lista.", "Selección Requerida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 2. Pedimos la nueva contraseña usando un InputBox
            string nuevaPassword = Interaction.InputBox(
                $"Ingrese la nueva contraseña para el usuario: {txtUsuario.Text}",
                "Restablecer Contraseña",
                ""); // '""' es el valor por defecto

            // 3. Verificamos que el admin no haya cancelado o dejado vacío
            if (string.IsNullOrEmpty(nuevaPassword))
            {
                MessageBox.Show("Operación cancelada o contraseña vacía.", "Cancelado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                // 4. Llamamos a la BLL (que hashea y guarda)
                bool exito = _usuarioBLL.ResetPassword(_idUsuarioSeleccionado, nuevaPassword);

                if (exito)
                {
                    MessageBox.Show(
                        "¡Contraseña restablecida exitosamente!",
                        "Éxito",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    LimpiarCampos(); // Limpiamos la selección
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error inesperado al restablecer la contraseña: " + ex.Message, "Error Crítico", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
