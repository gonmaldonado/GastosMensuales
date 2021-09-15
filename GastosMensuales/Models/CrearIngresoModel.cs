using GastosMensuales.Infrastructure.DataAccess;
using GastosMensuales.Interfaces;
using GastosMensuales.Models.Domain;
using GastosMensuales.Models.Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GastosMensuales.Models
{
   
    public class CrearIngresoModel 
    {
        public IDataAccess _data = new Sql();
        public void Crear(Ingreso ingreso)
        {
            ServicioValidacion.Ingreso(ingreso);
            if (ingreso.Periodicidad > 1)
            {
                ServicioPresupuesto.Crear(ingreso.Periodicidad);
                int periodicidad = ingreso.Periodicidad;
                int presupuesto = ingreso.IdPresupuesto;
                for (int i = 0; i < periodicidad; i++)
                {
                    ingreso.Periodicidad = periodicidad - i;
                    ingreso.IdPresupuesto = presupuesto + i;
                    _data.CrearIngreso(ingreso);
                }
            }
            else
            {
                _data.CrearIngreso(ingreso);
            }
        }
    }
}
