using Android.OS;
using Android.Views;
using MvvmCross.Binding.Droid.BindingContext;
using MvvmCross.Droid.Support.V4;
using SZWMar2018.Core.ViewModels.Game;

namespace SZWMar2018.Droid.Views.Game
{
    public class ObjectiveStepNavigationFragment : MvxFragment<ObjectiveStepNavigationViewModel>
    {
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            base.OnCreateView(inflater, container, savedInstanceState);
            return this.BindingInflate(Resource.Layout.fragment_objectivestepnavigation, null);
        }
    }
}
