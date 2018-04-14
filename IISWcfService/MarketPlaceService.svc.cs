using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.IO;
using System.Web.Hosting;

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
            string dbFileName = "database.sqlite";
            string dbFilePath = Path.Combine(HostingEnvironment.ApplicationPhysicalPath, "App_Data");
            this.dataManager = new DataManager(new ProductRepository(new SQLiteDatabase(dbFilePath, dbFileName)), new PurchaseRepository(new SQLiteDatabase(dbFilePath, dbFileName)));
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
