using FlexiMvvm.Bindings;
using FlexiMvvm.Views;
using Sample.Core.Presentation.ValueConverters;
using Sample.Core.Presentation.ViewModels;

namespace Sample.iOS.Views
{
    public class UserProfileViewController : BindableViewController<UserProfileViewModel, UserProfileParameters>
    {
        public new UserProfileView View
        {
            get => (UserProfileView)base.View;
            set => base.View = value;
        }

        public override void LoadView()
        {
            View = new UserProfileView();
        }

        public override void Bind(BindingSet<UserProfileViewModel> bindingSet)
        {
            base.Bind(bindingSet);

            //// Two-way default bindings

            bindingSet.Bind(View.FirstName)
                .For(v => v.TextAndEditingDidEndBinding())
                .To(vm => vm.FirstName);

            bindingSet.Bind(View.LastName)
                .For(v => v.TextAndEditingDidEndBinding())
                .To(vm => vm.LastName);

            bindingSet.Bind(View.Email)
                .For(v => v.TextAndEditingDidEndBinding())
                .To(vm => vm.Email);

            //// One-way-to-source default binding

            bindingSet.Bind(View.SelectLanguageButton)
                .For(v => v.TouchUpInsideBinding())
                .To(vm => vm.NavigateToLanguagesCommand);

            bindingSet.Bind(View.SaveButton)
                .For(v => v.TouchUpInsideBinding())
                .To(vm => vm.SaveCommand);

            //// One-way default binding

            bindingSet.Bind(View.LanguageSelected)
                .For(v => v.TextBinding())
                .To(vm => vm.Language);

            bindingSet.Bind(View.DateOfBirthSelected)
                .For(v => v.TextBinding())
                .To(vm => vm.DateOfBirthday);

            //// Custom Two-way Data Binding with Value Converter

            bindingSet.Bind(View)
                .For(v => v.DateOfBirthdayChangedBinding())
                .To(vm => vm.DateOfBirthday)
                .WithConversion<StringToDateTimeValueConverter>();
        }
    }
}
