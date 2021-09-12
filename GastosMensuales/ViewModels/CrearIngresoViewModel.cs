using GastosMensuales.Helpers;
using GastosMensuales.Models;
using GastosMensuales.Models.Domain;
using GastosMensuales.Models.Services;
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
    public class CrearIngresoViewModel : INotifyPropertyChanged
    {
        public Action CloseAction { get; set; }
        private ICommand _crear;
        public static readonly CrearIngresoModel _model = new CrearIngresoModel();
        public event PropertyChangedEventHandler PropertyChanged;
        public static Ingreso ingreso = new Ingreso();
        protected static string _mensaje;
        protected static string _nombre;
        protected static string _descripcion;
        protected static decimal _monto;
        protected static int _periodicidad;
        protected static int _tipoMontoId;
        protected static string _tipoMonto = "Seleccione un tipo";

        public CrearIngresoViewModel()
        {
            Limpiar();
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

        public ICommand CrearCommand
        {
            get { return _crear ?? (_crear = new RelayCommand(CrearExecute)); }

        }

        public void CrearExecute(object parameter)
        {
            try
            {
                LimpiarMensaje();
                ingreso.Nombre = Nombre;
                ingreso.Descripcion = Descripcion;
                ingreso.Monto = Monto;
                ingreso.Periodicidad = Periodicidad;
                ingreso.IdPresupuesto = ServicioPresupuesto.IdPresupuestoActual();
                _model.Crear(ingreso);
                CloseAction();
            }
            catch (ApplicationException ex)
            {
                Mensaje = ex.Message;
            }

        }
        public void Limpiar()
        {
            Mensaje = null;
            Nombre = null;
            Descripcion = null;
            Monto = 0;
            Periodicidad = 0;

        }
        public void LimpiarMensaje()
        {
            Mensaje = null;
        }

    }
}
