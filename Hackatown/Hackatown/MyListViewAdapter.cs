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
using Hackatown.Backend.Model;
using Android.Graphics;

namespace Hackatown
{
    class MyListViewAdapter : BaseAdapter<BuildingHistory>
    {
        List<BuildingHistory> Items;
        Context Ctx;

        public override BuildingHistory this[int position] => Items[position];

        public override int Count => Items.Count;

        public override long GetItemId(int position)
        {
            return position;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            View row = convertView == null ? LayoutInflater.From(Ctx).Inflate(Resource.Layout.LinearLayout, null, false) : convertView;
            var tmp = row.FindViewById<TextView>(Resource.Id.listRowText);
            tmp.Text = Items[position].Date.ToString("yyyy-MM-dd hh:mm") + "\n" +
                       Items[position].Name + " @ " + $"{Items[position].Pourcentage.ToString()}%";

            return row;
        }

        public MyListViewAdapter(Context ctx, List<BuildingHistory> items)
        {
            Ctx = ctx;
            Items = items;
        }
    }
}