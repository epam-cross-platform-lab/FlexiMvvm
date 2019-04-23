[... Back to CONTENTS](index.md)

---

# Navigation with Parameters

Usually while navigating to a screen, we need to pass some parameters visible by target View Model to run appropriate initialization. iOS and Android have completely different native approaches to do this.
- On iOS we can simply instantiate a new View Controller instance and store needed data in its custom Properties
- On Android things get complicated slightly as navigation from an Activity or settlement a Fragment requires the use of the ``Bundle`` instance.

Let's reuse the previous [Navigation](001-introduction-03-navigation.md) tutorial to pass some parameters onto the User Profile screen.

### Parameters type

We're adding a new custom Parameters type, FirstScreen.Core / Presentation / ViewModels / UserProfileParameters.cs:

```cs
namespace FirstScreen.Core.Presentation.ViewModels
{
    public class UserProfileParameters : FlexiMvvm.ViewModels.Parameters
    {
        public UserProfileParameters(string email)
        {
            Email = email;
        }

        public string Email
        {
            get => Bundle.GetString();
            set => Bundle.SetString(value);
        }
    }
}
```

So it has a single ``Email`` property the target View Model will be interested in to retrieve while initializing. FlexiMvvm's ``Parameters`` base class is used to inherit its capabilities to propagate parameters, as we can see in ``Email``'s setter and getter the ``Bundle`` entry property is used for that. It provides the wide range of methods to get or set values. Internally, the data preserved transparently as a dictionary on iOS, or as a native Bundle on Android.

![Bundle](001-introduction-04-screen-with-parameters/010-bundle.png)

### View Model with Parameters

Having ``UserProfileParameters``, we update ``UserProfileViewModel``:
1. Making it generic
2. Overriding ``InitializeAsync()`` which provides the needed parameters instance.

```cs

using System.Threading.Tasks;
using System.Windows.Input;
using FirstScreen.Core.Infrastructure.Data;
using FlexiMvvm.ViewModels;

namespace FirstScreen.Core.Presentation.ViewModels
{
    public class UserProfileViewModel : ViewModel<UserProfileParameters>
    {

        //// ... some existing code is hidden for convenience

        public override async Task InitializeAsync(UserProfileParameters parameters)
        {
            await base.InitializeAsync(parameters);

            System.Diagnostics.Debug.WriteLine(
                $"Using Parameters... Email = {parameters.Email}");
        }        

        //// ... some existing code is hidden for convenience

    }
}
```

### Navigation

Ok, we have Parameters data type and View Model which is capable to use it. Now we need to adapt the navigation service. Add an additional parameter to the method, to enforce passing the ``UserProfileParameters`` instance:

```cs
using FirstScreen.Core.Presentation.ViewModels;

namespace FirstScreen.Core.Presentation.Navigation
{
    public interface INavigationService
    {
        void NavigateToUserProfile(EntryViewModel from, UserProfileParameters parameters);
    }
}
```

#### Android

There's a slight update on Android ``NavigationService`` to allow a source View Model to pass the Parameters object, FirstScreen.Droid / Navigation / NavigationService.cs:

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
        public void NavigateToUserProfile(EntryViewModel from, UserProfileParameters parameters)
        {
            var splashScreenActivity = GetActivity<SplashScreenActivity, EntryViewModel>(from);

            var intent = new Intent(splashScreenActivity, typeof(UserProfileActivity));
            intent.AddFlags(ActivityFlags.ClearTask | ActivityFlags.ClearTop | ActivityFlags.NewTask);
            intent.PutParameters(parameters);

            splashScreenActivity.StartActivity(intent);
        }
    }
}

```

``PutParameters()`` extention method is used over ``Intent``, to propagate ``UserProfileParameters`` to the target View Model. Also on ``UserProfileActivity`` View the ``UserProfileParameters`` type parameter should be specified:

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
    public class UserProfileActivity : BindableAppCompatActivity<UserProfileViewModel, UserProfileParameters>
    {
        //// ... some existing code is hidden for convenience
    }
}
```

#### iOS

iOS implementation for the new parameter, FirstScreen.iOS / Navigation / NavigationService.cs:

```cs
using System;
using FirstScreen.Core.Presentation.Navigation;
using FirstScreen.Core.Presentation.ViewModels;
using FirstScreen.iOS.Views;

namespace FirstScreen.iOS.Navigation
{
    public class NavigationService : FlexiMvvm.Navigation.NavigationService, INavigationService
    {
        public void NavigateToUserProfile(EntryViewModel from, UserProfileParameters parameters)
        {
            var controller =
                GetViewController<RootNavigationViewController, EntryViewModel>(from);
                
            controller.PushViewController(new UserProfileViewController(parameters), false);
        }
    }
}
```

So the only change is to pass parameters to the target View Controller constructor. To be able to do it, we're updating FirstScreen.iOS / Views / UserProfileViewController.cs:

```cs
using System;
using FirstScreen.Core.Presentation.ViewModels;
using FlexiMvvm.Bindings;
using FlexiMvvm.Views;

namespace FirstScreen.iOS.Views
{
    public class UserProfileViewController : BindableViewController<UserProfileViewModel, UserProfileParameters>
    {
        public UserProfileViewController(UserProfileParameters parameters) : base(parameters)
        {
            Title = "Profile";
        }

        //// ... some existing code is hidden for convenience
    }
}

```

We see here that the second type parameter is used over the generic base class and constructor is added to make the Parameters instance required for ``UserProfileViewController``.

### Last step

Finally, we're tuning our navigation to the User Profile, FirstScreen.Core / Presentation / ViewModels / EntryViewModel.cs:

```cs
using System.Threading.Tasks;
using FirstScreen.Core.Presentation.Navigation;
using FlexiMvvm.ViewModels;

namespace FirstScreen.Core.Presentation.ViewModels
{
    public class EntryViewModel : ViewModel
    {
        //// ... some existing code is hidden for convenience

        public override async Task InitializeAsync()
        {
            await base.InitializeAsync();

            _navigationService.NavigateToUserProfile(this, new UserProfileParameters("example@icloud.com"));
        }
    }
}
```
---

[Next: Navigation for a Result](001-introduction-05-result.md)