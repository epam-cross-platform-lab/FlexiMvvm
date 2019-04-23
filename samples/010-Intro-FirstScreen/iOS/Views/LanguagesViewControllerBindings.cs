using System;
using FlexiMvvm.Bindings;
using FlexiMvvm.Bindings.Custom;

namespace FirstScreen.iOS.Views
{
    public static class LanguagesViewControllerBindings
    {
        public static TargetItemBinding<LanguagesViewController, string> LanguageSelectedBinding(
            this IItemReference<LanguagesViewController> target)
        {
            if (target == null)
            {
                throw new ArgumentNullException(nameof(target));
            }

            return new TargetItemOneWayToSourceCustomBinding<LanguagesViewController, string, string>(
                target,
                (t, eventHandler) => t.LanguageSelected += eventHandler,
                (t, eventHandler) => t.LanguageSelected -= eventHandler,
                (t, canExecuteCommand) => { },
                (t, @value) => @value,
                () => "LanguageSelected");
        }
    }
}
