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
            if (viewReference == null)
                throw new ArgumentNullException(nameof(viewReference));

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
                () => $"{nameof(View.Click)}");
        }

        [NotNull]
        public static TargetItemBinding<View, bool> EnabledBinding(
            [NotNull] this IItemReference<View> viewReference)
        {
            if (viewReference == null)
                throw new ArgumentNullException(nameof(viewReference));

            return new TargetItemOneWayCustomBinding<View, bool>(
                viewReference,
                (view, enabled) => view.NotNull().Enabled = enabled,
                () => $"{nameof(View.Enabled)}");
        }

        [NotNull]
        public static TargetItemBinding<View, object> FocusChangeBinding(
            [NotNull] this IItemReference<View> viewReference,
            FocusDirection focusDirection = FocusDirection.InOut,
            bool trackCanExecuteCommandChanged = false)
        {
            if (viewReference == null)
                throw new ArgumentNullException(nameof(viewReference));

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
                (view, eventArgs) => null,
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
                () => $"{nameof(View.FocusChange)}");
        }

        [NotNull]
        public static TargetItemBinding<View, bool> KeepScreenOnBinding(
            [NotNull] this IItemReference<View> viewReference)
        {
            if (viewReference == null)
                throw new ArgumentNullException(nameof(viewReference));

            return new TargetItemOneWayCustomBinding<View, bool>(
                viewReference,
                (view, keepScreenOn) => view.NotNull().KeepScreenOn = keepScreenOn,
                () => $"{nameof(View.KeepScreenOn)}");
        }

        [NotNull]
        public static TargetItemBinding<View, object> LongClickBinding(
            [NotNull] this IItemReference<View> viewReference,
            bool trackCanExecuteCommandChanged = false)
        {
            if (viewReference == null)
                throw new ArgumentNullException(nameof(viewReference));

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
                () => $"{nameof(View.LongClick)}");
        }

        [NotNull]
        public static TargetItemBinding<View, bool> SelectedBinding(
            [NotNull] this IItemReference<View> viewReference)
        {
            if (viewReference == null)
                throw new ArgumentNullException(nameof(viewReference));

            return new TargetItemOneWayCustomBinding<View, bool>(
                viewReference,
                (view, selected) => view.NotNull().Selected = selected,
                () => $"{nameof(View.Selected)}");
        }

        [NotNull]
        public static TargetItemBinding<View, ViewStates> VisibilityBinding(
            [NotNull] this IItemReference<View> viewReference)
        {
            if (viewReference == null)
                throw new ArgumentNullException(nameof(viewReference));

            return new TargetItemOneWayCustomBinding<View, ViewStates>(
                viewReference,
                (view, visibility) => view.NotNull().Visibility = visibility,
                () => $"{nameof(View.Visibility)}");
        }
    }
}
