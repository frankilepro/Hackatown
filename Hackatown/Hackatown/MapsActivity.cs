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
using Android.Locations;
using System.Threading;
using Android.Gms.Maps;
using Android.Gms.Maps.Model;

namespace Hackatown
{
    [Activity(Label = "MapsActivity")]
    public class MapsActivity : Activity, ILocationListener, IOnMapReadyCallback
    {
        MapFragment _mapFragment;
        GoogleMap _map;
        ProgressDialog _pDialog;
        LocationManager _locationManager;

        //Marker _currentPosMarker;
        //Marker _firstMarker;
        //Marker _secondMarker;
        //Marker _thirdMarker;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Maps);

            _pDialog = new ProgressDialog(this);
            _pDialog.Indeterminate = true;
            _pDialog.SetProgressStyle(ProgressDialogStyle.Spinner);
            _pDialog.SetMessage("Loading...");
            _pDialog.SetCancelable(false);
            _pDialog.Show();
            
            _locationManager = GetSystemService(Context.LocationService) as LocationManager;

            _mapFragment = FragmentManager.FindFragmentByTag("map") as MapFragment;
            if (_mapFragment == null)
            {
                GoogleMapOptions mapOptions = new GoogleMapOptions()
                    .InvokeMapType(GoogleMap.MapTypeSatellite)
                    .InvokeZoomControlsEnabled(false)
                    .InvokeCompassEnabled(true);

                FragmentTransaction fragTx = FragmentManager.BeginTransaction();
                _mapFragment = MapFragment.NewInstance(mapOptions);
                fragTx.Add(Resource.Id.map, _mapFragment, "map");
                fragTx.Commit();
            }
            _mapFragment.GetMapAsync(this);
        }
        public void OnMapReady(GoogleMap map)
        {
            _map = map;
            _map.MapType = GoogleMap.MapTypeNormal;
        }
        protected override void OnResume()
        {
            base.OnResume();
            var locationCriteria = new Criteria();
            locationCriteria.Accuracy = Accuracy.NoRequirement;
            locationCriteria.PowerRequirement = Power.NoRequirement;
            string locationProvider = _locationManager.GetBestProvider(locationCriteria, true);
            _locationManager.RequestLocationUpdates(locationProvider, 2000, 1, this);
        }

        protected override void OnPause()
        {
            base.OnPause();
            _locationManager.RemoveUpdates(this);
        }
        public void OnLocationChanged(Location location)
        {
            LatLng here = new LatLng(location.Latitude, location.Longitude);

            CameraPosition.Builder builder = CameraPosition.InvokeBuilder();
            builder.Target(here);
            builder.Zoom(13);
            CameraPosition cameraPosition = builder.Build();
            CameraUpdate cameraUpdate = CameraUpdateFactory.NewCameraPosition(cameraPosition);

            _map.MoveCamera(cameraUpdate);

            MarkerOptions curMarkerOps = new MarkerOptions();
            curMarkerOps.SetPosition(here);
            curMarkerOps.SetTitle("You are here");
            _map.AddMarker(curMarkerOps);




            _pDialog.Hide();
        }

        public void OnProviderDisabled(string provider)
        {
        }

        public void OnProviderEnabled(string provider)
        {
        }

        public void OnStatusChanged(string provider, [GeneratedEnum] Availability status, Bundle extras)
        {
        }
    }
}
