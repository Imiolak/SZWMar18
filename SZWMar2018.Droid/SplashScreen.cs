using Android.App;
using Android.Content.PM;
using MvvmCross.Droid.Views;

namespace SZWMar2018.Droid
{
    [Activity(Label = "Śladami Żołnierzy Wyklętych - Bochnia 2018", 
        MainLauncher = true, 
        Icon = "@drawable/icon", 
        Theme = "@style/Theme.Splash", 
        NoHistory = true, 
        ScreenOrientation = ScreenOrientation.Portrait)]
    public class SplashScreen : MvxSplashScreenActivity
    {
        public SplashScreen() : base(Resource.Layout.splash_screen)
        {
        }
    }
}
