// --- Archivo: frmGestionClientes.cs ---
// --- Proyecto: TechSolutions.Presentacion ---

// --- AÑADE ESTOS USINGS ---
using TechSolutions.BLL;
using TechSolutions.Entidades;
// ----------------------------

using System;
using System.Collections.Generic; // Para List<>
using System.Windows.Forms;

namespace TechSolutions.Presentacion
{
    public partial class frmGestionClientes : Form
    {
        // --- AÑADE LA INSTANCIA DE LA BLL ---
        private readonly ClienteBLL _clienteBLL = new ClienteBLL();
        // ------------------------------------
        private int _idClienteSeleccionado = 0;
        // Esta lista guardará los datos originales de la BD
        private List<Cliente> _listaCompletaClientes;
        // ----------------------------
        public frmGestionClientes()
        {
            InitializeComponent();
        }

        private void frmGestionClientes_Load(object sender, EventArgs e)
        {
            CargarClientes();

        }
        // (El resto del código vendrá aquí)
        // --- Dentro de 'public partial class frmGestionClientes : Form' ---

        // Este es el método que se creó en el paso 2
        //private void frmGestionClientes_Load(object sender, EventArgs e)
        // {

        // }

        /// <summary>
        /// Método auxiliar para cargar la cuadrícula (DataGridView)
        /// con los datos de la base de datos.
        /// </summary>
        private void CargarClientes()
        {
            try
            {
                // 1. Llamamos a la BLL para obtener la lista COMPLETA
                _listaCompletaClientes = _clienteBLL.ObtenerClientes();

                // 2. Asignamos la lista como la fuente de datos
                dgvClientes.DataSource = null;
                dgvClientes.DataSource = _listaCompletaClientes;

                // 1. Llamamos a la BLL para obtener la lista
                List<Cliente> listaClientes = _clienteBLL.ObtenerClientes();

                // 2. Asignamos la lista como la fuente de datos
                //    de nuestra cuadrícula (DataGridView)
                dgvClientes.DataSource = null; // Limpiamos primero (buena práctica)
                dgvClientes.DataSource = listaClientes;

                // (Opcional) Ocultar columnas que no quieres ver
                // dgvClientes.Columns["IdCliente"].Visible = false;
                // dgvClientes.Columns["Estado"].Visible = false;
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
                // 1. Recolectar los datos del formulario
                Cliente nuevoCliente = new Cliente
                {
                    Nombre = txtNombre.Text,
                    Apellido = txtApellido.Text,
                    Documento = txtDocumento.Text,
                    Correo = txtCorreo.Text,
                    Telefono = txtTelefono.Text,
                    Direccion = txtDireccion.Text
                    // El 'Estado' se maneja por defecto en el Stored Procedure
                };

                // 2. Llamar a la BLL para que intente registrarlo
                bool exito = _clienteBLL.RegistrarCliente(nuevoCliente);

                // 3. Evaluar la respuesta de la BLL
                if (exito)
                {
                    MessageBox.Show(
                        "¡Cliente registrado exitosamente!",
                        "Registro Exitoso",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    // 4. Refrescar la cuadrícula para ver al nuevo cliente
                    CargarClientes();

                    // 5. (Opcional) Limpiar los campos
                    LimpiarCampos();
                }
                else
                {
                    // Esto sucede si la BLL o la DAL devuelven 'false'
                    // (ej. el documento ya existe)
                    MessageBox.Show(
                        "No se pudo registrar el cliente. Verifique que el documento no esté duplicado o que los campos obligatorios (Nombre, Apellido, Documento) estén completos.",
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
        /// Método auxiliar para limpiar los TextBox del formulario.
        /// </summary>
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
            // 1. Verificamos que se haya hecho clic en una fila válida
            //    (e.RowIndex >= 0) evita el clic en la cabecera
            if (e.RowIndex >= 0)
            {
                // 2. Obtenemos la fila seleccionada
                DataGridViewRow fila = dgvClientes.Rows[e.RowIndex];

                // 3. Pasamos los valores de las celdas a los TextBox
                txtNombre.Text = fila.Cells["Nombre"].Value.ToString();
                txtApellido.Text = fila.Cells["Apellido"].Value.ToString();
                txtDocumento.Text = fila.Cells["Documento"].Value.ToString();
                txtCorreo.Text = fila.Cells["Correo"].Value.ToString();
                txtTelefono.Text = fila.Cells["Telefono"].Value.ToString();
                txtDireccion.Text = fila.Cells["Direccion"].Value.ToString();

                // 4. Guardamos el ID del cliente en nuestra variable privada
                //    Esto es crucial para el botón "Actualizar"
                _idClienteSeleccionado = Convert.ToInt32(fila.Cells["IdCliente"].Value);
                // --- AÑADE ESTA LÍNEA ---
                btnVerHistorial.Enabled = true;
            }

        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            // 1. Verificamos que haya un cliente seleccionado
            if (_idClienteSeleccionado <= 0)
            {
                MessageBox.Show(
                    "Por favor, seleccione un cliente de la lista antes de actualizar.",
                    "Selección Requerida",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return; // Salimos del método
            }

            try
            {
                // 2. Recolectar los datos del formulario
                Cliente clienteActualizado = new Cliente
                {
                    // ¡IMPORTANTE! Asignamos el ID que guardamos al seleccionar
                    IdCliente = _idClienteSeleccionado,

                    Nombre = txtNombre.Text,
                    Apellido = txtApellido.Text,
                    Documento = txtDocumento.Text,
                    Correo = txtCorreo.Text,
                    Telefono = txtTelefono.Text,
                    Direccion = txtDireccion.Text
                };

                // 3. Llamar a la BLL para que intente actualizarlo
                bool exito = _clienteBLL.ActualizarCliente(clienteActualizado);

                // 4. Evaluar la respuesta de la BLL
                if (exito)
                {
                    MessageBox.Show(
                        "¡Cliente actualizado exitosamente!",
                        "Actualización Exitosa",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    // 5. Refrescar la cuadrícula para ver los cambios
                    CargarClientes();

                    // 6. Limpiar los campos y el ID
                    LimpiarCampos();
                }
                else
                {
                    // Esto sucede si la BLL o la DAL devuelven 'false'
                    // (ej. el documento está duplicado por OTRO cliente)
                    MessageBox.Show(
                        "No se pudo actualizar el cliente. Verifique que el documento no esté duplicado.",
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
            // 1. Verificamos que haya un cliente seleccionado
            if (_idClienteSeleccionado <= 0)
            {
                MessageBox.Show(
                    "Por favor, seleccione un cliente de la lista antes de eliminar.",
                    "Selección Requerida",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return; // Salimos del método
            }

            // 2. ¡Confirmación!
            //    Pedimos al usuario que confirme la acción.
            DialogResult confirmacion = MessageBox.Show(
                "¿Está seguro de que desea eliminar a este cliente?\nEsta acción no se puede deshacer.",
                "Confirmar Eliminación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            // 3. Verificamos la respuesta
            if (confirmacion == DialogResult.Yes)
            {
                try
                {
                    // 4. Llamar a la BLL para que intente eliminarlo
                    bool exito = _clienteBLL.EliminarCliente(_idClienteSeleccionado);

                    if (exito)
                    {
                        MessageBox.Show(
                            "¡Cliente eliminado exitosamente!",
                            "Eliminación Exitosa",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);

                        // 5. Refrescar la cuadrícula (el cliente desaparecerá)
                        CargarClientes();

                        // 6. Limpiar los campos y el ID
                        LimpiarCampos();
                    }
                }
                catch (Exception ex)
                {
                    // Esto captura errores más graves (ej. se cayó la BD)
                    MessageBox.Show(
                        "Error inesperado al eliminar: " + ex.Message,
                        "Error Crítico",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
            // Si el usuario presiona "No", no hacemos nada.

        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            // 1. Obtenemos el texto de búsqueda (en minúsculas para ignorar may/min)
            string filtro = txtBuscar.Text.ToLower().Trim();

            List<Cliente> listaFiltrada;

            // --- 2. ¡AQUÍ ESTÁ EL LINQ! ---
            //    Usamos LINQ to Objects para filtrar la lista en memoria

            if (string.IsNullOrEmpty(filtro))
            {
                // Si el buscador está vacío, mostramos la lista completa
                listaFiltrada = _listaCompletaClientes;
            }
            else
            {
                // Si hay texto, filtramos
                listaFiltrada = _listaCompletaClientes
                    .Where(cliente =>
                        cliente.Nombre.ToLower().Contains(filtro) ||
                        cliente.Apellido.ToLower().Contains(filtro) ||
                        cliente.Documento.Contains(filtro)
                    )
                    .ToList(); // Convertimos el resultado de nuevo a una Lista
            }

            // 3. Actualizamos la cuadrícula (DataGridView) con los resultados filtrados
            dgvClientes.DataSource = null;
            dgvClientes.DataSource = listaFiltrada;
        }

        private void btnVerHistorial_Click(object sender, EventArgs e)
        {
            // Pasamos el ID y el nombre del cliente al nuevo formulario
            string nombreCliente = $"{txtNombre.Text} {txtApellido.Text}";

            frmHistorialCliente formularioHistorial = new frmHistorialCliente(_idClienteSeleccionado, nombreCliente);
            formularioHistorial.Show();
        }

        private void txtNombre_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            // 'sender' es el TextBox que disparó el evento
            TextBox cajon = (TextBox)sender;

            if (string.IsNullOrEmpty(cajon.Text.Trim()))
            {
                // Si está vacío, pone el ícono de error
                epClientes.SetError(cajon, "Este campo es obligatorio");
            }
            else
            {
                // Si está lleno, limpia el error
                epClientes.SetError(cajon, "");
            }
        }

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {
            // Verificamos si todos los campos requeridos están llenos
            bool nombreOK = !string.IsNullOrEmpty(txtNombre.Text.Trim());
            bool apellidoOK = !string.IsNullOrEmpty(txtApellido.Text.Trim());
            bool docOK = !string.IsNullOrEmpty(txtDocumento.Text.Trim());

            // Habilitamos el botón SOLO si todos están OK
            btnRegistrar.Enabled = (nombreOK && apellidoOK && docOK);
        }
    }
}