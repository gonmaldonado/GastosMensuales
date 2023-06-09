﻿using GastosMensuales.Helpers;
using GastosMensuales.Infrastructure.DataAccess;
using GastosMensuales.Interfaces;
using GastosMensuales.Models;
using GastosMensuales.Views;
using Microsoft.TeamFoundation.Server;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace GastosMensuales.ViewModels
{
    public class HomeViewModel : INotifyPropertyChanged
    {
        private ICommand _crearIngreso;
        private ICommand _crearGasto;
        public event PropertyChangedEventHandler PropertyChanged;
        public static readonly HomeModel _model = new HomeModel();
        public static string _presupuesto;
        public static object _seleccionarGasto;
        public static object _seleccionarIngreso;
        protected static DataTable _tablaGastos;
        protected static DataTable _tablaIngresos;
        protected static decimal _ingresos;
        protected static decimal _gastos;
        protected decimal _total;
        protected DataTable _listaPresupuestos;

        public HomeViewModel()
        {
            Presupuesto = _model.PresupestoActual();
            TablaGastos = _model.TablaGastos(Presupuesto); 
            TablaIngresos = _model.TablaIngresos(Presupuesto);
            Ingresos = _model.TotalMonto(TablaIngresos);
            Gastos = _model.TotalMonto(TablaGastos);
            Total = _model.Total(Ingresos, Gastos);
            ListaPresupuestos = _model.ListarPresupuestos();
        }

        public void Actualizar()
        {
            TablaGastos = _model.TablaGastos(Presupuesto);
            TablaIngresos = _model.TablaIngresos(Presupuesto);
            ListaPresupuestos = _model.ListarPresupuestos();
            Gastos = _model.TotalMonto(TablaGastos);
            Ingresos = _model.TotalMonto(TablaIngresos);
            Total = _model.Total(Ingresos, Gastos);

        }
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
                Actualizar();
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

        public ICommand CrearIngresoCommand
        {
            get { return _crearIngreso ?? (_crearIngreso = new RelayCommand(CrearIngresoExecute)); }

        }
        public void CrearIngresoExecute(object parameter)
        {
            CrearIngresoView form = new CrearIngresoView();
            form.ShowDialog();
            Actualizar();
        }
        public ICommand CrearGastoCommand
        {
            get { return _crearGasto ?? (_crearGasto = new RelayCommand(CrearGastoExecute)); }

        }
        public void CrearGastoExecute(object parameter)
        {
            CrearGastoView form = new CrearGastoView();
            form.ShowDialog();
            Actualizar();
        }
        public void MostrarDetalleGasto(object parameter)
        {
            if (parameter != null)
            {
                DataRowView drv = (DataRowView)parameter;
                DetalleGastoView form = new DetalleGastoView(Convert.ToInt32(drv["Codigo"]));
                form.ShowDialog();
                Actualizar();
            }
        }
        public void MostrarDetalleIngreso(object parameter)
        {
            if (parameter != null)
            {
                DataRowView drv = (DataRowView)parameter;
                DetalleIngresoView form = new DetalleIngresoView(Convert.ToInt32(drv["Codigo"]));
                form.ShowDialog();
                Actualizar();
            }
        }

        public object SeleccionarGasto
        {
            get { return _seleccionarGasto; }
            set
            {
                _seleccionarGasto = value;
                MostrarDetalleGasto(SeleccionarGasto);
                OnPropertyChanged("SeleccionarGasto");
            }
        }
        public object SeleccionarIngreso
        {
            get { return _seleccionarIngreso; }
            set
            {
                _seleccionarIngreso = value;
                MostrarDetalleIngreso(SeleccionarIngreso);
                OnPropertyChanged("SeleccionarIngreso");
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
