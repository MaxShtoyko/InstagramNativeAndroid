using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace Ins.Models
{
    public class Photo
    {
        public string Author { get; set; }
        public string DateOfPublication { get; set; }
        public Bitmap Picture { get; set; }
    }
}