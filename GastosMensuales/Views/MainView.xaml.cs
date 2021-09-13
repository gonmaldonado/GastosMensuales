using System;
using GastosMensuales.ViewModels;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using GastosMensuales.Helpers;

namespace GastosMensuales.Views
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainView : Window
    {
        private ViewNavigator _viewNavigator;
        public MainView()
        {
            InitializeComponent();

            _viewNavigator = Container.ViewNavigator();
            _viewNavigator.NavigationChanged += OnNavigationChanged;

            DataContext = FactoryViewModel.Build("LOGIN");
        }

        private void OnNavigationChanged(object sender, System.EventArgs e)
        {
            NavigationEventArgs eventArgs = (NavigationEventArgs)e;

            DataContext = FactoryViewModel.Build(eventArgs.NavigationName);
        }
    }
}
