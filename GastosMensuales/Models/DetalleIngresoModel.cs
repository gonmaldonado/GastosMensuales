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
    public class DetalleIngresoModel
    {
        public IDataAccess _data= new Sql();
        public Ingreso TraerIngreso(int codigo)
        {
            return _data.TraerIngreso(codigo);
        }
        public void Modificar(Ingreso ingreso)
        {
            ServicioValidacion.Ingreso(ingreso);
            _data.ModificarIngreso(ingreso);
        }
        public void Eliminar(int code)
        {
            _data.EliminarIngreso(code);

        }
    }
}
