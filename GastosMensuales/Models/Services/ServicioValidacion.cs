using GastosMensuales.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GastosMensuales.Models.Services
{
    public class ServicioValidacion
    {
        public static void Monto(decimal monto)
        {
            if (monto == 0)
                throw new ApplicationException("Error en campo monto.");
        }
        public static void Periodicidad(int periodicidad,string campo)
        {
            if (periodicidad == 0)
                throw new ApplicationException("Error en campo "+campo.Trim()+".");
        }
        public static void Gasto(Gasto gasto)
        {
            if (gasto.Periodicidad == 0 || gasto.Nombre ==null || gasto.Monto == 0 || gasto.Descripcion == null)
                throw new ApplicationException("Campos incompletos.");
        }
        public static void Ingreso(Ingreso ingreso)
        {
            if (ingreso.Periodicidad == 0 || ingreso.Nombre == null || ingreso.Monto == 0 || ingreso.Descripcion == null)
                throw new ApplicationException("Campos incompletos.");
        }
        public static void EsFecha(string fecha)
        {
            try
            {
                DateTime.Parse(fecha);
            }
            catch
            {
                throw new ApplicationException("Fecha incorrecta.");
            }
        }
        public static void Fechas(DateTime Desde, DateTime Hasta )
        {
            if (Desde > Hasta)
                throw new ApplicationException("La fecha desde es mayor que la fecha hasta.");
        }

    }
}
