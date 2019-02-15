using FirstScreen.Core.Infrastructure.Data;
using FirstScreen.Core.Presentation.Navigation;
using FirstScreen.Core.Presentation.ViewModels;
using FirstScreen.iOS.Navigation;
using FirstScreen.iOS.Views;
using FlexiMvvm.Ioc;
using FlexiMvvm.ViewModels;
using Foundation;
using UIKit;

namespace FirstScreen.iOS
{
    [Register("AppDelegate")]
    public class AppDelegate : UIApplicationDelegate
    {
        public override UIWindow Window { get; set; }

        public override bool FinishedLaunching(UIApplication application, NSDictionary launchOptions)
        {
            InitApp();

            Window = new UIWindow(UIScreen.MainScreen.Bounds) { RootViewController = new RootNavigationViewController() };
            Window.MakeKeyAndVisible();

            return true;
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
