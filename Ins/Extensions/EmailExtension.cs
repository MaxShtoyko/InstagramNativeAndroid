using System;
using System.Net.Mail;

namespace Ins.Droid.Extensions
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