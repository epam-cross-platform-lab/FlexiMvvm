using Android.App;
using Android.OS;
using FirstScreen.Core.Infrastructure.Data;
using FirstScreen.Core.Presentation.Navigation;
using FirstScreen.Core.Presentation.ViewModels;
using FirstScreen.Droid.Navigation;
using FlexiMvvm.Ioc;
using FlexiMvvm.ViewModels;
using FlexiMvvm.Views;

namespace FirstScreen.Droid.Views
{
    [Activity(
        MainLauncher = true,
        NoHistory = true,
        Theme = "@style/SplashTheme")]
    public class SplashScreenActivity : AppCompatActivity<EntryViewModel>
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            InitApp();

            base.OnCreate(savedInstanceState);
        }

        private void InitApp()
        {
            var container = new SimpleIoc();

            container.Register<IUserProfileRepository>(
                () => new UserProfileRepository());

            container.Register<INavigationService>(
                () => new NavigationService());

            container.Register(
                () => new EntryViewModel(
                    container.Get<INavigationService>()));

            container.Register(
                () => new UserProfileViewModel(
                    container.Get<IUserProfileRepository>()));

            ViewModelProvider.SetFactory(new DependencyProviderViewModelFactory(container));
        }
    }
}
