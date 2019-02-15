using Android.Content;
using FirstScreen.Core.Presentation.Navigation;
using FirstScreen.Core.Presentation.ViewModels;
using FirstScreen.Droid.Views;
using FlexiMvvm.Views;

namespace FirstScreen.Droid.Navigation
{
    public class NavigationService : FlexiMvvm.Navigation.NavigationService, INavigationService
    {
        public void NavigateToUserProfile(EntryViewModel from, UserProfileParameters parameters)
        {
            var splashScreenActivity = GetActivity<SplashScreenActivity, EntryViewModel>(from);
            var intent = new Intent(splashScreenActivity, typeof(UserProfileActivity));
            intent.AddFlags(ActivityFlags.ClearTask | ActivityFlags.ClearTop | ActivityFlags.NewTask);
            intent.PutParameters(parameters);
            splashScreenActivity.StartActivity(intent);
        }
    }
}
