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
    public interface IUserService
    {
        User GetCurrentUser();
        bool IsCorrect(User user);
        void SetUser(FacebookProfile result);
    }
}