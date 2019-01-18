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
using JetBrains.Annotations;
using UIKit;

namespace FlexiMvvm.Views.Keyboard
{
    internal static class UIViewExtensions
    {
        [CanBeNull]
        internal static Tuple<UIView, UIScrollView> FindFirstResponderInScrollView([NotNull] this UIView rootView)
        {
            if (rootView == null)
                throw new ArgumentNullException(nameof(rootView));

            return FindFirstResponderInScrollView(rootView, null);
        }

        [CanBeNull]
        private static Tuple<UIView, UIScrollView> FindFirstResponderInScrollView([NotNull] UIView view, [CanBeNull] UIScrollView scrollView)
        {
            if (view is UIScrollView uiScrollView)
            {
                scrollView = uiScrollView;
            }

            if (view.IsFirstResponder)
            {
                return scrollView != null ? new Tuple<UIView, UIScrollView>(view, scrollView) : null;
            }

            if (view.Subviews != null)
            {
                foreach (var subview in view.Subviews)
                {
                    var firstResponderInScrollView = FindFirstResponderInScrollView(subview, scrollView);

                    if (firstResponderInScrollView != null)
                    {
                        return firstResponderInScrollView;
                    }
                }
            }

            return null;
        }
    }
}
