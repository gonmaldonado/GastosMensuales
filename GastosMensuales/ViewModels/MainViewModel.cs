using Microsoft.TeamFoundation.Client.Reporting;
using Microsoft.TeamFoundation.Server;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace GastosMensuales.ViewModels
{
    
    public class MainViewModel : INotifyPropertyChanged
    {
        private UserControl _content;

        public event PropertyChangedEventHandler PropertyChanged;

        internal void SetNewContent(UserControl _content)
        {
            ContentWindow = _content;
        }

        public UserControl ContentWindow
        {
            get { return _content; }
            set
            {
                _content = value;
                OnPropertyChanged("ContentWindow");
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
