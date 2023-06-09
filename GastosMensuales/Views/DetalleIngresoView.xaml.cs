﻿using GastosMensuales.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace GastosMensuales.Views
{
    /// <summary>
    /// Lógica de interacción para DetalleIngresoView.xaml
    /// </summary>
    public partial class DetalleIngresoView : Window
    {
        public DetalleIngresoView(int valor)
        {
            InitializeComponent();
            DetalleIngresoViewModel vm = new DetalleIngresoViewModel(valor);
            DataContext = vm;
            if (vm.CloseAction == null)
                vm.CloseAction = new Action(this.Close);
        }
    }
}
