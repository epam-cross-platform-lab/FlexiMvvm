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
using System.Collections.Generic;
using Cirrious.FluentLayouts.Touch;
using JetBrains.Annotations;
using ObjCRuntime;
using UIKit;

namespace FlexiMvvm.Views
{
    public static class FluentLayoutExtensions
    {
        private const float DefaultMargin = 0;

        [Obsolete("FullSizeOf(UIView, UILayoutGuide, nfloat?) will be removed soon. Use FullSizeOfSafeArea(UIView, UIView, nfloat?) method instead.")]
        [NotNull]
        public static IEnumerable<FluentLayout> FullSizeOf(
            [NotNull] this UIView view,
            [NotNull] UILayoutGuide safeAreaLayoutGuide,
            [CanBeNull] nfloat? margin = null)
        {
            if (view == null)
                throw new ArgumentNullException(nameof(view));
            if (safeAreaLayoutGuide == null)
                throw new ArgumentNullException(nameof(safeAreaLayoutGuide));

            return FullSizeOf(view, safeAreaLayoutGuide, new Margins((float)margin.GetValueOrDefault(DefaultMargin)));
        }

        public static IEnumerable<FluentLayout> FullSizeOfSafeArea(
            this UIView view,
            UIView parentView,
            nfloat? margin = null)
        {
            if (view == null)
                throw new ArgumentNullException(nameof(view));
            if (parentView == null)
                throw new ArgumentNullException(nameof(parentView));

            return FullSizeOfSafeArea(view, parentView, new Margins((float)margin.GetValueOrDefault(DefaultMargin)));
        }

        [Obsolete("FullSizeOf(UIView, UILayoutGuide, Margins) will be removed soon. Use FullSizeOfSafeArea(UIView, UIView, Margins) method instead.")]
        [NotNull]
        public static IEnumerable<FluentLayout> FullSizeOf(
            [NotNull] this UIView view,
            [NotNull] UILayoutGuide safeAreaLayoutGuide,
            [NotNull] Margins margins)
        {
            if (view == null)
                throw new ArgumentNullException(nameof(view));
            if (safeAreaLayoutGuide == null)
                throw new ArgumentNullException(nameof(safeAreaLayoutGuide));
            if (margins == null)
                throw new ArgumentNullException(nameof(margins));

            return new List<FluentLayout>
            {
                view.Top().NotNull().EqualTo(margins.Top).NotNull().TopOf(safeAreaLayoutGuide).NotNull().WithIdentifier("Top"),
                view.Bottom().NotNull().EqualTo(margins.Bottom).NotNull().BottomOf(safeAreaLayoutGuide).NotNull().WithIdentifier("Bottom"),
                view.Left().NotNull().EqualTo(margins.Left).NotNull().LeftOf(safeAreaLayoutGuide).NotNull().WithIdentifier("Left"),
                view.Right().NotNull().EqualTo(margins.Right).NotNull().RightOf(safeAreaLayoutGuide).NotNull().WithIdentifier("Right")
            };
        }

        public static IEnumerable<FluentLayout> FullSizeOfSafeArea(
            this UIView view,
            UIView parentView,
            Margins margins)
        {
            if (view == null)
                throw new ArgumentNullException(nameof(view));
            if (parentView == null)
                throw new ArgumentNullException(nameof(parentView));
            if (margins == null)
                throw new ArgumentNullException(nameof(margins));

            return new[]
            {
                view.AtLeftOfSafeArea(parentView, margins.Left),
                view.AtTopOfSafeArea(parentView, margins.Top),
                view.AtRightOfSafeArea(parentView, margins.Right),
                view.AtBottomOfSafeArea(parentView, margins.Bottom)
            };
        }

        [NotNull]
        public static IEnumerable<FluentLayout> FullSizeOf(
            [NotNull] this UIView view,
            [NotNull] UIView parent,
            [NotNull] IUILayoutSupport topLayoutGuide,
            [NotNull] IUILayoutSupport bottomLayoutGuide,
            [CanBeNull] nfloat? margin = null)
        {
            if (view == null)
                throw new ArgumentNullException(nameof(view));
            if (parent == null)
                throw new ArgumentNullException(nameof(parent));
            if (topLayoutGuide == null)
                throw new ArgumentNullException(nameof(topLayoutGuide));
            if (bottomLayoutGuide == null)
                throw new ArgumentNullException(nameof(bottomLayoutGuide));

            return FullSizeOf(view, parent, topLayoutGuide, bottomLayoutGuide, new Margins((float)margin.GetValueOrDefault(DefaultMargin)));
        }

        [NotNull]
        public static IEnumerable<FluentLayout> FullSizeOf(
            [NotNull] this UIView view,
            [NotNull] UIView parent,
            [NotNull] IUILayoutSupport topLayoutGuide,
            [NotNull] IUILayoutSupport bottomLayoutGuide,
            [NotNull] Margins margins)
        {
            if (view == null)
                throw new ArgumentNullException(nameof(view));
            if (parent == null)
                throw new ArgumentNullException(nameof(parent));
            if (topLayoutGuide == null)
                throw new ArgumentNullException(nameof(topLayoutGuide));
            if (bottomLayoutGuide == null)
                throw new ArgumentNullException(nameof(bottomLayoutGuide));
            if (margins == null)
                throw new ArgumentNullException(nameof(margins));

            var nsTopLayoutGuide = Runtime.GetNSObject(topLayoutGuide.Handle);
            var nsBottomLayoutGuide = Runtime.GetNSObject(bottomLayoutGuide.Handle);

            return new List<FluentLayout>
            {
                view.Top().NotNull().EqualTo(margins.Top).NotNull().BottomOf(nsTopLayoutGuide).NotNull().WithIdentifier("Top"),
                view.Bottom().NotNull().EqualTo(margins.Bottom).NotNull().TopOf(nsBottomLayoutGuide).NotNull().WithIdentifier("Bottom"),
                view.AtLeftOf(parent, margins.Left).NotNull().WithIdentifier("Left"),
                view.AtRightOf(parent, margins.Right).NotNull().WithIdentifier("Right")
            };
        }
    }
}
