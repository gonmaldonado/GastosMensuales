using GastosMensuales.ViewModels;
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
    /// Lógica de interacción para DetalleGastoView.xaml
    /// </summary>
    public partial class DetalleGastoView : Window
    {
        public DetalleGastoView(int valor)
        {
            InitializeComponent();
            DetalleGastoViewModel vm = new DetalleGastoViewModel(valor);
            DataContext = vm;
            if (vm.CloseAction == null)
                vm.CloseAction = new Action(this.Close);
        }

    }
}
