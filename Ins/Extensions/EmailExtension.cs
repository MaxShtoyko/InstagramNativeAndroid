using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace Ins.Extensions
{
    static public class EmailExtension
    {
        static public bool IsEmail( this string text )
        {
            try{
                MailAddress mailAddress = new MailAddress(text);
                return true;
            }
            catch (FormatException){
                return false;
            }
        }
    }
}