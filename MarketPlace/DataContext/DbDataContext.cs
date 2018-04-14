using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.ServiceModel.Channels;
using System.Text;
using System.Threading.Tasks;

using MarketPlace.Model;
using MarketPlace.Model.Entities;
using MarketPlace.Client.MarketPlaceSelfHostService;

namespace MarketPlace.Client.DataContext
{
    public class DbDataContext : IDataContext
    {
        private DataManager dataManager;

        public DbDataContext(DataManager dataManager)
        {
            this.dataManager = dataManager;
        }

        public Product GetProduct(string id)
        {
            return dataManager.Products.GetProduct(id);
        }

        public void CreatePurchase(Purchase purchase)
        {
            dataManager.Purchases.CreatePurchase(purchase);
        }
    }
}
