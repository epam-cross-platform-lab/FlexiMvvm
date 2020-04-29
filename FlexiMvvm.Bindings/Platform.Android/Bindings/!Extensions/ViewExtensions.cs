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

namespace FlexiMvvm.Bindings
{
    public static class ViewExtensions
    {
        public static TargetItemBinding<View, object> ClickBinding(
            this IItemReference<View> viewReference,
            bool trackCanExecuteCommandChanged = false)
        {
            if (viewReference == null)
                throw new ArgumentNullException(nameof(viewReference));

            return new TargetItemOneWayToSourceCustomBinding<View, object>(
                viewReference,
                (view, handler) => view.Click += handler,
                (view, handler) => view.Click -= handler,
                (view, canExecuteCommand) =>
                {
                    if (trackCanExecuteCommandChanged)
                    {
                        view.Enabled = canExecuteCommand;
                    }
                },
                view => null,
                () => $"{nameof(View.Click)}");
        }

        public static TargetItemBinding<View, string> ContentDescriptionBinding(
            this IItemReference<View> viewReference)
        {
            if (viewReference == null)
                throw new ArgumentNullException(nameof(viewReference));

            return new TargetItemOneWayCustomBinding<View, string>(
                viewReference,
                (view, contentDescription) => view.ContentDescription = contentDescription,
                () => $"{nameof(View.ContentDescription)}");
        }

        public static TargetItemBinding<View, bool> EnabledBinding(
            this IItemReference<View> viewReference)
        {
            if (viewReference == null)
                throw new ArgumentNullException(nameof(viewReference));

            return new TargetItemOneWayCustomBinding<View, bool>(
                viewReference,
                (view, enabled) => view.Enabled = enabled,
                () => $"{nameof(View.Enabled)}");
        }

        public static TargetItemBinding<View, object> FocusChangeBinding(
            this IItemReference<View> viewReference,
            FocusDirection focusDirection = FocusDirection.InOut,
            bool trackCanExecuteCommandChanged = false)
        {
            if (viewReference == null)
                throw new ArgumentNullException(nameof(viewReference));

            return new TargetItemOneWayToSourceCustomBinding<View, object, View.FocusChangeEventArgs>(
                viewReference,
                (view, handler) => view.FocusChange += handler,
                (view, handler) => view.FocusChange -= handler,
                (view, canExecuteCommand) =>
                {
                    if (trackCanExecuteCommandChanged)
                    {
                        view.Enabled = canExecuteCommand;
                    }
                },
                (view, args) => null,
                (view, args) =>
                {
                    switch (focusDirection)
                    {
                        case FocusDirection.InOut:
                            return true;
                        case FocusDirection.In:
                            return args.HasFocus;
                        case FocusDirection.Out:
                            return !args.HasFocus;
                        default:
                            return false;
                    }
                },
                () => $"{nameof(View.FocusChange)}");
        }

        public static TargetItemBinding<View, bool> KeepScreenOnBinding(
            this IItemReference<View> viewReference)
        {
            if (viewReference == null)
                throw new ArgumentNullException(nameof(viewReference));

            return new TargetItemOneWayCustomBinding<View, bool>(
                viewReference,
                (view, keepScreenOn) => view.KeepScreenOn = keepScreenOn,
                () => $"{nameof(View.KeepScreenOn)}");
        }

        public static TargetItemBinding<View, object> LongClickBinding(
            this IItemReference<View> viewReference,
            bool trackCanExecuteCommandChanged = false)
        {
            if (viewReference == null)
                throw new ArgumentNullException(nameof(viewReference));

            return new TargetItemOneWayToSourceCustomBinding<View, object, View.LongClickEventArgs>(
                viewReference,
                (view, handler) => view.LongClick += handler,
                (view, handler) => view.LongClick -= handler,
                (view, canExecuteCommand) =>
                {
                    if (trackCanExecuteCommandChanged)
                    {
                        view.Enabled = canExecuteCommand;
                    }
                },
                (view, args) => null,
                () => $"{nameof(View.LongClick)}");
        }

        public static TargetItemBinding<View, bool> SelectedBinding(
            this IItemReference<View> viewReference)
        {
            if (viewReference == null)
                throw new ArgumentNullException(nameof(viewReference));

            return new TargetItemOneWayCustomBinding<View, bool>(
                viewReference,
                (view, selected) => view.Selected = selected,
                () => $"{nameof(View.Selected)}");
        }

        public static TargetItemBinding<View, int> SetBackgroundResourceBinding(
            this IItemReference<View> viewReference)
        {
            if (viewReference == null)
                throw new ArgumentNullException(nameof(viewReference));

            return new TargetItemOneWayCustomBinding<View, int>(
                viewReference,
                (view, resid) => view.SetBackgroundResource(resid),
                () => $"{nameof(View.SetBackgroundResource)}");
        }

        public static TargetItemBinding<View, ViewStates> VisibilityBinding(
            this IItemReference<View> viewReference)
        {
            if (viewReference == null)
                throw new ArgumentNullException(nameof(viewReference));

            return new TargetItemOneWayCustomBinding<View, ViewStates>(
                viewReference,
                (view, visibility) => view.Visibility = visibility,
                () => $"{nameof(View.Visibility)}");
        }
    }
}
