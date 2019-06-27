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
using UIKit;

namespace FlexiMvvm.Bindings
{
    public static class UIBarButtonItemExtensions
    {
        public static TargetItemBinding<UIBarButtonItem, object> ClickedBinding(
            this IItemReference<UIBarButtonItem> barButtonItemReference,
            bool trackCanExecuteCommandChanged = false)
        {
            if (barButtonItemReference == null)
                throw new ArgumentNullException(nameof(barButtonItemReference));

            return new TargetItemOneWayToSourceCustomBinding<UIBarButtonItem, object>(
                barButtonItemReference,
                (barButtonItem, handler) => barButtonItem.Clicked += handler,
                (barButtonItem, handler) => barButtonItem.Clicked -= handler,
                (barButtonItem, canExecuteCommand) =>
                {
                    if (trackCanExecuteCommandChanged)
                    {
                        barButtonItem.Enabled = canExecuteCommand;
                    }
                },
                barButtonItem => null,
                () => $"{nameof(UIBarButtonItem.Clicked)}");
        }

        public static TargetItemBinding<UIBarButtonItem, bool> EnabledBinding(
            this IItemReference<UIBarButtonItem> barButtonItemReference)
        {
            if (barButtonItemReference == null)
                throw new ArgumentNullException(nameof(barButtonItemReference));

            return new TargetItemOneWayCustomBinding<UIBarButtonItem, bool>(
                barButtonItemReference,
                (barButtonItem, enabled) => barButtonItem.Enabled = enabled,
                () => $"{nameof(UIBarButtonItem.Enabled)}");
        }

        public static TargetItemBinding<UIBarButtonItem, string> TitleBinding(
            this IItemReference<UIBarButtonItem> barButtonItemReference)
        {
            if (barButtonItemReference == null)
                throw new ArgumentNullException(nameof(barButtonItemReference));

            return new TargetItemOneWayCustomBinding<UIBarButtonItem, string>(
                barButtonItemReference,
                (barButtonItem, title) => barButtonItem.Title = title,
                () => $"{nameof(UIBarButtonItem.Title)}");
        }

        public static TargetItemBinding<UIBarButtonItem, nfloat> WidthBinding(
            this IItemReference<UIBarButtonItem> barButtonItemReference)
        {
            if (barButtonItemReference == null)
                throw new ArgumentNullException(nameof(barButtonItemReference));

            return new TargetItemOneWayCustomBinding<UIBarButtonItem, nfloat>(
                barButtonItemReference,
                (barButtonItem, width) => barButtonItem.Width = width,
                () => $"{nameof(UIBarButtonItem.Width)}");
        }
    }
}
