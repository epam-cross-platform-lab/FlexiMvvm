﻿// =========================================================================
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
using JetBrains.Annotations;
using UIKit;

namespace FlexiMvvm.Bindings
{
    public static class UIViewBindings
    {
        [NotNull]
        public static TargetItemBinding<UIView, float> AlphaBinding(
            [NotNull] this IItemReference<UIView> viewReference)
        {
            if (viewReference == null)
                throw new ArgumentNullException(nameof(viewReference));

            return new TargetItemOneWayCustomBinding<UIView, float>(
                viewReference,
                (view, alpha) => view.NotNull().Alpha = alpha,
                () => "Alpha");
        }

        [NotNull]
        public static TargetItemBinding<UIView, bool> EndEditingBinding(
            [NotNull] this IItemReference<UIView> viewReference)
        {
            if (viewReference == null)
                throw new ArgumentNullException(nameof(viewReference));

            return new TargetItemOneWayCustomBinding<UIView, bool>(
                viewReference,
                (view, force) => view.NotNull().EndEditing(force),
                () => "EndEditing");
        }

        [NotNull]
        public static TargetItemBinding<UIView, bool> HiddenBinding(
            [NotNull] this IItemReference<UIView> viewReference)
        {
            if (viewReference == null)
                throw new ArgumentNullException(nameof(viewReference));

            return new TargetItemOneWayCustomBinding<UIView, bool>(
                viewReference,
                (view, hidden) => view.NotNull().Hidden = hidden,
                () => "Hidden");
        }

        [NotNull]
        public static TargetItemBinding<UIView, bool> IsAccessibilityElementBinding(
            [NotNull] this IItemReference<UIView> viewReference)
        {
            if (viewReference == null)
                throw new ArgumentNullException(nameof(viewReference));

            return new TargetItemOneWayCustomBinding<UIView, bool>(
                viewReference,
                (view, isAccessibilityElement) => view.NotNull().IsAccessibilityElement = isAccessibilityElement,
                () => "IsAccessibilityElement");
        }

        [NotNull]
        public static TargetItemBinding<UIView, bool> MultipleTouchEnabledBinding(
            [NotNull] this IItemReference<UIView> viewReference)
        {
            if (viewReference == null)
                throw new ArgumentNullException(nameof(viewReference));

            return new TargetItemOneWayCustomBinding<UIView, bool>(
                viewReference,
                (view, multipleTouchEnabled) => view.NotNull().MultipleTouchEnabled = multipleTouchEnabled,
                () => "MultipleTouchEnabled");
        }

        [NotNull]
        public static TargetItemBinding<UIView, bool> OpaqueBinding(
            [NotNull] this IItemReference<UIView> viewReference)
        {
            if (viewReference == null)
                throw new ArgumentNullException(nameof(viewReference));

            return new TargetItemOneWayCustomBinding<UIView, bool>(
                viewReference,
                (view, opaque) => view.NotNull().Opaque = opaque,
                () => "Opaque");
        }

        [NotNull]
        public static TargetItemBinding<UIView, object> TapBinding(
            [NotNull] this IItemReference<UIView> viewReference)
        {
            if (viewReference == null)
                throw new ArgumentNullException(nameof(viewReference));

            return new UIViewTapBinding(
                viewReference,
                (view, canExecuteCommand) => { });
        }

        [NotNull]
        public static TargetItemBinding<UIView, bool> UserInteractionEnabledBinding(
            [NotNull] this IItemReference<UIView> viewReference)
        {
            if (viewReference == null)
                throw new ArgumentNullException(nameof(viewReference));

            return new TargetItemOneWayCustomBinding<UIView, bool>(
                viewReference,
                (view, userInteractionEnabled) => view.NotNull().UserInteractionEnabled = userInteractionEnabled,
                () => "UserInteractionEnabled");
        }
    }
}
