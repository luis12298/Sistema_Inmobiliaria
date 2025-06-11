using Humanizer;
using Microsoft.Reporting.WinForms;
using SistemaInmobiliaria.Controllers;
using SistemaInmobiliaria.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaInmobiliaria.Views
{
    public partial class frmInicio : Form
    {
        private Form currentForm;
        //PlaceholderController placeholderC = new PlaceholderController();
        private const int CP_NOCLOSE_BUTTON = 0x200;
        public frmInicio()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            userLog.Text = UsuarioModel.Usuario;
            // Agrega un separador flexible que empuja los ítems siguientes hacia la derecha
            //obtener año actual
            int year = DateTime.Now.Year;
            label2.Text = $"Sistema Inmobiliaria {year}";
            loadform(new frmDashboard());
            IniciarReloj();


        }
        private void IniciarReloj()
        {
            Timer timer = new Timer();
            timer.Interval = 1000; // 1 segundo
            timer.Tick += (s, e) =>
            {
                lblHora.Text = DateTime.Now.ToString("HH:mm:ss");
            };
            timer.Start();
        }

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams myCp = base.CreateParams;
                myCp.ClassStyle = myCp.ClassStyle | CP_NOCLOSE_BUTTON;
                return myCp;
            }
        }
        private void verClientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmListaCliente frm = new frmListaCliente();
            frm.ShowDialog();
        }

        private void verLotesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmListaLote frm = new frmListaLote();
            frm.ShowDialog();
        }



        private void registrarContratoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            loadform(new frmListaContrato());
        }

        private void calculadoraDeCuotasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            loadform(new frmCalculadora());
        }
        public void loadform(object Form)
        {
            try
            {
                // Cerrar el formulario actual, si existe
                if (currentForm != null)
                {
                    currentForm.Close();
                    currentForm = null;
                }
                if (this.Main.Controls.Contains(currentForm))
                {
                    currentForm.BringToFront();
                    return;
                }

                // Eliminar controles existentes en el panel Main
                if (this.Main.Controls.Count > 0)
                {
                    Main.Controls.Clear();
                }

                // Convertir el objeto recibido a Form
                Form form = Form as Form;
                if (form != null)
                {
                    form.TopLevel = false; // Configurar como control secundario
                    form.FormBorderStyle = FormBorderStyle.None; // Sin borde
                    form.Dock = DockStyle.Fill; // Llenar completamente el panel
                    form.AutoScroll = true; // Habilitar desplazamiento si es necesario
                    form.BackColor = Color.White; // Fondo blanco

                    // Agregar el formulario al panel principal
                    this.Main.Controls.Add(form);
                    this.Main.Tag = form;

                    // Mostrar el formulario
                    form.Show();

                    // Evento al cerrar el formulario
                    form.FormClosed += (s, args) =>
                    {
                        //loadform(new frmDashboard()); // Cargar el formulario predeterminado
                    };
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar el formulario: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void registrarClienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            loadform(new frmCliente());
        }

        private void registrarLoteOTerrenoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            loadform(new frmLote());
        }

        private void registrarContratoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmVerListaContrato frm = new frmVerListaContrato(this);
            frm.ShowDialog();
        }

        private void cobrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            loadform(new frmListaCobro());
        }

        public void cobrar(string id)
        {

            loadform(new frmRegistrarPago(int.Parse(id)));
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmLogin frmLogin = new frmLogin();
            frmLogin.ShowDialog();
            this.Close();
        }

        private void agregarUsuarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            loadform(new frmUsuario());

        }

        private void frmInicio_Load(object sender, EventArgs e)
        {

        }

        private void verReporteGeneralToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmReporteGeneral frmReporte = new frmReporteGeneral();
            frmReporte.ShowDialog();
        }

        private void agregarCorreoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            loadform(new frmCorreo());
        }
    }
}
