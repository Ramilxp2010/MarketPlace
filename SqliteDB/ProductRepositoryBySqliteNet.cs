using MarketPlace.Model.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MarketPlace.Model.Entities;
using SQLite;
using System.IO;

namespace MarketPlace.DB.SqliteDB
{
    public class ProductRepositoryBySqliteNet : IProductRepository
    {
        private string databasePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "database.sqlite");

        public ProductRepositoryBySqliteNet()
        {
            SQLiteConnection db = new SQLiteConnection(databasePath);
            db.CreateTable<Product>();
            db.Close();
        }
        public ProductRepositoryBySqliteNet(string databasePath)
        {
            this.databasePath = databasePath;
            var db = new SQLiteConnection(databasePath);
            db.CreateTable<Purchase>();
            db.Close();
        }

        public Product GetProduct(string id)
        {
            try
            {
                using (SQLiteConnection db = new SQLiteConnection(databasePath))
                {
                    Product product = db.Table<Product>().FirstOrDefault(x => x.Id == id);
                    db.Close();
                    return product;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void CreateProduct(Product product)
        {
            try
            {
                using (SQLiteConnection db = new SQLiteConnection(databasePath))
                {
                    db.Insert(product);
                    db.Close();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public IEnumerable<Product> GetProducts()
        {
            try
            {
                using (SQLiteConnection db = new SQLiteConnection(databasePath))
                {
                    var products = db.Table<Product>();
                    db.Close();
                    return products;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        
    }
}
