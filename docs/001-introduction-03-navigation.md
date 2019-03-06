[... Back to CONTENTS](index.md)

---

# Basic Navigation

Navigation is View Model driven. At the same time, FlexiMvvm **encourages to use native APIs for navigation**. For that, the following approach is suggested:

1. ``INavigationService`` contract is defined in shared code;
2. iOS and Android ``NavigationService`` implementations provide suitable native behavior.
3. View Models use ``INavigationService`` dependency for initiating navigation.

For our previous [First Screen](001-introduction-02-first-screen.md) tutorial, let's introduce some basic navigation: when applications completes its loading, it navigates to our User Profile screen.

### Shared Contract

Let's start with the interface. It defines the contract which may be used across the app when moving through screens (or to a subview on the screen, if needed). So, the interface is placed into the **Core** project, FirstScreen.Core / Presentation / Navigation / INavigationService.cs:

```cs
using FirstScreen.Core.Presentation.ViewModels;

namespace FirstScreen.Core.Presentation.Navigation
{
    public interface INavigationService
    {
        void NavigateToUserProfile(EntryViewModel from);
    }
}
```

Immediately we notice here ``EntryViewModel`` parameter. It's a new View Model we will add below which is the very first View Model app uses when loads.

> Providing "from" View Model parameter is needed for FlexiMvvm, to properly resolve the underlying View to perform the navigation.

### EntryViewModel

To start some navigation, we need a source View Model. Let's add one, FirstScreen.Core / Presentation / ViewModels / EntryViewModel.cs:

```cs
using System.Threading.Tasks;
using FirstScreen.Core.Presentation.Navigation;
using FlexiMvvm.ViewModels;

namespace FirstScreen.Core.Presentation.ViewModels
{
    public class EntryViewModel : ViewModel
    {
        private INavigationService _navigationService;

        public EntryViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
        }

        public override async Task InitializeAsync()
        {
            await base.InitializeAsync();

            _navigationService.NavigateToUserProfile(this);
        }
    }
}
```

We see ``EntryViewModel`` receives ``INavigationService`` as the dependency and therefore is able to perform the ``NavigateToUserProfile()`` navigation.

### Platforms

#### Android

##### NavigationService

Starting from Android, we're adding new ``NavigationService`` which engages standard Android's ``Intent`` for transitioning to an ``Activity`` or settlement of a ``Fragment`` on the screen. In our case it's just a simple Actvity-to-Activity switch:

```cs
using Android.Content;
using FlexiMvvm.Views;
using FirstScreen.Core.Presentation.Navigation;
using FirstScreen.Core.Presentation.ViewModels;
using FirstScreen.Droid.Views;

namespace FirstScreen.Droid.Navigation
{
    public class NavigationService : FlexiMvvm.Navigation.NavigationService, INavigationService
    {
        public void NavigateToUserProfile(EntryViewModel from)
        {
            var splashScreenActivity = GetActivity<SplashScreenActivity, EntryViewModel>(from);
            var intent = new Intent(splashScreenActivity, typeof(UserProfileActivity));
            intent.AddFlags(ActivityFlags.ClearTask | ActivityFlags.ClearTop | ActivityFlags.NewTask);
            splashScreenActivity.StartActivity(intent);
        }
    }
}

```

We see here base ``GetActivity()`` method which is capable to resolve current View context by the View Model provided, ``EntryViewModel``. And following lines are typical for Xamarin.Android app when switching from one Activity to another. Due to the first one is the splash screen and we do not want to keep it on Backstack, appropriate flags were added into ``Intent``.

After that we need to add & update our ``Activities``.

##### UserProfileActivity

Compared to the previous [First screen](001-introduction-02-first-screen.md) tutorial, we need to remove ``InitApp()`` method as this ``Activity`` is not starting one anymore. Also no need to keep it as ``MainLauncher``. As before, this View is "linked" with ``UserProfileViewModel``:

