using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaInmobiliaria.Models
{
    internal class FactCuotaModel
    {
        public string Referencia { get; set; }
        public string Identificacion { get; set; }
        public string Nombre { get; set; }
        public string NoCuota { get; set; }
        public string Fecha { get; set; }
        public string Mes { get; set; }
        public string LoteNo { get; set; }
        public string CuotaFinal { get; set; }
        public string Total { get; set; }
    }
}
