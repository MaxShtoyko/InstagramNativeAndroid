﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using SQLite;
using Xamarin.Facebook.Login.Widget;

namespace Ins.Models
{
    public class User
    {
        [PrimaryKey]
        public string Email { get; set; }
        public string FullName { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }

        public ProfilePictureView ProfilePictureView { get; set; }
    }
}