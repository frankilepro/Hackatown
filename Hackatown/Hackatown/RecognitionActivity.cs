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
using Android.Provider;
using Android.Graphics;
using Android.Content.PM;
using Android.Hardware;
using Android.Locations;
using Uri = Android.Net.Uri;

using Java.IO;
using Camera;
using System.Threading.Tasks;
using Hackatown.Backend;

namespace Hackatown
{
    [Activity(Label = "RecognitionActivity")]
    public class RecognitionActivity : Activity
    {
        Button BtnTakeImg;
        Button BtnSelectImg;
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
                BtnSelectImg = FindViewById<Button>(Resource.Id.btnselectpicture);
                ImgView = FindViewById<ImageView>(Resource.Id.ImgTakeimg);
                BtnTakeImg.Click += TakeAPicture;
                BtnSelectImg.Click += BtnSelectImg_Click;
            }
        }

        private void BtnSelectImg_Click(object sender, EventArgs e)
        {
            Intent = new Intent();
            Intent.SetType("image/*");
            Intent.SetAction(Intent.ActionGetContent);
            StartActivityForResult(Intent.CreateChooser(Intent, "Select Picture"), 102);

        }
        private void TakeAPicture(object sender, EventArgs eventArgs)
        {
            Intent intent = new Intent(MediaStore.ActionImageCapture);
            _file = new File(_dir, string.Format("Image_{0}.jpg", Guid.NewGuid()));
            intent.PutExtra(MediaStore.ExtraOutput, Uri.FromFile(_file));
            StartActivityForResult(intent, 102);
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
        
        protected async override void OnActivityResult(int requestCode, Result resultCode, Intent data)
        {
            
            if (requestCode == 102 && resultCode == Result.Ok)
            {
                if(_file == null)
                {
                    _file = new File(GetPathToImage(data.Data));
                }
                // make it available in the gallery  
                Intent mediaScanIntent = new Intent(Intent.ActionMediaScannerScanFile);
                Uri contentUri = Uri.FromFile(_file);
                
                mediaScanIntent.SetData(contentUri);
                SendBroadcast(mediaScanIntent);
                //Converstion Image Size  
                int height = ImgView.Height;
                int width = Resources.DisplayMetrics.WidthPixels;
                using (Bitmap bitmap = _file.Path.LoadAndResizeBitmap(height, width))
                {
                    progress = new Android.App.ProgressDialog(this);
                    progress.Indeterminate = true;
                    progress.SetProgressStyle(Android.App.ProgressDialogStyle.Spinner);
                    progress.SetMessage("Loading...");
                    progress.SetCancelable(false);
                    progress.Show();

                    var closest = await ClarifaiCaller.CallApi(bitmap);
                    Toast.MakeText(this, string.Join("\n", closest), ToastLength.Long).Show();
                    //View ImageView  
                    ImgView.RecycleBitmap();
                    ImgView.SetImageBitmap(bitmap);
                    //Upload Image in Database

                    await Task.Delay(TimeSpan.FromSeconds(2));

                    Intent res = new Intent(this, typeof(ResultActivity));
                    res.PutExtra("name", closest.First().Split(':')[0]);
                    StartActivity(res);
                }
            }
        }
        private string GetPathToImage(Android.Net.Uri uri)
        {
            string doc_id = "";
            using (var c1 = ContentResolver.Query(uri, null, null, null, null))
            {
                c1.MoveToFirst();
                String document_id = c1.GetString(0);
                doc_id = document_id.Substring(document_id.LastIndexOf(":") + 1);
            }

            string path = null;

            // The projection contains the columns we want to return in our query.
            string selection = Android.Provider.MediaStore.Images.Media.InterfaceConsts.Id + " =? ";
            using (var cursor = ManagedQuery(Android.Provider.MediaStore.Images.Media.ExternalContentUri, null, selection, new string[] { doc_id }, null))
            {
                if (cursor == null) return path;
                var columnIndex = cursor.GetColumnIndexOrThrow(Android.Provider.MediaStore.Images.Media.InterfaceConsts.Data);
                cursor.MoveToFirst();
                path = cursor.GetString(columnIndex);
            }
            return path;
        }
    }
}