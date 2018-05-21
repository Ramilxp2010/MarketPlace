using System;
using System.Data;
using System.Data.SQLite;
using System.Collections.Generic;
using MarketPlace.Model.Entities;
using MarketPlace.Model.Interface;

namespace MarketPlace.DB.Implement
{
    public class ProductRepository : IProductRepository
    {
        public readonly SQLiteDatabase Db;
        public ProductRepository(SQLiteDatabase db)
        {
            Db = db;
            CreateTable();
        }

        public IEnumerable<Product> GetProducts()
        {
            try
            {
                Db.OpenConnection();
                using (SQLiteCommand cmd = new SQLiteCommand("SELECT * FROM Product", Db.Connection))
                {
                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {
                        List<Product> products = new List<Product>();
                        while (reader.Read())
                        {
                            Product product = new Product();
                            product.Id = reader["Id"].ToString();
                            product.Description = reader["Description"].ToString();
                            product.Price = Decimal.Parse(reader["Price"].ToString());
                            products.Add(product);
                        }
                        return products;
                    }
                }
            }
            catch (Exception ex)
            {
                //this.Logger.log(ex);
                throw;
            }
            finally
            {
                Db.CloseConnection();
            }
        }

        public Product GetProduct(string id)
        {
            try
            {
                Product product = null;
                Db.OpenConnection();
                using (SQLiteCommand cmd = new SQLiteCommand("SELECT * FROM Product WHERE Id = @Id", Db.Connection))
                {
                    cmd.Parameters.Add(new SQLiteParameter("@Id", DbType.String) { Value = id });
                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            product = new Product();
                            product.Id = reader["Id"].ToString();
                            product.Description = reader["Description"].ToString();
                            product.Price = Decimal.Parse(reader["Price"].ToString());
                            return product;
                        }
                    }
                }
                return product;
            }
            catch (Exception ex)
            {
                //this.Logger.log(ex);
                throw;
            }
            finally
            {
                Db.CloseConnection();
            }
        }
        
        public void CreateProduct(Product product)
        {
            Product oldProduct = GetProduct(product.Id);
            if (oldProduct != null)
                return;

            try
            {
                Db.OpenConnection();
                using (SQLiteCommand cmd = new SQLiteCommand("INSERT INTO Product (Description, Price) VALUES (@Description, @Price)", Db.Connection))
                {
                    cmd.Parameters.Add(new SQLiteParameter("@Description", DbType.String) { Value = product.Description });
                    cmd.Parameters.Add(new SQLiteParameter("@Price", DbType.Decimal) { Value = product.Price });
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                //this.Logger.log(ex);
                throw;
            }
            finally
            {
                Db.CloseConnection();
            }
        }

        private void CreateTable()
        {
            try
            {
                Db.OpenConnection();
                string createQuery =
                    @"CREATE TABLE IF NOT EXISTS
                    [Product](
	                [Id]	        TEXT NOT NULL UNIQUE PRIMARY KEY,
	                [Description]	TEXT,
	                [Price]	        REAL)";

                using (SQLiteCommand cmd = new SQLiteCommand(Db.Connection))
                {
                    cmd.CommandText = createQuery;
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                //this.Logger.log(ex);
                throw;
            }
            finally
            {
                Db.CloseConnection();
            }
        }
    }
}
