using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Channels;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

using MarketPlace.Model.Entities;
using MarketPlace.Client.ModelView;

namespace MarketPlace.Client.Command
{
    public class AddCommand : RelayCommand
    {
        public AddCommand(BasketViewModel basketMV)
            : base(basketMV)
        {
        }

        public override bool CanExecute(object parameter)
        {
            return true;
        }
        public override void Execute(object parameter)
        {
            string code = parameter as string;
            Product product = BasketVM.dataContext.GetProduct(code);
            if (product != null)
            {
                BasketVM.Basket.AddProduct(product);
            }
            else
            {
                MessageBox.Show("Product with this code was not found", "Info", MessageBoxButton.OK, MessageBoxImage.Information);
            }

            BasketVM.ProductCode = string.Empty;
        }
    }
}
