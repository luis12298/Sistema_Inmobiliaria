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
using static System.Windows.Forms.LinkLabel;
using MessageBox = System.Windows.Forms.MessageBox;
using OtpNet;
using System.Diagnostics;
using System.IO;

namespace SistemaInmobiliaria
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            GenerarClaveSecreta();
        }
        private string claveSecreta;

        private void iconButton1_Click(object sender, EventArgs e)
        {



        }
        private void GenerarClaveSecreta()
        {
            claveSecreta = "QCBBTQTAXAL4ELVH72ECMLAGTGV5C3VA";

            // Generar y mostrar el QR (una sola vez es suficiente)
            string nombre = "App:Lottin";
            string issuer = "App";
            string otpauth = $"otpauth://totp/{nombre}?secret={claveSecreta}&issuer={issuer}";
            string urlQR = $"https://api.qrserver.com/v1/create-qr-code/?data={Uri.EscapeDataString(otpauth)}";

            linkqr.Text = "Haz clic aquí para abrir el QR";
            linkqr.Tag = urlQR;
            label1.Text = "Clave Secreta: " + claveSecreta;
        }


        private void linkqr_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void linkqr_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string url = linkqr.Tag.ToString();
            Process.Start(new ProcessStartInfo { FileName = url, UseShellExecute = true });
        }

        private void iconButton1_Click_1(object sender, EventArgs e)
        {
            var bytes = Base32Encoding.ToBytes(claveSecreta);
            var totp = new Totp(bytes);
            string pin = textBox1.Text.Trim();

            if (totp.VerifyTotp(pin, out _, new VerificationWindow(1, 1)))
            {
                MessageBox.Show("✅ PIN correcto. Acceso autorizado.");
            }
            else
            {
                MessageBox.Show("❌ PIN incorrecto. Intenta de nuevo.");
            }
        }
    }

}