using FirstScreen.Core.Presentation.ViewModels;
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

            Window = new UIWindow(UIScreen.MainScreen.Bounds) { RootViewController = new UserProfileViewController() };
            Window.MakeKeyAndVisible();

            return true;
        }

        private void InitApp()
        {
            var container = new SimpleIoc();
            container.Register(() => new UserProfileViewModel());

            LifecycleViewModelProvider.SetFactory(
                new DefaultLifecycleViewModelFactory(container));
        }
    }
}
