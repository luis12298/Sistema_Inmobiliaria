using System;
using System.Collections.Generic;
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
    }
}
