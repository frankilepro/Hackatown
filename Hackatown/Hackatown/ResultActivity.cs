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
        TextView valueView;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.Result);
            img = FindViewById<ImageView>(Resource.Id.ResultImgView);
            text = FindViewById<TextView>(Resource.Id.ResultTextView);
            valueView = FindViewById<TextView>(Resource.Id.ResultValueView);


            SetResultObject(Intent.GetStringExtra("name"), Intent.GetStringExtra("value"));
        }

        public void SetResultObject(string name, string value)
        {
            text.Text = name;
            valueView.Text = $"Précision de {value}\n{FakeDatabase.Buildings[name].Description}";
            img.SetImageResource(FakeDatabase.Buildings[name].Img);
        }
    }
}