using FlexiMvvm.Bootstrappers;
using FlexiMvvm.Ioc;
using Foundation;
using NavigationFlow.Core.Bootstrapper;
using NavigationFlow.iOS.Bootstrapper;
using NavigationFlow.iOS.Views;
using UIKit;

namespace NavigationFlow.iOS
{
    [Register("AppDelegate")]
    public class AppDelegate : UIApplicationDelegate
    {
        public override UIWindow Window
        {
            get;
            set;
        }

        public override bool FinishedLaunching(UIApplication application, NSDictionary launchOptions)
        {
            var config = new BootstrapperConfig();
            config.SetSimpleIoc(new SimpleIoc());

            var compositeBootstrapper = new CompositeBootstrapper(new IosBootstrapper(), new CoreBootstrapper());
            compositeBootstrapper.Execute(config);

            Window = new UIWindow(UIScreen.MainScreen.Bounds)
            {
                RootViewController = new RootNavigationController()
            };

            Window.MakeKeyAndVisible();

            return true;
        }
    }
}
