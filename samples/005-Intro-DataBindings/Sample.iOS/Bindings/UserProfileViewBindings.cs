using System;
using FlexiMvvm.Bindings.Custom;
using Sample.iOS.Views;

namespace FlexiMvvm.Bindings
{
    public static class UserProfileViewBindings
    {
        public static TargetItemBinding<UserProfileView, DateTime> DateOfBirthdayChangedBinding(this IItemReference<UserProfileView> target)
        {
            if (target == null)
            {
                throw new ArgumentNullException(nameof(target));
            }

            return new TargetItemTwoWayCustomBinding<UserProfileView, DateTime>(
                target,
                (t, handler) => t.DateOfBirthdayChanged += handler,
                (t, handler) => t.DateOfBirthdayChanged -= handler,
                (t, canExecuteCommand) => { },
                t => t.DateOfBirth,
                (t, @value) => t.DateOfBirth = @value,
                () => "DateOfBirthdayChanged");
        }
    }
}
