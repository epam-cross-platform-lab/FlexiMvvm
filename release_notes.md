# FlexiMvvm Release Notes

## v.0.10.7 (preview)

### New functionality

**FlexiMvvm.Bindings** module:

- Added bindings for RatingBar.

### Existing functionality changes

**FlexiMvvm.Common** module:

- `FlexiMvvm.Ioc.ISimpleIoc` implements the `System.IServiceProvider` interface in addition to the `FlexiMvvm.Ioc.IDependencyProvider` one. `FlexiMvvm.Ioc.IDependencyProvider`will be removed in **0.10.8** release.
- `FlexiMvvm.Interactions.Interaction*` classes are moved to the **FlexiMvvm.Lifecycle** module, `FlexiMvvm.ViewModels` namespace.

**FlexiMvvm.Lifecycle** module:

- FlexiMvvm.Lifecycle is now a **release candidate**! Significant breaking changes are no longer expected.

#### FlexiMvvm.Lifecycle 0.10.6 migration flow:

##### View models migration:

 - `FlexiMvvm.ViewModels.ViewModel` class has been renamed to the `FlexiMvvm.ViewModels.LifecycleViewModel` and `FlexiMvvm.ViewModels.ItemViewModel` has been  renamed to the `FlexiMvvm.ViewModels.ViewModel`.
Based on observation, almost every developer uses `FlexiMvvm.ViewModels.ViewModel` as a base class for their own view models. But this is not entirely correct. Therefore, renaming was done. There are the following rules to determine which class should be used as a base one:
	- Use `FlexiMvvm.ViewModels.LifecycleViewModel`as a base class if its owner is Activity/Fragment  for Android platform or UIViewController for iOS one. Only view models inherited from `FlexiMvvm.ViewModels.LifecycleViewModel` can participate in the navigation, save its state and be initialized by its owner.
	 - Use `FlexiMvvm.ViewModels.ViewModel`as a base class if it is owned by another view model or a view not mentioned above. Such view models cannot participate in the navigation or persist own state.
 - `FlexiMvvm.ViewModels.LifecycleViewModel.Initialize*` methods takes one more parameter: `recreated`. It has `true` value in case when the view model has been destroyed to recover memory and recreated with a restored state if it was persisted. If you are doing navigation in your view model then  you need to write:

>     public override void Initialize(bool recreated)
>     {
>         base.Initialize(recreated);
>       
>         // Call NavigateToItem() only if Initialize() is called first time
>         if (!recreated)
>         {
>             NavigateToItem(DefaultItem);
>         }    
>     }

Android will restore UI itself, so you don't need to perform navigation when recreated is `true`. The code above is equivalent to the one for Android:

>     protected override void OnCreate(Bundle savedInstanceState)
>     {
>         base.OnCreate(savedInstanceState);
>     
>         if (savedInstanceState == null)
>         {
>             NavigateToItem(DefaultItem);
>         }
>     }

`recreated` always has `false` value for iOS due to a view model is never recreated on this platform.
- `FlexiMvvm.ViewModels.ViewModelProvider` is `FlexiMvvm.ViewModels.LifecycleViewModelProvider` now, `FlexiMvvm.ViewModels.DependencyProviderViewModelFactory` is `FlexiMvvm.ViewModels.DefaultLifecycleViewModelFactory` (which expects a `System.IServiceProvider` instance as a constructor parameter instead of  `FlexiMvvm.Ioc.IDependecyProvider` one). `FlexiMvvm.ViewModels.ViewModelFactory` class has been deleted, so implement the `FlexiMvvm.ViewModels.ILifecycleViewModelFactory` interface instead.
-  `FlexiMvvm.ViewModels.ObservableObject` class has been moved to the **FlexiMvvm.Common** module and is available in the `FlexiMvvm` namespace.
 
##### Navigation migration:

- `FlexiMvvm.Navigation.NavigationService` no longer has methods for getting existing instances of views. All these methods have been moved to the `FlexiMvvm.Navigation.NavigationViewProvider` class. In addition, it requires `ILifecycleViewModel` instances instead of `IViewModel` ones.
- Previously, FlexiMvvm-adapted `UIViewController`s had a parameterless constructor or constructor with parameters. The disadvantage of this approach that it is not possible to use constructors provided by iOS.
Starting from 0.10.7, adapted view controllers have the same set of constructors as adaptable ones.
This led to a change in the way parameters are passed for a view controller. Previously, to pass parameters in a `UIViewController` instance, it was necessary to write like this:

>     var myParameters = new MyParameters(/* parameters initialization */);
>     var myViewController = new MyViewController(myParameters);
>     
>     Navigate<MyViewController>(myViewController);

Now it is:

>     var myParameters = new MyParameters(/* parameters initialization */);
>     var myViewController = new MyViewController();
>     myViewController.SetParameters(myParameters);
>     
>     Navigate<MyViewController>(myViewController);

or even a better approach (which is more consistent with the Android one):

>     var myParameters = new MyParameters(/* parameters initialization */);
>     var myViewController = new MyViewController();
>     
>     Navigate<MyViewController, MyParamters>(myViewController, myParameters);

### Bug fixes

- CanExecuteChanged event for a command not raised during the initial execution of bindings.

## v.0.10.6 (preview)

### New functionality

- Added SpinnerObservableAdapter.
- Added bindings for AdapterView, Spinner, UIPickerView, IItemsSource.

### Existing functionality changes

- PickerViewObservableModel refactoring. Now it is more simple and works with positions instead of objects. New implementation is not compatible with old one.

### Bug fixes

- ValueSet crashes when call GetValue method.

## v.0.10.5 (preview)

### Existing functionality changes

- Switch on C# 8 for FlexiMvvm source code (main reason - nullable reference types support).
- Starting removing Jetbrains Code Annotations and replace them with nullable reference types.
- Replace `FlexiMvvm.Configuration.Config` class with `FlexiMvvm.Collections.ValueSet`(API not changed, just renaming).

### Bug fixes

- If navigate from ActivityA to ActivityB for result and ActivityA killed by the Android then app crashes if return back.
- Cascading return result doesn't work properly in iOS.

### Code documentation

- Bootstrappers*, Configuration*, Parameter, Result classes have been documented.

## v.0.10.4 (preview)

### Existing functionality changes

- Remove `OperationFactory property` from the `ViewModel` class.

### Bug fixes

- View models parameters are not passed to a `UITabBarController`.

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