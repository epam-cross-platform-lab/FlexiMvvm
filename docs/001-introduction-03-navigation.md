[... Back to CONTENTS](index.md)

---

# Complete sample

Whole sample code is [available in the repository](https://github.com/epam-xamarin-lab/FlexiMvvm/tree/master/samples/002-Intro-Navigation/).

# Basic Navigation

Navigation is **View Model driven**.
At the same time, FlexiMvvm **encourages to use native APIs for navigation**.
From many applications developed, we believe this is one of the major factors to deliver native look and feel for mobile users.
For that, the following approach is suggested:

1. ``INavigationService`` contract is defined in shared code;
2. iOS and Android ``AppNavigationService`` implementations provide suitable native behavior, having full power of Android ``Intent``s or iOS ``UINavigationController``.
3. View Models use ``INavigationService`` dependency for initiating navigation.

Starting with our previous [First Screen](001-introduction-02-first-screen.md) tutorial, let's introduce some basic navigation: when applications completes its loading, it navigates to the User Profile screen we've built before.

### Navigation Contract

Let's start with the interface. It defines the contract which may be used across the app when moving through screens (or to a subview on the screen, if needed). So, the interface is placed into the **Core** project, Sample.Core / Presentation / Navigation / INavigationService.cs:

```cs
using Sample.Core.Presentation.ViewModels;

namespace Sample.Core.Navigation
{
    public interface INavigationService
    {
        void NavigateToUserProfile(EntryViewModel from);
    }
}

```

Immediately we notice here ``EntryViewModel`` parameter. It's a new View Model we will add below which is the very first View Model app uses when loads. So we're going to trigger the navigation to our User Profile screen from a splash screen - when the application is ready.

> Providing the "from" View Model parameter is needed by FlexiMvvm, to properly resolve the associated source View (UIViewController on iOS, Android/Fragment on Android) to perform the navigation.

### EntryViewModel

To start some navigation, we need a source View Model. Let's add one, Sample.Core / Presentation / ViewModels / EntryViewModel.cs:

```cs
using FlexiMvvm.ViewModels;
using Sample.Core.Presentation.Navigation;

namespace Sample.Core.Presentation.ViewModels
{
    public class EntryViewModel : LifecycleViewModel
    {
        private INavigationService _navigationService;

        public EntryViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
        }

        public override void Initialize(bool recreated)
        {
            base.Initialize(recreated);

            _navigationService.NavigateToUserProfile(this);
        }
    }
}

```

We see ``EntryViewModel`` receives ``INavigationService`` as the dependency and therefore is able to perform the ``NavigateToUserProfile()`` navigation.

### Platforms

#### Android

##### UserProfileActivity

Compared to the previous [First screen](001-introduction-02-first-screen.md) tutorial, firstly let's update our ``MainActivity`` and move it to Sample.Droid / Views / ``UserProfileActivity.cs``.
We need to remove ``InitApp()`` method as this ``Activity`` does not initialize the application any more.
As before, this View is "linked" with ``UserProfileViewModel``:

```cs
using Android.App;
using Android.OS;
using Android.Views;
using Android.Widget;
using FlexiMvvm;
using FlexiMvvm.Bindings;
using FlexiMvvm.Ioc;
using FlexiMvvm.ViewModels;
using FlexiMvvm.Views;
using Sample.Core.Presentation.ViewModels;

namespace Sample.Droid.Views
{
    [Activity(Theme = "@style/AppTheme.NoActionBar")]
    public class UserProfileActivity : BindableAppCompatActivity<UserProfileViewModel>
    {
        //// ... some existing code is hidden for convenience

        protected override void OnCreate(Bundle savedInstanceState)
        {
            //// No InitApp() here anymore

            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.activity_main);
            SetSupportActionBar(FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.toolbar));

            _firstName = FindViewById<EditText>(Resource.Id.firstName);
            _lastName = FindViewById<EditText>(Resource.Id.lastName);
            _email = FindViewById<EditText>(Resource.Id.email);
            _save = FindViewById<Button>(Resource.Id.save);
        }

        //// ... some existing code is hidden for convenience
    }
}

```

##### SplashScreenActivity

This is a new one, connected with ``EntryViewModel``, as a starting entry for the Android app, Sample.Droid / Views / SplashScreenActivity.cs:

```cs
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
            container.Register(() => new UserProfileViewModel());

            LifecycleViewModelProvider.SetFactory(
                new DefaultLifecycleViewModelFactory(container));
        }
    }
}

```

``InitApp()`` is moved here. Also it has got two new registrations for ``SimpleIoc``, ``AppNavigationService`` and ``EntryViewModel`` entries.

##### Android Navigation Service

For now we have prepared both source and target Activities we're going to navigate from and to.
Let's add a new ``AppNavigationService`` which engages Android specific ``Intent``-based transitioning to an ``Activity``:

```cs
using Android.Content;
using FlexiMvvm.Navigation;
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
    }
}

```

> Starting from 0.10.7, FlexiMvvm changed Navigation APIs, requiring ``ILifecycleViewModel`` source View Models for navigation initiation. Also to retrieve an instance of a source ``Activity`` or ``Fragment``, ``NavigationViewProvider`` static class should be used as shown above.

#### iOS

##### Root NavigationController

On iOS things a bit easier - no need to build a new splash screen specific View as on Android. We will need to involve standard iOS UINavigationController as a new root ViewController, to enabled application-wide navigation. Let's see the new Sample.iOS / Views / RootNavigationViewController.cs:

```cs
using FlexiMvvm.Views;
using Sample.Core.Presentation.ViewModels;

namespace Sample.iOS.Views
{
    public class RootNavigationViewController : NavigationController<EntryViewModel>
    {
    }
}

```

It leverages the FlexiMvvm base ``NavigationController`` which actually inherit from iOS UINavigationController and allows to associate it with our ``EntryViewModel`` - this will allow to drive the View Model based navigation as we will see in the ``AppNavigationService`` below.

##### App Delegate

``RootNavigationViewController`` plays the important role to receive the control when iOS app starts. As usual, we specify it in AppDelegate.cs, as a ``RootViewController`` for ``UIWindow``.

```cs
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
            container.Register(() => new UserProfileViewModel());

            LifecycleViewModelProvider.SetFactory(
                new DefaultLifecycleViewModelFactory(container));
        }
    }
}

```

Also ``InitApp()`` has became the same as on Android, registering new platform-specific ``AppNavigationService`` and ``EntryViewModel``.

##### iOS Navigation Service

The only missing thing is left is this ``AppNavigationService``. Here is the implementation, Sample.iOS / Navigation / AppNavigationService.cs

```cs
using System;
using FlexiMvvm.Navigation;
using Sample.Core.Presentation.Navigation;
using Sample.Core.Presentation.ViewModels;
using Sample.iOS.Views;

namespace Sample.iOS.Navigation
{
    public class AppNavigationService : NavigationService, INavigationService
    {
        public void NavigateToUserProfile(EntryViewModel from)
        {
            var controller = NavigationViewProvider.GetViewController<RootNavigationViewController, EntryViewModel>(from);
            controller.PushViewController(new UserProfileViewController(), false);
        }
    }
}

```

As we can see this service allows to perform View Model based navigation via the RootViewController created before. 
It inherits base features and also implements our ``INavigationService`` to go to the User Profile screen, the similar way as on Android but with iOS specifics.

---

[Next: Navigation with Parameters...](001-introduction-04-screen-with-parameters.md)