using Ins.Core.Interfaces;
using Ins.Core.Models;
using Ins.Droid.Helpers;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Ins.Droid.Services
{
    public class DataBaseService<T>:IDataBaseService<T> where T: new()
    {
        static private string _folder = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
        private SQLiteConnection connection = new SQLiteConnection(System.IO.Path.Combine(_folder, typeof(T).ToString()));

        public void CreateDataBase()
        {
            connection.CreateTable<T>();
        }

        public void InsertIntoTable(T item)
        {
            connection.Insert(item);
        }

        public List<T> GetItems()
        {
            return connection.Table<T>().ToList();
        }

        public void UpdateTable(T item)
        {
            connection.Update(item);
        }

        public bool InDataBase(object primaryKey)
        {
            return connection.Find<T>(primaryKey) != null;
        }
    }
}