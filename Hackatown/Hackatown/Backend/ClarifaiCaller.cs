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
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace Hackatown.Backend
{
    static class ClarifaiCaller
    {
        static async Task CallApi()
        {
            HttpClient client = new HttpClient();

            client.DefaultRequestHeaders.Add("Authorization", "f1cfabe6a9cc49d6827987dc7b48d333");
            client.DefaultRequestHeaders.Add("Accept", "application/json");

            string result = await client.GetStringAsync(@"https://api.clarifai.com/v2/models/Hackatown%202018/outputs");
            //var parsedResult = JsonConvert.DeserializeObject<ClarifaiResponse>(result);
        }
    }
}