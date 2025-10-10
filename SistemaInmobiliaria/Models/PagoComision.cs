using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaInmobiliaria.Models
{
    internal class PagoComision
    {
        public int IdPagoC { get; set; }
        public int IdVendedor { get; set; }
        public string FechaPago { get; set; }
        public double MontoPagado { get; set; }
        public double SaldoAnterior { get; set; }
        public double SaldoNuevo { get; set; }

    }
}
