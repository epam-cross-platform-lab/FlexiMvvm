using System;
using FlexiMvvm.Bindings;
using FlexiMvvm.Bindings.Custom;
using Sample.iOS.Views;

namespace Sample.iOS.Bindings
{
    public static class LanguagesViewBindings
    {
        public static TargetItemBinding<LanguagesView, string> LanguageSelectedBinding(
            this IItemReference<LanguagesView> target)
        {
            if (target == null)
            {
                throw new ArgumentNullException(nameof(target));
            }

            return new TargetItemOneWayToSourceCustomBinding<LanguagesView, string, string>(
                target,
                (t, eventHandler) => t.LanguageSelected += eventHandler,
                (t, eventHandler) => t.LanguageSelected -= eventHandler,
                (t, canExecuteCommand) => { },
                (t, @value) => @value,
                () => "LanguageSelected");
        }
    }
}
