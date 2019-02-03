[... Back to CONTENTS](index.md)

---
---
---

# First screen

### New Visual Studio solution

To get started, prepare your Visual Studio solution for the app.
For simplicity, let's assume you have three projects within:

![First Screen solution](images/001-Intro-003-FirstScreen-Solution.png)

- *FirstScreen.Core* for shared platform-agnostic code
	- Ensure, it complies to ``.net standard 2.0 +`` multiplatform spec:
	![.net standard 2.0](images/001-Intro-004-FirstScreen-NetStandard.png)
- *FirstScreen.Droid* for Android code
	- A project reference is added to *FirstScreen.Core*
	- Check that latest target Android SDK is selected:
	![Target Android](images/001-Intro-005-FirstScreen-TargetDroid.png)
	- Also set the Android versions range you're going to support. For instance, let's choose 3 recent API levels for our case:
	![Android versions](images/001-Intro-006-FirstScreen-DroidApiLevels.png)
- *FirstScreen.iOS* for iOS platform code
	- A project reference is added to *FirstScreen.Core*
	- Check your Deployment Target in Info.plist, selecting iOS versions range. For instance, we target iOS 11+:
	![iOS versions](images/001-Intro-007-FirstScreen-TargetiOS.png)

> It's recommended to use "Droid" suffix for your Android project, instead of "Android" to make life a bit easier for IDE to distinguish our versus Xamarin SDK namespaces

Our sample app with show just a single screen on start, with a basic Profile form where user can provide First Name, Last Name, Email via Text entry fields and save the information.

### Adding NuGet Packages

1. To *FirstScreen.Core*: **FlexiMvvm.Lifecycle**
2. To *FirstScreen.Droid* and *FirstScreen.iOS*: **FlexiMvvm.FullStack**

> On the time of documentation, FlexiMvvm was in the Preview mode, with "PreRelease" suffixes. Showing Preview packages option was required to be enabled for NuGet Manager.

These packages bring all required dependencies, other FlexiMvvm packages as well as external:
- Android project has **Xamarin.Android.Arch...** and **Xamarin.Android.Support** dependencies now
- iOS project has got **Cirrious.FluentLayout** which is explained a bit later when UI layout development is described

### View Models

Let's create the first View Model for our Profile form: *FirstScreen.Core* / Presentation / ViewModels:

```cs
using System.Windows.Input;
using FlexiMvvm;

namespace FirstScreen.Core.Presentation.ViewModels
{
	public class UserProfileViewModel : ViewModelBase
	{
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string Email { get; set; }

		public ICommand SaveCommand => CommandProvider.Get(Save)

		private void Save()
		{
			System.Debug.WriteLine($"Saved: {FirstName} {LastName}, {Email}.");
		}
	}
}
```

So, ``FirstName``, ``LastName``, ``Email`` string data properties are defined to observe values entered by user.
Also ``SaveCommand`` is added and used to call the ``Save()`` method when the user taps such button on the screen.
As we will see later, such ``ICommand`` driven handlers is a widely used approach across .net apps development.
It helps to relay UI (platform) actions triggering suitable handlers (cross-platform). Moreover, this technic can enable or disable executing of the Command, based on the state owned by the View Model.

We see here ``ViewModelBase`` used as the base class.
This is the FlexiMvvm's cross-platform entry to the proper lifecycle and UI changes observation mechanisms. ``ViewModelBase`` is used as a root base class of the hierarchy of our View Models.

> As you probably noticed in the sample above, our ``UserProfileViewModel`` does not implement ``INotifyPropertyChanged`` interface to enable data properties changes triggering. But actually it does. Inheriting from ``ViewModelBase``, brings base ``INotifyPropertyChanged`` implementation.

> TBD: Fody

### Initialization

Having all external dependencies added, we may try to build the solution and proceed to implementing app initialization steps.
In a minimalistic scenario when we have no specific initialization procedure, either shared or platform, the only thing FlexiMvvm should know about, is which View Models we're going to use.

### Lifecycle

TBD

### Views

TBD

### Handling user input with Commands

TBD

---

[Next: Second Screen with Parameters...](001-introduction-03-second-screen-with-parameters.md)