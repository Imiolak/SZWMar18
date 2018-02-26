using Android.App;
using Android.Content.PM;
using Android.Gms.Maps;
using Android.Gms.Maps.Model;
using Android.OS;
using MvvmCross.Droid.Support.V4;
using SZWMar2018.Core.ViewModels.Game;

namespace SZWMar2018.Droid.Views.Game
{
    [Activity(ScreenOrientation = ScreenOrientation.Portrait)]
    public class MapActivity : MvxFragmentActivity<MapViewModel>, IOnMapReadyCallback
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.activity_map);

            var mapFragment = FragmentManager.FindFragmentById<MapFragment>(Resource.Id.map);
            mapFragment.GetMapAsync(this);
        }

        public void OnMapReady(GoogleMap googleMap)
        {
            var cameraPosition = CameraPosition.InvokeBuilder()
                .Target(new LatLng(49.9714601, 20.4225756))
                .Zoom(14f)
                .Build();
            var cameraUpdate = CameraUpdateFactory.NewCameraPosition(cameraPosition);

            googleMap.MoveCamera(cameraUpdate);
            googleMap.MyLocationEnabled = true;

            foreach (var locationMarker in ViewModel.LocationMarkers)
            {
                var markerOptions = new MarkerOptions();
                markerOptions.SetPosition(new LatLng(locationMarker.Latitude, locationMarker.Longitude));
                markerOptions.SetTitle(locationMarker.Tooltip);

                googleMap.AddMarker(markerOptions);
            }
        }
    }
}
