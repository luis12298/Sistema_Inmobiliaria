using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaInmobiliaria.Models
{
    internal class LoteModel
    {
        public int IdLote { get; set; }
        public string LoteNo { get; set; }
        public double Metros { get; set; }
        public double Varas { get; set; }
        public double Precio { get; set; }
        public string Estado { get; set; }
        public string Descripcion { get; set; }
    }
}
