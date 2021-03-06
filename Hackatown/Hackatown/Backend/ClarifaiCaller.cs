﻿using System;
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
    static class ClarifaiCaller
    {
        public static async Task<List<(string name, float value)>> CallApi(Bitmap image)
        {
            HttpClient client = new HttpClient();

            client.DefaultRequestHeaders.Add("Authorization", "Key f1cfabe6a9cc49d6827987dc7b48d333");
            client.DefaultRequestHeaders.Add("Accept", "application/json");

            byte[] bitmapData;
            using (var stream = new MemoryStream())
            {
                image.Compress(Bitmap.CompressFormat.Png, 0, stream);
                bitmapData = stream.ToArray();
            }

            var content = new StringContent(JsonConvert.SerializeObject(new ClarifaiRequest
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
            }));
            var response = await client.PostAsync(@"https://api.clarifai.com/v2/models/Hackatown%202018/outputs", content);

            var olishit = JsonConvert.DeserializeObject<ClarifaiResponse>(await response.Content.ReadAsStringAsync());
            return olishit.Outputs.First().Data.Concepts.OrderByDescending(x => x.Value).Where(x => x.Value >= 0.10).Select(x => (x.Name, x.Value)).ToList();
        }
    }
}