using Android.App;
using Android.Widget;
using Android.OS;

namespace Hackatown
{
    [Activity(Label = "Hackatown", MainLauncher = true)]
    public class MainActivity : Activity
    {
        TextView test;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            test = FindViewById<TextView>(Resource.Id.test);
            test.Click += testClick;
        }

        private void testClick(object sender, System.EventArgs e)
        {
            test.Text = "allooasdoasoda";
        }
    }
}

