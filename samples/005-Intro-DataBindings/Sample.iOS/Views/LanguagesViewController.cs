using System;
using FlexiMvvm.Bindings;
using FlexiMvvm.Views;
using Sample.Core.Presentation.ViewModels;
using Sample.iOS.Bindings;

namespace Sample.iOS.Views
{
    public class LanguagesViewController : BindableViewController<LanguagesViewModel>
    {
        public LanguagesViewController()
        {
            Title = "Languages";
        }

        public new LanguagesView View
        {
            get => (LanguagesView)base.View;
            set => base.View = value;
        }

        public override void LoadView()
        {
            View = new LanguagesView();
        }

        public override void Bind(BindingSet<LanguagesViewModel> bindingSet)
        {
            base.Bind(bindingSet);

            bindingSet.Bind(View)
                .For(v => v.LanguageSelectedBinding())
                .To(vm => vm.SelectLanguage);
        }
    }
}
