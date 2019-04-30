using Android.App;
using Android.OS;
using FlexiMvvm.Bindings;
using FlexiMvvm.Views;
using NavigationFlow.Core.ViewModels.CustomFlow;

namespace NavigationFlow.Droid.Views.CustomFlow
{
    [Activity(Label = "FirstActivity")]
    internal sealed class FirstActivity : BindableAppCompatActivity<FirstViewModel>
    {
        private FirstActivityViewHolder ViewHolder { get; set; }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.activity_first);

            ViewHolder = new FirstActivityViewHolder(this);
        }

        public override void Bind(BindingSet<FirstViewModel> bindingSet)
        {
            bindingSet.Bind(ViewHolder.NextButton)
                .For(v => v.ClickBinding())
                .To(vm => vm.GoToNextCommand);
        }
    }
}