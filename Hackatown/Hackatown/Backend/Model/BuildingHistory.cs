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
using SQLite;

namespace Hackatown.Backend.Model
{
    public class BuildingHistory
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Name { get; set; }
        public int Img { get; set; }
        public int Pourcentage { get; set; }
    }
}