using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaInmobiliaria.Models
{
    internal class FactPrimaModel
    {
        public string Identidad { get; set; }
        public string NoLote { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public string NoFactura { get; set; }
        public string Total { get; set; }
        public string NumTexto { get; set; }

        // Encabezado
        public string NombreT { get; set; }
        public string DireccionT { get; set; }
        public string Telefono { get; set; }
        public string Correo { get; set; }
        public string LogoRuta { get; set; }

        public FactPrimaModel()
        {
            string jsonString = File.ReadAllText(@"C:\Data\Settings.json");
            var jsonObj = JObject.Parse(jsonString);
            LogoRuta = jsonObj["rutaLogo"]?.ToString() ?? "";
            NombreT = jsonObj["Nombre"]?.ToString() ?? "";
            DireccionT = jsonObj["Direccion"]?.ToString() ?? "";
            Telefono = jsonObj["Telefono"]?.ToString() ?? "";
            Correo = jsonObj["Correo"]?.ToString() ?? "";
        }
    }
}
