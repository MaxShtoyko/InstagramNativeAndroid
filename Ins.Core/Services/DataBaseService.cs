using Ins.Core.Interfaces;
using Ins.Core.Models;
using Ins.Droid.Helpers;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Ins.Droid.Services
{
    public class DataBaseService:IDataBaseService
    {
        static private string folder = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);

        public void CreateDataBase()
        {
            using (var connection = new SQLiteConnection(System.IO.Path.Combine(folder, ConstantHelper.dataBaseName)))
            {
                connection.CreateTable<User>();
            }
        }

        public void InsertIntoTableUser(User user)
        {
            using (var connection = new SQLiteConnection(System.IO.Path.Combine(folder, ConstantHelper.dataBaseName)))
            {
                connection.Insert(user);
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
    }
}