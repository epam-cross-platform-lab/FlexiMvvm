using System;
using FlexiMvvm.Navigation;
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
    }
}
