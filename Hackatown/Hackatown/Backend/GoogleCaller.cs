using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Hackatown.Backend.Model;
using Hackatown.Backend.Response;
using Newtonsoft.Json;

namespace Hackatown.Backend
{
    static class GoogleCaller
    {
        public static List<Building> BuildingProches(double lon, double lat)
        {
            return FakeDatabase.Buildings.Values.OrderBy(x => CalculateDistance(lon, x.Long, lat, x.Lat)).Take(3).ToList();

        }
        private static double CalculateDistance(double lon1, double lon2, double lat1, double lat2)
        {
            const double EARTH_RADIUS = 6371; //KM
            double dlon = lon2 - lon1;
            double dlat = lat2 - lat1;
            double a = Math.Pow((Math.Sin(dlat / 2)), 2) + Math.Cos(lat1) * Math.Cos(lat2) * Math.Pow((Math.Sin(dlon / 2)), 2);
            double c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));
            return EARTH_RADIUS * c;
        }
    }
}