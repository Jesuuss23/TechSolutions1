// --- Archivo: Program.cs ---
// --- Proyecto: TechSolutions.Presentacion ---

using System;
using System.Windows.Forms;
using TechSolutions.Entidades; // ¡Importante! Para que reconozca 'Usuario'

namespace TechSolutions.Presentacion
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // --- INICIO DEL BUCLE DE NAVEGACIÓN ---

            while (true) // 1. Bucle infinito para mantener la app viva
            {
                frmLogin loginForm = new frmLogin();

                // 2. Mostramos el Login
                if (loginForm.ShowDialog() == DialogResult.OK)
                {
                    // 3. Login exitoso, preparamos el menú
                    Usuario usuarioLogueado = loginForm.UsuarioLogueado;
                    frmMenuPrincipal menuForm = new frmMenuPrincipal(usuarioLogueado);

                    // 4. Mostramos el Menú. Esta línea PAUSA el código
                    //    hasta que 'menuForm' se cierre.
                    Application.Run(menuForm);

                    // 5. Cuando 'menuForm' se cierra, el código sigue aquí.
                    //    Revisamos POR QUÉ se cerró.
                    if (menuForm.CerrarSesion)
                    {
                        // El usuario hizo clic en "Cerrar Sesión"
                        // 'continue' vuelve al inicio del 'while (true)'
                        // y muestra el login de nuevo.
                        continue;
                    }
                    else
                    {
                        // El usuario cerró con la "X"
                        // 'break' rompe el 'while (true)' y cierra la app.
                        break;
                    }
                }
                else
                {
                    // 6. El usuario cerró el Login (con la "X" o "Cancelar")
                    // 'break' rompe el 'while (true)' y cierra la app.
                    break;
                }
            }

            // --- FIN DEL BUCLE DE NAVEGACIÓN ---
        }
    }
}