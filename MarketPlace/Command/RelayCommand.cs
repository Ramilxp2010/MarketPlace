using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

using MarketPlace.Client.ModelView;

namespace MarketPlace.Client.Command
{
    public abstract class RelayCommand : ICommand
    {
        protected BasketViewModel BasketVM;
        public RelayCommand(BasketViewModel BasketVM)
        {
            this.BasketVM = BasketVM;
        }

        public event EventHandler CanExecuteChanged;
        public abstract bool CanExecute(object parameter);
        public abstract void Execute(object parameter);
    }
}
