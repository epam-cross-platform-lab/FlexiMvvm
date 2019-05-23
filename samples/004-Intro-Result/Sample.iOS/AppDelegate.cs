using FlexiMvvm.Ioc;
using FlexiMvvm.ViewModels;
using Foundation;
using Sample.Core.Presentation.Navigation;
using Sample.Core.Presentation.ViewModels;
using Sample.iOS.Navigation;
using Sample.iOS.Views;
using UIKit;

namespace Sample.iOS
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
            container.Register<INavigationService>(() => new AppNavigationService());
            container.Register(() => new EntryViewModel(container.Get<INavigationService>()));
            container.Register(() => new UserProfileViewModel(container.Get<INavigationService>()));
            container.Register(() => new LanguagesViewModel(container.Get<INavigationService>()));

            LifecycleViewModelProvider.SetFactory(
                new DefaultLifecycleViewModelFactory(container));
        }
    }
}
