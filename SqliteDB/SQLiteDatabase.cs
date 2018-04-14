using System;
using System.IO;
using System.Data.SQLite;

namespace MarketPlace.DB
{
    public class SQLiteDatabase
    {
        private string dbFilePath = Environment.CurrentDirectory;
        private string dbFileName = "database.sqlite";

        private SQLiteConnection connection = null;

        private Exception exception;

        public SQLiteDatabase(string dbFileName = null)
        {
            if (!string.IsNullOrEmpty(dbFileName))
                this.dbFileName = dbFileName;

            ExtendendStatus = string.Empty;
            this.Exception = null;
        }

        public string DBFileNamePath
        {
            get
            {
                return Path.Combine(dbFilePath, dbFileName);
            }
        }
        public string DBFileName { get { return dbFileName; } }
        public string DBFilePath { get { return dbFilePath; } }

        public Exception Exception { get; set; }

        public string Status { get; private set; }
        public string ExtendendStatus { get; set; }

        public SQLiteConnection Connection { get { return connection; } }

        public bool ConnectionState
        {
            get
            {
                try
                {
                    if (connection == null) 
                        return false;

                    return connection.State == System.Data.ConnectionState.Open;
                }
                catch (Exception exp)
                {
                    this.Exception = exp;
                    throw new Exception(exp.Message);
                }
            }
        }

        public void OpenConnection(bool overwriteFile = false)
        {
            try
            {
                if (connection != null)
                {
                    if (connection.State == System.Data.ConnectionState.Open)
                        return;
                }
                else
                    ConstructConnection(overwriteFile);

                connection.Open();
            }
            catch (Exception exp)
            {
                this.Exception = exp;
                throw new Exception(exp.Message);
            }
        }

        public void CloseConnection()
        {
            try
            {
                if (ConnectionState)
                    connection.Close();

                connection = null;
            }
            catch (Exception exp)
            {
                this.Exception = exp;
                throw new Exception(exp.Message);
            }
        }

        private void ConstructConnection(bool overWriteFile = false)
        {
            var dbFileNamePath = DBFileNamePath;

            SQLiteConnectionStringBuilder connectString = new SQLiteConnectionStringBuilder();
            connectString.DataSource = dbFileNamePath;

            connection = new SQLiteConnection(connectString.ToString());

            if (!File.Exists(dbFileNamePath))
            {
                SQLiteConnection.CreateFile(dbFileNamePath);
            }
            else
            {
                if (overWriteFile)
                    SQLiteConnection.CreateFile(dbFileNamePath);
            }
        }
    }
}
