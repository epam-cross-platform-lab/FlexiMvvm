[... Back to CONTENTS](index.md)

---

# First screen

### New Visual Studio solution

To get started, prepare your Visual Studio solution for the app.
For simplicity, let's assume you have three projects within:

![First Screen solution](images/001-Intro-003-FirstScreen-Solution.png)

- *FirstScreen.Core* for the shared code
	- It's compliant to ``.net standard 2.0`` multiplatform spec:
	![.net standard 2.0](images/001-Intro-004-FirstScreen-NetStandard.png)
- *FirstScreen.Droid* for the Android code
	- It has a reference to the *FirstScreen.Core* project
	- Appropriate target Android SDK is selected. Consider any starting from Android 8.0 (Oreo):
	![Target Android](images/001-Intro-005-FirstScreen-TargetDroid.png)
	- Android versions range is set we're going to support. For our case, we have API Level 21+ support:
	![Android versions](images/001-Intro-006-FirstScreen-DroidApiLevels.png)
- *FirstScreen.iOS* for the iOS platform code
	- It has a reference to the *FirstScreen.Core* project
	- Info.plist file has selected Deployment Target. For instance, iOS 11+:
	![iOS versions](images/001-Intro-007-FirstScreen-TargetiOS.png)

> It's recommended to use "Droid" suffix for your Android project, instead of "Android" to make life a bit easier for IDE to distinguish our versus Xamarin SDK namespaces

Our sample app is going to show just a single screen on start, with a basic Profile form where user can provide the information via text entry fields and save it:
- First Name
- Last Name
- Email

### Adding NuGet Packages

| Project | Package |
| --- | --- |
| *FirstScreen.Core* | **FlexiMvvm.Lifecycle**
| *FirstScreen.Droid* | **FlexiMvvm.FullStack**
| *FirstScreen.iOS* | **FlexiMvvm.FullStack**

> On the time of documentation, FlexiMvvm was in the Preview mode, with "PreRelease" suffixes. Also showing Preview packages option was required to be enabled for NuGet Manager.

### View Models

Having all needed external dependencies added, we may try to build the solution and proceed to implementing some core stuff.
Let's create a View Model class for our Profile form, *FirstScreen.Core* / Presentation / ViewModels:

```cs
using System.Windows.Input;
using FlexiMvvm.ViewModels;

namespace FirstScreen.Core.Presentation.ViewModels
{
    public class UserProfileViewModel : ViewModel
    {
        private string _firstName;
        private string _lastName;
        private string _email;
        
        public string FirstName
        {
            get => _firstName;
            set => SetValue(ref _firstName, value);
        }

        public string LastName
        {
            get => _lastName;
            set => SetValue(ref _lastName, value);
        }

        public string Email
        {
            get => _email;
            set => SetValue(ref _email, value);
        }

        public ICommand SaveCommand => CommandProvider.Get(Save);

        private void Save()
        {
            System.Diagnostics.Debug.WriteLine(
                $"Saved: {FirstName} {LastName}, {Email}.");
        }
    }
}
```

So, ``FirstName``, ``LastName``, ``Email`` string Data Properties are defined to observe values entered by user.

We see here ``ViewModel`` used as the base class.
This is the FlexiMvvm's cross-platform entry to the proper lifecycle and UI changes observation mechanisms. ``ViewModel`` must be used as a root of the hierarchy of our View Models.

To recap, when adopting MVVM we create View Models which implement standard ``INotifyPropertyChanged`` interface. In our sample above,
base ``ViewModel`` type provided by FlexiMvvm is used, therefore child View Model inherits the appropriate ``INotifyPropertyChanged`` implementation. Just to engage it, we have added ``SetValue()`` methods in the Data Properties' setters - the ``PropertyChanged`` event will be invoked automatically when needed, bringing Data Bindings to life.

Also ``SaveCommand`` is added and used to call the ``Save()`` method when the user taps such button on the screen.
As we will see later, such ``ICommand`` driven handlers is a widely used approach across .net apps development introducing some extra advantages along with Data Bindings. Use of Commands is considered as a **recommended** way of user events handling.
To simplify the code, FlexiMvvm provides useful ``CommandProvider`` to setup Commands in different ways. Later we will review it in details.

### Initialization at the minimum

In the tutorial we have no specific application initialization procedure, the only thing FlexiMvvm should know about is which View Models we're going to use through the app. So we need to register our newly coded ``UserProfileViewModel`` and show how to instantiate it. 
For that, FlexiMvvm introduces ``Bootstrappers``: types which are capable to initialize their related module. In our case we have 3 such modules: *Core*, *iOS App* and *Android App*. Each of them should have own bootstrapper.

For the tutorial's purposes it's enough to add a bootstrapper for *Core* only. Let's add a new type, *FirstScreen.Core* / Bootstrappers:
```cs
using FirstScreen.Core.Presentation.ViewModels;
using FlexiMvvm.Bootstrappers;
using FlexiMvvm.Ioc;
using FlexiMvvm.ViewModels;

namespace FirstScreen.Core.Bootstrappers
{
    public class CoreBootstrapper : IBootstrapper
    {
        public void Execute(BootstrapperConfig config)
        {
            var container = new SimpleIoc();
            container.Register(() => new UserProfileViewModel());

            ViewModelProvider.SetFactory(new DependencyProviderViewModelFactory(container));
        }
    }
}

```

This type implements the single ``IBootstrapper``'s ``Execute()`` method, ignoring its ``config`` parameter for now - Configuration part as well as more sophisticated and real life ready bootstrapping approach will be revisited in details later.

``SimpleIoc`` is available as an out-of-the-box Inversion of Control (IoC) container, to hold dependencies and provide their instances on demand. **No Reflection** is used by FlexiMvvm to automate dependencies resolution. All the instantiation logic is provided by us explicitly via the ``Register()`` method. For now we have just a single registration entry, our ``UserProfileViewModel``.

> On mobile, performance and application start time specifically are pretty critial qualities. ``SimpleIoc`` is good on that. It's recommended though not mandatory - any container may be involved instead.

Then we use ``ViewModelProvider`` which is central for View Models provisioning and leverage existing factory passed in, ``DependencyProviderViewModelFactory``. It gets our container ready with the registered View Model.

The only thing is left is to call this Bootstrapper when the app is loading, let's go ahead and create some iOS and Android things.

### Views

TBD


### Lifecycle

TBD

---

[Next: Second Screen with Parameters...](001-introduction-03-second-screen-with-parameters.md)