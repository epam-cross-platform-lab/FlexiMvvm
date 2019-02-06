[... Back to CONTENTS](index.md)

---

# First screen

### New Visual Studio solution

To get started, prepare your Visual Studio solution for the app.
For simplicity, let's assume you have three projects within:

![First Screen solution](images/001-Intro-003-FirstScreen-Solution.png)

- **FirstScreen.Core** for the shared code
	- It's compliant to ``.net standard 2.0`` multiplatform spec:
	![.net standard 2.0](images/001-Intro-004-FirstScreen-NetStandard.png)
- **FirstScreen.Droid** for the Android code
	- It has a reference to the FirstScreen.Core project
	- Appropriate target Android SDK is selected. Consider any starting **from Android 8.0 (Oreo)**:
	![Target Android](images/001-Intro-005-FirstScreen-TargetDroid.png)
	- Android versions range is set we're going to support. For our case, we have API Level 21+ support, though API Level 19+ (Android 4.4 (KitKat)) may be supported
	![Android versions](images/001-Intro-006-FirstScreen-DroidApiLevels.png)
- **FirstScreen.iOS** for the iOS platform code
	- It has a reference to the FirstScreen.Core project
	- Info.plist file has selected Deployment Target. For instance, iOS 11+:
	![iOS versions](images/001-Intro-007-FirstScreen-TargetiOS.png)

> It's recommended to use **"Droid"** suffix for your Android project, instead of "Android" to make life a bit easier for IDE to distinguish our versus Xamarin SDK namespaces

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

> On the time of documentation, FlexiMvvm was in the Preview mode, with **"PreRelease"** suffixes. Also showing Preview packages option was required to be enabled for NuGet Manager.

### View Models

Having all needed external dependencies added, we may try to build the solution and proceed to implementing some core stuff.
Let's create a View Model class for our Profile form, FirstScreen.Core / Presentation / ViewModels:

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

### Views

#### Android

Starting with Android, let's scaffold a minimal app with a single Activity. The following points are quite regular for any Xamarin.Android app and just summarised:

1. FirstScreen.Droid / Resources / layout / Main.axml: UI layout for the sample Activity. Just ``TextViews``, ``EditText`` and ``Button`` controls withing ``LinearLayout``s.
2. FirstScreen.Droid / Resources / values / styles.xml: Theme setup
3. FirstScreen.Droid / Resources / values / styles.xml: Colors definitions
4. FirstScreen.Droid / Resources / values / strings.xml: string resources

Finally, we approached the Activity which needs FlexiMvvm specific customizations. FirstScreen.Droid / Views / ``UserProfileActivity``. Here is its full definition:

```cs
using Android.App;
using Android.OS;
using Android.Widget;
using FirstScreen.Core.Presentation.ViewModels;
using FlexiMvvm.Bindings;
using FlexiMvvm.Ioc;
using FlexiMvvm.ViewModels;
using FlexiMvvm.Views;

namespace FirstScreen.Droid.Views
{
    [Activity(MainLauncher = true, NoHistory = true, Theme = "@style/AppTheme")]
    public class UserProfileActivity : BindableAppCompatActivity<UserProfileViewModel>
    {
        private EditText _firstName;
        private EditText _lastName;
        private EditText _email;
        private Button _save;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            Init();

            SetContentView(Resource.Layout.Main);

            _firstName = FindViewById<EditText>(Resource.Id.firstName);
            _lastName = FindViewById<EditText>(Resource.Id.lastName);
            _email = FindViewById<EditText>(Resource.Id.email);
            _save = FindViewById<Button>(Resource.Id.save);

            base.OnCreate(savedInstanceState);
        }

        public override void Bind(BindingSet<UserProfileViewModel> bindingSet)
        {
            base.Bind(bindingSet);

            bindingSet.Bind(_firstName)
                .For(v => v.TextAndTextChangedBinding())
                .To(vm => vm.FirstName);

            bindingSet.Bind(_lastName)
                .For(v => v.TextAndTextChangedBinding())
                .To(vm => vm.LastName);

            bindingSet.Bind(_email)
                .For(v => v.TextAndTextChangedBinding())
                .To(vm => vm.Email);

            bindingSet.Bind(_save)
              .For(v => v.ClickBinding())
              .To(vm => vm.SaveCommand);
        }

        private void Init()
        {
            var container = new SimpleIoc();
            container.Register(() => new UserProfileViewModel());

            ViewModelProvider.SetFactory(new DependencyProviderViewModelFactory(container));
        }
    }
}
```

We see this ``UserProfileActivity`` has uncommon base class, FlexiMvvm's ``BindableAppCompatActivity`` which has got our View Model as the type parameter. Doing this, we indirectly link our View with its View Model. And by overriding ``Bind()`` method, we are able to define all required Data Bindings between the User Interface and the observable Data.

> Later a better way will be demostrated with code-generated ``ViewHolder``s, without the need to inflate each user control and preserve in a private field.

FlexiMvvm provides a wide range of default Data Bindings to iOS and Android standard controls. Custom Data Binding is possible as well.

And another major part here is the ``Init()`` method which is placed in Activity for simplicity. ``SimpleIoc`` is available as an out-of-the-box Inversion of Control (IoC) container, to hold dependencies and provide their instances on demand. For now we have just a single registration entry, our ``UserProfileViewModel``.

> On mobile, performance and application start time specifically are pretty critial qualities. ``SimpleIoc`` is good on that. **No Reflection** is used by ``SimpleIoc`` to automate dependencies resolution but all the instantiation logic is provided by us explicitly via the ``Register()`` method. It's recommended though not mandatory - any container may be involved instead.

Then we use ``ViewModelProvider`` which is central for View Model instance provisioning and leverage the existing factory passed in, ``DependencyProviderViewModelFactory``. The latter gets our container (and uses it internally) with the registered View Model.

#### iOS

TBD

### Data Bindings in action

Just to demonstrate that Data Bindings work two-way, from source View Model and back from target View, let's initialize Data Properties with some values and let Data Bindings to propagate changes onto UI.

For that, each ``ViewModel`` inheritor has ``InitializeAsync()`` and ``Initialize()`` methods.

TBD

---

[Next: Second Screen with Parameters...](001-introduction-03-second-screen-with-parameters.md)