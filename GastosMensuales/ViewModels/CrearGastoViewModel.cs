using GastosMensuales.Helpers;
using GastosMensuales.Models;
using GastosMensuales.Models.Domain;
using GastosMensuales.Models.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace GastosMensuales.ViewModels
{
    public class CrearGastoViewModel : INotifyPropertyChanged
    {
        public Action CloseAction { get; set; }
        private ICommand _crear;
        public static readonly CrearGastoModel _model = new CrearGastoModel();
        public event PropertyChangedEventHandler PropertyChanged;
        public static Gasto gasto = new Gasto();
        protected static string _mensaje;
        protected static string _nombre;
        protected static string _descripcion;
        protected static decimal _monto;
        protected static int _periodicidad;

        public CrearGastoViewModel()
        {
            Limpiar();
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



        public string Mensaje
        {
            get { return _mensaje; }
            set
            {
                _mensaje = value;
                OnPropertyChanged("Mensaje");
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
                gasto.Nombre = Nombre;
                gasto.Descripcion = Descripcion;
                gasto.Monto = Monto;
                gasto.Periodicidad = Periodicidad;
                gasto.IdPresupuesto = ServicioPresupuesto.IdPresupuestoActual();
                _model.Crear(gasto);
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
