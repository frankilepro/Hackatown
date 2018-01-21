using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Hackatown.Backend.Model;
using SQLite;

namespace Hackatown
{
    public static class DatabaseCaller
    {
        static string Path = System.IO.Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "BuildingHistory.db3");

        static DatabaseCaller()
        {
            var conn = new SQLiteAsyncConnection(Path);
            conn.CreateTableAsync<BuildingHistory>();
        }

        public static async Task AddNewPerson(Building building, int pourcentage)
        {
            var conn = new SQLiteAsyncConnection(Path);
            var result = await conn.InsertAsync(new BuildingHistory
            {
                Date = DateTime.Now,
                Img = building.Img,
                Name = building.Name,
                Pourcentage = pourcentage
            });
        }

        public static async Task<List<BuildingHistory>> GetLatest()
        {
            var conn = new SQLiteAsyncConnection(Path);
            return await conn.Table<BuildingHistory>().OrderBy(x => x.Date).ToListAsync();
        }
    }
}