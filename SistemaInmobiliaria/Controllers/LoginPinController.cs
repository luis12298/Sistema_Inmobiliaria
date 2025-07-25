using OtpNet;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaInmobiliaria.Controllers
{
    internal class LoginPinController
    {
        public string ClaveSecreta { get; private set; }
        public string Nombre { get; private set; }
        public string Issuer { get; private set; }

        public LoginPinController(string nombre = "App:Lottin", string issuer = "App")
        {
            Nombre = nombre;
            Issuer = issuer;
            ClaveSecreta = "QCBBTQTAXAL4ELVH72ECMLAGTGV5C3VA"; // Puedes permitir que sea aleatoria si lo prefieres
        }
        public string GenerarUrlQR()
        {
            string otpauth = $"otpauth://totp/{Nombre}?secret={ClaveSecreta}&issuer={Issuer}";
            return $"https://api.qrserver.com/v1/create-qr-code/?data={Uri.EscapeDataString(otpauth)}";
        }
        public bool VerificarPIN(string pin)
        {
            var bytes = Base32Encoding.ToBytes(ClaveSecreta);
            var totp = new Totp(bytes);
            return totp.VerifyTotp(pin.Trim(), out _, new VerificationWindow(1, 1));
        }

        public void AbrirQR(string urlQR)
        {
            Process.Start(new ProcessStartInfo
            {
                FileName = urlQR,
                UseShellExecute = true
            });
        }
    }
}
