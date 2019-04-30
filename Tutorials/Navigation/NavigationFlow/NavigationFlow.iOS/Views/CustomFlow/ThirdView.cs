using Cirrious.FluentLayouts.Touch;
using FlexiMvvm.Views;
using UIKit;

namespace NavigationFlow.iOS.Views.CustomFlow
{
    internal sealed class ThirdView : LayoutView
    {
        public UITextField ResultTextField { get; private set; }

        public UIButton AcceptButton { get; private set; }

        public UIButton DeclineButton { get; private set; }

        protected override void SetupSubviews()
        {
            base.SetupSubviews();

            BackgroundColor = UIColor.White;

            ResultTextField = new UITextField
            {
                AccessibilityHint = "Enter result",
                BackgroundColor = UIColor.Yellow
            };

            AcceptButton = new UIButton(UIButtonType.System);
            AcceptButton.SetTitle("Accept", UIControlState.Normal);

            DeclineButton = new UIButton(UIButtonType.System);
            DeclineButton.SetTitle("Decline", UIControlState.Normal);
        }

        protected override void SetupLayout()
        {
            base.SetupLayout();

            this.AddLayoutSubview(ResultTextField)
                .AddLayoutSubview(AcceptButton)
                .AddLayoutSubview(DeclineButton);
        }

        protected override void SetupLayoutConstraints()
        {
            base.SetupLayoutConstraints();

            this.SubviewsDoNotTranslateAutoresizingMaskIntoConstraints();

            this.AddConstraints(
                ResultTextField.AtLeftOf(this, 24),
                ResultTextField.AtRightOf(this, 24),
                ResultTextField.WithSameCenterY(this));

            this.AddConstraints(
                AcceptButton.Below(ResultTextField, 24),
                AcceptButton.WithSameCenterX(this));

            this.AddConstraints(
                DeclineButton.Below(AcceptButton, 24),
                DeclineButton.WithSameCenterX(this));
        }
    }
}