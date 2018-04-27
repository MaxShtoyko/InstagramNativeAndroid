using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Ins.Droid.Helpers
{
    static public class ConstantHelper
    {
        static readonly public List<string> permissions = new List<string> { "public_profile", "user_friends", "email" };

        static readonly public string userId = "592106287822987";
        static readonly public Uri authorizeUrl = new Uri("https://m.facebook.com/dialog/oauth/");
        static readonly public Uri redirectUrl = new Uri("https://www.facebook.com/connect/login_success.html");

    }
}