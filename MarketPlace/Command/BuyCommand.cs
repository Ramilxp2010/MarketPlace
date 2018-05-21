using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.IO;
using MarketPlace.Client.ModelView;
using System.ServiceModel.Channels;
using System.Windows;

using MarketPlace.Model.Entities;

namespace MarketPlace.Client.Command
{
    public class BuyCommand : RelayCommand
    {
        public BuyCommand(BasketViewModel basketVM)
            :base(basketVM) {}
        
        public override bool CanExecute(object parameter)
        {
            return true;
        }
        
        public override void Execute(object parameter)
        {
            if (BasketVM.Products.Count == 0)
                return;

            DateTime date = DateTime.Now;
            Purchase purchase = new Purchase(BasketVM.Basket, date);
            BasketVM.dataContext.CreatePurchase(purchase);
            BasketVM.Basket.ClearBasket();
        }
    }
}
