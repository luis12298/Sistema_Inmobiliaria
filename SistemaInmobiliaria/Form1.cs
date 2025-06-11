using Infobip.Api.Client.Api;
using Infobip.Api.Client.Model;
using Infobip.Api.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;

namespace SistemaInmobiliaria
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(@"C:\Android\adb.exe", "shell am start -a android.intent.action.SENDTO -d smsto:+50488768182 --es sms_body \"Esto es un mensaje de prueba\" --ez exit_on_sent true");


        }
        private void enviar()
        {

        }

    }

}