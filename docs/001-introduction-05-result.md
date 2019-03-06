[... Back to CONTENTS](index.md)

---

# Navigation for a Result

Another important navigation pattern is the result back propagation.
On Android, such scenario is supported explicitly: [Getting a Result from an Activity](https://developer.android.com/training/basics/intents/result), usually for moving onto a picker screen, choosing some item and returning it back to the initial screen. On iOS, to accommodate recommended navigation and View Controllers creation via code, things are a bit easier: we create a new View Controller and subscribe for its results from the calling View Controller.

FlexiMvvm incorporates both platform specific patterns, exposing a common straighforward approach for us. Briefly, we do the following:
1. Add new ``Result`` type representing the result data.
2. On the source View Model, implement ``IViewModelWithResultHandler`` interface to handle this ``Result`` instance returned back.
3. On the target View Model, implement ``IViewModelWithResult<TResult>`` generic interface with this ``Result`` type to set the result when needed.
4. Extend Navigation in our app to go to the target View Model and propagate the result back to the source View Model.
5. Create View layouts for the source and target screens if not done yet.

The complete sample is [available in the repository](https://github.com/epam-xamarin-lab/FlexiMvvm/tree/master/samples/010-Intro-FirstScreen/). For now, let's review this process step by step.

### Result

This is a data transfer object which represents the result of an operation. Some examples are a selected Country, a chosen Shipping option, or whatever else picked from a list. Also this may be a result of a wizard if the target screen performs this way. For the tutorial purposes, we're reusing the previous sample. Let's imagine that from the User Profile we may go to pick a Language from a list. So our result would be FirstScreen.Core / Presentation / Navigation / SelectedLanguageResult.cs:

```cs
using FlexiMvvm.ViewModels;

namespace FirstScreen.Core.Presentation.Navigation
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

```cs
using System.Threading.Tasks;
using FirstScreen.Core.Infrastructure.Data;
using FirstScreen.Core.Presentation.Navigation;
using FlexiMvvm.Commands;
using FlexiMvvm.ViewModels;

namespace FirstScreen.Core.Presentation.ViewModels
{
    public class UserProfileViewModel : ViewModel<UserProfileParameters>, IViewModelWithResultHandler
    {
        //// ... some existing code is hidden for convenience

        private string _language;

        public string Language
        {
            get => _language;
            set => SetValue(ref _language, value);
        }        

        public async void HandleResult(ResultCode resultCode, Result result)
        {
            if (result is SelectedLanguageResult selectedLanguageResult)
            {
                if (resultCode == ResultCode.Ok && selectedLanguageResult.IsSelected)
                {
                    Language = selectedLanguageResult.SelectedLanguage;

                    await _userProfileRepository.Update(new UserProfile
                    {
                        Email = Email,
                        FirstName = FirstName,
                        LastName = LastName,
                        Language = Language
                    });
                }
            }
        }

        //// ... some existing code is hidden for convenience        
    }
}
```

So we're adding ``IViewModelWithResultHandler`` and implementing the ``HandleResult()`` method to properly use the result provided, checking the ``ResultCode`` which is also available. Keep attention, that in a sophisticated situation a single source View Model may handle multiple ``Result`` types, from different picker or wizard screens, if needed. In the ``HandleResult()`` method all these results should be handled, checking the ``Result`` type as well as ``ResultCode``.

### Target View Model

So the target screen is a list of Languages the User is able to choose from. The new View Model is added, FirstScreen.Core / Presentation / ViewModels / LanguagesViewModel.cs:

```cs
using FirstScreen.Core.Presentation.Navigation;
using FlexiMvvm.Commands;
using FlexiMvvm.ViewModels;

namespace FirstScreen.Core.Presentation.ViewModels
{
    public class LanguagesViewModel : ViewModel, IViewModelWithResult<SelectedLanguageResult>
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

So, it's very simple View Model which handles User's item selection via the ``SelectLanguage`` command with the ``OnSelectLanguage()`` handler. The latter just calls the ``SetResult()`` method which is required by the ``IViewModelWithResult<SelectedLanguageResult>`` interface specified.

As you can see, the result back propagation is done via our Navigation service - let's review how it's implemented. 

### Navigation service

Firstly, it's updated contract, FirstScreen.Core / Presentation / Navigation / INavigationService.cs:

```cs
using FirstScreen.Core.Presentation.ViewModels;
using FlexiMvvm.ViewModels;

namespace FirstScreen.Core.Presentation.Navigation
{
    public interface INavigationService
    {
        void NavigateToUserProfile(EntryViewModel from, UserProfileParameters parameters);

        void NavigateToLanguages(UserProfileViewModel from);

        void NavigateBack(LanguagesViewModel from, ResultCode code, SelectedLanguageResult result);
    }
}
```

Proceeding to the Languages list screen is basic - we just specifying source View Model as the parameter for the ``NavigateToLanguages()`` method, as usual.

Navigating back from Languages list to the User Profile back with the ``NavigateBack()`` method, this is the central point of our attention so far. 

#### Android

FirstScreen.Droid / Navigation / NavigationService.cs:

```cs
using System;
using Android.Content;
using FirstScreen.Core.Presentation.Navigation;
using FirstScreen.Core.Presentation.ViewModels;
using FirstScreen.Droid.Views;
using FlexiMvvm.ViewModels;
using FlexiMvvm.Views;

namespace FirstScreen.Droid.Navigation
{
    public class NavigationService : FlexiMvvm.Navigation.NavigationService, INavigationService
    {
        //// ... some existing code is hidden for convenience 

        public void NavigateToLanguages(UserProfileViewModel from)
        {
            var userProfileActivity = GetActivity<UserProfileActivity, UserProfileViewModel>(from);

            var intent = new Intent(userProfileActivity, typeof(LanguagesActivity));

            var requestCode = new RequestCode();
            userProfileActivity.StartActivityForResult(intent, requestCode.GetFor<SelectedLanguageResult>());
        }

        public void NavigateBack(LanguagesViewModel from, ResultCode resultCode, SelectedLanguageResult result)
        {
            var languagesActivity = GetActivity<LanguagesActivity, LanguagesViewModel>(from);

            var intent = new Intent(languagesActivity, typeof(UserProfileActivity));
            intent.PutResult(result);

            languagesActivity.SetResult(resultCode, intent);
            languagesActivity.Finish();
        }
    }
}

```

On Android, we leverage the native capability for results navigation. ``NavigateToLanguages()`` calls ``StartActivityForResult()`` as usual.
But with ``RequestCode`` provided by FlexiMvvm we are specifying our ``SelectedLanguageResult`` instance as an expected result to propagate back.

Also as we already used by ``LanguagesViewModel`` when calling our Navigation service, ``NavigateBack()`` is being provided with the operation's ``ResultCode`` and ``SelectedLanguageResult`` parameters which then passed via Intent's ``PutResult()`` and target screen Activity's ``SetResult()`` methods.

Of course, we also need the Languages list screen Activity to add, though it's out of the tutorial scope - this may be any Android app screen which leads to the result expected. The [sample contains](https://github.com/epam-xamarin-lab/FlexiMvvm/blob/master/samples/010-Intro-FirstScreen/Droid/Views/LanguagesActivity.cs) a very basic ``RecyclerView`` driven list screen the User can choose the Language from.

#### iOS

TBD

---

[Next: ...](index.md)