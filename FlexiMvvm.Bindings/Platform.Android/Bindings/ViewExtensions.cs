// =========================================================================
// Copyright 2018 EPAM Systems, Inc.
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

using Android.Views;
using FlexiMvvm.Bindings.Custom;
using JetBrains.Annotations;

namespace FlexiMvvm.Bindings
{
    public static class ViewExtensions
    {
        [NotNull]
        public static TargetItemBinding<View, object> ClickBinding(
            [NotNull] this IItemReference<View> viewReference,
            bool trackCanExecuteCommandChanged = false)
        {
            return new TargetItemOneWayToSourceCustomBinding<View, object>(
                viewReference,
                (view, eventHandler) => view.NotNull().Click += eventHandler,
                (view, eventHandler) => view.NotNull().Click -= eventHandler,
                (view, canExecuteCommand) =>
                {
                    if (trackCanExecuteCommandChanged)
                    {
                        view.NotNull().Enabled = canExecuteCommand;
                    }
                },
                view => null,
                () => "Click");
        }

        [NotNull]
        public static TargetItemBinding<View, object> FocusChangeBinding(
            [NotNull] this IItemReference<View> viewReference,
            FocusDirection focusDirection,
            bool trackCanExecuteCommandChanged = false)
        {
            return new TargetItemOneWayToSourceCustomBinding<View, object, View.FocusChangeEventArgs>(
                viewReference,
                (view, eventHandler) => view.NotNull().FocusChange += eventHandler,
                (view, eventHandler) => view.NotNull().FocusChange -= eventHandler,
                (view, canExecuteCommand) =>
                {
                    if (trackCanExecuteCommandChanged)
                    {
                        view.NotNull().Enabled = canExecuteCommand;
                    }
                },
                (view, eventArgs) =>
                {
                    switch (focusDirection)
                    {
                        case FocusDirection.InOut:
                            return true;
                        case FocusDirection.In:
                            return eventArgs.NotNull().HasFocus;
                        case FocusDirection.Out:
                            return !eventArgs.NotNull().HasFocus;
                        default:
                            return false;
                    }
                },
                () => "FocusChange");
        }

        [NotNull]
        public static TargetItemBinding<View, object> LongClickBinding(
            [NotNull] this IItemReference<View> viewReference,
            bool trackCanExecuteCommandChanged = false)
        {
            return new TargetItemOneWayToSourceCustomBinding<View, object, View.LongClickEventArgs>(
                viewReference,
                (view, eventHandler) => view.NotNull().LongClick += eventHandler,
                (view, eventHandler) => view.NotNull().LongClick -= eventHandler,
                (view, canExecuteCommand) =>
                {
                    if (trackCanExecuteCommandChanged)
                    {
                        view.NotNull().Enabled = canExecuteCommand;
                    }
                },
                (view, eventArgs) => null,
                () => "LongClick");
        }
    }
}
