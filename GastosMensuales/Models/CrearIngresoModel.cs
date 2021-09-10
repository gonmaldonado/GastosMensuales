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
            _data.CrearIngreso(ingreso);
        }

    }
}
