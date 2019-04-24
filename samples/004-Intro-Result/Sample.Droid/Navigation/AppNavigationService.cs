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

        public void NavigateToLanguages(ILifecycleViewModelWithResultHandler from)
        {
            var view = NavigationViewProvider.Get(from);
            NavigateForResult<LanguagesActivity, SelectedLanguageResult>(view);

            /* Here's what is approximately done by Navigate() above:

            var source = view.GetActivity();
            var code = view.RequestCode.GetFor<DefaultResultMapper<SelectedLanguageResult>>();
            var intent = new Intent(source, typeof(LanguagesActivity));
            source.StartActivityForResult(intent, code);

            */
        }

        public void NavigateBack(LanguagesViewModel from, ResultCode code, SelectedLanguageResult result)
        {
            var view = NavigationViewProvider.Get(from);
            NavigateBack(view, code, result);

            /* Here's what is approximately done by Navigate() above:

            var source = view.GetActivity();
            var intent = new Intent(source, typeof(UserProfileActivity));
            intent.PutResult(result);
            source.SetResult(code, intent);
            source.Finish();

            */
        }
    }
}
