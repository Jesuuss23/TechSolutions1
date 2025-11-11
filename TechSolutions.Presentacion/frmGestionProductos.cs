using TechSolutions.BLL;
using TechSolutions.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TechSolutions.Presentacion
{
    public partial class frmGestionProductos : Form
    {
        private readonly ProductoBLL _productoBLL = new ProductoBLL();
        private readonly CategoriaBLL _categoriaBLL = new CategoriaBLL();
        private int _idProductoSeleccionado = 0;
        public frmGestionProductos()
        {
            InitializeComponent();
        }

        private void frmGestionProductos_Load(object sender, EventArgs e)
        {
            CargarCategorias(); // ¡Primero cargamos el ComboBox!
            CargarProductos();
        }
        /// <summary>
        /// Carga el ComboBox (cmbCategoria) con las categorías de la BD.
        /// </summary>
        private void CargarCategorias()
        {
            try
            {
                List<Categoria> listaCategorias = _categoriaBLL.ObtenerCategorias();

                // Configuramos el ComboBox
                cmbCategoria.DataSource = listaCategorias;
                cmbCategoria.DisplayMember = "NombreCategoria"; // Lo que ve el usuario
                cmbCategoria.ValueMember = "IdCategoria";     // El valor oculto (ID)
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar categorías: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Carga la cuadrícula (dgvProductos) con los productos de la BD.
        /// </summary>
        private void CargarProductos()
        {
            try
            {
                List<Producto> listaProductos = _productoBLL.ObtenerProductos();

                dgvProductos.DataSource = null;
                dgvProductos.DataSource = listaProductos;

                // (Opcional) Ocultar columnas
                dgvProductos.Columns["IdProducto"].Visible = false;
                dgvProductos.Columns["IdCategoria"].Visible = false;
                dgvProductos.Columns["Estado"].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar productos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            try
            {
                // 1. Recolectar los datos del formulario
                Producto nuevoProducto = new Producto
                {
                    Nombre = txtNombre.Text,
                    Descripcion = txtDescripcion.Text,
                    Precio = numPrecio.Value, // Obtenemos el valor del NumericUpDown
                    Stock = (int)numStock.Value, // Convertimos el valor a 'int'

                    // Obtenemos el ID de la categoría seleccionada en el ComboBox
                    IdCategoria = (int)cmbCategoria.SelectedValue
                };

                // 2. Llamar a la BLL para que intente registrarlo
                //    (La BLL validará que los campos no estén vacíos)
                bool exito = _productoBLL.RegistrarProducto(nuevoProducto);

                // 3. Evaluar la respuesta de la BLL
                if (exito)
                {
                    MessageBox.Show(
                        "¡Producto registrado exitosamente!",
                        "Registro Exitoso",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    // 4. Refrescar la cuadrícula
                    CargarProductos();

                    // 5. Limpiar los campos
                    LimpiarCampos();
                }
                else
                {
                    // Esto sucede si la BLL o la DAL devuelven 'false'
                    // (ej. el nombre ya existe o faltan campos)
                    MessageBox.Show(
                        "No se pudo registrar el producto. Verifique que el nombre no esté duplicado o que todos los campos estén completos.",
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
            txtNombre.Text = "";
            txtDescripcion.Text = "";
            numPrecio.Value = 0;
            numStock.Value = 0;
            cmbCategoria.SelectedIndex = 0; // Selecciona el primer ítem
            _idProductoSeleccionado = 0; // Reseteamos el ID
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }

        private void dgvProductos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Verificamos que se haya hecho clic en una fila válida
            if (e.RowIndex >= 0)
            {
                try
                {
                    // 1. Obtenemos la fila seleccionada
                    DataGridViewRow fila = dgvProductos.Rows[e.RowIndex];

                    // 2. Pasamos los valores de las celdas a los controles
                    txtNombre.Text = fila.Cells["Nombre"].Value.ToString();
                    txtDescripcion.Text = fila.Cells["Descripcion"].Value.ToString();
                    numPrecio.Value = Convert.ToDecimal(fila.Cells["Precio"].Value);
                    numStock.Value = Convert.ToInt32(fila.Cells["Stock"].Value);

                    // 3. --- SELECCIONAR LA CATEGORÍA EN EL COMBOBOX ---
                    //    Esto busca el IdCategoria de la fila (ej. 1)
                    //    y lo selecciona en el ComboBox.
                    cmbCategoria.SelectedValue = Convert.ToInt32(fila.Cells["IdCategoria"].Value);

                    // 4. Guardamos el ID del producto para el botón "Actualizar"
                    _idProductoSeleccionado = Convert.ToInt32(fila.Cells["IdProducto"].Value);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al seleccionar el producto: " + ex.Message);
                }
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            // 1. Verificamos que haya un producto seleccionado
            if (_idProductoSeleccionado <= 0)
            {
                MessageBox.Show(
                    "Por favor, seleccione un producto de la lista antes de actualizar.",
                    "Selección Requerida",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return; // Salimos del método
            }

            try
            {
                // 2. Recolectar los datos del formulario
                Producto productoActualizado = new Producto
                {
                    // ¡IMPORTANTE! Asignamos el ID que guardamos al seleccionar
                    IdProducto = _idProductoSeleccionado,

                    Nombre = txtNombre.Text,
                    Descripcion = txtDescripcion.Text,
                    Precio = numPrecio.Value,
                    Stock = (int)numStock.Value,
                    IdCategoria = (int)cmbCategoria.SelectedValue
                };

                // 3. Llamar a la BLL para que intente actualizarlo
                bool exito = _productoBLL.ActualizarProducto(productoActualizado);

                // 4. Evaluar la respuesta de la BLL
                if (exito)
                {
                    MessageBox.Show(
                        "¡Producto actualizado exitosamente!",
                        "Actualización Exitosa",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    // 5. Refrescar la cuadrícula para ver los cambios
                    CargarProductos();

                    // 6. Limpiar los campos y el ID
                    LimpiarCampos();
                }
                else
                {
                    // Esto sucede si la BLL o la DAL devuelven 'false'
                    // (ej. el nombre está duplicado por OTRO producto)
                    MessageBox.Show(
                        "No se pudo actualizar el producto. Verifique que el nombre no esté duplicado.",
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
            // 1. Verificamos que haya un producto seleccionado
            if (_idProductoSeleccionado <= 0)
            {
                MessageBox.Show(
                    "Por favor, seleccione un producto de la lista antes de eliminar.",
                    "Selección Requerida",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return; // Salimos del método
            }

            // 2. ¡Confirmación!
            DialogResult confirmacion = MessageBox.Show(
                "¿Está seguro de que desea eliminar este producto?\nEsta acción no se puede deshacer.",
                "Confirmar Eliminación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            // 3. Verificamos la respuesta
            if (confirmacion == DialogResult.Yes)
            {
                try
                {
                    // 4. Llamar a la BLL para que intente eliminarlo
                    bool exito = _productoBLL.EliminarProducto(_idProductoSeleccionado);

                    if (exito)
                    {
                        MessageBox.Show(
                            "¡Producto eliminado exitosamente!",
                            "Eliminación Exitosa",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);

                        // 5. Refrescar la cuadrícula (el producto desaparecerá)
                        CargarProductos();

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
    }
}
