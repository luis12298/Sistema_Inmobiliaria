using SistemaInmobiliaria.Views;
using System;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;

namespace SistemaInmobiliaria
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            // Obtener el nombre del proceso actual (sin extensión .exe)
            string nombreProceso = Process.GetCurrentProcess().ProcessName;
            Process[] procesos = Process.GetProcessesByName(nombreProceso);

            if (procesos.Length > 1)
            {
                MessageBox.Show("La aplicación ya está en ejecución.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmInicio());
        }
    }
}
