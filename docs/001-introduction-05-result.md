[... Back to CONTENTS](index.md)

---

# Navigation for a Result

Another important navigation pattern is the result back propagation.
On Android, such scenario is supported explicitly: [Getting a Result from an Activity](https://developer.android.com/training/basics/intents/result), usually for moving onto a picker screen, choosing some item and returning it back to the initial screen. On iOS, to accommodate recommended **code-driven UI approach**, things are a bit easier: we create a new target View Controller and subscribe for its results from the calling source View Controller.

FlexiMvvm incorporates both platform specific patterns, exposing a common straighforward approach for us. Briefly, we do the following:
1. Add new ``Result`` type representing the result data.
2. On the source View Model, implement ``ILifecycleViewModelWithResultHandler`` interface to handle  a ``Result`` instance returned back (same source View Model may handle different ``Result`` types).
3. On the target View Model, implement ``ILifecycleViewModelWithResult<TResult>`` generic interface with this ``Result`` type is going to be supported.
4. Extend Navigation service to go to the target View Model and propagate the result back to the source View Model.

The complete sample is [available in the repository](https://github.com/epam-xamarin-lab/FlexiMvvm/tree/master/samples/004-Intro-Result/). For now, let's review this process step by step.

### Result

This is a data transfer object which represents the result of an operation. Some examples are a selected Country, a chosen Shipping option, or whatever else picked from a list. Also this may be a result of a wizard if the target screen performs this way. For the tutorial purposes, we're reusing the previous sample. Let's imagine that from the User Profile we may go to pick a Language from a list. So our result would be Sample.Core / Presentation / Navigation / SelectedLanguageResult.cs:

```cs
using FlexiMvvm.ViewModels;

namespace Sample.Core.Presentation.Navigation
{
    public class SelectedLanguageResult : Result
    {
        public SelectedLanguageResult(bool isSelected, string selectedLanguage)
        {
            IsSelected = isSelected;
            SelectedLanguage = selectedLanguage;
        }

        public bool IsSelected
        {
            get => Bundle.GetBool();
            private set => Bundle.SetBool(value);
        }

        public string SelectedLanguage
        {
            get => Bundle.GetString();
            private set => Bundle.SetString(value);
        }
    }
}

```

The important point is that it inherits from ``Result`` base class which is capable to preserve the result during transitioning to the source screen. Our result holds two data properties which will be used on the source View Model. As you can see, base ``Bundle`` is used to safely preserve the values.

### Source View Model

We're updating a bit the View Model used in the previous tutorials: adding the new ``Language`` Data Property and the ``HandleResult()`` method required by the ``ILifecycleViewModelWithResultHandler`` contract.

```cs
using FlexiMvvm.Commands;
using FlexiMvvm.ViewModels;
using Sample.Core.Presentation.Navigation;

namespace Sample.Core.Presentation.ViewModels
{
    public class UserProfileViewModel : LifecycleViewModel<UserProfileParameters>, ILifecycleViewModelWithResultHandler
    {
        //// ... some existing code is hidden for convenience

        private string _language;

        public string Language
        {
            get => _language;
            set => SetValue(ref _language, value);
        }        

        public void HandleResult(ResultCode resultCode, Result result)
        {
            if (result is SelectedLanguageResult selectedLanguageResult)
            {
                if (resultCode == ResultCode.Ok && selectedLanguageResult.IsSelected)
                {
                    Language = selectedLanguageResult.SelectedLanguage;

                    System.Diagnostics.Debug.WriteLine($"Result retrieved: {Language}...");
                }
            }
        }

        //// ... some existing code is hidden for convenience
    }
}

```

So we're adding ``ILifecycleViewModelWithResultHandler`` and implementing the ``HandleResult()`` method to properly use the result provided, checking the ``ResultCode`` which is also available (same standard way as on Android). Keep attention, that in a sophisticated situation a single source View Model may handle multiple ``Result`` types, from different picker or wizard screens, if needed. In the ``HandleResult()`` method all these results should be handled, checking the ``Result`` type as well as ``ResultCode``.

### Target View Model

So the target screen in this tutorial is a list of Languages the User is able to choose from. The new View Model is added, Sample.Core / Presentation / ViewModels / LanguagesViewModel.cs:

```cs
using FlexiMvvm.Commands;
using FlexiMvvm.ViewModels;
using Sample.Core.Presentation.Navigation;

namespace Sample.Core.Presentation.ViewModels
{
    public class LanguagesViewModel : LifecycleViewModel, ILifecycleViewModelWithResult<SelectedLanguageResult>
    {
        private INavigationService _navigationService;

        public LanguagesViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
        }

        public Command<string> SelectLanguage => CommandProvider.Get<string>(OnSelectLanguage);

        public void SetResult(ResultCode resultCode, SelectedLanguageResult result)
        {
            _navigationService.NavigateBack(this, resultCode, result);
        }

        private void OnSelectLanguage(string @value)
        {
            SetResult(ResultCode.Ok, new SelectedLanguageResult(true, @value));
        }
    }
}

```

So, it's very simple View Model which handles User's item selection via the ``SelectLanguage`` command with the ``OnSelectLanguage()`` handler. The latter just calls the ``SetResult()`` method which is required by the ``ILifecycleViewModelWithResult<SelectedLanguageResult>`` interface specified.

As you can see, the result back propagation is done via our Navigation service's ``NavigateBack()`` - let's review how it's implemented. 

### Navigation service

Firstly, it's the updated contract, Sample.Core / Presentation / Navigation / INavigationService.cs:

```cs
using FlexiMvvm.ViewModels;
using Sample.Core.Presentation.ViewModels;

namespace Sample.Core.Presentation.Navigation
{
    public interface INavigationService
    {
        //// ... some existing code is hidden for convenience

        void NavigateToLanguages(ILifecycleViewModelWithResultHandler from);

        void NavigateBack(LanguagesViewModel from, ResultCode code, SelectedLanguageResult result);
    }
}

```

Proceeding to the Languages list screen with ``NavigateToLanguages()`` is basic and shown in the previous tutorials. The only note that we require a source View Model which is capable to handle the result, with the ``ILifecycleViewModelWithResultHandler`` parameter.
Navigating back from Languages list to the User Profile will be possible with the ``NavigateBack()`` method, providing result code and instance.

#### Android

Sample.Droid / Navigation / AppNavigationService.cs:

```cs
using Android.Content;
using FlexiMvvm.Navigation;
using FlexiMvvm.ViewModels;
using FlexiMvvm.Views;
using Sample.Core.Presentation.Navigation;
using Sample.Core.Presentation.ViewModels;
using Sample.Droid.Views;

namespace Sample.Droid.Navigation
{
    public class AppNavigationService : NavigationService, INavigationService
    {
        //// ... some existing code is hidden for convenience 

        public void NavigateToLanguages(ILifecycleViewModelWithResultHandler from)
        {
            var view = NavigationViewProvider.Get(from);
            NavigateForResult<LanguagesActivity, SelectedLanguageResult>(view);

            /* Here's what is approximately done by Navigate() above:

            var source = view.GetActivity();
            var code = view.RequestCode.GetFor<DefaultResultMapper<SelectedLanguageResult>>();
            var intent = new Intent(source, typeof(LanguagesActivity));
            source.StartActivityForResult(intent, code);

            */
        }

        public void NavigateBack(LanguagesViewModel from, ResultCode code, SelectedLanguageResult result)
        {
            var view = NavigationViewProvider.Get(from);
            NavigateBack(view, code, result);

            /* Here's what is approximately done by Navigate() above:

            var source = view.GetActivity();
            var intent = new Intent(source, typeof(UserProfileActivity));
            intent.PutResult(result);
            source.SetResult(code, intent);
            source.Finish();

            */
        }
    }
}

```

Again we use shorthand navigation here with ``NavigateForResult()`` and ``NavigateBack()`` base methods, though the commented sections provide some insight how they're implemented by FlexiMvvm, using Android Intent.

``LanguagesActivity`` is missing now. As it's out of this tutorial scope - this may be any Android screen which can provide the result. The [complete sample contains](https://github.com/epam-xamarin-lab/FlexiMvvm/blob/master/samples/004-Intro-Result/Sample.Droid/Views/LanguagesActivity.cs) a very basic ``RecyclerView`` driven list screen the User can choose the Language from. Basically this new screen executes a ``SelectLanguage`` command of the ``LanguagesViewModel``, which leads to the results back propagation we have implemented above. ``LanguagesActivity`` is reviewed in detail in the related [Data Bindings](001-introduction-06-data-bindings.md) tutorial.

Regarding ``NavigateBack()``, we see that Android Intent is leveraged here to pass the ``SelectedLanguageResult`` result instance to make it available for our ``UserProfileViewModel`` View Model.

#### iOS

Sample.iOS / Navigation / NavigationService.cs:

```cs
using System;
using FlexiMvvm.Navigation;
using FlexiMvvm.ViewModels;
using Sample.Core.Presentation.Navigation;
using Sample.Core.Presentation.ViewModels;
using Sample.iOS.Views;

namespace Sample.iOS.Navigation
{
    public class AppNavigationService : NavigationService, INavigationService
    {
        //// ... some existing code is hidden for convenience

        public void NavigateToLanguages(ILifecycleViewModelWithResultHandler from)
        {
            var view = NavigationViewProvider.Get(from);
            var target = new LanguagesViewController();
            NavigateForResult<LanguagesViewController, SelectedLanguageResult>(view, target, true);

            /* Here's what is done by Navigate() above:

            target.ResultSetWeakSubscribe(view.HandleResult);
            view.GetNavigationController().PushViewController(target, true);

            */
        }

        public void NavigateBack(LanguagesViewModel from, ResultCode code, SelectedLanguageResult result)
        {
            var view = NavigationViewProvider.Get(from);
            NavigateBack(view, code, result, true);

            /* Here's what is done by Navigate() above:

            view.SetResult(code, result);
            view.GetNavigationController().PopViewController(true);

            */
        }
    }
}

```

The commented sections explain how the navigation is implemented on iOS. When moving forward, a weak reference subscription is created, to invoke the ``HandleResult()`` method on the Result *receiving* View Controller when ready. When moving back, this invocation is triggered via ``SetResult()`` on the *providing* View Controller.

Again, missing iOS Languages list view screen to select a Language for the result is out of scope of this tutorial, but is reviewed in detail in the related one: [Data Bindings](001-introduction-06-data-bindings.md). For now, the [complete sample](https://github.com/epam-xamarin-lab/FlexiMvvm/blob/master/samples/004-Intro-Result/Sample.iOS/Views/LanguagesViewController.cs) may be reviewed.

---

[Next: ...](index.md)
