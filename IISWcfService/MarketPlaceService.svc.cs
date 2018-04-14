using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

using MarketPlace.Model;
using MarketPlace.Model.Entities;
using MarketPlace.Model.Interface;
using MarketPlace.DB;
using MarketPlace.DB.Implement;

namespace MarketPlace.Service.IISWcfService
{
    public class MarketPlaceService : IMarketPlaceService
    {
        private DataManager dataManager;

        public MarketPlaceService()
        {
            this.dataManager = new DataManager(new ProductRepository(new SQLiteDatabase()), new PurchaseRepository(new SQLiteDatabase()));
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
