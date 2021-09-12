using GastosMensuales.Infrastructure.DataAccess;
using GastosMensuales.Interfaces;
using GastosMensuales.Models.Domain;
using GastosMensuales.Models.Services;
using GastosMensuales.Views;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GastosMensuales.Models
{
    public class DetalleGastoModel
    {
        public IDataAccess _data = new Sql();
        public Gasto TraerGasto(int codigo)
        {
            return _data.TraerGasto(codigo);
        }
        public void Modificar(Gasto gasto)
        {
            ServicioValidacion.Gasto(gasto);
            _data.ModificarGasto(gasto);
        }
        public void Eliminar(int code)
        {
            _data.EliminarGasto(code);
          
        }
    }
}
