using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace GastosMensuales.Helpers
{
    /// <summary>
    /// A command whose sole purpose is to 
    /// relay its functionality to other
    /// objects by invoking delegates. The
    /// default return value for the CanExecute
    /// method is 'true'.
    /// </summary>
    public class RelayCommand : ICommand
    {
        private readonly Action<object> _execute;
        private readonly Func<bool> _canExecute;

        /// <summary>
        /// Initializes a new instance of the <see cref="RelayCommand"/> class. 
        /// Creates a new command that can always execute.
        /// </summary>
        /// <param name="execute">
        /// The execution logic.
        /// </param>
        public RelayCommand(Action<object> execute)
        : this(execute, null)
        {
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="RelayCommand"/> class. 
        /// Creates a new command.
        /// </summary>
        /// <param name="execute">
        /// The execution logic.
        /// </param>
        /// <param name="canExecute">
        /// The execution status logic.
        /// </param>
        public RelayCommand(Action<object> execute, Func<bool> canExecute)
        {
            if (execute == null)
            {
                throw new ArgumentNullException("execute");
            }

            _execute = execute;
            _canExecute = canExecute;
        }
        /// <summary>
        /// Gets the can execute changed.
        /// </summary>
        public event EventHandler CanExecuteChanged
        {
            add
            {
                if (this._canExecute != null)
                {
                    CommandManager.RequerySuggested += value;
                }
            }

            remove
            {
                if (this._canExecute != null)
                {
                    CommandManager.RequerySuggested -= value;
                }
            }
        }
        /// <summary>
        /// The execute.
        /// </summary>
        /// <param name="parameter">
        /// The parameter.
        /// </param>
        public void Execute(object parameter)
        {
            _execute(parameter);
        }
        /// <summary>
        /// The can execute.
        /// </summary>
        /// <param name="parameter">
        /// The parameter.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        [DebuggerStepThrough]
        public bool CanExecute(object parameter)
        {
            return _canExecute == null || _canExecute();
        }
    }
}
