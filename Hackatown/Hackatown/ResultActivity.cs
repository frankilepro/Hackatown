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
using Hackatown.Backend;
using Hackatown.Backend.Model;

namespace Hackatown
{
    [Activity(Label = "ResultActivity")]
    public class ResultActivity : Activity
    {
        ImageView img;
        TextView text;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.Result);
            img = FindViewById<ImageView>(Resource.Id.ResultImgView);
            text = FindViewById<TextView>(Resource.Id.ResultTextView);

            SetResultObject(Intent.GetStringExtra("name"));
        }

        public void SetResultObject(string name)
        {
            text.Text = name;
            img.SetImageResource(FakeDatabase.Buildings[name].Img);
        }
    }
}