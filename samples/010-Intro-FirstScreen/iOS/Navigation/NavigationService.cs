using System;
using FirstScreen.Core.Presentation.Navigation;
using FirstScreen.Core.Presentation.ViewModels;
using FirstScreen.iOS.Views;
using FlexiMvvm.ViewModels;
using FlexiMvvm.Views;

namespace FirstScreen.iOS.Navigation
{
    public class NavigationService : FlexiMvvm.Navigation.NavigationService, INavigationService
    {
        public void NavigateToUserProfile(EntryViewModel from, UserProfileParameters parameters)
        {
            var controller = GetViewController<RootNavigationViewController, EntryViewModel>(from);

            controller
                .GetNavigationController()
                .PushViewController(new UserProfileViewController(parameters), animated: false);
        }

        public void NavigateToLanguages(UserProfileViewModel from)
        {
            var controller = GetViewController<UserProfileViewController, UserProfileViewModel>(from);

            var targetController = new LanguagesViewController();
            targetController.ResultSetWeakSubscribe(controller.HandleResult);

            controller
                .GetNavigationController()
                .PushViewController(targetController, animated: true);
        }

        public void NavigateBack(LanguagesViewModel from, ResultCode code, SelectedLanguageResult result)
        {
            var controller = GetViewController<LanguagesViewController, LanguagesViewModel>(from);

            controller.SetResult(code, result);

            controller
                .GetNavigationController()
                .PopViewController(animated: true);
        }
    }
}
