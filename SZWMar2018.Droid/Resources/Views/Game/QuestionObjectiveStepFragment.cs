using Android.OS;
using Android.Views;
using MvvmCross.Binding.Droid.BindingContext;
using MvvmCross.Droid.Shared.Attributes;
using MvvmCross.Droid.Support.V4;
using SZWMar2018.Core.ViewModels.Game;
using SZWMar2018.Droid;

namespace UrbanGame.Droid.Resources.Views.Game
{
    [MvxFragment(typeof(GameViewModel), Resource.Id.objectiveStepViewContainer)]
    public class QuestionObjectiveStepFragment : MvxFragment<QuestionObjectiveStepViewModel>
    {
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            base.OnCreateView(inflater, container, savedInstanceState);
            return this.BindingInflate(Resource.Layout.fragment_questionobjectivestep, null);
        }
    }
}
