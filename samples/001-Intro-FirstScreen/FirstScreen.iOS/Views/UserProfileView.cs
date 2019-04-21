using Cirrious.FluentLayouts.Touch;
using FirstScreen.iOS.Themes;
using FlexiMvvm.Views;
using UIKit;

namespace FirstScreen.iOS.Views
{
    public class UserProfileView : LayoutView
    {
        private UILabel FirstNameLabel { get; set; }

        private UILabel LastNameLabel { get; set; }

        private UILabel EmailLabel { get; set; }

        public UITextField FirstName { get; set; }

        public UITextField LastName { get; set; }

        public UITextField Email { get; set; }

        public UIButton SaveButton { get; private set; }

        protected override void SetupSubviews()
        {
            base.SetupSubviews();

            BackgroundColor = Theme.Colors.BackgroundColor;

            FirstNameLabel = new UILabel().AsRegularBodyStyle("First Name:");
            LastNameLabel = new UILabel().AsRegularBodyStyle("Last Name:");
            EmailLabel = new UILabel().AsRegularBodyStyle("Email:");

            FirstName = new UITextField().AsTextFieldStyle("...");
            LastName = new UITextField().AsTextFieldStyle("...");
            Email = new UITextField().AsTextFieldStyle("example@icloud.com");

            SaveButton = new UIButton().AsRegularButtonStyle("Save");
        }

        protected override void SetupLayout()
        {
            base.SetupLayout();

            AddSubview(FirstNameLabel);
            AddSubview(LastNameLabel);
            AddSubview(EmailLabel);
            AddSubview(FirstName);
            AddSubview(LastName);
            AddSubview(Email);
            AddSubview(SaveButton);
        }

        protected override void SetupLayoutConstraints()
        {
            base.SetupLayoutConstraints();
            this.SubviewsDoNotTranslateAutoresizingMaskIntoConstraints();

            this.AddConstraints(
                FirstNameLabel.AtLeftOf(this, Theme.Dimensions.Inset2x),
                FirstNameLabel.AtTopOfSafeArea(this, Theme.Dimensions.Inset2x),
                FirstNameLabel.AtRightOf(this, Theme.Dimensions.Inset2x),
                FirstNameLabel.Height().EqualTo(Theme.Dimensions.LabelBodyHeight));
            this.AddConstraints(
                FirstName.AtLeftOf(this, Theme.Dimensions.Inset3x),
                FirstName.Below(FirstNameLabel, Theme.Dimensions.Inset1x),
                FirstName.AtRightOf(this, Theme.Dimensions.Inset2x),
                FirstName.Height().EqualTo(Theme.Dimensions.TextFieldRegularHeight));

            this.AddConstraints(
                LastNameLabel.AtLeftOf(this, Theme.Dimensions.Inset2x),
                LastNameLabel.Below(FirstName, Theme.Dimensions.Inset1x),
                LastNameLabel.AtRightOf(this, Theme.Dimensions.Inset2x),
                LastNameLabel.Height().EqualTo(Theme.Dimensions.LabelBodyHeight));
            this.AddConstraints(
                LastName.AtLeftOf(this, Theme.Dimensions.Inset3x),
                LastName.Below(LastNameLabel, Theme.Dimensions.Inset1x),
                LastName.AtRightOf(this, Theme.Dimensions.Inset2x),
                LastName.Height().EqualTo(Theme.Dimensions.TextFieldRegularHeight));

            this.AddConstraints(
                EmailLabel.AtLeftOf(this, Theme.Dimensions.Inset2x),
                EmailLabel.Below(LastName, Theme.Dimensions.Inset1x),
                EmailLabel.AtRightOf(this, Theme.Dimensions.Inset2x),
                EmailLabel.Height().EqualTo(Theme.Dimensions.LabelBodyHeight));
            this.AddConstraints(
                Email.AtLeftOf(this, Theme.Dimensions.Inset3x),
                Email.Below(EmailLabel, Theme.Dimensions.Inset1x),
                Email.AtRightOf(this, Theme.Dimensions.Inset2x),
                Email.Height().EqualTo(Theme.Dimensions.TextFieldRegularHeight));

            this.AddConstraints(
                SaveButton.Width().EqualTo(80),
                SaveButton.Below(Email, Theme.Dimensions.Inset2x),
                SaveButton.AtRightOf(this, Theme.Dimensions.Inset2x),
                SaveButton.Height().EqualTo(Theme.Dimensions.ButtonRegularHeight));
        }
    }
}
