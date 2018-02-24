using Android.App;
using Android.OS;
using MvvmCross.Droid.Support.V4;
using SZWMar2018.Core.ViewModels.Game;

namespace SZWMar2018.Droid.Views.Game
{
    [Activity]
    public class GameActivity : MvxCachingFragmentActivity<GameViewModel>
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.activity_game);
        }
    }
}
