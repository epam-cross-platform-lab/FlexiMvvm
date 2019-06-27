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
    public static class UIViewExtensions
    {
        public static TargetItemBinding<UIView, float> AlphaBinding(
            this IItemReference<UIView> viewReference)
        {
            if (viewReference == null)
                throw new ArgumentNullException(nameof(viewReference));

            return new TargetItemOneWayCustomBinding<UIView, float>(
                viewReference,
                (view, alpha) => view.Alpha = alpha,
                () => $"{nameof(UIView.Alpha)}");
        }

        public static TargetItemBinding<UIView, bool> EndEditingBinding(
            this IItemReference<UIView> viewReference)
        {
            if (viewReference == null)
                throw new ArgumentNullException(nameof(viewReference));

            return new TargetItemOneWayCustomBinding<UIView, bool>(
                viewReference,
                (view, force) => view.EndEditing(force),
                () => $"{nameof(UIView_UITextField.EndEditing)}");
        }

        public static TargetItemBinding<UIView, bool> HiddenBinding(
            this IItemReference<UIView> viewReference)
        {
            if (viewReference == null)
                throw new ArgumentNullException(nameof(viewReference));

            return new TargetItemOneWayCustomBinding<UIView, bool>(
                viewReference,
                (view, hidden) => view.Hidden = hidden,
                () => $"{nameof(UIView.Hidden)}");
        }

        public static TargetItemBinding<UIView, bool> IsAccessibilityElementBinding(
            this IItemReference<UIView> viewReference)
        {
            if (viewReference == null)
                throw new ArgumentNullException(nameof(viewReference));

            return new TargetItemOneWayCustomBinding<UIView, bool>(
                viewReference,
                (view, isAccessibilityElement) => view.IsAccessibilityElement = isAccessibilityElement,
                () => $"{nameof(UIView.IsAccessibilityElement)}");
        }

        public static TargetItemBinding<UIView, bool> MultipleTouchEnabledBinding(
            this IItemReference<UIView> viewReference)
        {
            if (viewReference == null)
                throw new ArgumentNullException(nameof(viewReference));

            return new TargetItemOneWayCustomBinding<UIView, bool>(
                viewReference,
                (view, multipleTouchEnabled) => view.MultipleTouchEnabled = multipleTouchEnabled,
                () => $"{nameof(UIView.MultipleTouchEnabled)}");
        }

        public static TargetItemBinding<UIView, bool> OpaqueBinding(
            this IItemReference<UIView> viewReference)
        {
            if (viewReference == null)
                throw new ArgumentNullException(nameof(viewReference));

            return new TargetItemOneWayCustomBinding<UIView, bool>(
                viewReference,
                (view, opaque) => view.Opaque = opaque,
                () => $"{nameof(UIView.Opaque)}");
        }

        public static TargetItemBinding<UIView, object> TapBinding(
            this IItemReference<UIView> viewReference)
        {
            if (viewReference == null)
                throw new ArgumentNullException(nameof(viewReference));

            return new UIViewTapBinding(
                viewReference,
                (view, canExecuteCommand) => { });
        }

        public static TargetItemBinding<UIView, bool> UserInteractionEnabledBinding(
            this IItemReference<UIView> viewReference)
        {
            if (viewReference == null)
                throw new ArgumentNullException(nameof(viewReference));

            return new TargetItemOneWayCustomBinding<UIView, bool>(
                viewReference,
                (view, userInteractionEnabled) => view.UserInteractionEnabled = userInteractionEnabled,
                () => $"{nameof(UIView.UserInteractionEnabled)}");
        }
    }
}
