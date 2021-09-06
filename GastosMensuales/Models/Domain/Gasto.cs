using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GastosMensuales.Models.Domain
{
    public class Gasto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public decimal Monto { get; set; }
        public int Periodicidad { get; set; }
        public int Cuotas { get; set; }
        public int TipoMonto { get; set; }

    }
}
