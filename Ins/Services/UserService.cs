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
using Ins.Extensions;
using Ins.Models;

namespace Ins.Services
{
    static public class UserService
    {
        static public bool IsCorrect( User user )
        {
            if (String.IsNullOrWhiteSpace(user.Email) || String.IsNullOrWhiteSpace(user.Password)){
                return false;
            }

            return user.Email.IsEmail() && user.Password.Length > 6;
        }
    }
}