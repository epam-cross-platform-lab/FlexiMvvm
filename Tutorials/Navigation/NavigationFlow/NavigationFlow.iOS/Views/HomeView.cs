using Cirrious.FluentLayouts.Touch;
using FlexiMvvm.Views;
using UIKit;

namespace NavigationFlow.iOS.Views
{
    internal sealed class HomeView : LayoutView
    {
        private UILabel HeaderLabel { get; set; }

        public UILabel ResultLabel { get; private set; }

        public UIButton NextButton { get; private set; }

        protected override void SetupSubviews()
        {
            base.SetupSubviews();

            BackgroundColor = UIColor.White;

            HeaderLabel = new UILabel { Text = "Home screen" };

            ResultLabel = new UILabel();

            NextButton = new UIButton(UIButtonType.System);
            NextButton.SetTitle("Go to separate flow", UIControlState.Normal);
        }

        protected override void SetupLayout()
        {
            base.SetupLayout();

            this.AddLayoutSubview(HeaderLabel)
                .AddLayoutSubview(ResultLabel)
                .AddLayoutSubview(NextButton);
        }

        protected override void SetupLayoutConstraints()
        {
            base.SetupLayoutConstraints();

            this.SubviewsDoNotTranslateAutoresizingMaskIntoConstraints();

            this.AddConstraints(
                HeaderLabel.WithSameCenterX(this),
                HeaderLabel.WithSameCenterY(this));

            this.AddConstraints(
                ResultLabel.Below(HeaderLabel, 24),
                ResultLabel.WithSameCenterX(this));

            this.AddConstraints(
                NextButton.Below(ResultLabel, 24),
                NextButton.WithSameCenterX(this));
        }
    }
}