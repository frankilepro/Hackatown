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

            Building etablissement = new Building(Intent.GetStringExtra("name"));
            SetResultObject(etablissement);
        }

        public void SetResultObject(Building e)
        {
            text.Text = e._name;
            img.SetImageResource(e._img);
        }
    }

    public class Building
    {
        public int _img;
        public string _name;

        public Building(string name)
        {
            switch(name)
            {
                case "Polytechnique":
                    _img = Resource.Drawable.Poly;
                    _name = "Polytechnique Montreal";
                    break;
                case "Universite de Montreal":
                    _img = Resource.Drawable.Udem;
                    _name = "Universite de Montreal";
                    break;
                case "Oratoire St-Joseph":
                    _name = "Oratoire St-Joseph";
                    _img = Resource.Drawable.Oratoire;
                    break;
                default:
                    _name = "Aucun bâtiment détecté.";
                    _img = Resource.Drawable.index;
                    break;
            }
        }
    }
}