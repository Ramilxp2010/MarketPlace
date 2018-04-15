﻿using System.ServiceModel;

using MarketPlace.Model;
using MarketPlace.Model.Entities;
using MarketPlace.DB;
using MarketPlace.DB.SqliteDB;
using MarketPlace.DB.Implement;
using System.IO;
using System;

namespace MarketPlace.Service.SelfHostService
{
    [ServiceBehavior(IncludeExceptionDetailInFaults = true)]
    public class MarketPlaceService : IMarketPlaceService
    {
        private DataManager dataManager;

        public MarketPlaceService()
        {
            string dbPathName = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            string dbFileName = "database.sqlite";
            string databasePath = Path.Combine(dbPathName, dbFileName);

            //Реализация с использованием Sqlite-net-pcl
            this.dataManager = new DataManager(new ProductRepositoryBySqliteNet(databasePath), new PurchaseRepositoryBySqliteNet(databasePath));
            
            //Реализация с использованием System.Data.SQLite
            /*SQLiteDatabase sqliteDatabase = new SQLiteDatabase(dbPathName, dbFileName);
            IProductRepository productRepository = new ProductRepository(sqliteDatabase);
            IPurchaseRepository purchaseRepository = new PurchaseRepository(sqliteDatabase);
            this.dataManager = new DataManager(productRepository, purchaseRepository);*/
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
