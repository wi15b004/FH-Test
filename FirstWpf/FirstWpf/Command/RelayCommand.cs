using FirstWpf.Delegates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;


namespace FirstWpf.Command
{
    public class RelayCommand : ICommand
    {

        DoIt action;
        CanWeDoIt canWeDoIt;

        public RelayCommand(DoIt action, CanWeDoIt canWeDoIt)
        {
            this.action = action;
            this.canWeDoIt = canWeDoIt;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            throw new NotImplementedException();
        }

        public void Execute(object parameter)
        {
            throw new NotImplementedException();
        }

        public void Execute(object parameter)
        {
            throw new NotImplementedException();
        }

    }
}
