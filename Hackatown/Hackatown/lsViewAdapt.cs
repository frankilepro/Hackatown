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
    class lsViewAdapt : BaseAdapter<string>
    {
        List<string> Items;
        Context Ctx;

        public override string this[int position] => Items[position];

        public override int Count => Items.Count;

        public override long GetItemId(int position)
        {
            return position;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            View row = convertView == null ? LayoutInflater.From(Ctx).Inflate(Resource.Layout.layout1, null, false) : convertView;
            var tmp = row.FindViewById<TextView>(Resource.Id.textView1);
            tmp.Text = Items[position];
            return row;
        }

        public lsViewAdapt(Context ctx, List<string> items)
        {
            Ctx = ctx;
            Items = items;
        }
    }
}