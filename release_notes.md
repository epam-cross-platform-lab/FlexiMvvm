# FlexiMvvm Release Notes
## v.0.10.3 (preview)

### Existing functionality changes

 - FlexiMvvm-adapted activity doesn't throw an exception anymore in Activity.OnActivityResult callback if its model doesn't implement IViewModelWithResultHandler. Reason: activities might communicate with each other without transmission the result to the view model.

## v.0.10.2 (preview)

### New functionality

 - Added classes for view model to view [interactions](https://github.com/epam-xamarin-lab/FlexiMvvm/tree/master/FlexiMvvm.Common/Interactions).

### Existing functionality changes

 - ViewModel.InitializeAsync is called when UIViewController.ViewDidLoad/Activity.OnCreate methods completed. Previously it was called at the beginning of ViewDidLoad/OnCreate. It didn't allow access to views because there were not created yet.
 -  Now Config implements IConfig implicitly. Don't need to cast to IConfig to access GetView/SetView methods.

### Bug fixes

 - NavigationService.Navigate methods crash for iOS.

### Code documentation

 - All navigation classes have been documented.

### Debugging

 - *.snupkg symbols are uploaded to NuGet.org starting from 0.10.2 release. [Read here how to consume*.snupkg from NuGet.org](https://blog.nuget.org/20181116/Improved-debugging-experience-with-the-NuGet-org-symbol-server-and-snupkg.html).