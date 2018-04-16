using System;
using System.Collections.Generic;
using SQLite;
using System.IO;
using MarketPlace.Model.Entities;
using MarketPlace.Model.Interface;

namespace MarketPlace.DB.SqliteDB
{
    public class PurchaseRepositoryBySqliteNet : IPurchaseRepository
    {
        private string databasePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "database.sqlite");

        public PurchaseRepositoryBySqliteNet()
        {
            using (SQLiteConnection db = new SQLiteConnection(databasePath))
            {
                db.CreateTable<Purchase>();
                db.Close();
            }
        }
        public PurchaseRepositoryBySqliteNet(string databasePath)
        {
            this.databasePath = databasePath;
            using (SQLiteConnection db = new SQLiteConnection(databasePath))
            {
                db.CreateTable<Purchase>();
                db.Close();
            }
        }
        
        public Purchase GetPurchase(int id)
        {
            try
            {
                using (SQLiteConnection db = new SQLiteConnection(databasePath))
                {
                    Purchase purchase = db.Table<Purchase>().FirstOrDefault(x => x.Id == id);
                    db.Close();
                    return purchase;
                }
            }
            catch (Exception ex)
            {
                //this.Logger.log(ex);
                throw;
            }
        }

        public void CreatePurchase(Purchase purchase)
        {
            try
            {
                using (SQLiteConnection db = new SQLiteConnection(databasePath))
                {
                    db.Insert(purchase);
                    db.Close();
                }
            }
            catch (Exception ex)
            {
                //this.Logger.log(ex);
                throw;
            }
        }

        public IEnumerable<Purchase> Purchases()
        {
            try
            {
                using (SQLiteConnection db = new SQLiteConnection(databasePath))
                {
                    var purchases = db.Table<Purchase>();
                    db.Close();
                    return purchases;
                }
            }
            catch (Exception ex)
            {
                //this.Logger.log(ex);
                throw;
            }
        }
    }
}
