using System;
using System.IO;
using System.Data;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Collections.Generic;
using System.Data.SQLite;

using MarketPlace.Model.Entities;
using MarketPlace.Model.Interface;

namespace MarketPlace.DB.Implement
{
    public class PurchaseRepository : IPurchaseRepository
    {
        private SQLiteDatabase Db;

        public PurchaseRepository(SQLiteDatabase db)
        {
            Db = db; 
            CreateTable();
        }

        public IEnumerable<Purchase> Purchases()
        {
            try
            {
                Db.OpenConnection();
                string query = "SELECT * FROM Purchase";
                using (SQLiteCommand cmd = new SQLiteCommand(query, Db.Connection))
                {
                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {
                        List<Purchase> purshases = new List<Purchase>();
                        while (reader.Read())
                        {
                            int id = Int32.Parse(reader["Id"].ToString());
                            string date = reader["Date"].ToString();
                            string content = reader["Content"].ToString();
                            purshases.Add(new Purchase { Id = id, Date = DateTime.Parse(date), Content = content });
                        }
                        return purshases;
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

        public Purchase GetPurchase(int id)
        {
            try
            {
                Purchase purchase = null;
                Db.OpenConnection();
                string query = "SELECT * FROM Purchase WHERE Id = " + id;
                using (SQLiteCommand cmd = new SQLiteCommand(query, Db.Connection))
                {
                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int purchaseId = Int32.Parse(reader["Id"].ToString());
                            string date = reader["Date"].ToString();
                            string content = reader["Content"].ToString();
                            purchase = new Purchase { Id = id, Date = DateTime.Parse(date), Content = content };
                        }
                    }
                }
                return purchase;
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

        public void CreatePurchase(Purchase purchase)
        {
            try
            {
                Db.OpenConnection();
                using (SQLiteCommand cmd = new SQLiteCommand("INSERT INTO Purchase (Date, Content) VALUES (@Date, @Content)", Db.Connection))
                {
                    cmd.Parameters.Add(new SQLiteParameter("@Date", DbType.DateTime2){ Value = purchase.Date });
                    cmd.Parameters.Add(new SQLiteParameter("@Content", DbType.String) { Value = purchase.Content });
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
                    [Purchase](
	                [Id]	        INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT UNIQUE,
	                [Date]	        TEXT,
	                [Content]	    TEXT)";

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
