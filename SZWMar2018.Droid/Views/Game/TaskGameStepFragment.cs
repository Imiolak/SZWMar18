using Android.Gms.Maps;
using Android.Gms.Maps.Model;
using Android.OS;
using Android.Views;
using MvvmCross.Binding.Droid.BindingContext;
using MvvmCross.Droid.Shared.Attributes;
using MvvmCross.Droid.Support.V4;
using SZWMar2018.Core.ViewModels.Game;

namespace SZWMar2018.Droid.Views.Game
{
    [MvxFragment(typeof(GameViewModel), Resource.Id.gameStepContainer)]
    public class TaskGameStepFragment : MvxFragment<TaskGameStepViewModel>, IOnMapReadyCallback
    {
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            base.OnCreateView(inflater, container, savedInstanceState);
            var view = this.BindingInflate(Resource.Layout.fragment_taskgamestep, null);

            var transaction = Activity.FragmentManager.BeginTransaction();
            var mapFragment = new MapFragment();
            transaction.Replace(Resource.Id.mapFragmentPlaceholder, new MapFragment());
            transaction.Commit();

            mapFragment.GetMapAsync(this);

            return view;
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
