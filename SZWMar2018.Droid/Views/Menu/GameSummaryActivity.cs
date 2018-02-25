using Android.App;
using Android.Content.PM;
using Android.OS;
using MvvmCross.Droid.Views;
using SZWMar2018.Core.ViewModels.Menu;

namespace SZWMar2018.Droid.Views.Menu
{
    [Activity(ScreenOrientation = ScreenOrientation.Portrait)]
    public class GameSummaryActivity : MvxActivity<GameSummaryViewModel>
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.activity_gamesummary);
        }
    }
}
