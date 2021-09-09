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

    public class DetalleGastoViewModel : INotifyPropertyChanged
    {
        private ICommand _eliminar;
        public static readonly DetalleGastoModel _model = new DetalleGastoModel();
        public event PropertyChangedEventHandler PropertyChanged;
        public static Gasto gasto;
        protected static DataTable _tiposDeMonto = _model.TiposDeMontos();
        protected static int _codigo;
        protected static string _nombre;
        protected static string _descripcion;
        protected static decimal _monto;
        protected static int _periodicidad;
        protected static int _cuotas;
        protected static int _tipoMontoId;
        protected static string _tipoMonto;

        public DetalleGastoViewModel(int Valor)
        {
            gasto = _model.TraerGasto(Valor);
            _codigo = gasto.Id;
            _nombre = gasto.Nombre;
            _descripcion = gasto.Descripcion;
            _monto = gasto.Monto;
            _periodicidad = gasto.Periodicidad;
            _cuotas = gasto.Cuotas;
            _tipoMontoId = gasto.TipoMonto;
            _tipoMonto = _model.TipoMonto(gasto.TipoMonto);
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
        public int Cuotas
        {
            get { return _cuotas; }
            set
            {
                _cuotas = value;
                OnPropertyChanged("Cuotas");
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
        public void Modificar()
        {
            gasto.Nombre = Nombre;
            gasto.Descripcion = Descripcion;
            gasto.Monto = Monto;
            gasto.Periodicidad = Periodicidad;
            gasto.Cuotas = Cuotas;
            gasto.TipoMonto = _model.TipoMonto(TipoMonto);
            _model.Modificar(gasto);          
        }
        public ICommand EliminarCommand
        {
            get { return _eliminar ?? (_eliminar = new RelayCommand(EliminarExecute)); }

        }
        public void EliminarExecute(object parameter)
        {
            _model.Eliminar(Codigo);

        }


    }
}
