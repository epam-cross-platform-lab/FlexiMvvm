[... Back to CONTENTS](index.md)

---

# Complete sample

Whole sample code is [available in the repository](https://github.com/epam-xamarin-lab/FlexiMvvm/tree/master/samples/005-Intro-DataBindings/).

# Custom Data Bindings

We've reviewed how Data Binding is approached by FlexiMvvm and turned up that 3 classes bring its core:
- *TargetItemOneWayCustomBinding* - for **One Way**: from ViewModel to View. Example: propagating text to a UI Label.
- *TargetItemOneWayToSourceCustomBinding* - for **One Way to Source**: to ViewModel from View; like propagating a selected item chosen from a list.
- *TargetItemTwoWayCustomBinding* - for **Two Way**: both directions like a Text entry's value.

Given a View Model with a source Data Property or Command exposed, in general the steps are:
1. Prepare your **Target**: a control, subview or a whole Activity. Provide abilities to set/get the value or notify about its change.
2. Create an **extension method** and wire up your Target with an appropriate FlexiMvvm's *TargetItem...Binding*
3. **Use** this extension method as a normal Data Binding

### One way to Source

In the [sample provided](https://github.com/epam-xamarin-lab/FlexiMvvm/tree/master/samples/005-Intro-DataBindings/) above, this Data Binding type is used on the *Languages* screen: when a list item is selected it is handled then by the View Model, Sample.Core / Presentation / ViewModels / LanguagesViewModel.cs:

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

Here, the ``SelectLanguage`` **command** is exposed to receive the Language item string value and handle it in ``OnSelectLanguage`` action method. To do this, we're wiring up iOS and Android Views with a custom One way to Source Data Binding. That's how it's made by the steps above, for both platforms.

#### Android

1. Prepare the **Target** - LanguagesActivity, the view with the list of Language items. Let's add the ``EventHandler<string> LanguageSelected`` event to trigger Data Binding and push the selected value.
2. Add **extension method** - LanguageSelectedBinding(), to define the Data Binding.
3. **Use** the extension method in LanguagesActivity.

So, this is Sample.Droid / Views / LanguagesActivity.cs, with the ``LanguageSelected`` event and ``LanguageSelectedBinding()`` use:

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

The list view is controled by RecyclerView's Adapter which assigns the Activity's ``InvokeLanguageSelected()`` method as the List item Click event handler.
We see here the FlexiMvvm's overridden ``Bind()`` method where ``LanguageSelectedBinding()`` extension method is used.

Let's create a new file, Sample.Droid / Bindings / LanguagesActivityBindings.cs, add wire up the View event with the ``LanguageSelectedBinding()`` extension method:

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
1. Prepare the **Target** - LanguagesView, the view with the list of Language items. Let's add the ``EventHandler<string> LanguageSelected`` event to trigger Data Binding and push the selected value.
2. Add **extension method** - LanguageSelectedBinding(), to define the Data Binding.
3. **Use** the extension method in LanguagesViewController.

This is the Sample.iOS / Views / LanguagesView.cs:

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

The Data Binding definition in a new Sample.iOS / Bindings / LanguagesViewBindings.cs file:

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
                (t, eventHandler) => t.LanguageSelected += eventHandler, // to notify about new value
                (t, eventHandler) => t.LanguageSelected -= eventHandler, // to gracefully clean up
                (t, canExecuteCommand) => { }, // in our case, always enabled
                (t, @value) => @value, // in our case, just grab the value provided directly
                () => "LanguageSelected"); // log into console with this name
        }
    }
}

```

And usage of the Data Binding by Sample.iOS / Views / LanguagesViewController.cs:

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

Done for iOS as well.

So, no matter how complex and different custom UI may be on iOS versus Android, we always can abstract logic with our Data Binding, notifying View Model and passing all needed data into platform-agnostic context.

### Two Way

In the [sample available](https://github.com/epam-xamarin-lab/FlexiMvvm/tree/master/samples/005-Intro-DataBindings/), Two Way Data Binding was used on the *User Profile* screen, for the *Date of Birth* value. We can change it via a platform-specific Date picker as well as change on View Model side, still keeping synchronized with the UI.

Actually, there's no significant difference with One Way to Source example shown above. We just only need to provide a data setter on the target View side, to be able to perform data movement from ViewModel as well. On the ViewModel side, the corresponding Data Property is defined. Internally, FlexiMvvm uses standard and widely used by other MVVM frameworks - ``System.ComponentModel.INotifyPropertyChanged`` which is implemented by base ViewModel types. This will engage the Data Binding to keep values in sync on both sides.

Let's review all the steps for Two Way Data Binding. Again, starting with the shared part, Sample.Core / Presentation / ViewModels / UserProfileViewModel.cs:

```cs
using System;
using FlexiMvvm.Commands;
using FlexiMvvm.ViewModels;
using Sample.Core.Presentation.Navigation;

