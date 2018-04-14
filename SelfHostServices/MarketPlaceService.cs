using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

using MarketPlace.Model;
using MarketPlace.Model.Entities;
using MarketPlace.Model.Interface;
using MarketPlace.DB;
using MarketPlace.DB.Implement;
using MarketPlace.DB.SqliteDB;

namespace MarketPlace.Service.SelfHostService
{
    [ServiceBehavior(IncludeExceptionDetailInFaults = true)]
    public class MarketPlaceService : IMarketPlaceService
    {
        private DataManager dataManager;

        public MarketPlaceService(/*DataManager dataManager*/)
        {
            //this.dataManager = new DataManager(new ProductRepository(new SQLiteDatabase()), new PurchaseRepository(new SQLiteDatabase()));

            // Нужно будет доработать ProductRepositoryBySqliteNet и PurchaseRepositoryBySqliteNet. И попробовать внедрения зависимостей
            this.dataManager = new DataManager(new ProductRepositoryBySqliteNet(), new PurchaseRepositoryBySqliteNet());
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