```cs
using Android.App;
using Android.OS;
using Android.Widget;
using FirstScreen.Core.Presentation.ViewModels;
using FlexiMvvm.Bindings;
using FlexiMvvm.Views;

namespace FirstScreen.Droid.Views
{
    [Activity(Theme = "@style/AppTheme")]
    public class UserProfileActivity : BindableAppCompatActivity<UserProfileViewModel>
    {
        //// ... some existing code is hidden for convenience

        protected override void OnCreate(Bundle savedInstanceState)
        {
            SetContentView(Resource.Layout.Main);

            _firstName = FindViewById<EditText>(Resource.Id.firstName);
            _lastName = FindViewById<EditText>(Resource.Id.lastName);
            _email = FindViewById<EditText>(Resource.Id.email);
            _save = FindViewById<Button>(Resource.Id.save);

            base.OnCreate(savedInstanceState);
        }

        //// ... some existing code is hidden for convenience
    }
}
```

##### SplashScreenActivity

This is a new one, connected with ``EntryViewModel``, as a starting entry for the Android app, FirstScreen.Droid / Views / SplashScreenActivity.cs:

```cs
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

            container.Register<INavigationService>(
                () => new NavigationService());

            container.Register(
                () => new EntryViewModel(
                    container.Get<INavigationService>()));

            container.Register(
                () => new UserProfileViewModel());

            ViewModelProvider.SetFactory(new DependencyProviderViewModelFactory(container));
        }
    }
}
```

``InitApp()`` is moved here. Also it has got two new registrations on ``SimpleIoc``, for ``NavigationService`` and ``EntryViewModel`` entries.

#### iOS

##### NavigationService

Here is the iOS implementation, FirstScreen.iOS / Navigation / NavigationService.cs

```cs
using System;
using FirstScreen.Core.Presentation.Navigation;
using FirstScreen.Core.Presentation.ViewModels;
using FirstScreen.iOS.Views;

namespace FirstScreen.iOS.Navigation
{
    public class NavigationService : FlexiMvvm.Navigation.NavigationService, INavigationService
    {
        public void NavigateToUserProfile(EntryViewModel from)
        {
            var controller = GetViewController<RootNavigationViewController, EntryViewModel>(from);
            controller.PushViewController(new UserProfileViewController(), false);
        }
    }
}
```

It inherits base features and also implements our ``INavigationService`` defined above. ``GetViewController`` from the base class allows to resolve appropriate View Controller for the source View Model, ``EntryViewModel``. Then iOS native capabilities are used: ``RootNavigationViewController`` which is shown below, pushes our ``UserProfileViewController`` onto iOS navigation stack.

##### Root ViewController

FirstScreen.iOS / Views / RootNavigationViewController.cs:

```cs
using FirstScreen.Core.Presentation.ViewModels;
using FlexiMvvm.Views;

namespace FirstScreen.iOS.Views
{
    public class RootNavigationViewController : NavigationController<EntryViewModel>
    {
    }
}
```

As we can see, ``RootNavigationViewController`` uses ``EntryViewModel`` behind.

##### App Delegate

``RootNavigationViewController`` plays the important role to receive the control when iOS app starts. As usual, we specify it in FirstScreen.iOS / AppDelegate.cs, as a ``RootViewController`` for ``UIWindow``. But also as we have got ``NavigationService`` which has to be provided for ``EntryViewModel``, we use out-of-the-box ``SimpleIoc`` container to register this service as well:

```cs
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

            Window = new UIWindow(UIScreen.MainScreen.Bounds)
            {
                RootViewController = new RootNavigationViewController()
            };

            Window.MakeKeyAndVisible();

            return true;
        }

        private void InitApp()
        {
            var container = new SimpleIoc();

            container.Register<INavigationService>(
                () => new NavigationService());

            container.Register(
                () => new EntryViewModel(
                    container.Get<INavigationService>()));

            container.Register(
                () => new UserProfileViewModel());

            ViewModelProvider.SetFactory(new DependencyProviderViewModelFactory(container));
        }
    }
}
```

---

[Next: Navigation with Parameters...](001-introduction-04-screen-with-parameters.md)