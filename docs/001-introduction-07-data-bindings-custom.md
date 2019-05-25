[... Back to CONTENTS](index.md)

---

# Complete sample

Whole sample code is [available in the repository](https://github.com/epam-xamarin-lab/FlexiMvvm/tree/master/samples/005-Intro-DataBindings/).

# Custom Data Bindings

We've reviewed how Data Binding is approached by FlexiMvvm and turned up that 3 classes bring its core:
- *TargetItemOneWayCustomBinding* - for **One Way**: from ViewModel to View. Example: propagating text to a UI Label.
- *TargetItemOneWayToSourceCustomBinding* - for **One Way to Source**: to ViewModel from View; like propagating a selected item chosen from a list.
- *TargetItemTwoWayCustomBinding* - for **Two Way**: both directions like a Text entry's value.

Any custom Data Binding is implemented absolutely the same way, how this is made by FlexiMvvm itself.

Given a View Model with a source Data Property or Command exposed, in general the steps are:
1. Prepare your Target: a control, subview or a whole Activity. Provide abilities to set/get the value or notify about its change.
2. Create an extension method and wire up your Target with an appropriate FlexiMvvm's *TargetItem...Binding*
3. Use this extension method as a normal Data Binding

### One way to Source

This Data Binding type is used on the *Languages* screen in the sample mentioned - on the screen a list item is selected and handled then by the View Model, Sample.Core / Presentation / ViewModels / **LanguagesViewModel.cs**

```cs
using FlexiMvvm.Commands;
using FlexiMvvm.ViewModels;
using Sample.Core.Presentation.Navigation;

namespace Sample.Core.Presentation.ViewModels
{
    public class LanguagesViewModel : LifecycleViewModel, ILifecycleViewModelWithResult<SelectedLanguageResult>
    {
        //// ... some existing code is hidden for convenience

        public Command<string> SelectLanguage => CommandProvider.Get<string>(OnSelectLanguage);

        private void OnSelectLanguage(string @value)
        {
            SetResult(ResultCode.Ok, new SelectedLanguageResult(true, @value));
        }
    }
}

```

Here, the ``SelectLanguage`` command is exposed to receive the Language item value and handle it in ``OnSelectLanguage`` action method. To do this, we're wiring up iOS and Android Views with a custom One way to Source Data Binding. That's how it's made by the steps above, for both platforms.

#### Android

1. Sample.Droid / Views / **LanguagesActivity.cs**: View with the list of Language items. Selecting an item (raising the ``EventHandler<string> LanguageSelected`` event) notifies about the value passed
2. Sample.Droid / Bindings / **LanguagesActivityBindings.cs**: the Data Binding definition as an extension method
3. Sample.Droid / Views / **LanguagesActivity.cs** again, where the new Data Binding is used.

This is LanguagesActivity:

```cs
//// ... some existing code is hidden for convenience

namespace Sample.Droid.Views
{
    [Activity(Theme = "@style/AppTheme.NoActionBar")]
    public class LanguagesActivity : BindableAppCompatActivity<LanguagesViewModel>
    {
        //// ... some existing code is hidden for convenience

        public event EventHandler<string> LanguageSelected;

        // This method raises the Data Binding trigger event.
        // Called by a list item view.
        public void InvokeLanguageSelected(string @value)
        {
            LanguageSelected?.Invoke(this, @value);
        }

        public override void Bind(BindingSet<LanguagesViewModel> bindingSet)
        {
            base.Bind(bindingSet);

            bindingSet.Bind(this)
              .For(v => v.LanguageSelectedBinding())
              .To(vm => vm.SelectLanguage);
        }

        //// ... some existing code is hidden for convenience
    }
}


```

The list view is controled by RecyclerView's Adapter which assigns the Activity's ``InvokeLanguageSelected()`` method as the List item Click event handler. We see here the overridden ``Bind()`` method were ``LanguageSelectedBinding()`` extension method is used - let's review how Data Binding is defined by it, wiring up the View event and ViewModel command:

```cs
using System;
using FlexiMvvm.Bindings;
using FlexiMvvm.Bindings.Custom;
using Sample.Droid.Views;

namespace Sample.Droid.Bindings
{
    public static class LanguagesActivityBindings
    {
        public static TargetItemBinding<LanguagesActivity, string> LanguageSelectedBinding(this IItemReference<LanguagesActivity> target)
        {
            if (target == null)
            {
                throw new ArgumentNullException(nameof(target));
            }

            return new TargetItemOneWayToSourceCustomBinding<LanguagesActivity, string, string>(
                target,
                (t, eventHandler) => t.LanguageSelected += eventHandler, // how to notified about new value
                (t, eventHandler) => t.LanguageSelected -= eventHandler, // how to gracefully clean up
                (t, canExecuteCommand) => { }, // in our case, always enabled
                (t, @value) => @value, // in our case, just grab the value provided directly
                () => "LanguageSelected"); // log into console with this name
        }
    }
}

```

And that's is - Android is done. Just a tiny extension method, and we're able to push data onto ViewModel to handle.

#### iOS

For iOS, the following steps are similar:
1. Sample.iOS / Views / **LanguagesView.cs**: View with the list of Language items. Selecting an item (raising the ``EventHandler<string> LanguageSelected`` event) notifies about the value passed
2. Sample.iOS / Bindings / **LanguagesViewBindings.cs**: the Data Binding definition as an extension method
3. Sample.iOS / Views / **LanguagesViewController.cs**, where the new Data Binding is used.

This is the LanguagesView:

```cs
//// ... some existing code is hidden for convenience

namespace Sample.iOS.Views
{
    public class LanguagesView : LayoutView
    {
        public event EventHandler<string> LanguageSelected;

        //// ... some existing code is hidden for convenience

        // This method raises the Data Binding trigger event.
        // Called by LanguagesTableViewSource, reacting on RowSelected.
        private void OnLanguageSelected(string @value)
        {
            LanguageSelected?.Invoke(this, @value);
        }
    }

	//// ... some existing code is hidden for convenience
}

```

The Data Binding definition as an extension method:

```cs
using System;
using FlexiMvvm.Bindings;
using FlexiMvvm.Bindings.Custom;
using Sample.iOS.Views;

namespace Sample.iOS.Bindings
{
    public static class LanguagesViewBindings
    {
        public static TargetItemBinding<LanguagesView, string> LanguageSelectedBinding(
            this IItemReference<LanguagesView> target)
        {
            if (target == null)
            {
                throw new ArgumentNullException(nameof(target));
            }

            return new TargetItemOneWayToSourceCustomBinding<LanguagesView, string, string>(
                target,
                (t, eventHandler) => t.LanguageSelected += eventHandler, // how to notified about new value
                (t, eventHandler) => t.LanguageSelected -= eventHandler, // how to gracefully clean up
                (t, canExecuteCommand) => { }, // in our case, always enabled
                (t, @value) => @value, // in our case, just grab the value provided directly
                () => "LanguageSelected"); // log into console with this name
        }
    }
}

```

And usage of the Data Binding by LanguagesViewController:

```cs
//// ... some existing code is hidden for convenience

namespace Sample.iOS.Views
{
    public class LanguagesViewController : BindableViewController<LanguagesViewModel>
    {
        //// ... some existing code is hidden for convenience

        public override void Bind(BindingSet<LanguagesViewModel> bindingSet)
        {
            base.Bind(bindingSet);

            bindingSet.Bind(View)
                .For(v => v.LanguageSelectedBinding())
                .To(vm => vm.SelectLanguage);
        }
    }
}

```

Done for iOS as well. So, no matter how complex and different custom UI may be on iOS versus Android, we always can abstract logic with our Data Binding, notifying View Model and passing all needed data into platform-agnostic context.

### Two Way

TBD

---

[Next: ...](index.md)
