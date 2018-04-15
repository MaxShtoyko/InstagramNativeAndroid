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
using Ins.Models;
using SQLite;

namespace Ins.Services
{
    static class DataBaseService
    {
        static private string folder = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);

        static public bool createDataBase()
        {
            using (var connection = new SQLiteConnection(System.IO.Path.Combine(folder, ConstantHelper.dataBaseName)))
            {
                connection.CreateTable<User>();
                return true;
            }
        }

        static public void insertIntoTableUser(User User)
        {
            using (var connection = new SQLiteConnection(System.IO.Path.Combine(folder, ConstantHelper.dataBaseName)))
            {
                connection.Insert(User);
            }
        }

        static public List<User> getUsers()
        {
            using (var connection = new SQLiteConnection(System.IO.Path.Combine(folder, ConstantHelper.dataBaseName)))
            {
                return connection.Table<User>().ToList();
            }
        }

        static public void updateTableUser(User User)
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

        static public bool InDataBase(User user)
        {
            using (var connection = new SQLiteConnection(System.IO.Path.Combine(folder, ConstantHelper.dataBaseName)))
            {
                int result = connection.Table<User>().ToList().Where(u => u.Email == user.Email).ToList().Count;
                return result > 0;
            }
        }

    }
}