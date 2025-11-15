using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TechSolutions.BLL;
using TechSolutions.Entidades;

namespace TechSolutions.Presentacion
{
    public partial class frmGestionVentas : Form
    {
        private readonly ClienteBLL _clienteBLL = new ClienteBLL();
        private readonly ProductoBLL _productoBLL = new ProductoBLL();
        private readonly Usuario _vendedorActual; 

        private readonly VentaBLL _ventaBLL = new VentaBLL();

        private DataTable _carrito = new DataTable();

        public frmGestionVentas(Usuario usuarioVendedor)
        {
            InitializeComponent();
            _vendedorActual = usuarioVendedor; 
        }

        private void frmGestionVentas_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            StyleHelper.AplicarEstiloDataGridView(dgvCarrito);
            ConfigurarCarrito();
            CargarClientes();
            CargarProductos();
        }

        private void ConfigurarCarrito()
        {
            _carrito.Columns.Add("IdProducto", typeof(int));
            _carrito.Columns.Add("Producto", typeof(string));
            _carrito.Columns.Add("Precio", typeof(decimal));
            _carrito.Columns.Add("Cantidad", typeof(int));
            _carrito.Columns.Add("Subtotal", typeof(decimal), "Precio * Cantidad"); // Columna calculada

            dgvCarrito.DataSource = _carrito;

            dgvCarrito.Columns["IdProducto"].Visible = false;
        }

        private void CargarClientes()
        {
            try
            {
                List<Cliente> listaClientes = _clienteBLL.ObtenerClientes();

                cmbCliente.DataSource = listaClientes;
                cmbCliente.DisplayMember = "NombreCompleto"; 
                cmbCliente.ValueMember = "IdCliente";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar clientes: " + ex.Message, "Error");
            }
        }

        private void CargarProductos()
        {
            try
            {
                List<Producto> listaProductos = _productoBLL.ObtenerProductos();

                cmbProducto.DataSource = listaProductos;
                cmbProducto.DisplayMember = "Nombre";
                cmbProducto.ValueMember = "IdProducto";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar productos: " + ex.Message, "Error");
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                Producto productoSeleccionado = (Producto)cmbProducto.SelectedItem;

                int cantidad = (int)numCantidad.Value;

                if (cantidad > productoSeleccionado.Stock)
                {
                    MessageBox.Show(
                        $"Stock insuficiente. Solo quedan {productoSeleccionado.Stock} unidades de {productoSeleccionado.Nombre}.",
                        "Error de Stock", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return; 
                }

                DataRow filaExistente = _carrito.AsEnumerable()
                                        .FirstOrDefault(fila => (int)fila["IdProducto"] == productoSeleccionado.IdProducto);

                if (filaExistente != null)
                {
                    int cantidadActual = (int)filaExistente["Cantidad"];

                    if (cantidadActual + cantidad > productoSeleccionado.Stock)
                    {
                        MessageBox.Show(
                           $"Stock insuficiente. Ya tiene {cantidadActual} en el carrito y solo quedan {productoSeleccionado.Stock} unidades.",
                           "Error de Stock", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    filaExistente["Cantidad"] = cantidadActual + cantidad;
                }
                else
                {
                    _carrito.Rows.Add(
                        productoSeleccionado.IdProducto,
                        productoSeleccionado.Nombre,
                        productoSeleccionado.Precio,
                        cantidad
                    );
                }

                ActualizarTotal();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al agregar al carrito: " + ex.Message, "Error");
            }
        }

        private void ActualizarTotal()
        {
            decimal totalVenta = _carrito.AsEnumerable()
                                         .Sum(fila => (decimal)fila["Subtotal"]);

            lblTotal.Text = $"Total: S/ {totalVenta:N2}";
        }

        private void btnRegistrarVenta_Click(object sender, EventArgs e)
        {
            if (_carrito.Rows.Count == 0)
            {
                MessageBox.Show("Debe agregar al menos un producto al carrito.", "Venta Vacía", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cmbCliente.SelectedValue == null)
            {
                MessageBox.Show("Debe seleccionar un cliente.", "Cliente Requerido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                Venta nuevaVenta = new Venta
                {
                    IdCliente = (int)cmbCliente.SelectedValue,
                    IdUsuario = _vendedorActual.IdUsuario,
                    Detalles = new List<DetalleVenta>() 
                };

                foreach (DataRow filaCarrito in _carrito.Rows)
                {
                    DetalleVenta detalle = new DetalleVenta
                    {
                        IdProducto = (int)filaCarrito["IdProducto"],
                        Cantidad = (int)filaCarrito["Cantidad"],
                        PrecioUnitario = (decimal)filaCarrito["Precio"] // Tomamos el precio del carrito
                    };
                    nuevaVenta.Detalles.Add(detalle);
                }

                bool exito = _ventaBLL.RegistrarVenta(nuevaVenta);

                if (exito)
                {
                    MessageBox.Show(
                        "¡Venta registrada exitosamente!",
                        "Transacción Exitosa",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    LimpiarFormularioVenta();

                    CargarProductos();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "No se pudo registrar la venta.\n\n" +
                    "Error: " + ex.Message,
                    "Error en Transacción",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void LimpiarFormularioVenta()
        {
            _carrito.Clear(); 
            ActualizarTotal(); 
            cmbCliente.SelectedIndex = 0;
            cmbProducto.SelectedIndex = 0;
            numCantidad.Value = 1;
        }
    }
}



