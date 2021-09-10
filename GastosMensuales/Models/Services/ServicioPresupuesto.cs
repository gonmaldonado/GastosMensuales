using GastosMensuales.Infrastructure.DataAccess;
using GastosMensuales.Interfaces;
using GastosMensuales.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GastosMensuales.Models.Services
{
    public class ServicioPresupuesto
    {
        public static IDataAccess _data = new Sql();
        public static int AñoActual()
        {
            DateTime fechaActual = DateTime.Today;
            return fechaActual.Year;
        }
        public static int MesActual()
        {
            DateTime fechaActual = DateTime.Today;
            return fechaActual.Month;
        }
        public static string GenerarNombre()
        {
            string mes = NombreMes(MesActual());
            string año = AñoActual().ToString();
            return mes + "_" + año;
        }
        public static string NombreMes(int mes)
        {
            switch (mes)
            {
                case 1:
                    return  "ENERO";
                case 2:
                    return "FEBRERO";
                case 3:
                    return "MARZO";
                case 4:
                    return "ABRIL";
                case 5:
                    return  "MAYO";
                case 6:
                    return "JUNIO";
                case 7:
                    return "JULIO";
                case 8:
                    return "AGOSTO";
                case 9:
                    return "SEPTIEMBRE";
                case 10:
                    return "OCTUBRE";
                case 11:
                    return "NOVIEMBRE";
                case 12:
                    return "DICIEMBRE";
                default:
                    throw new ApplicationException("Error al crear nombre de pres");
            }
        }
        public static string PresupuestoActual()
        {
            return _data.TraerUltmoPresupuesto();
        }
        public static int IdPresupuestoActual()
        {
            return _data.TraerUltmoIdPresupuesto();
        }
        public static void Crear()
        {
            Presupuesto presupuesto = new Presupuesto();
            presupuesto.Año = AñoActual();
            presupuesto.Mes = MesActual();
            presupuesto.Nombre = GenerarNombre();
            presupuesto.Ingresos = 0;
            presupuesto.Gastos = 0;
            presupuesto.Total = 0;
            try
            {
                _data.CrearPresupuesto(presupuesto);

            }
            catch (Exception)
            {

                throw new ApplicationException("Error al crear presupuesto.");
            }
        }
        public static void NuevoMes()
        {
            int mes = MesActual();
            if(_data.TraerUltmoMesPresupuesto() == mes)
            {
                Crear();
            }
        }
    }

    
}
