using GastosMensuales.Infrastructure.DataAccess;
using GastosMensuales.Interfaces;
using GastosMensuales.Models.Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GastosMensuales.Models
{
    public class HomeModel
    {
        public HomeModel()
        {

        }
        public IDataAccess _data = new Sql();
        public DataTable ListarPresupuestos()
        {
            return _data.TraerNombrePresupuesto();
        }

        public string PresupestoActual()
        {
            ServicioPresupuesto.NuevoMes();
            return ServicioPresupuesto.PresupuestoActual();
        }
        public DataTable TablaGastos(string presupuesto)
        {
            return _data.TraerGastos(presupuesto);
        }
        public DataTable TablaIngresos(string presupuesto)
        {
            return _data.TraerIngresos(presupuesto);
        }
        public decimal Total (decimal ingresos, decimal gastos)
        {
            return (ingresos - gastos);
        }
        public decimal TotalMonto (DataTable dt)
        {
            decimal total = 0;
            if (dt != null)
            {
                var result = (from s in dt.Rows.Cast<DataRow>()
                              select s["Monto"]).ToList();
                total = result.Sum(item => Convert.ToDecimal(item));
            }
            return total;


        }
    }
}
