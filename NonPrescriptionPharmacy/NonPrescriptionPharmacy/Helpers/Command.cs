using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace NonPrescriptionPharmacy.Helpers
{
    class Command : ICommand
    {
        private Action<object> execute;
        private Predicate<object> canExecute;

        public Command(Action<object> e, Predicate<object> c)
        {
            execute = e;
            canExecute = c;
        }

        public bool CanExecute(object parameter)
        {
            bool b = canExecute == null ? true : canExecute(parameter);
            return b;
        }

        public void Execute(object parameter)
        {
            execute(parameter);
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }    
    }
}
