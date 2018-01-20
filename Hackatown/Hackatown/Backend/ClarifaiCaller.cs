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
using Newtonsoft.Json;

namespace Hackatown.Backend
{
    static class ClarifaiCaller
    {
        public static async Task<string> CallApi(Bitmap image)
        {
            HttpClient client = new HttpClient();

            client.DefaultRequestHeaders.Add("Authorization", "f1cfabe6a9cc49d6827987dc7b48d333");
            client.DefaultRequestHeaders.Add("Accept", "application/json");

            byte[] bitmapData;
            using (var stream = new MemoryStream())
            {
                image.Compress(Bitmap.CompressFormat.Png, 0, stream);
                bitmapData = stream.ToArray();
            }

            var response = await client.PostAsync(@"https://api.clarifai.com/v2/models/Hackatown%202018/outputs",
                                                  new StringContent(JsonConvert.SerializeObject(new ClarifaiRequest
                                                  {
                                                      inputs = new List<Input>
                                                       {
                                                           new Input
                                                           {
                                                               data = new Data
                                                               {
                                                                   image = new Image
                                                                   {
                                                                       base64 = Convert.ToBase64String(bitmapData)
                                                                   }
                                                               }
                                                           }
                                                       },
                                                  })));

            return await response.Content.ReadAsStringAsync();
        }
    }
}