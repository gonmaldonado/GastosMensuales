using GastosMensuales.Infrastructure.DataAccess;
using GastosMensuales.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GastosMensuales.Models
{
    public class InformeModel
    {
        public IDataAccess _data = new Sql();
        public DataTable TablaInforme(string desde,string hasta)
        {
            return _data.InformePrespuesto(desde,hasta);
        }
    }
}
