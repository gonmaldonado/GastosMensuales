using GastosMensuales.Infrastructure.DataAccess;
using GastosMensuales.Interfaces;
using GastosMensuales.Models;
using Microsoft.TeamFoundation.Server;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace GastosMensuales.ViewModels
{

    public class HomeViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public static readonly HomeModel _model = new HomeModel();
        public static string _presupuesto = _model.PresupestoActual();
        protected static DataTable _tablaGastos = _model.TablaGastos(_presupuesto);
        protected static DataTable _tablaIngresos= _model.TablaIngresos(_presupuesto);
        protected static decimal _ingresos = _model.TotalMonto(_tablaIngresos);
        protected static decimal _gastos = _model.TotalMonto(_tablaGastos);
        protected decimal _total = _model.Total(_ingresos, _gastos);
        protected DataTable _listaPresupuestos = _model.ListarPresupuestos();
       
        public decimal Gastos
        {
            get { return _gastos; }
            set
            {
                _gastos = value;
                OnPropertyChanged("Gastos");
            }
        }
        public string Presupuesto
        {
            get { return _presupuesto; }
            set
            {
                _presupuesto = value;
                OnPropertyChanged("Presupuesto");
            }
        }
        public decimal Ingresos
        {
            get { return _ingresos; }
            set
            {
                _ingresos = value;
                OnPropertyChanged("Ingresos");
            }
        }
        public decimal Total
        {
            get { return _total; }
            set
            {
                _total = value;
                OnPropertyChanged("Total");
            }
        }
        public DataTable TablaGastos
        {
            get { return _tablaGastos; }
            set
            {
                _tablaGastos = value;
                OnPropertyChanged("TablaGastos");
            }
        }
        public DataTable TablaIngresos
        {
            get { return _tablaIngresos; }
            set
            {
                _tablaIngresos = value;
                OnPropertyChanged("TablaIngresos");
            }
        }
        public DataTable ListaPresupuestos
        {
           
            get { return _listaPresupuestos; }
            set
            {
                _listaPresupuestos = value;
                OnPropertyChanged("ListaPresupuestos");
            }
        }



        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
