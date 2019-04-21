using Android.App;
using Android.OS;
using Android.Views;
using Android.Widget;
using FlexiMvvm;
using FlexiMvvm.Bindings;
using FlexiMvvm.Ioc;
using FlexiMvvm.ViewModels;
using FlexiMvvm.Views;
using Sample.Core.Presentation.ViewModels;

namespace Sample.Droid
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme.NoActionBar", MainLauncher = true, NoHistory = true)]
    public class MainActivity : BindableAppCompatActivity<UserProfileViewModel>
    {
        private EditText _firstName;
        private EditText _lastName;
        private EditText _email;
        private Button _save;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            InitApp();

            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.activity_main);
            SetSupportActionBar(FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.toolbar));

            _firstName = FindViewById<EditText>(Resource.Id.firstName);
            _lastName = FindViewById<EditText>(Resource.Id.lastName);
            _email = FindViewById<EditText>(Resource.Id.email);
            _save = FindViewById<Button>(Resource.Id.save);
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

        private void InitApp()
        {
            var container = new SimpleIoc();
            container.Register(() => new UserProfileViewModel());

            LifecycleViewModelProvider.SetFactory(
                new DefaultLifecycleViewModelFactory(container));
        }
    }
}
