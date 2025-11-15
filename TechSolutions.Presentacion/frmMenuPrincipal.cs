

using System;
using System.Windows.Forms;
using TechSolutions.BLL;
using TechSolutions.Entidades; 

namespace TechSolutions.Presentacion
{
    public partial class frmMenuPrincipal : Form
    {
        private readonly Usuario _usuarioActual;

        private readonly DashboardBLL _dashboardBLL = new DashboardBLL();
        private DataGridView dgvBajoEstock;

        public bool CerrarSesion { get; private set; } = false;

        public frmMenuPrincipal(Usuario usuarioLogueado)
        {
            InitializeComponent();

            _usuarioActual = usuarioLogueado;

            this.Text = $"TechSolutions - ¡Bienvenido, {_usuarioActual.NombreUsuario}!";
        }

        private void frmMenuPrincipal_Load(object sender, EventArgs e)
        {
        }

        private void btnGestionClientes_Click(object sender, EventArgs e)
        {

            frmGestionClientes formularioClientes = new frmGestionClientes();

            formularioClientes.Show();
        }

        private void btnGestionProductos_Click(object sender, EventArgs e)
        {
            frmGestionProductos formularioProductos = new frmGestionProductos();
            formularioProductos.Show();
        }

        private void btnGestionVentas_Click(object sender, EventArgs e)
        {

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
            lblReloj.Text = DateTime.Now.ToString("G");
        }

        private void btnGestionUsuarios_Click(object sender, EventArgs e)
        {
            frmGestionUsuarios formularioUsuarios = new frmGestionUsuarios();
            formularioUsuarios.Show();
        }

        private void frmMenuPrincipal_Load_1(object sender, EventArgs e)
        {
            StyleHelper.AplicarEstiloDataGridView(dgvBajoStock);
            StyleHelper.AplicarEstiloDataGridView(dgvUltimasVentas);
            this.WindowState = FormWindowState.Maximized;
            //StyleHelper.AplicarEstiloFormulario(this);
            MessageBox.Show($"Rol detectado: '{_usuarioActual.NombreRol}'");

            btnGestionUsuarios.Visible = false;
            btnGestionProductos.Visible = false;
            btnReportes.Visible = false;
            btnGestionClientes.Visible = false;
            btnGestionVentas.Visible = false;

            string rol = _usuarioActual.NombreRol.Trim();

            switch (rol)
            {
                case "Administrador":
                    btnGestionUsuarios.Visible = true;
                    btnGestionProductos.Visible = true;
                    btnReportes.Visible = true;
                    btnGestionClientes.Visible = true;
                    btnGestionVentas.Visible = true;
                    break;

                case "Gerente":
                    btnReportes.Visible = true;
                    btnGestionClientes.Visible = true;
                    btnGestionVentas.Visible = true;
                    break;

                case "Vendedor":
                    btnGestionClientes.Visible = true;
                    btnGestionVentas.Visible = true;
                    break;

                case "Logística":
                    btnGestionProductos.Visible = true;
                    break;
            }
            CargarDatosDashboard();
        }
        private void CargarDatosDashboard()
        {
            MessageBox.Show("¡Cargando el Dashboard!");
            try
            {
                Dashboard dashboardData = _dashboardBLL.ObtenerDatosDashboard();

                lblVentasHoy.Text = dashboardData.TotalVentasHoy.ToString("C"); 

                dgvBajoStock.DataSource = null;
                dgvBajoStock.DataSource = dashboardData.ProductosBajoStock;
                if (dgvBajoStock.Columns.Count > 0)
                {
                    dgvBajoStock.Columns["Nombre"].HeaderText = "Producto";
                }

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
            this.CerrarSesion = true;

            this.Close();
        }
    }

}