using Android.App;
using Android.OS;
using FlexiMvvm.Bindings;
using FlexiMvvm.Views;
using NavigationFlow.Core.ViewModels.CustomFlow;

namespace NavigationFlow.Droid.Views.CustomFlow
{
    [Activity(Label = "ThirdActivity")]
    internal sealed class ThirdActivity : BindableAppCompatActivity<ThirdViewModel>
    {
        private ThirdActivityViewHolder ViewHolder { get; set; }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.activity_third);

            ViewHolder = new ThirdActivityViewHolder(this);
        }

        public override void Bind(BindingSet<ThirdViewModel> bindingSet)
        {
            bindingSet.Bind(ViewHolder.ResultEditText)
                .For(v => v.TextChangedBinding())
                .To(vm => vm.Result);

            bindingSet.Bind(ViewHolder.AcceptButton)
                .For(v => v.ClickBinding())
                .To(vm => vm.AcceptCommand);

            bindingSet.Bind(ViewHolder.DeclineButton)
                .For(v => v.ClickBinding())
                .To(vm => vm.DeclineCommand);
        }
    }
}