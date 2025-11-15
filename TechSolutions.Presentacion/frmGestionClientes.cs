
using TechSolutions.BLL;
using TechSolutions.Entidades;
// ----------------------------

using System;
using System.Collections.Generic; 
using System.Windows.Forms;

namespace TechSolutions.Presentacion
{
    public partial class frmGestionClientes : Form
    {
        private readonly ClienteBLL _clienteBLL = new ClienteBLL();
        private int _idClienteSeleccionado = 0;
        private List<Cliente> _listaCompletaClientes;
        public frmGestionClientes()
        {
            InitializeComponent();
        }

        private void frmGestionClientes_Load(object sender, EventArgs e)
        {
            StyleHelper.AplicarEstiloDataGridView(dgvClientes);
            this.WindowState = FormWindowState.Maximized;
            CargarClientes();

        }
        private void CargarClientes()
        {
            try
            {
                _listaCompletaClientes = _clienteBLL.ObtenerClientes();

                dgvClientes.DataSource = null;
                dgvClientes.DataSource = _listaCompletaClientes;

                List<Cliente> listaClientes = _clienteBLL.ObtenerClientes();

                dgvClientes.DataSource = null; 
                dgvClientes.DataSource = listaClientes;

            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error al cargar los clientes: " + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            try
            {
                Cliente nuevoCliente = new Cliente
                {
                    Nombre = txtNombre.Text,
                    Apellido = txtApellido.Text,
                    Documento = txtDocumento.Text,
                    Correo = txtCorreo.Text,
                    Telefono = txtTelefono.Text,
                    Direccion = txtDireccion.Text
                };

                bool exito = _clienteBLL.RegistrarCliente(nuevoCliente);

                if (exito)
                {
                    MessageBox.Show(
                        "¡Cliente registrado exitosamente!",
                        "Registro Exitoso",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    CargarClientes();

                    LimpiarCampos();
                }
                else
                {
                    MessageBox.Show(
                        "No se pudo registrar el cliente. Verifique que el documento no esté duplicado o que los campos obligatorios (Nombre, Apellido, Documento) estén completos.",
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
            txtNombre.Text = "";
            txtApellido.Text = "";
            txtDocumento.Text = "";
            txtCorreo.Text = "";
            txtTelefono.Text = "";
            txtDireccion.Text = "";
            _idClienteSeleccionado = 0;
            btnVerHistorial.Enabled = false;

        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }

        private void dgvClientes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow fila = dgvClientes.Rows[e.RowIndex];

                txtNombre.Text = fila.Cells["Nombre"].Value.ToString();
                txtApellido.Text = fila.Cells["Apellido"].Value.ToString();
                txtDocumento.Text = fila.Cells["Documento"].Value.ToString();
                txtCorreo.Text = fila.Cells["Correo"].Value.ToString();
                txtTelefono.Text = fila.Cells["Telefono"].Value.ToString();
                txtDireccion.Text = fila.Cells["Direccion"].Value.ToString();

                _idClienteSeleccionado = Convert.ToInt32(fila.Cells["IdCliente"].Value);
                btnVerHistorial.Enabled = true;
            }

        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (_idClienteSeleccionado <= 0)
            {
                MessageBox.Show(
                    "Por favor, seleccione un cliente de la lista antes de actualizar.",
                    "Selección Requerida",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return; 
            }

            try
            {
                Cliente clienteActualizado = new Cliente
                {
                    IdCliente = _idClienteSeleccionado,

                    Nombre = txtNombre.Text,
                    Apellido = txtApellido.Text,
                    Documento = txtDocumento.Text,
                    Correo = txtCorreo.Text,
                    Telefono = txtTelefono.Text,
                    Direccion = txtDireccion.Text
                };

                bool exito = _clienteBLL.ActualizarCliente(clienteActualizado);

                if (exito)
                {
                    MessageBox.Show(
                        "¡Cliente actualizado exitosamente!",
                        "Actualización Exitosa",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    CargarClientes();

                    LimpiarCampos();
                }
                else
                {
                    MessageBox.Show(
                        "No se pudo actualizar el cliente. Verifique que el documento no esté duplicado.",
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
            if (_idClienteSeleccionado <= 0)
            {
                MessageBox.Show(
                    "Por favor, seleccione un cliente de la lista antes de eliminar.",
                    "Selección Requerida",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return; 
            }

            DialogResult confirmacion = MessageBox.Show(
                "¿Está seguro de que desea eliminar a este cliente?\nEsta acción no se puede deshacer.",
                "Confirmar Eliminación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirmacion == DialogResult.Yes)
            {
                try
                {
                    bool exito = _clienteBLL.EliminarCliente(_idClienteSeleccionado);

                    if (exito)
                    {
                        MessageBox.Show(
                            "¡Cliente eliminado exitosamente!",
                            "Eliminación Exitosa",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);

                        CargarClientes();

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

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            string filtro = txtBuscar.Text.ToLower().Trim();

            List<Cliente> listaFiltrada;


            if (string.IsNullOrEmpty(filtro))
            {
                listaFiltrada = _listaCompletaClientes;
            }
            else
            {
                listaFiltrada = _listaCompletaClientes
                    .Where(cliente =>
                        cliente.Nombre.ToLower().Contains(filtro) ||
                        cliente.Apellido.ToLower().Contains(filtro) ||
                        cliente.Documento.Contains(filtro)
                    )
                    .ToList(); 
            }

            dgvClientes.DataSource = null;
            dgvClientes.DataSource = listaFiltrada;
        }

        private void btnVerHistorial_Click(object sender, EventArgs e)
        {
            string nombreCliente = $"{txtNombre.Text} {txtApellido.Text}";

            frmHistorialCliente formularioHistorial = new frmHistorialCliente(_idClienteSeleccionado, nombreCliente);
            formularioHistorial.Show();
        }

        private void txtNombre_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            TextBox cajon = (TextBox)sender;

            if (string.IsNullOrEmpty(cajon.Text.Trim()))
            {
                epClientes.SetError(cajon, "Este campo es obligatorio");
            }
            else
            {
                epClientes.SetError(cajon, "");
            }
        }

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {
            bool nombreOK = !string.IsNullOrEmpty(txtNombre.Text.Trim());
            bool apellidoOK = !string.IsNullOrEmpty(txtApellido.Text.Trim());
            bool docOK = !string.IsNullOrEmpty(txtDocumento.Text.Trim());

            btnRegistrar.Enabled = (nombreOK && apellidoOK && docOK);
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}