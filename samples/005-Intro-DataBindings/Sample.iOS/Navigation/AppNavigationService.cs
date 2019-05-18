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

        public void NavigateToLanguages(ILifecycleViewModelWithResultHandler from)
        {
            var view = NavigationViewProvider.Get(from);
            var target = new LanguagesViewController();
            NavigateForResult<LanguagesViewController, SelectedLanguageResult>(view, target, true);

            /* Here's what is done by Navigate() above:

            target.ResultSetWeakSubscribe(view.HandleResult);
            view.GetNavigationController().PushViewController(target, true);

            */
        }

        public void NavigateBack(LanguagesViewModel from, ResultCode code, SelectedLanguageResult? result)
        {
            var view = NavigationViewProvider.Get(from);
            NavigateBack(view, code, result, true);

            /* Here's what is done by Navigate() above:

            view.SetResult(code, result);
            view.GetNavigationController().PopViewController(true);

            */
        }
    }
}
