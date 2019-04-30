using FlexiMvvm.Bindings;
using FlexiMvvm.Views;
using NavigationFlow.Core.ViewModels;

namespace NavigationFlow.iOS.Views
{
    internal sealed class HomeViewController : BindableViewController<HomeViewModel>
    {
        public new HomeView View
        {
            get => (HomeView)base.View;
            set => base.View = value;
        }

        public override void LoadView()
        {
            View = new HomeView();
        }

        public override void Bind(BindingSet<HomeViewModel> bindingSet)
        {
            base.Bind(bindingSet);

            bindingSet.Bind(View.NextButton)
                .For(v => v.TouchUpInsideBinding())
                .To(vm => vm.StartSeparateFlowCommand);

            bindingSet.Bind(View.ResultLabel)
                .For(v => v.TextBinding())
                .To(vm => vm.Result);
        }
    }
}