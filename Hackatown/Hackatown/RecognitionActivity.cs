﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.Provider;
using Android.Graphics;
using Android.Content.PM;
using Android.Hardware;
using Android.Locations;
using Uri = Android.Net.Uri;

using Java.IO;
using Camera;
using System.Threading.Tasks;

namespace Hackatown
{
    [Activity(Label = "RecognitionActivity")]
    public class RecognitionActivity : Activity
    {
        Button BtnTakeImg;
        ImageView ImgView;

        Android.App.ProgressDialog progress;

        public static File _file;
        public static File _dir;
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            // Set our view from the "main" layout resource  
            SetContentView(Resource.Layout.Recognition);
            if (IsThereAnAppToTakePictures())
            {
                CreateDirectoryForPictures();
                BtnTakeImg = FindViewById<Button>(Resource.Id.btntakepicture);
                ImgView = FindViewById<ImageView>(Resource.Id.ImgTakeimg);
                BtnTakeImg.Click += TakeAPicture;
            }
        }
        private void CreateDirectoryForPictures()
        {
            _dir = new File(Android.OS.Environment.GetExternalStoragePublicDirectory(Android.OS.Environment.DirectoryPictures), "Hackatown");
            if (!_dir.Exists())
            {
                _dir.Mkdirs();
            }
        }
        private bool IsThereAnAppToTakePictures()
        {
            Intent intent = new Intent(MediaStore.ActionImageCapture);
            IList<ResolveInfo> availableActivities = PackageManager.QueryIntentActivities(intent, PackageInfoFlags.MatchDefaultOnly);
            return availableActivities != null && availableActivities.Count > 0;
        }
        private void TakeAPicture(object sender, EventArgs eventArgs)
        {
            Intent intent = new Intent(MediaStore.ActionImageCapture);
            _file = new File(_dir, string.Format("Image_{0}.jpg", Guid.NewGuid()));
            intent.PutExtra(MediaStore.ExtraOutput, Uri.FromFile(_file));
            StartActivityForResult(intent, 102);
        }
        
        protected async override void OnActivityResult(int requestCode, Result resultCode, Intent data)
        {
            if (requestCode == 102 && resultCode == Result.Ok)
            {
                // make it available in the gallery  
                Intent mediaScanIntent = new Intent(Intent.ActionMediaScannerScanFile);
                Uri contentUri = Uri.FromFile(_file);
                
                mediaScanIntent.SetData(contentUri);
                SendBroadcast(mediaScanIntent);
                //Converstion Image Size  
                int height = ImgView.Height;
                int width = Resources.DisplayMetrics.WidthPixels;
                using (Bitmap bitmap = _file.Path.LoadAndResizeBitmap(width, height))
                {
                    var test = await ClarifaiCaller.CallApi(bitmap);
                    //View ImageView  
                    ImgView.RecycleBitmap();
                    ImgView.SetImageBitmap(bitmap);
                    //Upload Image in Database
                    progress = new Android.App.ProgressDialog(this);
                    progress.Indeterminate = true;
                    progress.SetProgressStyle(Android.App.ProgressDialogStyle.Spinner);
                    progress.SetMessage("Loading...");
                    progress.SetCancelable(false);
                    progress.Show();

                    await Task.Delay(TimeSpan.FromSeconds(2));

                    Intent res = new Intent(this, typeof(ResultActivity));
                    res.PutExtra("name", "poly");
                    StartActivity(res);
                }
            }
        }
    }
}