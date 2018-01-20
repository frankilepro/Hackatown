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
    class ClarifaiRequest
    {
        public List<Input> inputs { get; set; }
    }

    class Input
    {
        public Data data { get; set; }
    }

    class Data
    {
        public Image image { get; set; }
    }

    class Image
    {
        public string base64 { get; set; }
    }
}