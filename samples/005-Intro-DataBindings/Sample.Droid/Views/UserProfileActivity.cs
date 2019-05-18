using System;
using Android.App;
using Android.OS;
using Android.Views;
using Android.Widget;
using FlexiMvvm;
using FlexiMvvm.Bindings;
using FlexiMvvm.Bindings.Converters;
using FlexiMvvm.Views;
using Sample.Core.Presentation.ViewModels;
using Sample.Droid.Bindings;

namespace Sample.Droid.Views
{
    [Activity(Theme = "@style/AppTheme.NoActionBar")]
    public class UserProfileActivity : BindableAppCompatActivity<UserProfileViewModel, UserProfileParameters>
    {
        private EditText _firstName;
        private EditText _lastName;
        private EditText _email;
        private TextView _language;
        private Button _selectLanguage;
        private TextView _dateOfBirth;
        private Button _save;
        private Button _openPicker;

        public event EventHandler DateOfBirthdayChanged;

        public DateTime DateOfBirthday { get; set; }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.activity_main);
            SetSupportActionBar(FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.toolbar));

            _firstName = FindViewById<EditText>(Resource.Id.firstName);
            _lastName = FindViewById<EditText>(Resource.Id.lastName);
            _email = FindViewById<EditText>(Resource.Id.email);
            _language = FindViewById<TextView>(Resource.Id.language);
            _selectLanguage = FindViewById<Button>(Resource.Id.selectLanguage);
            _dateOfBirth = FindViewById<TextView>(Resource.Id.dateOfBirth);
            _save = FindViewById<Button>(Resource.Id.save);
            _openPicker = FindViewById<Button>(Resource.Id.openDatePicker);
            _openPicker.Click += OpenPicker;
        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.menu_main, menu);
            return true;
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            int id = item.ItemId;
            if (id == Resource.Id.action_settings)
            {
                return true;
            }

            return base.OnOptionsItemSelected(item);
        }

        public override void Bind(BindingSet<UserProfileViewModel> bindingSet)
        {
            base.Bind(bindingSet);

            //// Two-way default bindings

            bindingSet.Bind(_firstName)
                .For(v => v.TextAndTextChangedBinding())
                .To(vm => vm.FirstName);

            bindingSet.Bind(_lastName)
                .For(v => v.TextAndTextChangedBinding())
                .To(vm => vm.LastName);

            bindingSet.Bind(_email)
                .For(v => v.TextAndTextChangedBinding())
                .To(vm => vm.Email);

            //// One-way-to-source default binding

            bindingSet.Bind(_selectLanguage)
                .For(v => v.ClickBinding())
                .To(vm => vm.NavigateToLanguagesCommand);

            bindingSet.Bind(_save)
                .For(v => v.ClickBinding())
                .To(vm => vm.SaveCommand);

            //// One-way default binding

            bindingSet.Bind(_language)
                .For(v => v.TextBinding())
                .To(vm => vm.Language);

            bindingSet.Bind(_dateOfBirth)
                .For(v => v.TextBinding())
                .To(vm => vm.DateOfBirthday);

            //// Custom Two-way Data Binding with Value Converter

            bindingSet.Bind(this)
                .For(v => v.DateOfBirthdayChangedBinding())
                .To(vm => vm.DateOfBirthday)
                .WithConversion<StringToDateTimeValueConverter>();
        }

        private void OpenPicker(object sender, EventArgs eventArgs)
        {
            var fr = new DatePickerFragment(OnDatePicked, DateOfBirthday == DateTime.MinValue ? DateTime.Now : DateOfBirthday);
            fr.ShowsDialog = true;
            fr.Show(SupportFragmentManager, "DatePicker");
        }

        private void OnDatePicked(DateTime dt)
        {
            DateOfBirthday = dt;
            DateOfBirthdayChanged?.Invoke(this, EventArgs.Empty);
        }
    }
}
