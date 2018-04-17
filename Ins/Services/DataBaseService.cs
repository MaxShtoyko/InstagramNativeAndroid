using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using Ins.Helpers;
using Ins.Interfaces;
using Ins.Models;
using SQLite;

namespace Ins.Services
{
    class DataBaseService:IDataBaseService
    {
        static private string folder = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);

        public bool CreateDataBase()
        {
            using (var connection = new SQLiteConnection(System.IO.Path.Combine(folder, ConstantHelper.dataBaseName)))
            {
                connection.CreateTable<User>();
                return true;
            }
        }

        public void InsertIntoTableUser(User User)
        {
            using (var connection = new SQLiteConnection(System.IO.Path.Combine(folder, ConstantHelper.dataBaseName)))
            {
                connection.Insert(User);
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