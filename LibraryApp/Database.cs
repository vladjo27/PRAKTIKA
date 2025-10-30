// Database.cs
using System;
using System.Data;
using System.Data.OleDb;

namespace LibraryApp
{
    public static class Database
    {
        public static OleDbConnection GetConnection()
        {
            string path = AppDomain.CurrentDomain.BaseDirectory + "LibraryDB.accdb";
            string connectString = $"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={path};";
            return new OleDbConnection(connectString);
        }
    }
}