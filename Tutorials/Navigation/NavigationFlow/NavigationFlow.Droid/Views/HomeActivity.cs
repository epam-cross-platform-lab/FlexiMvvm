using Android.App;
using Android.OS;
using FlexiMvvm.Bindings;
using FlexiMvvm.Views;
using NavigationFlow.Core.ViewModels;

namespace NavigationFlow.Droid.Views
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme")]
    internal sealed class HomeActivity : BindableAppCompatActivity<HomeViewModel>
    {
        private HomeActivityViewHolder ViewHolder { get; set; }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.activity_home);

            ViewHolder = new HomeActivityViewHolder(this);
        }

        public override void Bind(BindingSet<HomeViewModel> bindingSet)
        {
            bindingSet.Bind(ViewHolder.ResultTextView)
                .For(v => v.TextBinding())
                .To(vm => vm.Result);

            bindingSet.Bind(ViewHolder.NextButton)
                .For(v => v.ClickBinding())
                .To(vm => vm.StartSeparateFlowCommand);
        }
    }
}