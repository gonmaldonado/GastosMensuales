using GastosMensuales.Infrastructure.DataAccess;
using GastosMensuales.Interfaces;
using GastosMensuales.Models.Domain;
using GastosMensuales.Models.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GastosMensuales.Models
{
    public class CrearGastoModel
    {
        public IDataAccess _data = new Sql();
        public void Crear(Gasto gasto)
        {
            ServicioValidacion.Gasto(gasto);
            _data.CrearGasto(gasto);
        }
    }
}
