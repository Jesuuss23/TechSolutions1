// --- Archivo: frmMenuPrincipal.cs ---
// --- Proyecto: TechSolutions.Presentacion ---

using System;
using System.Windows.Forms;
using TechSolutions.BLL;
using TechSolutions.Entidades; // ¡Importante! Para que reconozca la clase 'Usuario'

namespace TechSolutions.Presentacion
{
    public partial class frmMenuPrincipal : Form
    {
        // 1. Un campo privado para guardar quién está logueado
        private readonly Usuario _usuarioActual;

        private readonly DashboardBLL _dashboardBLL = new DashboardBLL();

        // Esta propiedad le dirá a Program.cs si debe
        // volver al login (true) o cerrar la app (false).
        public bool CerrarSesion { get; private set; } = false;
        // ------------------------------

        // 2. Modificamos el constructor por defecto
        public frmMenuPrincipal(Usuario usuarioLogueado)
        {
            InitializeComponent();

            // 3. Guardamos al usuario
            _usuarioActual = usuarioLogueado;

            // 4. (Opcional) Configura el formulario al cargar
            this.Text = $"TechSolutions - ¡Bienvenido, {_usuarioActual.NombreUsuario}!";
        }

        private void frmMenuPrincipal_Load(object sender, EventArgs e)
        {
        }

        private void btnGestionClientes_Click(object sender, EventArgs e)
        {
            // Creamos una instancia del formulario de clientes
            frmGestionClientes formularioClientes = new frmGestionClientes();

            // Lo mostramos
            formularioClientes.Show();
        }

        private void btnGestionProductos_Click(object sender, EventArgs e)
        {
            frmGestionProductos formularioProductos = new frmGestionProductos();
            formularioProductos.Show();
        }

        private void btnGestionVentas_Click(object sender, EventArgs e)
        {
            // Necesitamos pasar el usuario logueado al formulario de ventas
            // para saber quién es el vendedor.
            frmGestionVentas formularioVentas = new frmGestionVentas(_usuarioActual);
            formularioVentas.Show();
        }

        private void btnReportes_Click(object sender, EventArgs e)
        {
            frmReporteVentas formularioReportes = new frmReporteVentas();
            formularioReportes.Show();
        }

        private void timerReloj_Tick(object sender, EventArgs e)
        {
            // Esto se ejecuta CADA SEGUNDO
            // "G" es un formato estándar (fecha corta y hora larga con segundos)
            lblReloj.Text = DateTime.Now.ToString("G");
        }

        private void btnGestionUsuarios_Click(object sender, EventArgs e)
        {
            frmGestionUsuarios formularioUsuarios = new frmGestionUsuarios();
            formularioUsuarios.Show();
        }

        private void frmMenuPrincipal_Load_1(object sender, EventArgs e)
        {
            MessageBox.Show($"Rol detectado: '{_usuarioActual.NombreRol}'");
            // Aquí puedes poner lógica para habilitar/deshabilitar
            // botones según el rol del usuario:
            if (_usuarioActual.NombreRol == "Vendedor")
            {
                // ejemplo: btnAdministracion.Enabled = false;
            }
            if (_usuarioActual.NombreRol != "Administrador")
            {
                // Si NO es Administrador, ocultamos los botones sensibles
                btnGestionUsuarios.Visible = false;
                btnGestionProductos.Visible = false;
                btnReportes.Visible = false;
                // ...puedes ocultar cualquier otro botón que quieras...
            }
            CargarDatosDashboard();
        }
        private void CargarDatosDashboard()
        {
            MessageBox.Show("¡Cargando el Dashboard!");
            try
            {
                // 1. Llamamos a la BLL para obtener todos los datos
                Dashboard dashboardData = _dashboardBLL.ObtenerDatosDashboard();

                // 2. Cargar Tarjeta 1: Ventas de Hoy
                lblVentasHoy.Text = dashboardData.TotalVentasHoy.ToString("C"); // "C" de Currency

                // 3. Cargar Tarjeta 2: Bajo Stock
                dgvBajoStock.DataSource = null;
                dgvBajoStock.DataSource = dashboardData.ProductosBajoStock;
                if (dgvBajoStock.Columns.Count > 0)
                {
                    dgvBajoStock.Columns["Nombre"].HeaderText = "Producto";
                }

                // 4. Cargar Tarjeta 3: Últimas Ventas
                dgvUltimasVentas.DataSource = null;
                dgvUltimasVentas.DataSource = dashboardData.UltimasVentas;
                if (dgvUltimasVentas.Columns.Count > 0)
                {
                    dgvUltimasVentas.Columns["FechaVenta"].HeaderText = "Fecha";
                    dgvUltimasVentas.Columns["Total"].DefaultCellStyle.Format = "c";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error al cargar el Dashboard: " + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            // 1. Marcamos que queremos cerrar sesión (no salir de la app)
            this.CerrarSesion = true;

            // 2. Cerramos este formulario
            this.Close();
        }
    }

}