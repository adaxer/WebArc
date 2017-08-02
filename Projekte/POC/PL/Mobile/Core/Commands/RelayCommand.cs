using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Southwind.Core.Commands
{
    public class RelayCommand : ICommand
    {
        Action<object> executeAction;
        Func<object, Boolean> canExecuteFunc;

        public RelayCommand(Action<object> exec, Func<object, bool> canExec = null)
        {
            executeAction = exec;
            canExecuteFunc = canExec ?? new Func<object, bool>(o => true);
        }

        public bool CanExecute(object parameter)
        {
            return canExecuteFunc(parameter);
        }

        public event EventHandler CanExecuteChanged = (s, e) => { };

        public void Execute(object parameter)
        {
            executeAction(parameter);
            CanExecuteChanged(this, EventArgs.Empty);
        }
    }

}
