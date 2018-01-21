using Android.App;
using Android.Widget;
using Android.OS;

namespace Hackatown
{
    [Activity(Label = "Vision Tourisme", MainLauncher = true)]
    public class MainActivity : Activity
    {
        Button recognition;
        Button maps;
        Button rallye;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);
            

            recognition = FindViewById<Button>(Resource.Id.recognition);
            maps = FindViewById<Button>(Resource.Id.maps);
            rallye = FindViewById<Button>(Resource.Id.rallye);
            recognition.Click += Recognition_Click;
            maps.Click += Maps_Click;
            rallye.Click += Rallye_Click;
        }

        private void Rallye_Click(object sender, System.EventArgs e)
        {
            StartActivity(typeof(RallyeActivity));
        }

        private void Maps_Click(object sender, System.EventArgs e)
        {
            StartActivity(typeof(MapsActivity));
        }

        private void Recognition_Click(object sender, System.EventArgs e)
        {
            StartActivity(typeof(RecognitionActivity));
        }
    }
}

