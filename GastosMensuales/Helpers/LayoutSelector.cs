using GastosMensuales.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace GastosMensuales.Helpers
{
    public class LayoutSelector : DataTemplateSelector
    {
        public DataTemplate BlankTemplate { get; set; }

        public override DataTemplate
            SelectTemplate(object item, DependencyObject container)
        {
            HomeViewModel element = item as HomeViewModel;
            FrameworkElement layout = container as FrameworkElement;

            if (element != null && item != null && item is HomeViewModel)
            {
                return null;
            }

            return layout.FindResource("LayoutTemplate") as DataTemplate;
        }
    }
}
