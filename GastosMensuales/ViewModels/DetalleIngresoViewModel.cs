using GastosMensuales.Helpers;
using GastosMensuales.Models;
using GastosMensuales.Models.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace GastosMensuales.ViewModels
{
    public class DetalleIngresoViewModel : INotifyPropertyChanged
    {
        public Action CloseAction { get; set; }
        private ICommand _eliminar;
        private ICommand _modificar;
        public static readonly DetalleIngresoModel _model = new DetalleIngresoModel();
        public event PropertyChangedEventHandler PropertyChanged;
        public static Ingreso ingreso;
        protected static DataTable _tiposDeMonto = _model.TiposDeMontos();
        protected static int _codigo;
        protected static string _nombre;
        protected static string _descripcion;
        protected static decimal _monto;
        protected static int _periodicidad;
        protected static int _tipoMontoId;
        protected static string _tipoMonto;

        public DetalleIngresoViewModel(int Valor)
        {
            ingreso = _model.TraerIngreso(Valor);
            _codigo = ingreso.Id;
            _nombre = ingreso.Nombre;
            _descripcion = ingreso.Descripcion;
            _monto = ingreso.Monto;
            _periodicidad = ingreso.Periodicidad;
            _tipoMontoId = ingreso.TipoMonto;
            _tipoMonto = _model.TipoMonto(ingreso.TipoMonto);
        }
        public int Codigo
        {
            get { return _codigo; }
            set
            {
                _codigo = value;
                OnPropertyChanged("Codigo");
            }
        }
        public decimal Monto
        {
            get { return _monto; }
            set
            {
                _monto = value;
                OnPropertyChanged("Monto");
            }
        }
        public int Periodicidad
        {
            get { return _periodicidad; }
            set
            {
                _periodicidad = value;
                OnPropertyChanged("Periodicidad");
            }
        }

        public int TipoMontoId
        {
            get { return _tipoMontoId; }
            set
            {
                _tipoMontoId = value;
                OnPropertyChanged("TipoMontoId");
            }
        }
        public string TipoMonto
        {
            get { return _tipoMonto; }
            set
            {
                _tipoMonto = value;
                OnPropertyChanged("TipoMonto");
            }
        }
        public DataTable TiposDeMonto
        {
            get { return _tiposDeMonto; }
            set
            {
                _tiposDeMonto = value;
                OnPropertyChanged("TiposDeMonto");
            }
        }
        public string Nombre
        {
            get { return _nombre; }
            set
            {
                _nombre = value;
                OnPropertyChanged("Nombre");
            }
        }
        public string Descripcion
        {
            get { return _descripcion; }
            set
            {
                _descripcion = value;
                OnPropertyChanged("Descripcion");
            }
        }
        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public ICommand EliminarCommand
        {
            get { return _eliminar ?? (_eliminar = new RelayCommand(EliminarExecute)); }

        }
        public ICommand ModificarCommand
        {
            get { return _modificar ?? (_modificar = new RelayCommand(ModificarExecute)); }

        }
        public void EliminarExecute(object parameter)
        {
            _model.Eliminar(Codigo);
            CloseAction();

        }
        public void ModificarExecute(object parameter)
        {
            ingreso.Nombre = Nombre;
            ingreso.Descripcion = Descripcion;
            ingreso.Monto = Monto;
            ingreso.Periodicidad = Periodicidad;
            ingreso.TipoMonto = _model.TipoMonto(TipoMonto);
            _model.Modificar(ingreso);
            CloseAction();

        }
    }
}
