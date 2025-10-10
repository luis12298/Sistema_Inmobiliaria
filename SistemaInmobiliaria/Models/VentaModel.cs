using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaInmobiliaria.Models
{
    internal class VentaModel
    {
        public int IdVenta { get; set; }
        public int IdVendedor { get; set; }
        public double Comision { get; set; }
        public string NoLote { get; set; }
        public string FechaVenta { get; set; }
    }
}
