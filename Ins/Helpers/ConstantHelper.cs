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

namespace Ins.Droid.Helpers
{
    static public class ConstantHelper
    {
        static readonly public string dataBaseName = "UsersTest.db";
        static readonly public List<string> permissions = new List<string> { "public_profile", "user_friends", "email" };
}
}