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
            if (gasto.Periodicidad > 1)
            {
                ServicioPresupuesto.Crear(gasto.Periodicidad);
                int periodicidad = gasto.Periodicidad;
                int presupuesto = gasto.IdPresupuesto;
                for (int i = 0; i < periodicidad; i++)
                {
                    gasto.Periodicidad = periodicidad - i;
                    gasto.IdPresupuesto = presupuesto + i;
                    _data.CrearGasto(gasto);
                }
            }
            else
            {
                _data.CrearGasto(gasto);
            }
        }
    }
}
