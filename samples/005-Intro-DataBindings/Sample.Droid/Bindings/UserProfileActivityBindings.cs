using System;
using FlexiMvvm.Bindings;
using FlexiMvvm.Bindings.Custom;
using Sample.Droid.Views;

namespace Sample.Droid.Bindings
{
    public static class UserProfileActivityBindings
    {
        public static TargetItemBinding<UserProfileActivity, DateTime> DateOfBirthdayChangedBinding(this IItemReference<UserProfileActivity> target)
        {
            if (target == null)
            {
                throw new ArgumentNullException(nameof(target));
            }

            return new TargetItemTwoWayCustomBinding<UserProfileActivity, DateTime>(
                target,
                (t, handler) => t.DateOfBirthdayChanged += handler,
                (t, handler) => t.DateOfBirthdayChanged -= handler,
                (t, canExecuteCommand) => { },
                t => t.DateOfBirthday,
                (t, @value) => t.DateOfBirthday = @value,
                () => "DateOfBirthdayChanged");
        }
    }
}
