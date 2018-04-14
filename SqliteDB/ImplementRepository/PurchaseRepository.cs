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
                string query = "SELECT * FROM Purchases";
                using (SQLiteCommand cmd = new SQLiteCommand(query, Db.Connection))
                {
                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {
                        List<Purchase> purshases = new List<Purchase>();
                        while (reader.Read())
                        {
                            string content = reader["Content"].ToString();
                            Purchase purchase = XMLDeserializePurchase(content);
                            purshases.Add(purchase);
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
                string query = "SELECT * FROM Purchases WHERE Id = " + id;
                using (SQLiteCommand cmd = new SQLiteCommand(query, Db.Connection))
                {
                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string content = reader["Content"].ToString();
                            purchase = XMLDeserializePurchase(content);
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

        public void InsertPurchase(DateTime date, string content)
        {
            try
            {
                Db.OpenConnection();
                using (SQLiteCommand cmd = new SQLiteCommand("INSERT INTO Purchases (Date, Content) VALUES (@Date, @Content)", Db.Connection))
                {
                    cmd.Parameters.Add(new SQLiteParameter("@Date", DbType.DateTime2){ Value = date });
                    cmd.Parameters.Add(new SQLiteParameter("@Content", DbType.String) { Value = content });
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
                    [Purchases](
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

            }
            finally
            {
                Db.CloseConnection();
            }
        }

        private Purchase XMLDeserializePurchase(string content)
        {
            Purchase result = null;
            XmlSerializer serializer = new XmlSerializer(typeof(Purchase));            
            using (TextReader reader = new StringReader(content))
            {
                result = serializer.Deserialize(reader) as Purchase;
            }
            return result;
        }
    }
}
