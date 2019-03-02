using System;
using Android.Content;
using FirstScreen.Core.Presentation.Navigation;
using FirstScreen.Core.Presentation.ViewModels;
using FirstScreen.Droid.Views;
using FlexiMvvm.ViewModels;
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

        public void NavigateToLanguages(UserProfileViewModel from)
        {
            var userProfileActivity = GetActivity<UserProfileActivity, UserProfileViewModel>(from);

            var intent = new Intent(userProfileActivity, typeof(LanguagesActivity));

            var requestCode = new RequestCode();
            userProfileActivity.StartActivityForResult(intent, requestCode.GetFor<SelectedLanguageResult>());
        }

        public void NavigateBack(LanguagesViewModel from, ResultCode resultCode, SelectedLanguageResult result)
        {
            var languagesActivity = GetActivity<LanguagesActivity, LanguagesViewModel>(from);

            var intent = new Intent(languagesActivity, typeof(UserProfileActivity));
            intent.PutResult(result);

            languagesActivity.SetResult(resultCode, intent);
            languagesActivity.Finish();
        }
    }
}
