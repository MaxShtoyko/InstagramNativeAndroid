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
        static private string _folder = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
        private SQLiteConnection _connection = new SQLiteConnection(System.IO.Path.Combine(_folder, typeof(T).ToString()));

        public void CreateDataBase()
        {
            _connection.CreateTable<T>();
        }

        public void InsertIntoTable(T item)
        {
            _connection.Insert(item);
        }

        public List<T> GetItems()
        {
            return _connection.Table<T>().ToList();
        }

        public void UpdateTable(T item)
        {
            _connection.Update(item);
        }

        public bool InDataBase(object primaryKey)
        {
            return _connection.Find<T>(primaryKey) != null;
        }

        public T GetItem(object primaryKey)
        {
            return _connection.Find<T>(primaryKey);
        }
    }
}