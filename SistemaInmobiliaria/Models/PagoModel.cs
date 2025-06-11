using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaInmobiliaria.Models
{
    internal class PagoModel
    {
        public int IdPago { get; set; }
        public int IdContrato { get; set; }
        public int NoCuota { get; set; }
        public string FechaCuota { get; set; }
        public double MontoPagado { get; set; }
        public string Estado { get; set; }
        public string FechaPago { get; set; }
        public string UsuarioCreo { get; set; }

    }
}
