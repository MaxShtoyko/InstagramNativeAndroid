using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Ins.Droid.Models;

namespace Ins.Droid.Interfaces
{
    public interface IDataBaseService
    {
        bool InDataBase(User user);

        void CreateDataBase();
        void InsertIntoTableUser(User User);
        void UpdateTableUser(User User);

        List<User> GetUsers();
    }
}