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

        public IEnumerable<Product> GetProducts()
        {
            return dataManager.Products.GetProducts();
        }
        public Product GetProduct(string id)
        {
            return dataManager.Products.GetProduct(id);
        }
        public void CreateProduct(string id, string description, decimal price)
        {
            dataManager.Products.CreateProduct(id, description, price);
        }

        public void CreatePurchase(DateTime date, string content)
        {
            dataManager.Purchases.InsertPurchase(date, content);
        }
    }
}
