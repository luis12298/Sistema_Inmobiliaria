using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaInmobiliaria.Models
{
    internal class PagoContratoModel
    {
        //tring MontoP, string MontoR, string CuotaPg, string Cuotar
        public string IdContrato { get; set; }
        public string IdCliente { get; set; }
        public string Nombre { get; set; }
        public string NoCuota { get; set; }
        public string Frecuencia { get; set; }
        public string FechaPago { get; set; }
        public string MontoCuota { get; set; }
        public string MontoPagado { get; set; }
        public string Estado { get; set; }
        public string MontoP { get; set; }
        public string MontoR { get; set; }
        public string CuotaPg { get; set; }
        public string Cuotar { get; set; }
    }
}
