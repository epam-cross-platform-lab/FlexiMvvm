[... Back to CONTENTS](index.md)

---
---
---

# First screen

### New Visual Studio solution

To get started, prepare your Visual Studio solution for the app.
For simplicity, let's assume you have three projects within:

![First Screen solution](images/001-Intro-003-FirstScreen-Solution.png)

- *FirstScreen.Core* for the shared code
	- It has to be compliant to ``.net standard 2.0`` multiplatform spec:
	![.net standard 2.0](images/001-Intro-004-FirstScreen-NetStandard.png)
- *FirstScreen.Droid* for the Android code
	- It has to reference the *FirstScreen.Core* project
	- Latest target Android SDK is selected:
	![Target Android](images/001-Intro-005-FirstScreen-TargetDroid.png)
	- Android versions range is set we're going to support. For instance, let's choose 3 recent API levels:
	![Android versions](images/001-Intro-006-FirstScreen-DroidApiLevels.png)
- *FirstScreen.iOS* for the iOS platform code
	- It has to reference the *FirstScreen.Core* project
	- Info.plist file has selected needed Deployment Target, iOS versions range. For instance, iOS 11+:
	![iOS versions](images/001-Intro-007-FirstScreen-TargetiOS.png)

> It's recommended to use "Droid" suffix for your Android project, instead of "Android" to make life a bit easier for IDE to distinguish our versus Xamarin SDK namespaces

Our sample app is going to show just a single screen on start, with a basic Profile form where user can provide the information via text entry fields and save it:
- First Name
- Last Name
- Email

### Adding NuGet Packages

1. To *FirstScreen.Core*: **FlexiMvvm.Lifecycle**
2. To *FirstScreen.Droid* and *FirstScreen.iOS*: **FlexiMvvm.FullStack**

> On the time of documentation, FlexiMvvm was in the Preview mode, with "PreRelease" suffixes. Also showing Preview packages option was required to be enabled for NuGet Manager.

These packages bring all required dependencies. Some of them are external:
- Android project has got **Xamarin.Android.Arch...** and **Xamarin.Android.Support...**
- iOS project has got **Cirrious.FluentLayout** which is explained a bit later when UI layout development is described

### View Models

Having all external dependencies added, we may try to build the solution and proceed to implementing some core stuff.
Let's create a View Model for our Profile form: *FirstScreen.Core* / Presentation / ViewModels:

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
			System.Debug.WriteLine(
				$"Saved: {FirstName} {LastName}, {Email}.");
		}
	}
}
```

So, ``FirstName``, ``LastName``, ``Email`` string data properties are defined to observe values entered by user.
Also ``SaveCommand`` is added and used to call the ``Save()`` method when the user taps such button on the screen.
As we will see later, such ``ICommand`` driven handlers is a widely used approach across .net apps development introducing some extra advantages.

We see here ``ViewModelBase`` used as the base class.
This is the FlexiMvvm's cross-platform entry to the proper lifecycle and UI changes observation mechanisms. ``ViewModelBase`` must be used as a root of the hierarchy of our View Models.

> As you probably noticed in the sample above, our ``UserProfileViewModel`` does not implement ``INotifyPropertyChanged`` interface to enable data properties changes triggering. But actually it's just already inherited from ``ViewModelBase``.

> TBD: Fody

``CommandProvider``: TBD

### Initialization

In a minimalistic scenario when we have no specific initialization procedure, the only thing FlexiMvvm should know about is which View Models we're going to use through the app.

### Lifecycle

TBD

### Views

TBD

### Handling user input with Commands

TBD

---

[Next: Second Screen with Parameters...](001-introduction-03-second-screen-with-parameters.md)