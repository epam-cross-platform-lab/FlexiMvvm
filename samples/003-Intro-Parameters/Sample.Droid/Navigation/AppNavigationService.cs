using Android.Content;
using FlexiMvvm.Navigation;
using FlexiMvvm.ViewModels;
using FlexiMvvm.Views;
using Sample.Core.Presentation.Navigation;
using Sample.Core.Presentation.ViewModels;
using Sample.Droid.Views;

namespace Sample.Droid.Navigation
{
    public class AppNavigationService : NavigationService, INavigationService
    {
        public void NavigateToUserProfile(EntryViewModel from)
        {
            var splashActivity = NavigationViewProvider.GetActivity<SplashScreenActivity, EntryViewModel>(from);

            var intent = new Intent(splashActivity, typeof(UserProfileActivity));
            intent.AddFlags(ActivityFlags.ClearTask | ActivityFlags.ClearTop | ActivityFlags.NewTask);
            splashActivity.StartActivity(intent);
        }

        public void NavigateToUserProfile(ILifecycleViewModel from, UserProfileParameters parameters)
        {
            var view = NavigationViewProvider.Get(from);
            Navigate<UserProfileActivity, UserProfileParameters>(view, parameters);

            /* Here's what is approximately done by Navigate() above:

            var source = view.GetActivity();
            var intent = new Intent(source, typeof(UserProfileActivity));
            intent.PutParameters(parameters);
            source.StartActivity(intent);

            */
        }
    }
}
