using System;
using FlexiMvvm.Navigation;
using FlexiMvvm.ViewModels;
using Sample.Core.Presentation.Navigation;
using Sample.Core.Presentation.ViewModels;
using Sample.iOS.Views;

namespace Sample.iOS.Navigation
{
    public class AppNavigationService : NavigationService, INavigationService
    {
        public void NavigateToUserProfile(EntryViewModel from)
        {
            var controller = NavigationViewProvider.GetViewController<RootNavigationViewController, EntryViewModel>(from);
            controller.PushViewController(new UserProfileViewController(), false);
        }

        public void NavigateToUserProfile(ILifecycleViewModel from, UserProfileParameters parameters)
        {
            var view = NavigationViewProvider.Get(from);
            var target = new UserProfileViewController();
            Navigate(view, target, parameters, false);

            /* Here's what is done by Navigate() above:

            target.SetParameters(parameters);
            view.GetNavigationController().PushViewController(target, false);

            */
        }
    }
}