namespace Sample.Core.Presentation.ViewModels
{
    public class UserProfileViewModel : LifecycleViewModel<UserProfileParameters>, ILifecycleViewModelWithResultHandler
    {
        //// ... some existing code is hidden for convenience

        public string DateOfBirthday
        {
            get => _dob;
            set => SetValue(ref _dob, value);
        }

        //// ... some existing code is hidden for convenience

        public override void Initialize(UserProfileParameters? parameters, bool recreated)
        {
            base.Initialize(parameters, recreated);

            Email = parameters?.Email ?? string.Empty;

            // Lets imagine we looked up the data by the Email provided...
            FirstName = "Jeremy";
            LastName = "Simpson";
            DateOfBirthday = new DateTime(2000, 3, 1).ToShortDateString();
        }

        private void SaveAction()
        {
            System.Diagnostics.Debug.WriteLine($"Saving: {FirstName} {LastName}, {Email}, {Language}, {DateOfBirthday}...");
        }

        //// ... some existing code is hidden for convenience
    }
}

```

Just for the demo purposes, the ``DateOfBirthday``'s type is ``string`` - to show how to use ``ValueConverter`` with Data Binding (on the View side, it's going to be ``DateTime``).

That's how this ValueConverter is implemented in the new file, Sample.Core / Presentation / ValueConverters / StringToDateTimeValueConverter.cs:

```cs
using System;
using System.Globalization;
using FlexiMvvm.ValueConverters;

namespace Sample.Core.Presentation.ValueConverters
{
    public sealed class StringToDateTimeValueConverter : ValueConverter<string, DateTime>
    {
        private const string DateFormat = "d";

        protected override ConversionResult<DateTime> Convert(string value, Type targetType, object parameter, CultureInfo culture)
        {
            if (DateTime.TryParse(value, out var dt))
            {
                return ConversionResult<DateTime>.SetValue(new DateTime(dt.Year, dt.Month, dt.Day, 0, 0, 0, DateTimeKind.Utc));
            }

            return ConversionResult<DateTime>.SetValue(DateTime.UtcNow);
        }

        protected override ConversionResult<string> ConvertBack(DateTime value, Type targetType, object parameter, CultureInfo culture)
        {
            return ConversionResult<string>.SetValue(value.ToString(DateFormat));
        }
    }
}

```

``StringToDateTimeValueConverter`` is pretty typical for MVVM frameworks - it defines a couple of methods to convert the data back and forth. We will see its usage below.

#### Android

Once again, the plan is following:
1. Prepare the **Target** - UserProfileActivity. Along with the ``EventHandler DateOfBirthdayChanged`` event (not generic this time, just for the demo - such scenario is also supported when event does not bring the needed value via a parameter), it will introduce the ``DateTime DateOfBirthday`` data property which will be in sync with the ViewModel side.
2. Add **extension method** - DateOfBirthdayChangedBinding(), to define the Data Binding.
3. **Use** the extension method in UserProfileActivity.

Sample.Droid / Views / UserProfileActivity.cs:

```cs
//// ... some existing code is hidden for convenience

namespace Sample.Droid.Views
{
    [Activity(Theme = "@style/AppTheme.NoActionBar")]
    public class UserProfileActivity : BindableAppCompatActivity<UserProfileViewModel, UserProfileParameters>
    {
        //// ... some existing code is hidden for convenience
        
        public event EventHandler DateOfBirthdayChanged;

        public DateTime DateOfBirthday { get; set; }

        public override void Bind(BindingSet<LanguagesViewModel> bindingSet)
        {
            base.Bind(bindingSet);

            //// ... some existing code is hidden for convenience

            bindingSet.Bind(this)
                .For(v => v.DateOfBirthdayChangedBinding())
                .To(vm => vm.DateOfBirthday)
                .WithConversion<StringToDateTimeValueConverter>();
        }
 
        // Fired by a button click
        private void OpenPicker(object sender, EventArgs eventArgs)
        {
            var initialValue = DateOfBirthday == DateTime.MinValue ? DateTime.UtcNow : DateOfBirthday;
            var fr = new DatePickerFragment(OnDatePicked, initialValue);
            fr.ShowsDialog = true;
            fr.Show(SupportFragmentManager, "DatePicker");
        }

        // Callback used by DatePickerFragment
        private void OnDatePicked(DateTime dt)
        {
            DateOfBirthday = dt;
            DateOfBirthdayChanged?.Invoke(this, EventArgs.Empty); // Trigger our Data Binding here
        }
    }
}

```

When ``DateOfBirthdayChanged`` event is raised, this triggers the Data Binding and pushes the data to the View Model.
Also we see here the FlexiMvvm's overridden ``Bind()`` method where ``DateOfBirthdayChangedBinding()`` extension method is used, with the ``StringToDateTimeValueConverter`` ValueConverter we've defined earlier.

Let's create a new file, Sample.Droid / Bindings / UserProfileActivityBindings.cs, add wire up the View event and data setter in the ``DateOfBirthdayChangedBinding()`` extension method:

```cs
using System;
using FlexiMvvm.Bindings;
using FlexiMvvm.Bindings.Custom;
using Sample.Droid.Views;

