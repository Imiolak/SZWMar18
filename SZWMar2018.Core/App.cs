using MvvmCross.Core.ViewModels;
using MvvmCross.Platform;
using MvvmCross.Platform.IoC;
using SZWMar2018.Core.Custom;

namespace SZWMar2018.Core
{
    public class App : MvxApplication
    {
        public override void Initialize()
        {
            CreatableTypes()
                .EndingWith("Service")
                .AsInterfaces()
                .RegisterAsLazySingleton();           
            
            RegisterAppStart(Mvx.IocConstruct<CustomAppStart>());
        }
    }
}
