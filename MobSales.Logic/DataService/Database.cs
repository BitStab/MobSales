using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.IO;

#if WINDOWS_PHONE

#else
using Mono.Data.Sqlite;
#endif

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace MobSales.Logic.DataService
{
    public class Database
    {
        
        public Database()
        {
            string dbPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal),"mobSales.db3");
            bool exists = File.Exists(dbPath);

            if(!exists)
                SqliteConnection.CreateFile(dbPath);
            var connection = new SqliteConnection("Data Source=" + dbPath);
            connection.Open();

            if(!exists){
                var commands = new[]{
                    "CREATE TABLE [Items] (No varchar(30), Description varchar(50));",
                    "CREATE TABLE [Customers] (No varchar(30), Name varchar(50), Address varchar(120));"
                };
                foreach(var command in commands){
                    using (var c=connection.CreateCommand()){
                        c.CommandText = command;
                        c.ExecuteNonQuery();
                    }
                }
            }
        }

        public void AddCustomerIfNotExists(string No, string Name, string Address)
        {
            string dbPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "mobSales.db3");
            bool exists = File.Exists(dbPath);
            if (exists)
            {
                var connection = new SqliteConnection("Data Source=" + dbPath);
                connection.Open();

                var command = "SELECT * FROM Customers WHERE No=" + No + " AND Name=" + Name + " AND Address=" + Address;

                var c = connection.CreateCommand();
                c.CommandText = command;
                DataTable dt = new DataTable();
                SqliteDataReader reader = c.ExecuteReader();
                dt.Load(reader);
                reader.Close();
                connection.Close();
                if (dt.Rows.Count == 0)
                {
                    Insert("INSERT INTO Customers(No, Name, Address) values('" + No + "','" + Name + "','" + Address + "');");
                }
            }
        }

        private void Insert(string command)
        {
            string dbPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "mobSales.db3");
            bool exists = File.Exists(dbPath);
            if (exists)
            {
                var connection = new SqliteConnection("Data Source=" + dbPath);
                connection.Open();
                var c = connection.CreateCommand();
                c.CommandText = command;
                c.ExecuteNonQuery();
            }
        }

        public List<MobSales.Logic.Model.Customer> GetCustomers()
        {
            string dbPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "mobSales.db3");
            bool exists = File.Exists(dbPath);
            List<MobSales.Logic.Model.Customer> custs = new List<Model.Customer>();
            if (exists)
            {
                var connection = new SqliteConnection("Data Source=" + dbPath);
                connection.Open();
                var command = "SELECT * FROM Customers";

                var c = connection.CreateCommand();
                c.CommandText = command;
                DataTable dt = new DataTable();
                SqliteDataReader reader = c.ExecuteReader();
                dt.Load(reader);
                reader.Close();
                connection.Close();
                foreach (DataRow row in dt.Rows)
                {
                    custs.Add(new Model.Customer()
                    {
                        No = row["No"].ToString(),
                        Name = row["Name"].ToString(),
                        Address = row["Address"].ToString(),
                    }
                    );
                }
                return custs;
            }
            else
            {
                return null;
            }
        }
    }
}