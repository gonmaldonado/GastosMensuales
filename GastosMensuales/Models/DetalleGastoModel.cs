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
    public class DetalleGastoModel
    {
        public IDataAccess _data = new Sql();
        public DataTable TiposDeMontos()
        {
            return _data.TraerTipoMonto();
        }
        public Gasto TraerGasto(int codigo)
        {
            return _data.TraerGasto(codigo);
        }
        public string TipoMonto(int id)
        {
            return _data.TraerTipoMonto(id);
        }
        public int TipoMonto(string tipo)
        {
            return _data.TraerTipoMonto(tipo);
        }

        public void Modificar(Gasto gasto)
        {
            _data.ModificarGasto(gasto);
        }
        public void Eliminar(int code)
        {
            _data.EliminarGasto(code);
        }
    }
}
