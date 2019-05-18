using Android.App;
using Android.OS;
using FlexiMvvm.Ioc;
using FlexiMvvm.ViewModels;
using FlexiMvvm.Views;
using Sample.Core.Presentation.Navigation;
using Sample.Core.Presentation.ViewModels;
using Sample.Droid.Navigation;

namespace Sample.Droid.Views
{
    [Activity(
        MainLauncher = true,
        NoHistory = true,
        Theme = "@style/AppTheme.Splash")]
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
            container.Register<INavigationService>(() => new AppNavigationService());
            container.Register(() => new EntryViewModel(container.Get<INavigationService>()));
            container.Register(() => new UserProfileViewModel(container.Get<INavigationService>()));
            container.Register(() => new LanguagesViewModel(container.Get<INavigationService>()));

            LifecycleViewModelProvider.SetFactory(
                new DefaultLifecycleViewModelFactory(container));
        }
    }
}
