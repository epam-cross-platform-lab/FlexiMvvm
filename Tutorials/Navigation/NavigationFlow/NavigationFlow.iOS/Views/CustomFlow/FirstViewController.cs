using FlexiMvvm.Bindings;
using FlexiMvvm.Views;
using NavigationFlow.Core.ViewModels.CustomFlow;
using UIKit;

namespace NavigationFlow.iOS.Views.CustomFlow
{
    internal sealed class FirstViewController : BindableViewController<FirstViewModel>
    {
        private UIBarButtonItem CloseButton { get; } = new UIBarButtonItem("Close", UIBarButtonItemStyle.Plain, null);

        public new FirstView View
        {
            get => (FirstView)base.View;
            set => base.View = value;
        }

        public override void LoadView()
        {
            View = new FirstView();
        }

        public override void Bind(BindingSet<FirstViewModel> bindingSet)
        {
            base.Bind(bindingSet);

            bindingSet.Bind(View.NextButton)
                .For(v => v.TouchUpInsideBinding())
                .To(vm => vm.GoToNextCommand);

            bindingSet.Bind(CloseButton)
                .For(v => v.ClickedBinding())
                .To(vm => vm.CloseFlowCommand);
        }

        public override void ViewWillAppear(bool animated)
        {
            base.ViewWillAppear(animated);

            NavigationItem.LeftBarButtonItem = CloseButton;
        }
    }
}