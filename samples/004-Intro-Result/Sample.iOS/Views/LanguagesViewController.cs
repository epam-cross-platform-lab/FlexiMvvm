using System;
using FlexiMvvm.Bindings;
using FlexiMvvm.Views;
using Sample.Core.Presentation.ViewModels;

namespace Sample.iOS.Views
{
    public class LanguagesViewController : BindableViewController<LanguagesViewModel>
    {
        public LanguagesViewController()
        {
            Title = "Languages";
        }

        public event EventHandler<string> LanguageSelected;

        public new LanguagesView View
        {
            get => (LanguagesView)base.View;
            set => base.View = value;
        }

        public override void LoadView()
        {
            View = new LanguagesView();
            View.LanguageSelected += OnLanguageSelected;
        }

        public override void Bind(BindingSet<LanguagesViewModel> bindingSet)
        {
            base.Bind(bindingSet);

            bindingSet.Bind(this)
                .For(v => v.LanguageSelectedBinding())
                .To(vm => vm.SelectLanguage);
        }

        private void OnLanguageSelected(object sender, string @value)
        {
            LanguageSelected?.Invoke(this, @value);
        }
    }
}
