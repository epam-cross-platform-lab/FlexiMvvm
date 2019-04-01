// =========================================================================
// Copyright 2019 EPAM Systems, Inc.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
// http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// =========================================================================

using System;
using FlexiMvvm.Bindings.Custom;
using FlexiMvvm.Views;

namespace FlexiMvvm.Bindings
{
    /// <summary>
    /// Provides a set of static methods for creating bindings on <see cref="IOptionsMenuSource"/> members.
    /// </summary>
    public static class OptionsMenuSourceExtensions
    {
        /// <summary>
        /// One way to source binding on the <see cref="IOptionsMenuSource.OnOptionsItemSelectedCalled"/> event. Selected item Id is passed as a value.
        /// </summary>
        /// <param name="optionsMenuSourceReference">The options menu source reference.</param>
        /// <param name="itemId">The item Id for which the event is expected.</param>
        /// <returns>The binding instance.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="optionsMenuSourceReference"/> is <c>null</c>.</exception>
        public static TargetItemBinding<IOptionsMenuSource, object> OnOptionsItemSelectedBinding(
            this IItemReference<IOptionsMenuSource> optionsMenuSourceReference,
            int itemId)
        {
            if (optionsMenuSourceReference == null)
                throw new ArgumentNullException(nameof(optionsMenuSourceReference));

            return new TargetItemOneWayToSourceCustomBinding<IOptionsMenuSource, object, OptionsItemSelectedEventArgs>(
                optionsMenuSourceReference,
                (optionsMenuSource, handler) => optionsMenuSource.OnOptionsItemSelectedCalled += handler,
                (optionsMenuSource, handler) => optionsMenuSource.OnOptionsItemSelectedCalled -= handler,
                (optionsMenuSource, canExecuteCommand) => { },
                (optionsMenuSource, args) => null,
                (optionsMenuSource, args) =>
                {
                    if (args.Item.ItemId == itemId)
                    {
                        args.IsHandled = true;

                        return true;
                    }

                    return false;
                },
                () => $"{nameof(IOptionsMenuSource.OnOptionsItemSelectedCalled)}");
        }
    }
}
