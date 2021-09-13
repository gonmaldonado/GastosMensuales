using System;
using System.Windows.Navigation;

namespace GastosMensuales.Helpers
{
    public class ViewNavigator 
    {
        private event EventHandler<EventArgs> _navigationChanged;

        public event EventHandler<EventArgs> NavigationChanged
        {
            add => this._navigationChanged += value;
            remove => this._navigationChanged -= value;
        }

        public void InvokeNavigationChanged(string navigationName)
        {
            EventHandler<EventArgs> navigationChanged = this._navigationChanged;
            if (navigationChanged == null)
                return;
            navigationChanged((object)this, (EventArgs)new NavigationEventArgs(navigationName));
        }
        public class NavigationEventArgs : EventArgs
        {
            public string NavigationName { get; private set; }

            public NavigationEventArgs(string navigationName) => this.NavigationName = navigationName;
        }
    }
}