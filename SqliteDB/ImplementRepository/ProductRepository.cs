﻿using System;
using System.Data;
using System.Text;
using System.Data.SQLite;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Runtime.CompilerServices;
using System.Runtime.Remoting.Metadata.W3cXsd2001;

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
                string query = "SELECT * FROM Items";
                using (SQLiteCommand cmd = new SQLiteCommand(query, Db.Connection))
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
                throw new Exception(ex.Message);
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
                string query = "SELECT * FROM Items WHERE Id = " + id;
                using (SQLiteCommand cmd = new SQLiteCommand(query, Db.Connection))
                {
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
                throw new Exception(ex.Message);
            }
            finally
            {
                Db.CloseConnection();
            }
        }

        public void CreateProduct(string id, string description, decimal price)
        {
            Product product = new Product { Id = id, Description = description, Price = price };
            CreateProduct(product);
        }
        public void CreateProduct(Product product)
        {
            Product oldProduct = GetProduct(product.Id);
            if (oldProduct != null)
                return;

            try
            {
                Db.OpenConnection();
                using (SQLiteCommand cmd = new SQLiteCommand("INSERT INTO Items (Id, Desciption, Price) VALUES (?,?,?)", Db.Connection))
                {
                    cmd.Parameters.Add(product.Id);
                    cmd.Parameters.Add(product.Description);
                    cmd.Parameters.Add(product.Price);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
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
                    [Items](
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
                throw new Exception(ex.Message);
            }
            finally
            {
                Db.CloseConnection();
            }
        }
    }
}