namespace Sample.Droid.Bindings
{
    public static class UserProfileActivityBindings
    {
        public static TargetItemBinding<UserProfileActivity, DateTime> DateOfBirthdayChangedBinding(this IItemReference<UserProfileActivity> target)
        {
            if (target == null)
            {
                throw new ArgumentNullException(nameof(target));
            }

            return new TargetItemTwoWayCustomBinding<UserProfileActivity, DateTime>(
                target,
                (t, handler) => t.DateOfBirthdayChanged += handler, // to notify about new value
                (t, handler) => t.DateOfBirthdayChanged -= handler, // to gracefully clean up
                (t, canExecuteCommand) => { }, // in our case, always enabled
                t => t.DateOfBirthday, // to get the value 
                (t, @value) => t.DateOfBirthday = @value, // to set the value
                () => "DateOfBirthdayChanged"); // to log for diagnostics
        }
    }
}

```

As we can see, ``TargetItemTwoWayCustomBinding`` type has only 2 type parameters - this is due to our View's ``EventHandler DateOfBirthdayChanged`` event which does not provide the value with a parameter. So, no need to specify it in the Data Binding wiring code anyhow. Instead, we provided two functions to get the value from ``UserProfileActivity`` and set it back.

And that's is - Android is done.

#### iOS

For iOS, the following steps are already straightforward:
1. Prepare the **Target** - UserProfileView, again with the ``EventHandler DateOfBirthdayChanged`` event and ``DateTime DateOfBirth`` data property.
2. Add **extension method** - DateOfBirthdayChangedBinding(), to define the Data Binding.
3. **Use** the extension method in UserProfileViewController.

This is the Sample.iOS / Views / UserProfileView.cs:

```cs
//// ... some existing code is hidden for convenience

namespace Sample.iOS.Views
{
    public class UserProfileView : LayoutView
    {
        public event EventHandler DateOfBirthdayChanged;

        public DateTime DateOfBirth { get; set; }

        //// ... some existing code is hidden for convenience

        // Callback for a button, to show up the Date Picker
        private void OnDateOfBirthTouchUpInside(object sender, EventArgs e)
        {
            SelectDateOfBirthButton.Hidden = true;
            DatePicker.Hidden = false;

            DatePicker.SetDate((NSDate)DateOfBirth, true);
        }

        // Callback for a Date Picker when its value is selected
        private void OnDateOfBirthSelected(object sender, EventArgs eventArgs)
        {
            SelectDateOfBirthButton.Hidden = false;
            DatePicker.Hidden = true;

            DateOfBirth = (DateTime)DatePicker.Date;
            DateOfBirthdayChanged?.Invoke(this, EventArgs.Empty); // Trigger our Data Binding here
        }
    }
}

```

The Data Binding definition in a new Sample.iOS / Bindings / UserProfileViewBindings.cs file:

```cs
using System;
using FlexiMvvm.Bindings.Custom;
using Sample.iOS.Views;

namespace FlexiMvvm.Bindings
{
    public static class UserProfileViewBindings
    {
        public static TargetItemBinding<UserProfileView, DateTime> DateOfBirthdayChangedBinding(this IItemReference<UserProfileView> target)
        {
            if (target == null)
            {
                throw new ArgumentNullException(nameof(target));
            }

            return new TargetItemTwoWayCustomBinding<UserProfileView, DateTime>(
                target,
                (t, handler) => t.DateOfBirthdayChanged += handler, // to notify about new value
                (t, handler) => t.DateOfBirthdayChanged -= handler, // to gracefully clean up
                (t, canExecuteCommand) => { }, // in our case, always enabled
                t => t.DateOfBirth, // to get the UserProfileView value
                (t, @value) => t.DateOfBirth = @value, // to set the UserProfileView value
                () => "DateOfBirthdayChanged"); // to log for diagnostics
        }
    }
}

```

And usage of the Data Binding by Sample.iOS / Views / UserProfileViewController.cs:

```cs
//// ... some existing code is hidden for convenience

namespace Sample.iOS.Views
{
    public class UserProfileViewController : BindableViewController<UserProfileViewModel, UserProfileParameters>
    {
        //// ... some existing code is hidden for convenience

        public override void Bind(BindingSet<LanguagesViewModel> bindingSet)
        {
            base.Bind(bindingSet);

            //// ... some existing code is hidden for convenience

            bindingSet.Bind(View)
                .For(v => v.DateOfBirthdayChangedBinding())
                .To(vm => vm.DateOfBirthday)
                .WithConversion<StringToDateTimeValueConverter>();
        }
    }
}

```

That's it. Again, we're unlimited with native capabilities in a View implementation. To segregate common logic, we just create an extension method which specifies how to be notified and how to get/set the Target value.

---

[Next: ...](index.md)
