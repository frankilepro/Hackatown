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

namespace Hackatown.Backend.Model
{
    public class Building
    {
        public int Img { get; set; }
        public string Description { get; set; }
        public double Long { get; set; }
        public double Lat { get; set; }
    }

}