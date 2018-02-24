using Android.Content;
using MvvmCross.Core.ViewModels;
using MvvmCross.Droid.Platform;
using MvvmCross.Droid.Shared.Presenter;
using MvvmCross.Droid.Views;
using MvvmCross.Platform;
using MvvmCross.Platform.Platform;
using SZWMar2018.Core;
using SZWMar2018.Droid.Custom;

namespace SZWMar2018.Droid
{
    public class Setup : MvxAndroidSetup
    {
        public Setup(Context applicationContext) : base(applicationContext)
        {
        }

        protected override IMvxApplication CreateApp()
        {
            return new App();
        }

        protected override IMvxAndroidViewPresenter CreateViewPresenter()
        {
            var fragmentsPresenter = new MvxFragmentsPresenter(AndroidViewAssemblies);
            var presenter = new CustomAndroidPresenter(fragmentsPresenter);
            Mvx.RegisterSingleton<IMvxAndroidViewPresenter>(presenter);

            return presenter;
        }

        protected override IMvxTrace CreateDebugTrace()
        {
            return new DebugTrace();
        }
    }
}
