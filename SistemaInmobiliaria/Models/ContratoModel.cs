using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaInmobiliaria.Models
{
    internal class ContratoModel
    {
        public static int IdContratoG;
        public int IdContrato { get; set; }
        public int IdCliente { get; set; }
        public int IdLote { get; set; }
        public string FechaInicio { get; set; }
        public string FechaFinal { get; set; }
        public string FechaFin { get; set; }
        public double MontoTotal { get; set; }
        public double CantidadCuota { get; set; }
        public double CuotaFinal { get; set; }
        public double InteresRetraso { get; set; }
        public string Estado { get; set; }
        public bool Prima { get; set; }
        public string Descripcion { get; set; }
    }
}
