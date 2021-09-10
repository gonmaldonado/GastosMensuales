using GastosMensuales.Models.Domain;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GastosMensuales.Interfaces
{
    public interface IDataAccess
    {
        void CrearIngreso(Ingreso ingreso);
        void EliminarIngreso(int idIngreso);
        void ModificarIngreso(Ingreso ingreso);
        void CrearGasto(Gasto gasto);
        void EliminarGasto(int idGasto);
        void ModificarGasto(Gasto gasto);
        void CrearPresupuesto(Presupuesto presupuesto);
        DataTable TraerGastos(string presupuesto);
        DataTable TraerIngresos(string presupuesto);
        DataTable TraerNombrePresupuesto();
        DataTable TraerTipoMonto();
        string TraerTipoMonto(int id);
        int TraerTipoMonto(string tipo);

        DataTable InformePrespuesto(string fechaDesde, string fechaHasta);
        int TraerUltmoMesPresupuesto();
        string TraerUltmoPresupuesto();
        Ingreso TraerIngreso(int id);
        Gasto TraerGasto(int id);
        int TraerUltmoIdPresupuesto();

    }
}
