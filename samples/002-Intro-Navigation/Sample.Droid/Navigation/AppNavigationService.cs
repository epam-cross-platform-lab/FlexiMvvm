using Android.Content;
using FlexiMvvm.Navigation;
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
    }
}
