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
        // --- AÑADE LAS INSTANCIAS DE LAS BLLs Y EL USUARIO ---
        private readonly ClienteBLL _clienteBLL = new ClienteBLL();
        private readonly ProductoBLL _productoBLL = new ProductoBLL();
        private readonly Usuario _vendedorActual; // Para saber quién registra la venta

        private readonly VentaBLL _ventaBLL = new VentaBLL();

        // --- AÑADE LA TABLA PARA EL CARRITO ---
        // Un DataTable es una "tabla" en memoria, perfecta para el carrito.
        private DataTable _carrito = new DataTable();

        public frmGestionVentas(Usuario usuarioVendedor)
        {
            InitializeComponent();
            _vendedorActual = usuarioVendedor; // Guarda al vendedor
        }

        private void frmGestionVentas_Load(object sender, EventArgs e)
        {
            ConfigurarCarrito();
            CargarClientes();
            CargarProductos();
        }

        /// <summary>
        /// Crea las columnas para nuestro carrito (el DataGridView)
        /// </summary>
        private void ConfigurarCarrito()
        {
            // Añadimos las columnas a nuestra tabla en memoria
            _carrito.Columns.Add("IdProducto", typeof(int));
            _carrito.Columns.Add("Producto", typeof(string));
            _carrito.Columns.Add("Precio", typeof(decimal));
            _carrito.Columns.Add("Cantidad", typeof(int));
            _carrito.Columns.Add("Subtotal", typeof(decimal), "Precio * Cantidad"); // Columna calculada

            // Asignamos esta tabla al DataGridView
            dgvCarrito.DataSource = _carrito;

            // (Opcional) Ocultar la columna del ID
            dgvCarrito.Columns["IdProducto"].Visible = false;
        }

        /// <summary>
        /// Carga el ComboBox (cmbCliente) con los clientes de la BD.
        /// </summary>
        private void CargarClientes()
        {
            try
            {
                // Usamos la BLL para obtener la lista
                List<Cliente> listaClientes = _clienteBLL.ObtenerClientes();

                // Configuramos el ComboBox
                cmbCliente.DataSource = listaClientes;
                cmbCliente.DisplayMember = "NombreCompleto"; // ¡Necesitamos añadir esta propiedad!
                cmbCliente.ValueMember = "IdCliente";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar clientes: " + ex.Message, "Error");
            }
        }

        /// <summary>
        /// Carga el ComboBox (cmbProducto) con los productos de la BD.
        /// </summary>
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
                // 1. Obtener el producto seleccionado del ComboBox
                //    (Hacemos 'casting' al objeto completo)
                Producto productoSeleccionado = (Producto)cmbProducto.SelectedItem;

                // 2. Obtener la cantidad
                int cantidad = (int)numCantidad.Value;

                // --- VALIDACIONES ---

                // Validacion 1: Verificar el Stock
                if (cantidad > productoSeleccionado.Stock)
                {
                    MessageBox.Show(
                        $"Stock insuficiente. Solo quedan {productoSeleccionado.Stock} unidades de {productoSeleccionado.Nombre}.",
                        "Error de Stock", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return; // Salimos del método
                }

                // Validacion 2: ¿El producto ya está en el carrito?
                DataRow filaExistente = _carrito.AsEnumerable()
                                        .FirstOrDefault(fila => (int)fila["IdProducto"] == productoSeleccionado.IdProducto);

                if (filaExistente != null)
                {
                    // --- SÍ ESTÁ: Actualizamos la cantidad ---
                    int cantidadActual = (int)filaExistente["Cantidad"];

                    // Verificamos el stock total (lo que hay en el carrito + lo nuevo)
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
                    // --- NO ESTÁ: Agregamos una nueva fila ---
                    _carrito.Rows.Add(
                        productoSeleccionado.IdProducto,
                        productoSeleccionado.Nombre,
                        productoSeleccionado.Precio,
                        cantidad
                    // El subtotal se calcula solo (lo definimos en ConfigurarCarrito)
                    );
                }

                // 3. Actualizar el total
                ActualizarTotal();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al agregar al carrito: " + ex.Message, "Error");
            }
        }

        /// <summary>
        /// Método auxiliar para calcular y mostrar el total de la venta.
        /// </summary>
        private void ActualizarTotal()
        {
            // Suma todos los valores de la columna "Subtotal" del carrito
            decimal totalVenta = _carrito.AsEnumerable()
                                         .Sum(fila => (decimal)fila["Subtotal"]);

            // Muestra el total en el Label con formato de moneda
            lblTotal.Text = $"Total: S/ {totalVenta:N2}";
        }

        private void btnRegistrarVenta_Click(object sender, EventArgs e)
        {
            // --- VALIDACIONES INICIALES ---

            // 1. Validar que el carrito no esté vacío
            if (_carrito.Rows.Count == 0)
            {
                MessageBox.Show("Debe agregar al menos un producto al carrito.", "Venta Vacía", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 2. Validar que haya un cliente seleccionado
            if (cmbCliente.SelectedValue == null)
            {
                MessageBox.Show("Debe seleccionar un cliente.", "Cliente Requerido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // 3. --- CREAR EL OBJETO VENTA (Cabecera) ---
                Venta nuevaVenta = new Venta
                {
                    IdCliente = (int)cmbCliente.SelectedValue,
                    IdUsuario = _vendedorActual.IdUsuario,
                    Detalles = new List<DetalleVenta>() // Inicializamos la lista de detalles
                };

                // 4. --- LLENAR LOS DETALLES DE LA VENTA (El Carrito) ---
                //    Convertimos el DataTable '_carrito' a una List<DetalleVenta>
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

                // 5. --- LLAMAR A LA BLL PARA EJECUTAR LA TRANSACCIÓN ---
                bool exito = _ventaBLL.RegistrarVenta(nuevaVenta);

                // 6. Evaluar la respuesta
                if (exito)
                {
                    MessageBox.Show(
                        "¡Venta registrada exitosamente!",
                        "Transacción Exitosa",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    // 7. Limpiar todo para una nueva venta
                    LimpiarFormularioVenta();

                    // 8. (IMPORTANTE) Recargar los productos, ya que el stock ha cambiado
                    CargarProductos();
                }
            }
            catch (Exception ex)
            {
                // 8. Capturamos cualquier error, especialmente el RAISERROR del SP por
                //    stock insuficiente que viaja a través de la DAL y BLL.
                MessageBox.Show(
                    "No se pudo registrar la venta.\n\n" +
                    "Error: " + ex.Message,
                    "Error en Transacción",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Método auxiliar para limpiar todo el formulario de ventas.
        /// </summary>
        private void LimpiarFormularioVenta()
        {
            _carrito.Clear(); // Vacía el DataGridView
            ActualizarTotal(); // Pone el total en S/ 0.00
            cmbCliente.SelectedIndex = 0;
            cmbProducto.SelectedIndex = 0;
            numCantidad.Value = 1;
        }
    }
}



