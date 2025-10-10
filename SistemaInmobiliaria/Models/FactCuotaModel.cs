using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaInmobiliaria.Models
{
    internal class FactCuotaModel
    {
        public string Referencia { get; set; }
        public string Identificacion { get; set; }
        public string RutaLogo { get; set; }
        public string RutaFirma { get; set; }
        public string Nombre { get; set; }
        public string NoCuota { get; set; }
        public string Fecha { get; set; }
        public string Mes { get; set; }
        public string LoteNo { get; set; }
        public string CuotaFinal { get; set; }
        public string Total { get; set; }
        //Encabezado

        // Encabezado
        public string NombreT { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string Correo { get; set; }

        public FactCuotaModel()
        {
            string jsonString = File.ReadAllText(@"C:\Data\Settings.json");
            var jsonObj = JObject.Parse(jsonString);
            RutaLogo = jsonObj["rutaLogo"]?.ToString() ?? "";
            RutaFirma = jsonObj["rutaFirma"]?.ToString() ?? "";
            NombreT = jsonObj["Nombre"]?.ToString() ?? "";
            Direccion = jsonObj["Direccion"]?.ToString() ?? "";
            Telefono = jsonObj["Telefono"]?.ToString() ?? "";
            Correo = jsonObj["Correo"]?.ToString() ?? "";
        }
    }
}
