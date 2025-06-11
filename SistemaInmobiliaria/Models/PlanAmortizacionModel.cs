using Org.BouncyCastle.Asn1.Pkcs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaInmobiliaria.Models
{
    internal class PlanAmortizacionModel
    {
        public string IdContrato { get; set; }
        public string IdCliente { get; set; }
        public string Identifacion { get; set; }
        public string Nombre { get; set; }
        public string Telefono { get; set; }
        public string NumeroCuota { get; set; }
        public string FechaCuota { get; set; }
        public string SaldoInicial { get; set; }
        public string NombreMes { get; set; }
        public string CantidadCuota { get; set; }
        public string CuotaFinal { get; set; }
        public string InteresRetraso { get; set; }
        public string SaldoRestante { get; set; }
    }
}
