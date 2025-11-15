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
            this.WindowState = FormWindowState.Maximized;
            StyleHelper.AplicarEstiloDataGridView(dgvProductos);
            CargarCategorias(); 
            CargarProductos();
        }
        private void CargarCategorias()
        {
            try
            {
                List<Categoria> listaCategorias = _categoriaBLL.ObtenerCategorias();

                cmbCategoria.DataSource = listaCategorias;
                cmbCategoria.DisplayMember = "NombreCategoria"; 
                cmbCategoria.ValueMember = "IdCategoria";     
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar categorías: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarProductos()
        {
            try
            {
                List<Producto> listaProductos = _productoBLL.ObtenerProductos();

                dgvProductos.DataSource = null;
                dgvProductos.DataSource = listaProductos;

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
                Producto nuevoProducto = new Producto
                {
                    Nombre = txtNombre.Text,
                    Descripcion = txtDescripcion.Text,
                    Precio = numPrecio.Value, 
                    Stock = (int)numStock.Value, 

                    IdCategoria = (int)cmbCategoria.SelectedValue
                };

                bool exito = _productoBLL.RegistrarProducto(nuevoProducto);

                if (exito)
                {
                    MessageBox.Show(
                        "¡Producto registrado exitosamente!",
                        "Registro Exitoso",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    CargarProductos();

                    LimpiarCampos();
                }
                else
                {
                    MessageBox.Show(
                        "No se pudo registrar el producto. Verifique que el nombre no esté duplicado o que todos los campos estén completos.",
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
            txtDescripcion.Text = "";
            numPrecio.Value = 0;
            numStock.Value = 0;
            cmbCategoria.SelectedIndex = 0; 
            _idProductoSeleccionado = 0;
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }

        private void dgvProductos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                try
                {
                    DataGridViewRow fila = dgvProductos.Rows[e.RowIndex];

                    txtNombre.Text = fila.Cells["Nombre"].Value.ToString();
                    txtDescripcion.Text = fila.Cells["Descripcion"].Value.ToString();
                    numPrecio.Value = Convert.ToDecimal(fila.Cells["Precio"].Value);
                    numStock.Value = Convert.ToInt32(fila.Cells["Stock"].Value);

                    cmbCategoria.SelectedValue = Convert.ToInt32(fila.Cells["IdCategoria"].Value);

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
            if (_idProductoSeleccionado <= 0)
            {
                MessageBox.Show(
                    "Por favor, seleccione un producto de la lista antes de actualizar.",
                    "Selección Requerida",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return; 
            }

            try
            {
                Producto productoActualizado = new Producto
                {
                    IdProducto = _idProductoSeleccionado,

                    Nombre = txtNombre.Text,
                    Descripcion = txtDescripcion.Text,
                    Precio = numPrecio.Value,
                    Stock = (int)numStock.Value,
                    IdCategoria = (int)cmbCategoria.SelectedValue
                };

                bool exito = _productoBLL.ActualizarProducto(productoActualizado);

                if (exito)
                {
                    MessageBox.Show(
                        "¡Producto actualizado exitosamente!",
                        "Actualización Exitosa",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    CargarProductos();

                    LimpiarCampos();
                }
                else
                {
                    MessageBox.Show(
                        "No se pudo actualizar el producto. Verifique que el nombre no esté duplicado.",
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
            if (_idProductoSeleccionado <= 0)
            {
                MessageBox.Show(
                    "Por favor, seleccione un producto de la lista antes de eliminar.",
                    "Selección Requerida",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return; 
            }

            DialogResult confirmacion = MessageBox.Show(
                "¿Está seguro de que desea eliminar este producto?\nEsta acción no se puede deshacer.",
                "Confirmar Eliminación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirmacion == DialogResult.Yes)
            {
                try
                {
                    bool exito = _productoBLL.EliminarProducto(_idProductoSeleccionado);

                    if (exito)
                    {
                        MessageBox.Show(
                            "¡Producto eliminado exitosamente!",
                            "Eliminación Exitosa",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);


                        CargarProductos();

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
    }
}
