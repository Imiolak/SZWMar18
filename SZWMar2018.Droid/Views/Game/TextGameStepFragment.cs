using Android.OS;
using Android.Views;
using MvvmCross.Binding.Droid.BindingContext;
using MvvmCross.Droid.Shared.Attributes;
using MvvmCross.Droid.Support.V4;
using SZWMar2018.Core.ViewModels.Game;

namespace SZWMar2018.Droid.Views.Game
{
    [MvxFragment(typeof(GameViewModel), Resource.Id.gameStepContainer)]
    public class TextGameStepFragment : MvxFragment<TextGameStepViewModel>
    {
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            base.OnCreateView(inflater, container, savedInstanceState);
            return this.BindingInflate(Resource.Layout.fragment_textgamestep, null);
        }
    }
}
