using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GastosMensuales.Models.Domain
{
    public class Presupuesto
    {
        public int Id { get; set; }
        public int Año { get; set; }
        public int Mes { get; set; }
        public string Nombre { get; set; }
        public decimal Ingresos { get; set; }
        public decimal Gastos { get; set; }
        public decimal Total { get; set; }


    }
}
