using Ins.Droid.Helpers;
using Ins.Droid.Interfaces;
using Ins.Droid.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Ins.Droid.Services
{
    public class DataBaseService<T>:IDataBaseService where T: class
    {
        static private string folder = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);

        public void CreateDataBase(T type, string dataBaseName)
        {
            using (var connection = new SQLiteConnection(System.IO.Path.Combine(folder, dataBaseName)))
            {
                connection.CreateTable<T>();
            }
        }

        public void InsertIntoTable(T item, string dataBaseName)
        {
            using (var connection = new SQLiteConnection(System.IO.Path.Combine(folder, dataBaseName)))
            {
                connection.Insert(item);
            }
        }

        public List<User> GetUsers()
        {
            using (var connection = new SQLiteConnection(System.IO.Path.Combine(folder, ConstantHelper.dataBaseName)))
            {
                return connection.Table<User>().ToList();
            }
        }

        public void UpdateTableUser(User User)
        {
            using (var connection = new SQLiteConnection(System.IO.Path.Combine(folder, ConstantHelper.dataBaseName)))
            {
                connection.Query<User>(
                    "UPDATE User set FullName=?,Login=?,Password=? Where Email=?", 
                    User.FullName,
                    User.Login, 
                    User.Password, 
                    User.Email);
            }
        }

        public bool InDataBase(User user)
        {
            using (var connection = new SQLiteConnection(System.IO.Path.Combine(folder, ConstantHelper.dataBaseName)))
            {
                int result = connection.Table<User>().ToList().Where(u => u.Email == user.Email).ToList().Count;
                return result > 0;
            }
        }

        public void CreateDataBase()
        {
            throw new NotImplementedException();
        }

        public void InsertIntoTableUser(User User)
        {
            throw new NotImplementedException();
        }
    }
}