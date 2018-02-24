using System.Collections.Generic;
using MvvmCross.Core.ViewModels;

namespace SZWMar2018.Core.Custom
{
    public class MvxViewModelWithNoBackStackNavigation : MvxViewModel
    {
        protected void ShowViewModelAndClearBackStack<TViewModel>()
            where TViewModel : MvxViewModel
        {
            var presentationBundle = new MvxBundle(
                new Dictionary<string, string>
                {
                    {
                        "ClearBackStack", ""
                    }
                });
            ShowViewModel<TViewModel>(presentationBundle: presentationBundle);
        }
    }
}
