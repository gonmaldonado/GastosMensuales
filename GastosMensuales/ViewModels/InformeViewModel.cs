using GastosMensuales.Helpers;
using GastosMensuales.Models;
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
    public class InformeViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public static readonly InformeModel _model = new InformeModel();
        private ICommand _informe;
        protected static DataTable _tablaInfome;
        public static string _mensaje;
        public static string _desde;
        public static string _hasta;

        public InformeViewModel()
        {
            TablaInforme = null;
            Desde = null;
            Hasta = null;
        }
        
        
        public string Desde
        {
            get { return _desde; }
            set
            {
                _desde = value;
                OnPropertyChanged("Desde");
            }
        }
        public string Hasta
        {
            get { return _hasta; }
            set
            {
                _hasta = value;
                OnPropertyChanged("Hasta");
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
        public DataTable TablaInforme
        {

            get { return _tablaInfome; }
            set
            {
                _tablaInfome = value;
                OnPropertyChanged("TablaInforme");
            }
        }
        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        public ICommand CrearInformeCommand
        {
            get { return _informe ?? (_informe = new RelayCommand(CrearInformeExecute)); }

        }
        public void CrearInformeExecute(object parameter)
        {
            try
            {
                LimpiarMensaje();
                ServicioValidacion.EsFecha(Hasta);
                ServicioValidacion.EsFecha(Desde);
                ServicioValidacion.Fechas(Convert.ToDateTime(Desde), Convert.ToDateTime(Hasta));
                TablaInforme=_model.TablaInforme(Desde, Hasta);

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
