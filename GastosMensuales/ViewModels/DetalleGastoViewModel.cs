using GastosMensuales.Helpers;
using GastosMensuales.Models;
using GastosMensuales.Models.Domain;
using NuGet.Protocol.Plugins;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace GastosMensuales.ViewModels
{


    public class DetalleGastoViewModel : INotifyPropertyChanged
    {
        public Action CloseAction { get; set; }
        private ICommand _eliminar;
        private ICommand _modificar;
        public static readonly DetalleGastoModel _model = new DetalleGastoModel();
        public event PropertyChangedEventHandler PropertyChanged;
        public static Gasto gasto;
        protected static string _mensaje;
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
            LimpiarMensaje();
            gasto = _model.TraerGasto(Valor);
            _codigo = gasto.Id;
            _nombre = gasto.Nombre;
            _descripcion = gasto.Descripcion;
            _monto = gasto.Monto;
            _periodicidad = gasto.Periodicidad;
        }
        public string Mensaje
        {
            get { return _mensaje; }
            set
            {
                _mensaje = value;
                OnPropertyChanged("Mensaje");
            }
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
            try
            {
                LimpiarMensaje();
                gasto.Nombre = Nombre;
                gasto.Descripcion = Descripcion;
                gasto.Monto = Monto;
                gasto.Periodicidad = Periodicidad;
                _model.Modificar(gasto);
                CloseAction();
            }
            catch (ApplicationException ex)
            {
                Mensaje = ex.Message;
            }
        }

        public void LimpiarMensaje()
        {
            Mensaje = null;
        }

    }
}
