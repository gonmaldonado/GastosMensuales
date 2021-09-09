using GastosMensuales.Infrastructure.DataAccess;
using GastosMensuales.Interfaces;
using GastosMensuales.Models.Domain;
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
        public IDataAccess _data = new Sql();
        public DataTable TiposDeMontos()
        {
            return _data.TraerTipoMonto();
        }
        public Ingreso TraerIngreso(int codigo)
        {
            return _data.TraerIngreso(codigo);
        }
        public string TipoMonto(int id)
        {
            return _data.TraerTipoMonto(id);
        }
        public int TipoMonto(string tipo)
        {
            return _data.TraerTipoMonto(tipo);
        }

        public void Modificar(Ingreso ingreso)
        {
            _data.ModificarIngreso(ingreso);
        }
        public void Eliminar(int code)
        {
            _data.EliminarIngreso(code);

        }
    }
}
